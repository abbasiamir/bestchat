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
using bestchat;

namespace bestchat
{
    public partial class Form_AddConference : Form
    {
        public Form_AddConference()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add();
        }
        void add()
        {
            string text = textBox1.Text;
            password.ValidateText(text);
            if (text == "نام کنفرانس" || text == "Confrence Name")
                return;
            var result = from p in db.Conferences where string.Equals(p.ConferenceRoomName , textBox1.Text)&& p.owner==(password.Fimily+"_"+password.Name) select p;
            if (result.Count() == 0)
            {
                Conferences tbl = new Conferences();
                tbl.ConferenceRoomName = textBox1.Text;
                tbl.owner = password.Fimily + "_" + password.Name;
                db.Conferences.Add(tbl);
                db.SaveChanges();
                password.AddConfrenceOK = true;
                password.Confrences.Add(textBox1.Text);
                this.Close();
            }
            else
            {
                //var r = from p in db.ConferenceChat where p.userName == password.Fimily + "_" + password.Name && p.ConferencId == result.First().Id select p;
                //db.ConferenceChat.RemoveRange(r);
                db.Conferences.Remove(result.First());
                db.SaveChanges();
                add();
            }
           }
        private void Form_AddConference_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                this.Text = "افزودن سالن کنفرانس";
                //label1.Text = "نام سالن کنفرانس";
                //textBox1.Location = new Point(textBox1.Location.X + 20, textBox1.Location.Y);
                //label1.Location = new Point(7, label1.Location.Y);
                button1.Text = "انجام";
                //button2.Text = "انصراف";
                textBox1.Text = "نام کنفرانس";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                add();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
