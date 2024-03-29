using bestchat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace totalchat
{
    public partial class Private_Form : Form
    {
        public Private_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text += "\n";
            send();
        }
        void bunish2()
        {
            string cpuid = password.GetCpuId();
            using (bestchat.amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var res = from p in db.Machin where p.CpuID == cpuid select p;
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

            }
            if (password.language == "English")
                MessageBox.Show("you bunished from chat for one day!!!");
            else
                MessageBox.Show("شما بمدت یک روز از چت اخراج شدید");

            Application.Exit();
        }
        int CurrentId = -1;

        void send()
        {
            if (!offlinemessage)
                IsonlineMessage();
            Isonline();
            amirabbasi1Entities1 db = new amirabbasi1Entities1();
            string text = richTextBox2.Text;
            if (text != ""&&text!="\n")
            {
                password.ValidateText(text);


                var r = (from p in db.@private where p.text == "" && p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_Name && p.to_Family == friend_Family select p).First();
                r.text = text;
                r.Color = password.color.ToString();
                db.SaveChanges();
                Isnew = true;


            }
            if (Isnew)
            {
                @private prv = new @private();
                prv.Name = password.Name;
                prv.Family = password.Fimily;
                prv.to_Family = friend_Family;
                prv.to_Name = friend_Name;
                prv.text = "";
                prv.Color = password.color.ToString();
                prv.Istyping = true;
                Isnew = false;
                db.@private.Add(prv);
                db.SaveChanges();
                if (offlinemessage)
                    password.Offlines.Add(prv.Id);
            }
            richTextBox2.Text = "";
            show();
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                send();
        }
        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            show();


        }
        bool offlinemessage = false;
        void IsonlineMessage()
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var result = from p in db.user where p.Name == friend_Name && p.Family == friend_Family && p.online == true select p;
                if (result.Count() == 0)
                {
                    messagBox message = new messagBox();
                    string text = "";
                    if (password.language == "English")
                        text = friend_Name + " " + friend_Family + " Is now offline messages go offlin box ";
                    else
                        text = " هم اکنون آفلاین است پیامها به صندوق پیام وصل میشود" + " " + friend_Name + " " + friend_Family;
                    offlinemessage = true;
                   message.label1.Text=(text);
                    message.ShowDialog();
                }
            }
        }
        void Isonline()
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var result = from p in db.user where p.Name == friend_Name && p.Family == friend_Family && p.online == true select p;
                if (result.Count() == 0)
                {
                    offlinemessage = true;
                }
            }
        }
        string typing_text;
        void settyping_text()
        {
            if (password.language == "English")
                typing_text = " Is typing";
            else
                typing_text = " در حال تایپ کردن است";
        }
        bool istyping()
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r = from p in db.@private where p.text == "" && p.Name == friend_Name && p.Family == friend_Family && p.to_Name == password.Name && p.to_Family == password.Fimily select p;
                if (r.Count() > 0)
                {
                    try
                    {
                        if (r.First().Istyping == true)
                        {

                            r.First().Istyping = false;
                            db.SaveChanges();
                            label1.Text = friend_Name + " " + friend_Family + typing_text;
                            return true;

                        }

                        else {
                            label1.Text = "";
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return false;
        }
        ArrayList printeds = new ArrayList();
        void show()
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r = from p in db.@private where ((p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_Name && p.to_Family == friend_Family) || (p.to_Name == password.Name && p.to_Family == password.Fimily && p.Name == friend_Name && p.Family == friend_Family)) && p.text != "" select p;
                bool isprinted = false;
                foreach (var res in r)
                {
                    isprinted = false;
                    foreach (int c in printeds)
                    {
                        if (c == res.Id)
                        {
                            isprinted = true;
                            break;
                        }
                    }
                    if (!isprinted)
                    {
                        printeds.Add(res.Id);

                        int len1 = 0;
                        string text1 = res.Family + "_" + res.Name + ": ";
                        //richTextBox1.Text += text1;
                        int end1 = text1.Length;
                        int len2 = end1;
                        string text2 = res.text;
                        int end2 = text2.Length;
                        text2 += "\n";
                        text2 = text2.Replace("\n\n", "\n");
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.SelectionLength = text1.Length;
                        richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Italic | FontStyle.Bold);
                        richTextBox1.SelectionColor = Color.DarkRed;
                        richTextBox1.AppendText(text1);
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.SelectionLength = text2.Length;
                        richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
                        richTextBox1.SelectionColor = ColorTranslator.FromWin32(Convert.ToInt32(res.Color));
                        richTextBox1.AppendText(text2);
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.ScrollToCaret();
                        //CurrentId = res.Id;
                    }
                }
            }
        }
        string friend_Name = "";
        string friend_Family = "";
        int freeId = -1;
        private void Private_Form_Load(object sender, EventArgs e)
        {
            if (this.Text.IndexOf("_") != -1)
            {
                friend_Name = this.Text.Substring(this.Text.IndexOf("_") + 1);
                friend_Family = this.Text.Substring(0, this.Text.IndexOf("_"));
            }
            else {
                friend_Family = this.Text.Substring(this.Text.IndexOf(" ") + 1);
                friend_Name = this.Text.Substring(0, this.Text.IndexOf(" "));
            }
            timer1.Interval = (int)password.Timer_private * 1000;
            amirabbasi1Entities1 db = new amirabbasi1Entities1();
            var res = from p in db.@private where p.text == "" && p.Name == friend_Name && p.Family == friend_Family && p.to_Name == password.Name && p.to_Family == password.Fimily select p;
            if (res.Count() > 0)
            {
                res.First().Istyping = false;
                db.SaveChanges();
            }
            var result = from p in db.@private where p.text == "" && p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_Name && p.to_Family == friend_Family select p;
            if (result.Count() > 0)
            {
                Isnew = false;
                result.First().Istyping = false;
                db.SaveChanges();
            }
            if (Isnew)
            {
                @private prv = new @private();
                prv.Name = password.Name;
                prv.Family = password.Fimily;
                prv.to_Family = friend_Family;
                prv.to_Name = friend_Name;
                prv.text = "";
                prv.Color = password.color.ToString();
                prv.Istyping = true;
                Isnew = false;
                db.@private.Add(prv);
                db.SaveChanges();
                Isonline();
                if (offlinemessage)
                    password.Offlines.Add(prv.Id);
                
            }
            bool thereIs = false;
            foreach(string f in password.openedforms)
            {
                if (f == password.Name + " " + password.Fimily)
                    thereIs = true;
            }
            if(!thereIs)
                password.openedforms.Add(password.Name + " " + password.Fimily);
            settyping_text();
            timer1.Start();
            timer_istyping.Start();
            show();
            
        }
        bool Isnew = true;
        int counttyped = 0;
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //if (richTextBox2.Text.Length == 1 || (richTextBox2.Text.Length > 0 && richTextBox2.Text[richTextBox2.Text.Length - 1] == ' '))
            //{
                using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
                {
                    if (!Isnew)
                    {
                        var r = from p in db.@private where p.text == "" && p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_Name && p.to_Family == friend_Family select p;
                        if (r.Count() > 0)
                        {
                            r.First().Istyping = true;
                            db.SaveChanges();
                        }
                    }
                }
            //}
        }

        private void Private_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var r = from p in db.@private where p.text == "" && p.Name == password.Name && p.Family == password.Fimily && p.to_Name == friend_Name && p.to_Family == friend_Family select p;
                if (r.Count() > 0)
                {
                    r.First().Istyping = false;
                    db.SaveChanges();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chatroom owner = new chatroom();
           // owner = (chatroom)this.Owner;
            owner.addfriend(this.Text);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tltip = new ToolTip();
            if (password.language == "English")
            {
                tltip.Show("Add friend", (PictureBox)sender);
            }
            else
            {
                tltip.Show("افزودن دوست", (PictureBox)sender);
            }
        }

        private void timer_istyping_Tick(object sender, EventArgs e)
        {
            istyping();
        }
    }
}
