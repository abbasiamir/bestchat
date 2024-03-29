using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bestchat;
using totalchat;
using System.Threading;

namespace bestchat
{
    public partial class Form_Confrence : Form
    {
        public Form_Confrence()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        int lastId = 0;
        public int confrenceId = -1;
        private void button_Send_Click(object sender, EventArgs e)
        {
            send();
        }
        void send()
        {
            if (richTextBox_send.Text == "" || richTextBox_send.Text == "\n")
                return;
            password.ValidateText(richTextBox_send.Text);
            richTextBox_send.Text += "\n";
            /* var result = from p in db.ConferenceChat join q in db.Conferences on p.ConferencId equals q.Id where q.ConferenceRoomName == this.Text && p.text == "ready#" select p;
             if (result.Count() > 0)
             {
                 result.First().text = richTextBox_send.Text;
                 db.SaveChanges();
             }
             else
             {*/
            ConferenceChat tbl = new ConferenceChat();
            tbl.text = richTextBox_send.Text;
            tbl.userName = password.Fimily + "_" + password.Name;
            tbl.ConferencId = confrenceId;// (from p in db.Conferences where p.ConferenceRoomName == this.Text select p).First().Id;
            tbl.color = password.color.ToString();
            db.ConferenceChat.Add(tbl);
            db.SaveChanges();

            richTextBox_send.Text = "";
        }
        private void Form_Confrence_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                button_Send.Text = "بفرست";
            }
            showall();
            userlist();
            timer_chat.Start();
            timer_istyping.Start();
        }

        private void timer_chat_Tick(object sender, EventArgs e)
        {
            showChats();
        }

        void userlist()
        {
            var R = from p in db.ConferenceChat join q in db.Conferences on p.ConferencId equals q.Id where p.ConferencId == confrenceId && q.ConferenceRoomName == this.Text && p.text == "#" group p by p.userName into group1 select group1.OrderBy(f => f.userName).FirstOrDefault();
            /*if (R.Count() == 0)
            {
                var R2 = from p in db.Conferences where p.ConferenceRoomName == this.Text select p;
                int y1 = 0;
                int count1 = panel_users.Controls.Count;
                int i1 = 0;
                if (i1 >= count1)
                {
                    Label us = new Label();
                    us.Size = new System.Drawing.Size(200, 15);
                    us.Text = R2.First().owner;
                    us.ForeColor = Color.Blue;
                    us.Location = new Point(0, y1);
                    panel_users.Controls.Add(us);
                }
                else
                    panel_users.Controls[i1].Text = (R2.First().owner);

                i1++;
                y1 += 17;
            }*/
            int y = 0;
            int count = panel_users.Controls.Count;
            int i = 0;
            foreach (var u in R)
            {

                if (i >= count)
                {
                    Label us = new Label();
                    us.Size = new System.Drawing.Size(200, 15);
                    us.Text = u.userName;
                    us.ForeColor = Color.Blue;
                    us.Location = new Point(0, y);
                    panel_users.Controls.Add(us);
                }
                else
                    panel_users.Controls[i].Text = (u.userName);

                i++;
                y += 17;



            }
            for (int j = i; j < panel_users.Controls.Count; j++)
            {
                panel_users.Controls.RemoveAt(j);
            }
        }
        void showChats()
        {
            var result = from p in db.ConferenceChat join q in db.Conferences on p.ConferencId equals q.Id where q.Id == confrenceId && q.ConferenceRoomName == this.Text && p.Id > lastId && p.text != "" && p.text != "#" select p;
            int chatcount = result.Count();
            if (chatcount > 0)
            {
                chatcount -= 1;
                string text1 = result.First().userName + ": ";
                richTextBox_chat.SelectionStart = richTextBox_chat.Text.Length;
                richTextBox_chat.SelectionLength = text1.Length;
                richTextBox_chat.SelectionFont = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                richTextBox_chat.SelectionColor = Color.DarkRed;
                richTextBox_chat.AppendText(text1);
                richTextBox_chat.SelectionColor = richTextBox_chat.ForeColor;
                richTextBox_chat.SelectionFont = richTextBox_chat.Font;
                string text2 = result.First().text;
                int end2 = text2.Length;
                text2 = text2.Replace("\n\n", "\n");
                richTextBox_chat.SelectionStart = richTextBox_chat.Text.Length;
                richTextBox_chat.SelectionLength = text2.Length;
                richTextBox_chat.SelectionFont = new Font("Arial", 18, FontStyle.Regular);
                richTextBox_chat.SelectionColor = ColorTranslator.FromWin32(Convert.ToInt32(result.First().color));
                richTextBox_chat.AppendText(text2);
                richTextBox_chat.SelectionColor = richTextBox_chat.ForeColor;
                richTextBox_chat.SelectionFont = richTextBox_chat.Font;
                richTextBox_chat.ScrollToCaret();
                lastId = result.First().Id;
                /*if (password.language == "English")
                    label_Queue.Text = chatcount.ToString() + " Messages in queue";
                else
                    label_Queue.Text = chatcount.ToString() + " پیام های در صف انتظار";*/
            }
            //if (chatcount == 0)
                //label_Queue.Text = "";
        }
        void showall()
        {
            var result = from p in db.ConferenceChat join q in db.Conferences on p.ConferencId equals q.Id where q.Id == confrenceId && q.ConferenceRoomName == this.Text && p.text != "" && p.text != "#" select p;
            int chatcount = result.Count();
            if (chatcount > 0)
            {
                foreach (var r in result)
                {
                    //chatcount -= 1;
                    string text1 = r.userName + ": ";
                    richTextBox_chat.SelectionStart = richTextBox_chat.Text.Length;
                    richTextBox_chat.SelectionLength = text1.Length;
                    richTextBox_chat.SelectionFont = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                    richTextBox_chat.SelectionColor = Color.DarkRed;
                    richTextBox_chat.AppendText(text1);
                    richTextBox_chat.SelectionColor = richTextBox_chat.ForeColor;
                    richTextBox_chat.SelectionFont = richTextBox_chat.Font;
                    string text2 = r.text;
                    int end2 = text2.Length;
                    text2 = text2.Replace("\n\n", "\n");
                    richTextBox_chat.SelectionStart = richTextBox_chat.Text.Length;
                    richTextBox_chat.SelectionLength = text2.Length;
                    richTextBox_chat.SelectionFont = new Font("Arial", 18, FontStyle.Regular);
                    richTextBox_chat.SelectionColor = ColorTranslator.FromWin32(Convert.ToInt32(result.First().color));
                    richTextBox_chat.AppendText(text2);
                    richTextBox_chat.SelectionColor = richTextBox_chat.ForeColor;
                    richTextBox_chat.SelectionFont = richTextBox_chat.Font;
                    richTextBox_chat.ScrollToCaret();
                    lastId = r.Id;
                }
            }

        }

        private void Form_Confrence_FormClosing(object sender, FormClosingEventArgs e)
        {

            // var res1 = from p in db.ConferenceChat join q in db.Conferences on p.ConferencId equals q.Id where q.ConferenceRoomName == this.Text && p.text == "#" select p;                             
            //int id = res.First().Id;
            //var res3 = from p in db.ConferenceChat join q in res on p.ConferencId equals res.First().Id select p;
            //var res = from p in db.ConferenceChat where  p.ConferencId == id && p.text == "#" select p;
            //var res2 = from p in db.ConferenceChat where p.userName == password.Fimily + "_" + password.Name && p.ConferencId == id && p.text == "#" select p;


            /*if (res1.Count() > 0)
            {
                var result = (from p in db.Conferences where p.ConferenceRoomName == this.Text select p).First();
                db.Conferences.Remove(result);
                db.SaveChanges();
                return;
            }*/
            //db.ConferenceChat.RemoveRange(res3);
            //db.ConferenceChat.Remove(res2.First());
            //db.SaveChanges();


        }

        private void richTextBox_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                send();
                return;
            }
            int id = confrenceId;// (from p in db.Conferences where p.ConferenceRoomName == this.Text select p).First().Id;
            var r = from p in db.ConferenceChat where p.ConferencId == id && p.text == "#" && p.userName == (password.Fimily + "_" + password.Name) select p;
            if (r.Count() > 0)
            {
                foreach (var item in r)
                {
                    db.ConferenceChat.Remove(item);
                    //db.SaveChanges();
                    ConferenceChat c = new ConferenceChat();
                    c.ConferencId = id;
                    c.text = "#";
                    c.userName = password.Fimily + "_" + password.Name;
                    c.Istyping = true;
                    db.ConferenceChat.Add(c);

                }
                db.SaveChanges();
            }

        }

        private void richTextBox_send_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_istyping_Tick(object sender, EventArgs e)
        {
            label1.Text = "";
            int id = confrenceId;// (from p in db.Conferences where p.ConferenceRoomName == this.Text select p).First().Id;
            var r = from p in db.ConferenceChat where p.ConferencId == id && p.text == "#" && p.Istyping == true && p.userName != (password.Fimily + "_" + password.Name) select p;
            if (r.Count() > 0)
            {
                foreach (var item in r)
                {
                    string messag = "";
                    if (password.language == "English")
                        messag = item.userName + "is typing  ";
                    else
                        messag = " در حال تایپ کردن است " + item.userName + "  ";
                    label1.Text += messag;
                    label1.Refresh();
                    item.Istyping = false;
                }
                db.SaveChanges();
            }
        }

        private void Form_Confrence_FormClosed(object sender, FormClosedEventArgs e)
        {
            int userid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var r = from p in db.ConfrenceUsers where p.confrenceId == confrenceId select p;
            if (r.Count() == 1)
            {
                deleteConfrence();
                db.ConfrenceUsers.RemoveRange(r);
            }
            else
            {
                foreach(var item in r)
                {
                    if (item.userId == userid)
                    {
                        db.ConfrenceUsers.Remove(item);
                       
                    }
                }
            }
            db.SaveChanges();
            /*chatroom chat = new chatroom();
            for (int i = 0; i < chat.Invited_confrences.Count; i++)
            {
                if ((string)chat.Invited_confrences[i] == this.Text)
                    chat.Invited_confrences.RemoveAt(i);
            }*/
            for (int i = 0; i < password.Confrences.Count; i++)
            {
                if ((string)password.Confrences[i] == this.Text)
                    password.Confrences.RemoveAt(i);
            }
        }
        void deleteConfrence()
        {
                         
            var res = (from p in db.Conferences where p.Id == confrenceId  select p);
            if (res.Count() > 0)
            {
                db.Conferences.Remove(res.First());
                
            }
            db.SaveChanges();


        }

        private void timer_userlist_Tick(object sender, EventArgs e)
        {
            userlist();
        }
    }
}
