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

namespace bestchat
{
    public partial class Form_Invite_ByName : Form
    {
        public Form_Invite_ByName()
        {
            InitializeComponent();
        }
        public string type = "";
        public string confrenceName = "";
        public string userName = "";
        public int confrenceId = -1;
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "User Name" && textBox1.Text != "نام کاربر" && textBox1.Text.IndexOf("_") != -1)
            {
                string name = textBox1.Text.Substring(textBox1.Text.IndexOf("_") + 1);
                string family = textBox1.Text.Substring(0, textBox1.Text.IndexOf("_"));
                var r = (from p in db.user where p.Name == name && p.Family == family select p);
                if (r.Count() == 0)
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                    {
                        message.label1.Text = "user couldnt be found";
                    }
                    else
                    {
                        message.label1.Text = "کاربر یافت نشد";
                    }
                    message.ShowDialog();
                    return;
                }
                if (r.First().online == false)
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                    {
                        message.label1.Text = "User is offline";
                    }
                    else
                    {
                        message.label1.Text = "کاربر آفلاین است";
                    }
                    message.ShowDialog();
                    return;
                }
            }
            else
                return;
            
            switch (type)
            {
                case "confrence":
                    {
                        Invite_to_confrence(confrenceId);
                        break;
                    }
            }
            
            this.Close();
        }
        void Invite_to_confrence(int id)
        {
            string user_toInvite = textBox1.Text;
            confrenceName = comboBox1.Text;
            if (confrenceName == "Confrence Name" || confrenceName == "نام کنفرانس")
                return;
            if (user_toInvite == "User Name")
                return;
            var result1 = from p in db.user where user_toInvite == p.Family + "_" + p.Name select p;
            if (result1.Count()==0)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text=("User name is not correct");
                else
                    message.label1.Text=("نام کاربری وجود ندارد");
                message.ShowDialog();
                return;
            }
            //int confrenceId = //(from p in db.Conferences where p.ConferenceRoomName==confrenceName select p).First().Id;
            var result = from p in db.ConferenceChat where user_toInvite == p.userName && p.text == "" && p.ConferencId == id select p;
            if (result.Count() == 0)
            {
                ConferenceChat tbl = new ConferenceChat();
                tbl.userName = user_toInvite;
                tbl.ConferencId = id;
                tbl.text = "";
                db.ConferenceChat.Add(tbl);
                db.SaveChanges();
            }
        }

        private void Form_Invite_ByName_Load(object sender, EventArgs e)
        {
            this.Text = "Invite to confrence ";
            if (password.language == "فارسی")
            {
                textBox1.Text = "نام کاربر";
                this.Text = string.Format("دعوت به کنفرانس");
                //comboBox1.Text = "نام کنفرانس";
                button1.Text = "انجام";
            }
            foreach (string s in password.Confrences)
                comboBox1.Items.Add(s);
            if (userName != "")
                textBox1.Text = userName;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="User Name"||textBox1.Text=="نام کاربر")
                textBox1.Text = "";
        }
    }
}
