using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using totalchat;

namespace bestchat
{
    public partial class Form_Invite_friend : Form
    {
        public Form_Invite_friend()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        public string name = "";
        public string answer = "";
        string firstname;
        string family;
        private void Form_Invite_friend_Load(object sender, EventArgs e)
        {
            label1.Text = name + " Invite you to become friend";
            if (password.language != "English")
            {
                this.Text = "دعوت به دوستی";
                button1.Text = "رد";
                button2.Text = "قبول";
                button3.Text = "قبول و اضافه کن";
                label1.Text = string.Format("به شما پیشنهاد دوستی میدهد آیا می پذیرید؟ {0  }", name);

            }
            int space = (this.Width - label1.Width) / 2;
            label1.Location = new Point(space, label1.Location.Y);
            family = name.Substring(0, name.IndexOf("_"));
            firstname = name.Substring(name.IndexOf("_") + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var id = (from p in db.user where p.Name == firstname && p.Family == family select p).First().Id;
            var myid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            declined dec = new declined();
            dec.userId = id;
            dec.friendId = myid;
            db.declined.Add(dec);
            db.SaveChanges();
            var result = from p in db.invited where p.suerId == id && p.FriendId == myid select p;
            if (result.Count() > 0)
            {
                result.First().result = "Declined";
                db.SaveChanges();
            }
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = (from p in db.user where p.Name == firstname && p.Family == family select p).First().Id;
            var myid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var res = from p in db.friends where p.UserId == id && p.FriendId == myid select p;
            if (res.Count() == 0)
            {
                friends fr = new friends();
                fr.UserId = id;
                fr.FriendId = myid;
                db.friends.Add(fr);
                db.SaveChanges();
            }
            friends fr2 = new friends();
            var result=from p in db.invited where p.suerId==id&&p.FriendId==myid select p;
            if (result.Count() > 0)
            {
                result.First().result = "Accepted";
                db.SaveChanges();
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = (from p in db.user where p.Name == firstname && p.Family == family select p).First().Id;
            var myid = (from p in db.user where p.Name == password.Name && p.Family == password.Fimily select p).First().Id;
            var res = from p in db.friends where p.UserId == id && p.FriendId == myid select p;
            if (res.Count() == 0)
            {
                friends fr = new friends();
                fr.UserId = id;
                fr.FriendId = myid;
                db.friends.Add(fr);
                db.SaveChanges();
            }
            var res2 = from p in db.friends where p.UserId == myid && p.FriendId == id select p;
            if (res2.Count() == 0)
            {
                friends fr2 = new friends();
                fr2.UserId = myid;
                fr2.FriendId = id;
                db.friends.Add(fr2);
                db.SaveChanges();
            }
            chatroom owner = new chatroom();
            owner=(chatroom)this.Owner;
            owner.answer = "Accepted and add";
            var result = from p in db.invited where p.suerId == id && p.FriendId == myid select p;
            if (result.Count() > 0)
            {
                result.First().result = "Accepted and add";
                db.SaveChanges();
            }
           
            this.Close();
        }
    }
}
