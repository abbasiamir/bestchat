using bestchat;
using bestchat.Properties;
//using bestchat.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace totalchat
{
    public partial class chatroom : Form
    {
        public chatroom()
        {
            InitializeComponent();
            //Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var r = from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p;
                r.First().online = false;
                int id = r.First().Id;
                var r2 = from p in db.room where p.userId == id select p;
                foreach (var rs in r2)
                {
                    db.room.Remove(rs);
                }
                db.SaveChanges();
            }
        }
        string FriendInvited = "";
        public string answer = "";
        int myid = -1;
        List<int> invitedFriends = new List<int>();
        List<List<string>> invfriendnames = new List<List<string>>();
        string Location = "";
        string Subject = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            /* if (!password.ValidateText(textBox1.Text))
             {
                 bunish2();
             }
             textBox2.Text = "";
             textBox3.Text = "";
             password.city = textBox1.Text;*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            /* if (!password.ValidateText(textBox2.Text))
             {
                 bunish2();
             }
             //textBox1.Text = "";
             textBox3.Text = "";
             password.Province = textBox2.Text;*/
        }
        void bunish2()
        {
            string cpuId = password.GetCpuId();
            string period = "";
            using (bestchat.amirabbasi1Entities1 db = new amirabbasi1Entities1())
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
            messagBox message = new messagBox();
            if (password.language == "English")
                message.label1.Text = ("you bunished from chat for " + period + " day!!!");
            else {
                message.label1.Text=("شما بمدت " + period + " روز از چت اخراج شدید");
                message.Text = "پیغام";
            }
            message.ShowDialog();
            Application.Exit();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            /*if (!password.ValidateText(textBox3.Text))
            {
                bunish2();

            }

            //textBox1.Text = "";
            textBox2.Text = "";
            password.city = textBox3.Text;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        string getloc()
        {
            if (password.city != "")
                return password.city;
            else if (password.Province != "")
                return password.Province;
            else
                return password.country;
        }
        string getsubject()
        {
            if (password.subject3 != "")
                return password.subject3;
            else if (password.subject2 != "")
                return password.subject2;
            else
                return password.subject1;
        }
        bool logintoRomm = false;
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            timer1.Start();
            login_to_chat = true;
            string previusLocation = Location;
            string previuseSubject = Subject;
            password.country = comboBox_countries.Text;
            password.Province = comboBox_states.Text;
            password.city = comboBox_cities.Text;
            Location = getloc();
            Subject = getsubject();
            if (previusLocation != "" || previuseSubject != "")
            {
                chat c = new chat();
                if (password.language == "English")
                {
                    c.text = password.Name + " " + password.Fimily + " left room";

                }
                else
                {
                    c.text = "روم را ترک کرد " + password.Name + " " + password.Fimily;
                }
                c.Location = previusLocation;
                c.Subject = previuseSubject;
                c.Color = Color.DarkRed.ToArgb().ToString();
                c.Name = "";
                c.Family = "";
                db.chat.Add(c);
                db.SaveChanges();
            }
            if (Location != "" || Subject != "")
            {
                var r = from p in db.chat where p.Location == Location && p.Subject == Subject select p;
                if (r.Count() > 100)
                {
                    /*for (int i = 0; i < 60; i++)
                    {
                        var d = (from q in db.chat where q.Location == Location && q.Subject == Subject select q).First();
                        db.chat.Remove(d);
                        
                    }*/
                    db.chat.RemoveRange(r.Take(r.Count() - 20));
                    db.SaveChanges();
                }
                chat c = new chat();
                if (password.language == "English")
                {
                    c.text = password.Name + " " + password.Fimily + " joined room ";

                }
                else
                {
                    c.text = "به روم پیوست " + password.Name + " " + password.Fimily;
                }
                c.Location = Location;
                c.Subject = Subject;
                c.Color = Color.DarkRed.ToArgb().ToString();
                c.Name = "";
                c.Family = "";

                db.chat.Add(c);
                db.SaveChanges();
            }
           
            var rs = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First();
            rs.online = true;
            var rs2 = from p in db.room where p.Location == Location && p.Subject == Subject && p.userId == rs.Id select p;
            if (rs2.Count() > 0)
            {
                foreach (var t in rs2)
                {
                    db.room.Remove(t);
                   
                }
               
            }
            db.SaveChanges();
            room tbl = new bestchat.room();
            tbl.Location = Location;
            tbl.Subject = Subject;
            tbl.userId = rs.Id;
            db.room.Add(tbl);
            db.SaveChanges();

            userlist();
            logintoRomm = true;
            if (comboBox_cities.Text == "" && comboBox_states.Text == "" && comboBox_countries.Text == "")
                return;

            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            richTextBox2.Enabled = true;
            
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var res= from p in db.chat where p.Location == Location && p.Subject == Subject && p.Name == "" && p.Family == ""&&p.text.IndexOf(password.Fimily+"_"+password.Name)==-1 select p;
                if (res.Count() > 20)
                {
                    db.chat.RemoveRange(res.Take(res.Count()-5));
                    db.SaveChanges();
                }
                
                var result = from p in db.chat where p.Location == Location && p.Subject == Subject && p.Name!="" && p.Family!="" select p;
                int start = 0;
                //if (result.Count() == 0)
                  //  return;
                if (result.Count() >= 40)
                    start = result.Count() - 40;
                int i = 0;
                int j = 0;
                Point[] ps = new Point[(result.Count() - start) * 2];
                int[] colors = new int[result.Count() - start];
                foreach (var r in result)
                {
                  
                    //if (i >= start)
                    //{
                        richTextBox1.DeselectAll();

                        string text = r.Family + "_" + r.Name + ": ";
                        
                            int st = richTextBox1.Text.Length;
                            richTextBox1.Text += text;
                            ps[j].X = st;
                            ps[j++].Y = text.Length;
                            text = r.text;
                            st = richTextBox1.Text.Length;
                            ps[j].X = st;
                            ps[j++].Y = text.Length;
                            richTextBox1.Text += text;
                            colors[i] = Convert.ToInt32(r.Color);
                            i++;
                        richTextBox1.Text += "\n";
                        richTextBox1.Text = richTextBox1.Text.Replace("\n\n", "\n");
                        password.lastid = r.Id;

                        
                   /* }
                    else
                    {
                        db.chat.Remove(r);
                        db.SaveChanges();
                    }*/
                   
                }
             
                int k = 0;
                for (int a = 0; a < j; a += 2)
                {
                    richTextBox1.Select(ps[a].X, ps[a].Y);
                    richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                    richTextBox1.SelectionColor = Color.DarkRed;
                    richTextBox1.Select(ps[a + 1].X, ps[a + 1].Y);
                    richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Regular);
                    richTextBox1.SelectionColor = ColorTranslator.FromWin32(colors[k++]);
                    richTextBox1.DeselectAll();
                }
                
                this.Text = Getroomname();

                string room = Getroomname();
                if (password.language == "English")
                    room = "Welcome to room " + Getroomname().ToString() + "!";
                else
                {
                    string text1 = "خوش آمدید ";
                    string text2 = Getroomname();
                    string text3 = " به روم ";
                    StringBuilder st = new StringBuilder();
                    st.AppendFormat("{0} {1} {2}", text1, text2, text3);
                    room = st.ToString();
                }
                richTextBox1.DeselectAll();
                int len = richTextBox1.Text.Length;
                richTextBox1.AppendText(room);
                richTextBox1.AppendText("\n");
                richTextBox1.RightToLeft = RightToLeft.No;
                richTextBox1.SelectionStart=len;
                richTextBox1.SelectionLength = room.Length;
                richTextBox1.SelectionColor = Color.DarkRed;
                richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Italic);

                richTextBox1.ScrollToCaret();
                var r2 = (from p in db.chat where p.Location == Location && p.Subject == Subject select p);
                if (r2.Count()>0)
                {
                    foreach (var item in r2)
                    {
                        password.lastpid = item.Id;
                    }
                }
            }
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        bool login_to_chat = false;
        Label selectedlabel = new Label();
        void userlist()
        {
            if ((Location == "" && Subject == "") || !login_to_chat)
                return;
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var R = from p in db.user join q in db.room on p.Id equals q.userId where q.Location == Location && q.Subject == Subject orderby p.Family, p.Name select p ;
                int y = 0;
                int count = panel_users.Controls.Count;
                //int i = 0;
                //if (R.Count()!=count)
                //{
                    panel_users.Controls.Clear();
                    foreach (var u in R)
                    {
                        if (u.online == true)
                        {
                           // bool found = false;
                            //if (i >= count)
                            //{
                            /*foreach (Control c in panel_users.Controls)
                                if (c.Text == (password.Fimily + "_" + password.Name))
                                    found = true;*/
                            //if (!found)
                            //{
                                Label us = new Label();
                                us.Size = new System.Drawing.Size(200, 15);
                                us.Text = (u.Family + "_" + u.Name);
                                us.ForeColor = Color.Blue;
                                us.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                                if (us.Text != password.Fimily + "_" + password.Name)
                                {
                                    if (password.language == "English")
                                        us.ContextMenuStrip.Items.Add("Add to friends list");
                                    else
                                        us.ContextMenuStrip.Items.Add("افزودن به لیست دوستان");
                                    us.ContextMenuStrip.Items[0].Click += ContextMenuStrip_Click5;
                                    if (password.Confrences.Count > 0)
                                    {
                                        if (password.language == "English")
                                            us.ContextMenuStrip.Items.Add("invite to confrence");
                                        else
                                            us.ContextMenuStrip.Items.Add(" دعوت به کنفرانس ");
                                        us.ContextMenuStrip.Items[1].Click += Chatroom_Click;
                                    }

                                }
                                us.MouseClick += Us_MouseClick;
                                us.Click += us_Click;
                                us.MouseClick += us_MouseClick;
                                us.DoubleClick += us_DoubleClick;
                                us.MouseDown += Us_MouseDown;
                                us.Location = new Point(0, y);
                                //y += 17;
                                panel_users.Controls.Add(us);

                                //}
                                //else {
                                //panel_users.Controls[i].Text = (u.Family + "_" + u.Name);
                                //us = (Label)panel_users.Controls[i];
                                if (us.Text != password.Fimily + "_" + password.Name)
                                {
                                    us.ContextMenuStrip.Items.Clear();
                                    if (password.language == "English")
                                        us.ContextMenuStrip.Items.Add("Add to friends list");
                                    else
                                        us.ContextMenuStrip.Items.Add("افزودن به لیست دوستان");
                                    us.ContextMenuStrip.Items[0].Click += ContextMenuStrip_Click5;
                                    if (password.Confrences.Count > 0)
                                    {
                                        if (password.language == "English")
                                            us.ContextMenuStrip.Items.Add("invite to confrence");
                                        else
                                            us.ContextMenuStrip.Items.Add(" دعوت به کنفرانس ");
                                        us.ContextMenuStrip.Items[1].Click += Chatroom_Click;
                                    }
                                }
                                //}
                                //i++;
                                y += 17;
                           

                        }
                    }
                    /*for (int j = i; j < panel_users.Controls.Count; j++)
                    {
                        panel_users.Controls.RemoveAt(j);
                    }*/
                }
            
        }

        private void Us_MouseDown(object sender, MouseEventArgs e)
        {
            Label lb = new Label();
            lb = (Label)sender;
            lb.Select();
            selecteduser = lb.Text;
            selectedlabel = lb;
        }

        private void Us_MouseClick(object sender, MouseEventArgs e)
        {
            Label lb = new Label();
            lb = (Label)sender;
            lb.Select();
            selecteduser = lb.Text;
            if (e.Button == MouseButtons.Right)
            {
                lb = new Label();
                lb = (Label)sender;
                lb.Select();
                selecteduser = lb.Text;
            }
        }

        void us_DoubleClick(object sender, EventArgs e)
        {
            if (selectedlabel.Text == password.Fimily + "_" + password.Name)
                return;
            foreach (string s in password.openedforms)
                if (s == seprate(selectedlabel.Text))
                    return;
            string name = selectedlabel.Text.Substring(selectedlabel.Text.IndexOf("_")+1);
            string family = selectedlabel.Text.Substring(0, selectedlabel.Text.IndexOf("_"));
            password.openedforms.Add(name+" "+family);
            Thread thread1 = new Thread(new ThreadStart(show_prv_window));
            //thread1.IsBackground = true;
            thread1.Start();

        }

        void us_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Control ctrl in panel_users.Controls)
            {
                ctrl.BackColor = Color.White;
            }
            Label lb = new Label();
            lb = (Label)sender;
            selectedlabel = lb;
            lb.BackColor = Color.LightBlue;
        }

        void item_Click(object sender, EventArgs e)
        {

        }

        void ContextMenuStrip_Click5(object sender, EventArgs e)
        {
            addfriend();
        }
        public void addfriend()
        {
            if (selectedlabel.Text == "")
                return;
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                //ContextMenuStrip menu = new ContextMenuStrip();
                //menu = (ContextMenuStrip)sender;
                string Friand_Name = selectedlabel.Text.Substring(selectedlabel.Text.IndexOf("_") + 1);
                string Friend_Family = selectedlabel.Text.Substring(0, selectedlabel.Text.IndexOf("_"));
                if (Friand_Name == password.Name && Friend_Family == password.Fimily)
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                        message.label1.Text = ("its you!!!");
                    else
                    {
                        message.label1.Text=("شما نمی توانید خودتان را به لیست دوستان اضافه کنید");
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                    return;
                }
                var r = from p in db.friends join q in db.user on p.FriendId equals q.Id where q.Name == Friand_Name && q.Family == Friend_Family join s in db.user on p.UserId equals s.Id where s.Name == password.Name && s.Family == password.Fimily select s;
                if (r.Count() > 0)
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                        message.label1.Text = ("this user already is in your friends list");
                    else
                    {
                        message.label1.Text=("این کاربر هم اکنون در لیست دوستان شما وجود دارد");
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                    return;
                }
                
                int suerId = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
                int FriendId = (from p in db.user where p.Name == Friand_Name && p.Family == Friend_Family select p).First().Id;
                var res = from p in db.invited where p.suerId == suerId && p.FriendId == FriendId select p;
                List<string> name = new List<string>();
                name.Add(Friand_Name);
                name.Add(Friend_Family);
                myid = suerId;
                if (res.Count() == 0)
                {
                    var res2 = from p in db.declined where p.userId == suerId && p.friendId == FriendId select p;
                    if (res2.Count() == 0)
                    {
                        invited frnd = new invited();
                        frnd.suerId = suerId;
                        frnd.FriendId = FriendId;
                        frnd.sent = "false";
                        db.invited.Add(frnd);

                        db.SaveChanges();
                        FriendInvited = Friand_Name + " " + Friend_Family;
                        timer_answer.Start();
                        invitedFriends.Add(FriendId);
                        invfriendnames.Add(name);
                        messagBox message = new messagBox();
                        if (password.language == "English")
                            message.label1.Text = ("Request sent");
                        else
                        {
                            message.label1.Text=("درخواست ارسال شد");
                            message.Text = "پیغام";
                        }
                        message.ShowDialog();
                    }
                    else
                    {
                        messagBox message = new messagBox();
                        if (password.language == "English")
                            message.label1.Text = ("Request declined");
                        else
                        {
                            message.label1.Text=("امکان ارسال درخواست وجود ندارد");
                            message.Text = "پیغام";
                        }
                        message.ShowDialog();
                    }
                }
                else
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                        message.label1.Text = ("Request is sended");
                    else
                    {
                        message.label1.Text=("درخواست ارسال شده است");
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                }


            }



        }
        public void addfriend(string friendname)
        {
            string Friand_Name="";
            string Friend_Family="";
            if (friendname.IndexOf("_") != -1)
            {
                Friand_Name = friendname.Substring(friendname.IndexOf("_") + 1);
                Friend_Family = friendname.Substring(0, friendname.IndexOf("_"));
            }
            else
            {
                Friend_Family = friendname.Substring(friendname.IndexOf(" ") + 1);
                Friand_Name = friendname.Substring(0, friendname.IndexOf(" "));
            }
            if (Friand_Name == password.Name && Friend_Family == password.Fimily)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("its you!!!");
                else
                {
                    message.label1.Text = ("شما نمی توانید خودتان را به لیست دوستان اضافه کنید");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                return;
            }
                var r = from p in db.friends join q in db.user on p.FriendId equals q.Id where q.Name == Friand_Name && q.Family == Friend_Family join s in db.user on p.UserId equals s.Id where s.Name == password.Name && s.Family == password.Fimily select s;
            if (r.Count() > 0)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("this user already is in your friends list");
                else
                {
                    message.label1.Text=("این کاربر هم اکنون در لیست دوستان شما وجود دارد");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                return;
            }
               
                int suerId = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
                int FriendId = (from p in db.user where p.Name == Friand_Name && p.Family == Friend_Family select p).First().Id;
                var res = from p in db.invited where p.suerId == suerId && p.FriendId == FriendId select p;
                List<string> name = new List<string>();
                name.Add(Friand_Name);
                name.Add(Friend_Family);
                myid = suerId;
            if (res.Count() == 0)
            {
                var res2 = from p in db.declined where p.userId == suerId && p.friendId == FriendId select p;
                if (res2.Count() == 0)
                {

                    using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
                    {
                        invited frnd = new invited();
                        frnd.suerId = suerId;
                        frnd.FriendId = FriendId;
                        frnd.sent = "false";
                        frnd.result = null;
                        db.invited.Add(frnd);
                        db.SaveChanges();
                    }
                    FriendInvited = Friand_Name + " " + Friend_Family;
                    timer_answer.Start();
                    invitedFriends.Add(FriendId);
                    invfriendnames.Add(name);
                    messagBox message = new messagBox();
                    if (password.language == "English")
                        message.label1.Text = ("Request sent");
                    else
                    {
                        message.label1.Text = ("درخواست ارسال شد");
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                }
                else
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                        message.label1.Text = ("Request declined");
                    else
                    {
                        message.label1.Text = ("امکان ارسال درخواست وجود ندارد");
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                }
            }
            else
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("Request is sended");
                else
                {
                    message.label1.Text=("درخواست ارسال شده است");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
            }


            



        }
        void us_Click(object sender, EventArgs e)
        {


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (richTextBox2.Text.Length > 200 || richTextBox2.Text == "")
                return;
            if (e.KeyChar == '\r')
                send();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length > 200 ||richTextBox2.Text=="")
                return;
            send();
        }
        void send()
        {
            if (richTextBox2.Text == ""||richTextBox2.Text=="\n")
                return;
            else
                password.chat = richTextBox2.Text;
            bool wrong = false;
            if (!password.ValidateText(richTextBox2.Text))
            {
               
                wrong = true;
            }
            if (!wrong)
            {
                using (bestchat.amirabbasi1Entities1 db = new amirabbasi1Entities1())
                {
                    chat cht = new chat();
                    cht.Color = password.color.ToString();
                    cht.Family = password.Fimily;
                    cht.Name = password.Name;
                    password.chat = password.chat.Replace("\n\n", "\n");
                    cht.text = password.chat;
                    cht.Location = Location;
                    cht.Subject = Subject;
                    db.chat.Add(cht);
                    db.SaveChanges();
                }
            }
            //showchats();
            richTextBox2.Text = "";
        }
        void writenonames(string text)
        {
            text += "\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.SelectionLength = text.Length;
            richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
            richTextBox1.SelectionColor = Color.DarkRed;
            richTextBox1.AppendText(text);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
            richTextBox1.SelectionFont = richTextBox1.Font;
        }
        bool completed = true;
        void showchats()
        {
            if (!completed)
                return;
            completed = false;
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r = from p in db.chat where (p.Location == Location && p.Subject == Subject&&p.text.IndexOf(password.Name + " " + password.Fimily) == -1 && p.Name == "" && p.Family == "" && p.Id>password.lastpid) select p;
                if (r.Count() > 0)
                {
                    foreach(var item in r)
                    {
                        writenonames(item.text);
                        password.lastpid = item.Id;
                    }
                   
                }
                var result = from p in db.chat where p.Id > password.lastid && p.Location == Location && p.Subject == Subject && p.Name != "" && p.Family != "" select p;
                int chatcount = result.Count();
                //MessageBox.Show(chatcount.ToString());
                if (chatcount > 0)
                {
                    chatcount -= 1;

                    int len1 = 0;
                    string text1 = result.First().Family + "_" + result.First().Name + ": ";
                    if (result.First().Family == "" && result.First().Name == "")
                    {
                        // MessageBox.Show(result.First().text);
                        text1 = "";
                    }
                    if (result.First().Name!=""&&result.First().Family!="")
                    {
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.SelectionLength = text1.Length;
                        richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                        richTextBox1.SelectionColor = Color.DarkRed;
                        richTextBox1.AppendText(text1);
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionFont = richTextBox1.Font;
                        /*LinkLabel userlink = new LinkLabel();
                        userlink.Text = text1;
                        userlink.ActiveLinkColor = Color.DarkRed;
                        userlink.Font= new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                        userlink.DoubleClick += Userlink_DoubleClick;
                        richTextBox1.Controls.(userlink);*/
                        string text2 = result.First().text;
                        int end2 = text2.Length;
                        if (result.First().Family == "" && result.First().Name == "")
                            text2 += "\n";
                        text2 = text2.Replace("\n\n", "\n");
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.SelectionLength = text2.Length;
                        richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Regular);
                        richTextBox1.SelectionColor = ColorTranslator.FromWin32(Convert.ToInt32(result.First().Color));
                        if (result.First().Family == "" && result.First().Name == "")
                            richTextBox1.SelectionColor = Color.DarkRed;
                        richTextBox1.AppendText(text2);
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionFont = richTextBox1.Font;
                        richTextBox1.ScrollToCaret();
                        // }
                        password.lastid = result.First().Id;
                        if (password.language == "English")
                            labelQueue.Text = chatcount.ToString() + " Messages in queue";
                        else
                            labelQueue.Text = chatcount.ToString() + " پیام های در صف انتظار";
                    }
                    else
                    {
                        password.lastid++;
                    }
                    if (chatcount == 0)
                        labelQueue.Text = "";
                }
            }
            completed = true;
        }

        private void Userlink_DoubleClick(object sender, EventArgs e)
        {
            LinkLabel label = (LinkLabel)sender;
            label.Text = label.Text.Remove(label.Text.IndexOf(":"));
            string name = label.Text.Substring(label.Text.IndexOf("_") + 1);
            string family = label.Text.Substring(0, label.Text.IndexOf("_"));
            password.openedforms.Add(name + " " + family);
            Thread thread1 = new Thread(new ThreadStart(show_prv_window));
            thread1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showchats();

        }

        private void chatroom_FormClosing(object sender, FormClosingEventArgs e)
        {

            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                /*var res = from p in db.Conferences where p.owner == (password.Fimily + "_" + password.Name) select p;
                if (res.Count() > 0)
                {
                    foreach (var item in res)
                    {
                        var res1 = from p in db.ConferenceChat where p.ConferencId == item.Id select p;
                        db.ConferenceChat.RemoveRange(res1);
                        db.SaveChanges();
                    }
                    db.Conferences.RemoveRange(res);
                    db.SaveChanges();
                }*/
                var r = from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p;
                if (r.Count() > 0)
                {
                    r.First().online = false;
                    db.SaveChanges();
                    int id = r.First().Id;
                   var r2 = from p in db.room where p.userId == id && p.Location == Location && p.Subject == Subject select p;
                    if (r2.Count() > 0)
                    {
                        foreach (var t in r2)
                        {
                            db.room.Remove(t);

                        }
                        db.SaveChanges();
                    }
                }
                if (Location != "" || Subject != "")
                {
                    chat c = new chat();
                    if (password.language == "English")
                    {
                        c.text = password.Name + " " + password.Fimily + " left room";

                    }
                    else
                    {
                        c.text = "روم را ترک کرد " + password.Name + " " + password.Fimily;
                    }
                    c.Location = Location;
                    c.Subject = Subject;
                    c.Color = Color.DarkRed.ToArgb().ToString();
                    c.Name = "";
                    c.Family = "";
                    db.chat.Add(c);
                    db.SaveChanges();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void chatroom_Load(object sender, EventArgs e)

        {

            richTextBox1.Cursor = Cursors.IBeam;
            richTextBox1.DetectUrls = true;
            richTextBox1.ReadOnly = true;
            timer_bunish.Start();
            comboBox_countries.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_states.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_cities.DropDownStyle = ComboBoxStyle.DropDownList;
            
            fillcountries();
            set_friends_status();
            if (password.language == "فارسی")
            {
                label1.Text = "کشور";
                label2.Text = "استان";
                label3.Text = "شهر";
                label_friends.Text = "دوستان";
                linkLabel1.Text = "موضوعات";
                linkLabel1.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
                button1.Text = "یادداشتهای اتاق";
                button1.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                button2.Text = "اتاق گفتگو";
                button2.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                button3.Text = "بفرست";
                button3.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            }
            //timer1.Interval = (int)password.Timer_room * 1000;
            //timer2.Interval = (int)password.Timer_friends * 1000;
            //timer_bunish.Start();
            timer2.Start();
            Random rnd = new Random();
            int color = rnd.Next(0, 16000000);
            password.color = color;
        }
        ArrayList friends_status = new ArrayList();
        ArrayList friend_names = new ArrayList();
        ArrayList prv_friend_status = new ArrayList();
        void set_friends_status(bool refresh=true)
        {
            friends_status.Clear();
            friend_names.Clear();
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                //var res = from p in db.friends join q in db.user on p.UserId equals q.Id where q.Name == password.Name && q.Family == password.Fimily select p;
                var myid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
                var res = from p in db.friends where p.UserId == myid orderby p.chatCount descending select p;
                foreach (var r in res)
                {

                    var res2 = (from p in db.user where p.Id==r.FriendId select p).First();
                    friends_status.Add(res2.online);
                    friend_names.Add(res2.Family + "_" + res2.Name);
                }
            }
            friends(refresh);
        }
        //bool first = true;
        bool first1 = true;
        void friends(bool first)
        {
            bool change = false;

            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                myid =( from p in db.user where p.Name == password.Name && p.Family == password.Fimily  select p).First().Id;
                var res = from p in db.friends where p.UserId == myid orderby p.chatCount descending select p;
                int frndindex = 0;
                foreach (var r in res)
                {

                    // var res2 = (from p in db.user join q in db.friends on p.Id equals q.FriendId where p.Id == r.FriendId select p).First();
                    var res2 = (from p in db.user where p.Id == r.FriendId select p).First();
                    frndindex = 0;
                    foreach (string f in friend_names)
                    {
                        if (f == res2.Family + "_" + res2.Name)
                            break;
                        frndindex++;
                    }
                    if (frndindex < prv_friend_status.Count)
                    {
                        if (res2.online == true)
                        {

                            if ((bool)prv_friend_status[frndindex] == false)
                            {
                                friends_status[frndindex] = true;
                                change = true;
                                /*prv_friend_status.Clear();
                                foreach (var item in friends_status)
                                {
                                    prv_friend_status.Add(item);
                                }*/
                                messagBox messageForm = new messagBox();
                                if (password.language == "English")
                                {
                                    messageForm.label1.Text=(res2.Name + " " + res2.Family + " is now online");
                                }
                                else
                                {
                                    messageForm.Text = "پیغام";
                                    messageForm.label1.Text=("هم اکنون آنلاین است " + res2.Name + " " + res2.Family);
                                }
                                messageForm.Show();
                            }
                        }
                        else
                        {

                            if ((bool)prv_friend_status[frndindex] == true)
                            {
                                friends_status[frndindex] = false;
                                change = true;
                                /*prv_friend_status.Clear();
                                foreach (var item in friends_status)
                                {
                                    prv_friend_status.Add(item);
                                }*/
                                messagBox messageForm = new messagBox();
                                if (password.language == "English")
                                {
                                    messageForm.label1.Text=(res2.Name + " " + res2.Family + " is now offline");
                                }
                                else
                                {
                                    messageForm.Text = "پیغام";
                                    messageForm.label1.Text = ("هم اکنون آفلاین است  " + res2.Name + " " + res2.Family);
                                }
                                messageForm.Show();
                            }
                        }
                    }
                    
                }
                
            }
            if (change || first)
            {
                prv_friend_status.Clear();
                foreach (var item in friends_status)
                {
                    prv_friend_status.Add(item);
                }
                draw_friends(true);
            }
           
        }
        void draw_friends(bool first)
        {
            int x = 80;
            int counter = 0;
            Control friendslable = new Control();
            friendslable=friends_panel.Controls["label_friends"];
            if (first)
            {
                friends_panel.Controls.Clear();
            }
            friends_panel.Controls.Add(friendslable);
            foreach (bool b in friends_status)
            {
                PictureBox picb = new PictureBox();
                if (b)
                    picb.Image = Resources.User_blue_icon;
                else
                    picb.Image = Resources.user;
                picb.Location = new Point(x, 0);
                Label lb = new Label();
                lb.AutoSize = true;
                lb.Text = (string)friend_names[counter];
                lb.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                lb.ForeColor = Color.Blue;
                picb.SizeMode = PictureBoxSizeMode.CenterImage;
                picb.Height = 60;
                if (lb.PreferredWidth >= picb.Width)
                {
                    picb.Width = lb.PreferredWidth;
                    lb.Location = new Point(x, 60);
                }
                else
                    lb.Location = new Point((picb.Width - lb.PreferredWidth) / 2 + x, 60);
                x += (picb.Width + 15);
                picb.DoubleClick += Picb_DoubleClick;
                picb.ContextMenuStrip = new ContextMenuStrip();
                string text = "حذف از لیست دوستان";
                if (password.language == "English")
                    text = "Delete from user list";
                picb.ContextMenuStrip.Items.Add(text).Click += friends_del_click;
                if (password.Confrences.Count > 0)
                {
                    if (password.language == "English")
                    {
                        text = "invite to confrence";
                    }
                    else
                    {
                        text = "دعوت به کنفرانس";
                    }
                    picb.ContextMenuStrip.Items.Add(text).Click += Chatroom_Click_friend_invite;
                }
                picb.MouseDown += Picb_MouseDown;
                friends_panel.Controls.Add(picb);
                friends_panel.Controls.Add(lb);
                counter++;
            }


        }

        private void Chatroom_Click_friend_invite(object sender, EventArgs e)
        {
            open_invite_by_name();
        }

        private void Picb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic1 = new PictureBox();
            pic1 = (PictureBox)sender;
            friendclicked = pic1.Parent.GetNextControl(pic1, true).Text;
        }

        string friendclicked = "";
       

        private void friends_del_click(object sender, EventArgs e)
        {
            string text = friendclicked;
            string familyf = text.Substring(0, text.IndexOf("_"));
            string namef= text.Substring(text.IndexOf("_") + 1);
            var r1 = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First();
            var r2 = (from p in db.user where p.Name == namef && p.Family == familyf select p).First();
            int idmine = r1.Id;
            int idf = r2.Id;
            var r = (from p in db.friends where p.UserId == idmine && p.FriendId == idf select p).First();
            db.friends.Remove(r);
            db.SaveChanges();
            set_friends_status();
           
           
        }

        private void Picb_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pic = new PictureBox();
            pic = (PictureBox)sender;
            string text = pic.Parent.GetNextControl(pic, true).Text;
            string text2 =seprate(pic.Parent.GetNextControl(pic, true).Text);
            foreach (string s in password.openedforms)
                if (s == text2)
                    return;
            password.openedforms.Add(text.Substring(text.IndexOf("_")+1)+" "+text.Substring(0,text.IndexOf("_")));
            string familyf = text.Substring(0, text.IndexOf("_"));
            string namef = text.Substring(text.IndexOf("_") + 1);
            var r1 = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First();
            var r2 = (from p in db.user where p.Name == namef && p.Family == familyf select p).First();
            int idmine = r1.Id;
            int idf = r2.Id;
            var r = (from p in db.friends where p.UserId == idmine && p.FriendId == idf select p).First();
            if (r.chatCount == null)
            {
                r.chatCount = 1;
            }
            else
                r.chatCount++;
            db.SaveChanges();
            set_friends_status();
            Thread thread1 = new Thread(new ThreadStart(show_prv_window));
            thread1.Start();

        }


        string seprate(string name)
        {
            string n = name.Substring(name.IndexOf("_") + 1);
            string f = name.Substring(0, name.IndexOf("_"));
            return (n + " " + f);
        }
        private void chatroom_Resize(object sender, EventArgs e)
        {

        }
        int windowsize = 0;
        private void chatroom_ResizeBegin(object sender, EventArgs e)
        {
            windowsize = this.Width;
        }

        private void chatroom_ResizeEnd(object sender, EventArgs e)
        {
            richTextBox1.Width += (this.Width - windowsize);
        }

        private void chatroom_SizeChanged(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width - 130;
            panel_users.Location = new Point(this.Width - 130, panel_users.Location.Y);
            panel_users.Height = this.Height - 253;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            getprivate();
            userlist();
            set_friends_status(false);
            /*for (int i = 0; i < password.ConfrenceThreads.Count; i++)
            {
                password.ConfrenceThreads[i] = null;
            }
            password.ConfrenceThreads.Clear();*/
            getConfrence();
           getInviteds();
            timer_answer.Start();
        }
        void getInviteds()
        {
            var id = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var res = (from p in db.invited where p.FriendId == id && p.sent=="false" select p);
            if (res.Count() > 0)
            {
                int otherid = (int)res.First().suerId;
                var result2 = from p in db.declined where p.friendId == id && p.userId ==otherid select p;
                if (result2.Count() == 0)
                {
                    var result = res.First();
                    result.sent = "true";
                    db.SaveChanges();
                    var res3 = (from p in db.user where p.Id == otherid select p).First();
                    Form_Invite_friend form = new Form_Invite_friend() { Owner = this };
                    form.name = res3.Family  + "_" + res3.Name;
                    answer = "";
                    form.ShowDialog();
                    //form.FormClosed += Form_Accept_FormClosed;
                    timer_addfriend.Start();
                    set_friends_status();
                }
            }
        }

       

        string confrenceName = "";
        int confrenceId = -1;
        public ArrayList Invited_confrences = new ArrayList();
        void getConfrence()
        {
            var result = from p in db.ConferenceChat where p.userName == password.Fimily + "_" + password.Name && p.text == "" select p;
            if (result.Count() > 0)
            {
                int chatid = result.First().Id;
                confrenceId = result.First().ConferencId;
                Form_Invite form = new Form_Invite();
                var result2 = (from p in db.Conferences join q in db.ConferenceChat on p.Id equals q.ConferencId where p.Id == confrenceId select p);
                if (result2.Count() > 0)
                {
                    confrenceName = result2.First().ConferenceRoomName;
                    foreach (string s in Invited_confrences)
                    {
                        if (s == confrenceName)
                            return;
                    }
                }
                else
                    return;
                form.Text = confrenceName;
                Invited_confrences.Add(confrenceName);
                form.ShowDialog();

                if (password.AcceptOK == true)
                {
                    result.First().text = "#";
                    db.SaveChanges();
                    addU2c(confrenceId);
                    password.AcceptOK = false;
                    Thread thread = new Thread(showConfrence);
                    thread.Start();
                }
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show(thread1.ThreadState.ToString());
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            // getprivate();
        }

        void getprivate()
        {
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var res = from p in db.@private where p.to_Name == password.Name && p.to_Family == password.Fimily && p.text != "" select p;
                if (res.Count() > 0)
                {
                    foreach (var r in res)
                    {
                        bool opened = false;
                        string name = r.Name + " " + r.Family;
                        foreach (string e in password.openedforms)
                            if (e == name)
                                opened = true;
                        if (!opened)
                        {
                            foreach (string n in blacklist)
                                if (name == n)
                                    return;
                            Thread thread1 = new Thread(new ThreadStart(show_prv_window2));
                            password.openedforms.Add(name);
                            thread1.Start();
                        }


                    }
                }
            }
        }
        void show_prv_window2()
        {
            Private_Form form = new Private_Form();

            form.Text = password.openedforms[password.openedforms.Count - 1].ToString();
            CheckBox chb = new CheckBox();
            chb.AutoSize = true;
            chb.RightToLeft = RightToLeft.Yes;
            chb.Location = new Point(form.Width - 210, form.Controls.Find("label1", true).First().Location.Y);
            if (password.language == "English")
                chb.Text = " Dont open again ";
            else
                chb.Text = " دیگر باز نکن";
            chb.CheckedChanged += Chb_CheckedChanged;
            form.Controls.Add(chb);
            form.FormClosing += Form_FormClosing2;
            SoundPlayer sound = new SoundPlayer(Resources.Windows_Notify_System_Generic);
            sound.Play();
            form.BringToFront();
            form.ShowDialog();
        }

        private void Form_FormClosing2(object sender, FormClosingEventArgs e)
        {
            Private_Form prvform = new Private_Form();
            prvform = (Private_Form)sender;
            string friend_name = prvform.Text.Substring(0, prvform.Text.IndexOf(" "));
            string friend_family = prvform.Text.Substring(prvform.Text.IndexOf(" ") + 1, prvform.Text.Length - prvform.Text.IndexOf(" ") - 1);
            private_formclosing(friend_name, friend_family);
        }

        void show_prv_window()
        {
            Private_Form form = new Private_Form();
            form.Text = password.openedforms[password.openedforms.Count - 1].ToString();
           
            form.FormClosing += Form_FormClosing1;
            form.ShowDialog();
        }

        private void Form_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Private_Form prvform = new Private_Form();
            prvform = (Private_Form)sender;
            string friend_name="";
            string friend_family="";
            try {
                 friend_name = prvform.Text.Substring(0, prvform.Text.IndexOf(" "));
                 friend_family = prvform.Text.Substring(prvform.Text.IndexOf(" ") + 1, prvform.Text.Length - prvform.Text.IndexOf(" ") - 1);
            }
            catch
            {
                friend_family = prvform.Text.Substring(0, prvform.Text.IndexOf("_"));
                friend_name = prvform.Text.Substring(prvform.Text.IndexOf("_") + 1, prvform.Text.Length - prvform.Text.IndexOf("_") - 1);

            }
            private_formclosing(friend_name, friend_family);
        }
        void private_formclosing(string friend_name, string friend_family)
        {

            for (int i = 0; i < password.openedforms.Count; i++)
            {
                if ((string)password.openedforms[i] == friend_name + ' ' + friend_family)
                {
                    password.openedforms.RemoveAt(i);
                    break;
                }
                if ((string)password.openedforms[i] == friend_family + '_' + friend_name)
                {
                    password.openedforms.RemoveAt(i);
                    break;
                }

            }
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r2 = from p in db.@private where ((p.Name == friend_name && p.Family == friend_family && p.to_Name == password.Name && p.to_Family == password.Fimily) || (p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_name && p.to_Family == friend_family)) && p.text != "" select p;
                foreach (var res in r2)
                {
                    bool IsOff = false;
                    foreach (int off in password.Offlines)
                    {
                        if (res.Id == off)
                        {
                            IsOff = true;
                            break;
                        }
                    }
                    if (!IsOff)
                        db.@private.Remove(res);

                }
                db.SaveChanges();
            }
            stoped_threads.Add(Thread.CurrentThread);
            timer_thread.Start();
        }
        ArrayList stoped_threads = new System.Collections.ArrayList();
        ArrayList blacklist = new ArrayList();
        private void Chb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = new CheckBox();
            chb = (CheckBox)sender;
            if (chb.Checked == true)
                blacklist.Add(chb.Parent.Text);
        }

        
        void threadAbort()
        {
            try
            {
                Thread.CurrentThread.Join();
                Thread.Sleep(3000);
                Thread.CurrentThread.Abort();

            }
            catch (ThreadAbortException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            subjects form = new subjects();
            form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            password.country = comboBox_countries.Text;
            password.Province = comboBox_states.Text;
            password.city = comboBox_cities.Text;
            Posts_Form form = new Posts_Form();
            Location = getloc();
            Subject = getsubject();
            form.Text = Getroomname();
            form.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 97 || e.KeyChar > 122)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("Please insert little english character");
                else
                {
                   message.label1.Text=("لطفا از حروف کوچک انگلیسی استفاده کنید");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                e.Handled = true;

            }
            else
                e.Handled = false;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 97 || e.KeyChar > 122)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("Please insert little english character");
                else
                {
                    message.label1.Text=("لطفا از حروف کوچک انگلیسی استفاده کنید");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                e.Handled = true;

            }
            else
                e.Handled = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 97 || e.KeyChar > 122)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("Please insert little english character");
                else
                {
                    message.label1.Text = ("لطفا از حروف کوچک انگلیسی استفاده کنید");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                e.Handled = true;

            }
            else
                e.Handled = false;
        }
        string Getroomname()
        {
            string name = Subject;
            if (name != "")
                name += "_";
            name += Location;
            if (Location == "")
                name = name.Remove(name.Length - 1);
            return name;
        }



        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                validate_clipboard();
            }
        }
        void validate_clipboard()
        {
            string clipboardtext = Clipboard.GetText();
            int httpindex = clipboardtext.IndexOf("http://");
            int wwwindex = clipboardtext.IndexOf("www.");
            if (httpindex != -1)
            {
                Clipboard.SetText(clipboardtext.Substring(httpindex, clipboardtext.IndexOf(' ', httpindex) - httpindex));
            }
            else if (wwwindex != -1)
            {
                Clipboard.SetText(clipboardtext.Substring(wwwindex, clipboardtext.IndexOf(' ', wwwindex) - wwwindex));
            }
            else
                Clipboard.Clear();
        }

        private void richTextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                validate_clipboard();
        }
        bool Isbunished()
        {
            string cpuId = password.GetCpuId();
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var result = (from p in db.Machin
                              where p.CpuID == cpuId
                              select p);
                if (result.Count() > 0)
                {
                    if (result.First().WarningDate != null)
                    {
                        int days = password.CompareDate((DateTime)result.First().WarningDate, password.now());
                        switch (result.First().WarningCount)
                        {
                            case 1:
                                {
                                    if (days > 1)
                                    {
                                        result.First().WarningDate = null;
                                        db.SaveChanges();
                                        return false;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (days > 3)
                                    {
                                        result.First().WarningDate = null;
                                        db.SaveChanges();
                                        return false;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (days > 7)
                                    {
                                        result.First().WarningDate = null;
                                        db.SaveChanges();
                                        return false;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (days >= 30)
                                    {
                                        result.First().WarningDate = null;
                                        db.SaveChanges();
                                        return false;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    return true;

                                }
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                }
            }

            return false;
        }
        void bunish()
        {
            if (Isbunished())
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("Access denied");
                else
                {
                   message.label1.Text=("دسترسی امکانپذیر نیست");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
                Application.Exit();
            }
        }

        private void timer_bunish_Tick(object sender, EventArgs e)
        {
            timer_bunish.Stop();
            bunish();
           

            
        }

        void fillcountries()
        {
            string[] countries = { "World", "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua & Deps", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia", "Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Rep", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Congo {Democratic Rep}", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland {Republic}", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea", "North Korea", "South Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall", "Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar {Burma}", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russian Federation", "Rwanda", "St Kitts & Nevis", "St Lucia", "Saint Vincent & the Grenadines", "Samoa", "San Marino", "Sao Tome & Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra", "Leone Singapore", "Slovakia", "Slovenia", "Solomon", "Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe" };
            var xml = new XmlDocument();
            xml.Load(Application.StartupPath + "/XML_countries.xml");
            comboBox_countries.Items.Add("World");
            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            {
                comboBox_countries.Items.Add(node.Attributes["name"]?.InnerText);
            }
            comboBox_countries.SelectedIndex = 0;
        }

        private void comboBox_states_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_cities.Items.Clear();
            password.Province = comboBox_states.SelectedItem.ToString();
            switch (password.Province)
            {
                case "آذربایجان شرقی ":
                    {
                        string[] cities = { "اهر", "بستان آباد", "بناب", "تبریز", "جلفا", "سراب", "شبستر", "کلیبر", "مراغه", "مرند", "ملکان", "میانه", "هرس", "هشترود" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "آذربایجان غربی ":
                    {
                        string[] cities = { "ارومیه", "اشنویه", "بوکان", "تکاب", "پیرانشهر", "سلماس", "سردشت", "سیه چشمه", "شاهین دژ", "خوی", "مهاباد", "میاندوآب", "ماکو", "نقده" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "اردبیل":
                    {
                        string[] cities = { "اردبیل", "بیله سوار", "پارس آباد", "خلخال", "گرمی", "مشکین شهر" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "اصفهان":
                    {
                        string[] cities = { "اردستان", "اصفهان", "خوانسار", "خمینی شهر", "داران", "زرین شهر", "سمیرم", "شهررضا", "شاهین شهر", "فریدون شهر", "فلاورجان", "کاشان", "گلپایگان", "ملک شهر", "نائین", "نجف آباد", "نطنز" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "البرز ":
                    {
                        string[] cities = { "  آسارا و شهرستانک  ", "  اشتهارد  ", "کرج", "هشتگرد", "ساوجبلاغ ", "طالقان", "گرمدره", "مشکین دشت و ولدآباد ", "نطنزآباد" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "ا یلام":
                    {
                        string[] cities = { "آبدانان", "ایلام", "ایوان", "دره شهر", "دهلران", "مهران" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "بوشهر ":
                    {
                        string[] cities = { "اهرم", "برازجان", "بندر بوشهر", "بندر دیر", "بندر دیلم", "بندر کنگان", "بندر گناوه", "خورموج" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "تهران ":
                    {
                        string[] cities = { "بهارستان ", "پاکدشت", "پیشوا", "تهران", "دماوند", "ورامین", "ری", "رباط کریم", "شمیران", "شهریار", "فیروزکوه", "قدس", "ملارد", "ملارد" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "چهار محال و بختیاری ":
                    {
                        string[] cities = { "اردل", "بروجن", "شهرکرد", "سامان", "فارسان", "لردگان", "هفشجان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "خراسان جنوبی":
                    {
                        string[] cities = { "فردوس", "قائنات", "نهبندان", "بیرجند", "درمیان", "سرایان", "سرچشمه" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "خراسان شمالی":
                    {
                        string[] cities = { "بجنورد", "شیروان", "اسفراین", "آشخانه", "جاجرم", "فاروج", "گرمه", "ارق", "راز", "تیتکانکو", "ایور", "صفی آباد", "قاضی", "شوقان", "پیش قلعه", "سنخواست", "حصارگرم خان", "لوجلی" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "خراسان رضوی ":
                    {
                        string[] cities = { " باخرز", "تخت", "بجستان", "بردسکن", "بینالود", "تایباد", "جلگه", "جام", "تربت حیدریه", "جغتای", "جوین", "چناران", "خلیل‌آباد", "خواف", "خوشاب", "درگز", "رشتخوار", "زاوه", "سبزوار", "سرخس", "فریمان", "قوچان", "کاشمر", "کلات", "گناباد", " مه ولات", "مشهد", "نیشابور" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "خوزستان":
                    {
                        string[] cities = { "آبادان ", "   اندیمشک  ", "  اهواز ", "   ایذه ", " باغ‌ملک  ", "  بندرماهشهر ", "   بهبهان ", "   خرمشهر ", " دزفول  ", "  رامهرمز ", "   سوسنگرد  ", "  شادگان ", " شوش ", "   شوشتر ", "   مسجد‌سلیمان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "زنجان":
                    {
                        string[] cities = { "ابهر ", "   خرم‌دره  ", "  زنجان ", "   ماهنشان", " ایجرود", " خدابنده", " ", " طارم", "   ماهنشان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "سمنان ":
                    {
                        string[] cities = { "آرادان", " دامغان", " سمنان", " شاهرود", " گرمسار", " مهدیشهر ", "  میامی " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "سیستان و بلوچستان":
                    {
                        string[] cities = { "ایرانشهر ", "   چابهار ", "   خاش  ", "  زابل ", " زاهدان ", "   سراوان  ", "  نیک‌شهر " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "فارس ":
                    {
                        string[] cities = { "آباده ", " ارسنجان ", " استهبان ", " اقلید ", " بوانات ", " پاسارگاد ", " جهرم ", " خرامه ", " خرم بید ", " خنج ", " داراب ", " رستم ", " زرین دشت ", " سپیدان ", " سروستان ", " شیراز ", " فراشبند ", " فسا ", " فیروزآباد ", " قیروکارزین ", " کازرون ", " کوار ", " گراش ", " لارستان ", " لامرد ", " مرودشت ", " ممسنی ", " مهر ", "نی‌ریز " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "قزوین ":
                    {
                        string[] cities = { "اوان", "بوئین‌زهرا ", "   تاکستان  ", "  قزوین" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "قم":
                    {
                        string[] cities = { "قم" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "کردستان ":
                    {
                        string[] cities = { "بانه   ", "  بیجار  ", "  دیواندره  ", "  سقز ", " سنندج  ", "  قروه  ", "  کامیاران ", "   مریوان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "کرمان ":
                    {
                        string[] cities = { " بردسیر", " بم", " جیرفت", " رابر", " راور", " رفسنجان", " رودبار جنوب", " ریگان", " زرند", " سیرجان", " شهر بابک", " عنبرآباد", " فاریاب", " فهرج", " قلعه گنج", " کرمان", " کهنوج", " کوهبنان", " منوجان ", " نرماشیر " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "کرمانشاه":
                    {
                        string[] cities = { "اسلام‌آباد غرب  ", "  پاوه  ", "  جوانرود  ", "  سرپل‌ذهاب ", " سنقر  ", "  صحنه  ", "  قصرشیرین  ", "  کرمانشاه ", " کنگاور  ", "  گیلانغرب ", "   هرسین " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "کهگیلویه و بویر احمد ":
                    {
                        string[] cities = { " دوگنبدان", " دهدشت", "یاسوج " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "گلستان ":
                    {
                        string[] cities = { "گرگان", " گنبدکاووس", " ترکمن", " علی‌آباد", " کردکوی", " آق‌قلا", " آزادشهر", " رامیان", " مینودشت", " کلاله و بندرگز " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "گیلان ":
                    {
                        string[] cities = { " آستارا ", "  آستانه‌اشرفیه  ", "  بندر‌انزلی  ", "  رشت", "  رودبار ", "   رود‌سر  ", "  شفت  ", "  صومعه‌سرا ", " فومن  ", "  لاهیجان  ", "  لنگرود ", "   هشتپر" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "لرستان ":
                    {
                        string[] cities = { " ازنا ", "   الیگودرز  ", "  بروجرد  ", "  پلدختر ", " خرم‌آباد  ", "  دورود  ", "  کوهدشت" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "مازندران ":
                    {
                        string[] cities = { " آمل ", "   بابل  ", "  بهشهر  ", "  تنکابن ", " چالوس  ", "  رامسر  ", "  ساری ", "   قائم‌شهر ", " محمودآباد ", "   نکا  ", "  نور و علمده ", "   نوشهر" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "مرکزی ":
                    {
                        string[] cities = { "آشتیان ", "   اراک ", "   تفرش  ", "  خمین ", " دلیجان  ", "  ساوه  ", "  شازند ", "   محلات " };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "هرمزگان ":
                    {
                        string[] cities = { " ابوموسی ", "  بندرجاسک ", "   بندرعباس  ", "  بندرلنگه ", " حاجی‌آباد  ", "  رودان (دهبارز) ", "   قشم ", "   کیش ", " میناب ", "   تنب بزرگ  ", "  تنب کوچک" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "همدان ":
                    {
                        string[] cities = { "اسدآباد  ", "  بهار  ", "  تویسرکان  ", "  رزن ", " کبودرآهنگ ", "   ملایر  ", "  نهاوند  ", "  همدان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
                case "یزد":
                    {
                        string[] cities = { " ابرکوه  ", "  بافق  ", "  تفت  ", "  مهریز ", " میبد  ", "  یزد  ", "  اردکان" };
                        comboBox_cities.Items.AddRange(cities);
                        break;
                    }
            }
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "/XML_states.xml");
            string state_id = "";
            foreach (XmlNode nod in doc1.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["name"]?.InnerText == password.Province)
                {
                    state_id = nod.Attributes["id"]?.InnerText;
                    break;
                }
            }
            XmlDocument doc2 = new XmlDocument();
            doc2.Load(Application.StartupPath + "/XML_cities.xml");
            foreach (XmlNode nod in doc2.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["state_id"]?.InnerText == state_id)
                {
                    comboBox_cities.Items.Add(nod.Attributes["name"]?.InnerText);
                }
            }
        }

        private void comboBox_countries_SelectedValueChanged(object sender, EventArgs e)
        {

            comboBox_states.Items.Clear();
            comboBox_cities.Items.Clear();
            password.country = comboBox_countries.SelectedItem.ToString();
            switch (password.country)
            {
                case "Iran":
                    {
                        string[] states = { "آذربایجان شرقی ", "آذربایجان غربی ", "اردبیل", "اصفهان", "البرز ", "ا یلام", "بوشهر ", "تهران ", "چهار محال و بختیاری ", "خراسان جنوبی", "خراسان رضوی ", "خراسان شمالی", "خوزستان", "زنجان", "سمنان ", "سیستان و بلوچستان", "فارس ", "قزوین ", "قم", "کردستان ", "کرمان ", "کرمانشاه", "کهگیلویه و بویر احمد ", "گلستان ", "گیلان ", "لرستان ", "مازندران ", "مرکزی ", "هرمزگان ", "همدان ", "یزد" };

                        comboBox_states.Items.AddRange(states);
                        return;
                    }

            }
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "/XML_countries.xml");
            string country_id = "";
            foreach (XmlNode nod in doc1.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["name"]?.InnerText == password.country)
                {
                    country_id = nod.Attributes["Id"]?.InnerText;
                    break;
                }
            }
            XmlDocument doc2 = new XmlDocument();
            doc2.Load(Application.StartupPath + "/XML_states.xml");
            foreach (XmlNode nod in doc2.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["country_id"]?.InnerText == country_id)
                {
                    comboBox_states.Items.Add(nod.Attributes["name"]?.InnerText);
                }
            }
        }

        private void comboBox_cities_SelectedValueChanged(object sender, EventArgs e)
        {
            password.city = comboBox_cities.SelectedItem.ToString();
        }

        private void comboBox_states_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox_cities_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_thread_Tick(object sender, EventArgs e)
        {
            timer_thread.Stop();
            for (int i = 0; i < stoped_threads.Count; i++)
            {
                stoped_threads[i] = null;
            }
            stoped_threads.Clear();
        }

        private void button_add_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            if (password.language == "English")
            {
                tooltip.Show("Add confrence", (Button)sender);
            }
            else
                tooltip.Show("افزودن کنفرانس", (Button)sender);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            addConfrence();
        }
        void addConfrence()
        {
            Form_AddConference form = new Form_AddConference();
            form.ShowDialog();
            confrenceName =(string) password.Confrences[password.Confrences.Count - 1];
            if (password.AddConfrenceOK)
            {
                var r = from p in db.Conferences where p.ConferenceRoomName == confrenceName && p.owner == (password.Fimily + "_" + password.Name) select p;
                if (r.Count() > 0)
                    confrenceId = r.First().Id;
                addToken();
                password.AddConfrenceOK = false;
                addU2c(confrenceId);
                Thread thread = new Thread(showConfrence);
                
                thread.Start();
                //foreach (Label label in panel_users.Controls)
                /*{
                    
                    if (password.language == "English")
                        label.ContextMenuStrip.Items.Add("invite to " + password.Confrences[password.Confrences.Count - 1] + " confrence");
                    else
                        label.ContextMenuStrip.Items.Add(string.Format("{0} دعوت به کنفرانس ", password.Confrences[password.Confrences.Count - 1]));
                    label.ContextMenuStrip.Items[label.ContextMenuStrip.Items.Count - 1].Click += Chatroom_Click;
                    
                }*/

               
            }
        }
        void addU2c(int conid)
        {
            int userid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            ConfrenceUsers cu = new ConfrenceUsers();
            cu.confrenceId = conid;
            cu.userId = userid;
            db.ConfrenceUsers.Add(cu);
            db.SaveChanges();
        }
        void addToken()
        {
            //confrenceName = (string)password.Confrences[password.Confrences.Count - 1];
            /*           
            var r1=(from p in db.Conferences where p.ConferenceRoomName == confrenceName && p.owner == password.Fimily + "_" + password.Name select p);
            if (r1.Count() == 0)
                return;
            else*/
            ConferenceChat tbl = new ConferenceChat();
            tbl.userName = password.Fimily + "_" + password.Name;
            tbl.ConferencId = confrenceId;
            tbl.color = password.color.ToString();
            tbl.text = "#";
            int id = 1;
            /*var r= (from p in db.ConferenceChat select p);
            foreach (var item in r)
                id = item.Id;
            tbl.Id = id + 1;*/
            try
            {
                db.ConferenceChat.Add(tbl);
                db.SaveChanges();
            }
            catch
            {
                var r = from p in db.ConferenceChat select p;
                if (r.Count() == 0)
                    tbl.Id = 1;
                else
                {
                    foreach (var item in r)
                        id = item.Id;
                    id++;
                    tbl.Id = id;
                }
                db.ConferenceChat.Add(tbl);
                db.SaveChanges();
            }
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        void open_invite_by_name()
        {
            Form_Invite_ByName form = new Form_Invite_ByName();
            form.userName = selecteduser;
            form.type = "confrence";
            var result = from p in db.Conferences where string.Equals(p.ConferenceRoomName, confrenceName) && p.owner == (password.Fimily + "_" + password.Name) select p;
            if (result.Count() > 0)
                form.confrenceId = result.First().Id;
            form.ShowDialog();
        }
        private void Chatroom_Click(object sender, EventArgs e)
        {
            open_invite_by_name();
        }
        string seperate_name(string name)
        {
            if (password.language == "English")
            {
                int previuse = name.IndexOf(' ', name.IndexOf("to"));
                int next = name.IndexOf("confrence", previuse + 1);
                return name.Substring(previuse + 1, next - previuse - 2);
            }
            else
            {
                string[] words = name.Split(' ');
                foreach (string s in words)
                {
                    if (s != "" && s.IndexOf("دعوت") == -1 && s.IndexOf("به") == -1 && s.IndexOf("کنفرانس") == -1 && s.IndexOf("با") == -1 && s.IndexOf("نام") == -1)
                        return s;
                }
                return "";
            }
        }
        void Invite_to_confrence(string confrence)
        {
            string user_toInvite = selecteduser;
            int confrenceId = (from p in db.Conferences where p.ConferenceRoomName == confrence select p).First().Id;
            var result = from p in db.ConferenceChat where user_toInvite == p.userName && p.text == "" && p.ConferencId == confrenceId select p;
            if (result.Count() == 0)
            {
                ConferenceChat tbl = new ConferenceChat();
                tbl.userName = user_toInvite;
                tbl.ConferencId = confrenceId;
                tbl.text = "";
                db.ConferenceChat.Add(tbl);
                db.SaveChanges();
            }
        }
        void showConfrence()
        {
            if(confrenceName=="")
                confrenceName = (string)password.Confrences[password.Confrences.Count - 1];
            Form_Confrence form = new Form_Confrence();
            form.Text = confrenceName;
            /*var result = from p in db.Conferences where string.Equals(p.ConferenceRoomName, confrenceName) && p.owner == (password.Fimily + "_" + password.Name) select p;
            if (result.Count() > 0)
            {
                form.confrenceId = result.First().Id;
                confrenceId = form.confrenceId;
            }
            else*/
                form.confrenceId = confrenceId;
            /*var r = from p in db.ConferenceChat  join q in db.Conferences on p.ConferencId equals q.Id select p ;
            if (r.Count() > 0)
            {
                db.ConferenceChat.RemoveRange(r);
                db.SaveChanges();
            }*/
           
            form.ShowDialog();
            confrenceName = "";
        }

        private void Form_FormClosing3(object sender, FormClosingEventArgs e)
        {
           /* Form f = new Form();
            f = (Form)sender;
            for (int i = 0; i < Invited_confrences.Count; i++)
            {
                if ((string)Invited_confrences[i] == f.Text)
                    Invited_confrences.RemoveAt(i);
            }
            for (int i = 0; i < password.Confrences.Count; i++)
            {
                if ((string)password.Confrences[i] == f.Text)
                    password.Confrences.RemoveAt(i);
            }*/
        }

        string selecteduser = "";
        private void panel_users_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Label lb in panel_users.Controls)
            {
                if (e.Y > lb.Location.Y && e.Y < lb.Location.Y + lb.Height)
                {
                    lb.Select();
                    selecteduser = lb.Text;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            double multi = 30;
            int row = 0;
            panel2.ContextMenuStrip = new ContextMenuStrip();
            if (password.language == "English")
            {
                panel2.ContextMenuStrip.Items.Add("Add user by name");
                panel2.ContextMenuStrip.Items[0].Click += Chatroom_Click3;
                panel2.ContextMenuStrip.Items.Add("Add Confrence");
                panel2.ContextMenuStrip.Items[1].Click += Chatroom_Click2;
                if (password.Confrences.Count > 0)
                {
                    panel2.ContextMenuStrip.Items.Add("Invite to confrence by name");
                    panel2.ContextMenuStrip.Items[2].Click += Chatroom_Click1;
                    multi = 8;
                    row = 50;
                }
            }
            else
            {
                panel2.ContextMenuStrip.Items.Add("افزودن دوستان با نام");
                panel2.ContextMenuStrip.Items[0].Click += Chatroom_Click3;
                panel2.ContextMenuStrip.Items.Add("افزودن کنفرانس");
                panel2.ContextMenuStrip.Items[1].Click += Chatroom_Click2;
                if (password.Confrences.Count > 0)
                {
                    panel2.ContextMenuStrip.Items.Add("دعوت به کنفرانس با نام");
                    panel2.ContextMenuStrip.Items[2].Click += Chatroom_Click1;
                    multi = 8;
                    row = 15;
                }
            }
            panel2.ContextMenuStrip.Show(this, panel2.Location.X - panel2.ContextMenuStrip.PreferredSize.Width - row + panel2.Width, Convert.ToInt32(panel2.Location.Y + 44 + panel2.ContextMenuStrip.PreferredSize.Height + multi));
        }

        private void Chatroom_Click3(object sender, EventArgs e)
        {
            Form_AddFreindByName form = new Form_AddFreindByName() { Owner = this };
            form.ShowDialog();
            set_friends_status();
            
        }

        private void Chatroom_Click2(object sender, EventArgs e)
        {
            addConfrence();
        }

        private void Chatroom_Click1(object sender, EventArgs e)
        {
            Form_Invite_ByName form = new Form_Invite_ByName();
            form.type = "confrence";
            form.ShowDialog();
        }

        private void friends_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_answer_Tick(object sender, EventArgs e)
        {
            myid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var result0 = from p in db.invited where p.suerId == myid && p.result != null select p;
            if (result0.Count() > 0)
            {
                foreach (var r in result0)
                {
                    var res0 =( from p in db.user
                               where p.Id == r.FriendId
                               select p).First();
                    var fname = res0.Name;
                    var ffamily = res0.Family;
                    FriendInvited = ffamily + " " + fname;
                    if (r.result == "Declined")
                    {
                        answer = "";
                        timer_answer.Stop();
                        messagBox message = new messagBox();
                        if (password.language == "English")
                        {
                            message.label1.Text = (FriendInvited + " Declines your invitation!");
                        }
                        else
                        {
                            message.label1.Text = ("دعوت شما به دوستی را رد کرد " + FriendInvited);
                            message.Text = "پیغام";
                        }

                        message.ShowDialog();

                        removeinvited((int)r.FriendId);
                    }
                    if (r.result == "Accepted")
                    {
                        answer = "";
                        timer_answer.Stop();
                        messagBox message = new messagBox();
                        if (password.language == "English")
                        {
                           message.label1.Text=(FriendInvited + " Accepts your invitation!");
                        }
                        else
                        {
                            message.label1.Text=("دعوت شما به دوستی را قبول کرد " + FriendInvited);
                            message.Text = "پیغام";
                        }
                        message.Show();
                        FriendInvited = "";
                        friends_status.Add(true);
                        friend_names.Add(fname + "_" + ffamily);
                        set_friends_status();

                        removeinvited((int)r.FriendId);
                    }
                    if (r.result == "Accepted and add")
                    {
                        answer = "";
                        timer_answer.Stop();
                        messagBox message = new messagBox();
                        if (password.language == "English")
                        {
                            message.label1.Text=(FriendInvited + " Accept your invitation and adds you in friend list!");
                        }
                        else
                        {
                            message.label1.Text=("دعوت شما به دوستی را قبول و به لیست دوستان اضافه کرد " + FriendInvited);
                            message.Text = "پیغام";
                        }
                        message.Show();
                        FriendInvited = "";
                        friends_status.Add(true);
                        friend_names.Add(fname + " " + ffamily);
                        set_friends_status();
                        removeinvited((int)r.FriendId);


                    }
                        
                    }
                
            }
            timer_answer.Stop();
        }
        void removeinvited(int frndId)
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var result = from p in db.invited where p.FriendId == frndId && p.suerId == myid select p;
                if (result.Count() > 0)
                {
                    foreach (var t in result)
                    {
                        db.invited.Remove(t);
                    }

                }
                db.SaveChanges();
            }
        }
        private void timer_friends_Tick(object sender, EventArgs e)
        {
            timer_friends.Interval = 10000;
            getInviteds();
        }

        private void timer_addfriend_Tick(object sender, EventArgs e)
        {
            timer_addfriend.Stop();
            if (answer == "Accept and add")
            {
                set_friends_status();

            }
        }

        private void chatroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            int userid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var res = from p in db.ConfrenceUsers where p.userId == userid select p;
            foreach(var item in res)
            {
                removeTrashes(item.confrenceId, item.userId);
            }
        }
        void removeTrashes(int confId,int userid)
        {
            var r = from p in db.ConfrenceUsers where p.confrenceId == confId select p;
            if (r.Count() == 1)
            {
                deleteConfrence(confId);
                db.ConfrenceUsers.RemoveRange(r);
            }
            else
            {
                foreach (var item in r)
                {
                    if (item.userId == userid)
                    {
                        db.ConfrenceUsers.Remove(item);

                    }
                }
            }
            db.SaveChanges();

        }
        void deleteConfrence(int conId)
        {

            var res = (from p in db.Conferences where p.Id == conId select p);
            if (res.Count() > 0)
            {
                db.Conferences.Remove(res.First());

            }
            db.SaveChanges();


        }
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // RichTextBox room = (RichTextBox)sender;
            
            
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int linefirst = richTextBox1.GetFirstCharIndexOfCurrentLine();
            if (richTextBox1.Text.Substring(linefirst, richTextBox1.Text.IndexOf("\n",linefirst)-linefirst).IndexOf("_") != -1&&
                richTextBox1.Text.Substring(linefirst, richTextBox1.Text.IndexOf("\n",linefirst)-linefirst).IndexOf(":") != -1)
            {
                richTextBox1.SelectionStart = linefirst;
                richTextBox1.SelectionLength = richTextBox1.Text.IndexOf(":", linefirst) - linefirst;
            }
            if (richTextBox1.SelectedText != "")
            {
                if (richTextBox1.SelectedText.IndexOf("_") != -1)
                {
                    string name = richTextBox1.SelectedText.Substring(richTextBox1.SelectedText.IndexOf("_") + 1);
                    string family = richTextBox1.SelectedText.Substring(0,richTextBox1.SelectedText.IndexOf("_"));
                    foreach(string item in password.openedforms)
                    {
                        string namef = item.Substring(0, item.IndexOf(" "));
                        string familyf = item.Substring(item.IndexOf(" ") + 1);
                        if (name == namef && familyf == family)
                        {
                            richTextBox1.DeselectAll();
                            return;
                        }
                    }
                    if (name != password.Name || family != password.Fimily)
                    {
                        password.openedforms.Add(name + " " + family);
                        Thread thread1 = new Thread(show_prv_window);
                        thread1.Start();
                    }
                    richTextBox1.DeselectAll();
                }
            }
        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
