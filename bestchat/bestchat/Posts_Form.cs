using bestchat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace totalchat
{
    public partial class Posts_Form : Form
    {
        class mylabel : LinkLabel
        {
            public int postid = -1;
        }
        public Posts_Form()
        {
            InitializeComponent();
            //timer1.Start();
        }
        void bunish2()
        {
            string cpuId = password.GetCpuId();
            string period = "";
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var res = from p in db.Machin where p.CpuID == cpuId select p;
                if (res.Count() > 0)
                {
                    res.First().WarningCount += 1;
                    db.SaveChanges();
                }
                else
                {
                    Machin mchn = new Machin();
                    mchn.CpuID = password.GetCpuId();
                    mchn.WarningCount = 1;
                    mchn.WarningDate = DateTime.Now;
                    db.Machin.Add(mchn);
                    db.SaveChanges();
                }

                switch (res.First().WarningCount)
                {
                    case 1:
                        {
                            period = "1";
                            break;
                        }
                    case 2:
                        {
                            period = "3";
                            break;
                        }
                    case 3:
                        {
                            period = "7";
                            break;
                        }
                    case 4:
                        {
                            period = "30";
                            break;
                        }
                    case 5:
                        {
                            period = "365";
                            break;
                        }
                }
            }

            if (password.language == "English")
                MessageBox.Show("you bunished from chat for " + period + " day!!!");
            else
                MessageBox.Show("شما بمدت " + period + " روز از چت اخراج شدید");

            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((loc == "" && subject == "")||richTextBox1.Text.Length>500)
                return;
            sendpost();
            showposts();
        }
        string loc = "";
        string subject = "";
        void setlocsub()
        {
            if (password.city != "")
                loc = password.city;
            else if (password.Province != "")
                loc = password.Province;
            else
                loc = password.country;
            if (password.subject3 != "")
                subject = password.subject3;
            else if (password.subject2 != "")
                subject = password.subject2;
            else
                subject = password.subject1;
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        void sendpost()

        {
            string text = richTextBox1.Text;
            if (text == ""||text=="\n")
                return;
            bool wrong = false;
            if (!password.ValidateText(text))
            {
                wrong = true;
                
            }
            if (!wrong)
            {
                var res = from p in db.posts where p.Location == loc && p.Subject == subject&&p.text==text orderby p.Id descending select p;
                if (res.Count() == 0)
                {
                    var r = from p in db.posts where p.Location == loc && p.Subject == subject select p;
                    if (r.Count() > 40)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            var d = (from p in db.posts where p.Location == loc && p.Subject == subject select p).First();
                            db.posts.Remove(d);
                            db.SaveChanges();
                        }
                        
                    }
                
                    posts pst = new posts();
                    pst.Name = password.Name;
                    pst.Family = password.Fimily;
                    pst.Location = loc;
                    pst.Subject = subject;
                    pst.Date = DateTime.Now;
                    pst.Time = DateTime.Now.TimeOfDay.ToString();
                    pst.text= text;
                    pst.Likes = 0;
                    pst.UnLikes = 0;
                    db.posts.Add(pst);
                    db.SaveChanges();
                    showposts();
                }
                    richTextBox1.Text = "";
                
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                sendpost();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showposts();
        }
        bool disablelikes(int pstid)
        {
            var l = from u in db.Likes where u.Name == password.Name && u.Family == password.Fimily&&u.podtId==pstid&&u.Location==loc&&u.Subject==subject select u;
            if (l.Count() > 0)
                return true;
            else
                return false;
        }
        void like_Click(object sender, EventArgs e)
        {
            mylabel lb = new mylabel();
            lb = (mylabel)sender;
            if (disablelikes(lb.postid))
                return;
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r = (from s in db.posts where s.Id == lb.postid select s).First();
                lb.Text = "like+" + (r.Likes + 1);
                /* posts p = new posts();
                 p.Name = r.Name;
                 p.Family = r.Family;
                 p.text = r.post1;
                 p.Location = r.loc;
                 p.Subject = r.subject;
                 p.Date = r.postDate;
                 p.Time = r.postTime;
                 p.UnLikes = r.unlikeNumber;*/
                Likes like = new Likes();
                like.Name = password.Name;
                like.Family = password.Fimily;
                like.podtId = r.Id;
                like.Subject = subject;
                like.Location = loc;
                db.Likes.Add(like);
                db.SaveChanges();
                r.Likes = r.Likes + 1;
                db.SaveChanges();

               }
            lb.Enabled = false;
            lb.Parent.GetNextControl(lb, true).Enabled=false;

        }
        int y = 35;
        int x = 27;
        void showallposts()
        {
            counter = 0;
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1()) {
                var result = from p in db.posts where p.Location == loc && p.Subject == subject orderby p.Date descending orderby p.Time descending select p;
                foreach (var r in result)
                {
                    if ((r.Date.Value.Year < DateTime.Now.Year || (r.Date.Value.Month < DateTime.Now.Month) && r.Date.Value.Day < DateTime.Now.Day))
                    {

                        db.posts.Remove(r);
                        db.SaveChanges();
                    }
                    else
                    {
                        
                        drawposts(r);
                        if (counter == 1)
                            lastpostid = (int)r.Id;
                        if (counter > 40)
                            return;
                    }
                }
                
                
            }
        }
        void drawposts(posts post)//string text,DateTime date)

        {
                int width=(Screen.PrimaryScreen.Bounds.Width-90)/2;
                RichTextBox richTextBox2 = new RichTextBox();
                richTextBox2.Font = new Font("Arial", 15, FontStyle.Italic | FontStyle.Bold);
                richTextBox2.Text += password.Fimily + "_" + password.Name + ": ";
                int len1 = password.Fimily.Length + password.Name.Length + 3;
                richTextBox2.Text += post.text + "\n";
                DateTime dt = new DateTime();
                dt = (DateTime)post.Date;
                if (password.language == "English")
                    richTextBox2.Text += post.Date.Value.Year + "/" + post.Date.Value.Month + "/" + post.Date.Value.Day + "  " + post.Time.Substring(0, 2) + ":" + post.Time.Substring(3, 2);
                else
                    richTextBox2.Text += password.farsidate(dt) + "  " + post.Time.Substring(0,2) + ":" + post.Time.Substring(3,2) ;
                richTextBox2.Location = new Point(x, y);
                richTextBox2.Size = new System.Drawing.Size(width, 170);
                richTextBox2.Select(0, len1);
                richTextBox2.SelectionFont = new Font("Arial", 15, FontStyle.Italic | FontStyle.Bold);
                richTextBox2.SelectionColor = Color.DarkRed;
                richTextBox2.DeselectAll();
                richTextBox2.Select(len1, post.text.Length);
                richTextBox2.SelectionFont = new Font("Arial", 15, FontStyle.Regular);
                richTextBox2.SelectionColor = Color.DarkGray;
                richTextBox2.DeselectAll();
                richTextBox2.Select(len1 + post.text.Length, 18);
                richTextBox2.SelectionFont = new Font("Arial", 10, FontStyle.Italic);
                richTextBox2.SelectionColor = Color.DarkRed;
                richTextBox2.DeselectAll();
                //richTextBox2.ScrollToCaret();
                mylabel like = new mylabel();
                like.Text = "like" + "+" +post.Likes;
                like.Click += like_Click;
                like.Font = new Font("Times New Roman", 15, FontStyle.Italic);
                like.ForeColor = Color.Blue;
                int charindex = richTextBox2.GetFirstCharIndexOfCurrentLine();
                Point linepos = richTextBox2.GetPositionFromCharIndex(charindex);
                linepos.Y += 50;
                like.Location = new Point(200, 140);
                like.postid = (int)post.Id;
                richTextBox2.Controls.Add(like);
                like = new mylabel();
                like.Text = "unlike" + "-" + post.UnLikes;
                like.Click += unlike_Click;
                like.Font = new Font("Times New Roman", 15, FontStyle.Italic);
                like.ForeColor = Color.Blue;
                like.Location = new Point(300, 140);
                like.postid = (int)post.Id;
                richTextBox2.Controls.Add(like);
                panel1.Controls.Add(richTextBox2);
            
            // panel1.ScrollControlIntoView(richTextBox2);
            if (counter % 2 == 1)
            {
                x = 27;
                y += 200;

            }
            else
                x += width+25;
            counter++;
            
            if (disablelikes((int)post.Id))
            {
                like.Enabled = false;
                like.Parent.GetNextControl(like, false).Enabled = false;
            }

        }
        int counter = 0;
        void showposts()
        {
            using(amirabbasi1Entities1 db =new amirabbasi1Entities1()) { 
            var result = from p in db.posts where p.Location == loc && p.Subject == subject &&p.Id>lastpostid select p;
                foreach (var r in result)
                {
                    drawposts(r);
                    lastpostid = (int)r.Id;
                }
            }
           
        }
        int lastpostid = -1;
        
        private void unlike_Click(object sender, EventArgs e)
        {
            mylabel lb = new mylabel();
            lb = (mylabel)sender;
            if (disablelikes(lb.postid))
                return;
            var r = (from s in db.posts where s.Id == lb.postid select s).First();
            lb.Text = "unlike-" +( r.UnLikes + 1);
            /*Post p = new Post();
            p.Name = r.Name;
            p.Family = r.Family;
            p.post1 = r.post1;
            p.loc = r.loc;
            p.subject = r.subject;
            p.postDate = r.postDate;
            p.postTime = r.postTime;
            p.likeNumber = r.likeNumber;*/
            r.UnLikes = r.UnLikes + 1;
            Likes like = new Likes();
            like.Name = password.Name;
            like.Family = password.Fimily;
            like.podtId = r.Id;
            like.Subject = subject;
            like.Location = loc;
            db.Likes.Add(like);
            db.SaveChanges();
            lb.Enabled = false;
            lb.Parent.GetNextControl(lb, false).Enabled=false;
        }

        private void Posts_Form_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                linkLabel1.Text = "براساس لایکها";
                linkLabel2.Text = "براساس تاریخ و زمان";
                button1.Text = "بفرست";
            }
            setlocsub();
            showallposts();
        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mostliked();
            //if(panel1.Controls.Count>0)
            //panel1.ScrollControlIntoView(panel1.Controls[panel1.Controls.Count - 1]);
        }
        void mostliked()
        {
            x = 27; y = 27;
            panel1.Controls.Clear();
            counter = 0;
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var result = (from p in db.posts where p.Location == loc && p.Subject == subject orderby p.Likes descending orderby p.Date descending orderby p.Time descending select p).OrderByDescending(m=>m.Likes-m.UnLikes);
                foreach (var r in result)
                {
                    drawposts(r);
                    if (counter > 40)
                    {
                        db.posts.Remove(r);
                       
                       
                    }
                }
                db.SaveChanges();
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            x = 27;
            y = 27;
            counter = 0;
            panel1.Controls.Clear();
            showallposts();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
