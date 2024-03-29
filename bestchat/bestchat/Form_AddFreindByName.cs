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
    public partial class Form_AddFreindByName : Form
    {
        public Form_AddFreindByName()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        messagBox message = new messagBox();
        private void button1_Click(object sender, EventArgs e)
        {
            string namep = textBox1.Text;
            if (namep.IndexOf("_") == -1)
            {
                if (password.language == "English")
                {
                    message.label1.Text=("please use _ between name and family");
                    
                }
                else
                {
                    message.label1.Text=("لطفا بین نام و فامیل از _ استفاده کنید");
                   
                }
                message.ShowDialog();
                return;
            }
            string family = namep.Substring(0, namep.IndexOf("_"));
            string name = namep.Substring(namep.IndexOf("_") + 1);
            var n = from p in db.user where p.Name == name && p.Family == family select p;
            if (n.Count() > 0)
            {
                chatroom owner = new chatroom();
                owner = (chatroom)this.Owner;
                owner.addfriend(textBox1.Text);
            }
            else
            {
                if (password.language == "English")
                    message.label1.Text=("user not found. use family+_+name");
                else
                    message.label1.Text=("کاربر یافت نشد از این فرمت استفاده کنید :family+_+name ");
                message.ShowDialog();
            }
            this.Close(); 
        }
        void addfriend()
        {
            string fiendname = textBox1.Text;
            if (fiendname == "" || fiendname == "Friend Name" || fiendname == "نام کاربر")
                return;
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                //ContextMenuStrip menu = new ContextMenuStrip();
                //menu = (ContextMenuStrip)sender;
                string Friand_Name = fiendname.Substring(fiendname.IndexOf("_") + 1);
                string Friend_Family = fiendname.Substring(0, fiendname.IndexOf("_"));
                if (Friand_Name == password.Name && Friend_Family == password.Fimily)
                {
                    if (password.language == "English")
                        message.label1.Text=("its you!!!");
                    else
                        message.label1.Text=("شما نمی توانید خودتان را به لیست دوستان اضافه کنید");
                    message.ShowDialog();
                    return;
                }
                var r = from p in db.friends join q in db.user on p.FriendId equals q.Id where q.Name == Friand_Name && q.Family == Friend_Family join s in db.user on p.UserId equals s.Id where s.Name == password.Name && s.Family == password.Fimily select s;
                if (r.Count() > 0)
                {
                    if (password.language == "English")
                        message.label1.Text=("this user already is in your friends list");
                    else
                        message.label1.Text=("این کاربر هم اکنون در لیست دوستان شما وجود دارد");
                    message.ShowDialog();
                    return;
                }
                friends frnd = new friends();
                frnd.UserId = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
                var result = from p in db.user where p.Name == Friand_Name && p.Family == Friend_Family select p;
                if (result.Count() == 0)
                {
                    if (password.language == "English")
                        message.label1.Text=("user name is not coorect");
                    else
                        message.label1.Text=("نام کاربری اشتباه است");
                    message.ShowDialog();
                    return;
                }
                else
                    frnd.FriendId = result.First().Id;
                db.friends.Add(frnd);
                db.SaveChanges();

            }
            if (password.language == "English")
               message.label1.Text=("user added to your friends list");
            else
                message.label1.Text=("کاربر به لیست دوستان شما اضافه شد");
            message.ShowDialog();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Friend Name" || textBox1.Text == "نام کاربر")
                textBox1.Text = "";
        }

        private void Form_AddFreindByName_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                this.Text = "افزودن به لیست دوستان";
                textBox1.Text = "نام کاربر";
                button1.Text = "انجام";
            }
        }
    }
}
