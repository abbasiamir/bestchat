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
    public partial class Form_Invite : Form
    {
        public Form_Invite()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        string confName = "";
        private void Form_Invite_Load(object sender, EventArgs e)
        {
            var result = from p in db.Conferences where p.ConferenceRoomName == this.Text select p;
            string Inviter = result.First().owner;
            if (password.language == "English")
            {
                label1.Text = "You have invited to confrence " + this.Text + " by " + Inviter;
                this.Text.Insert(0, "Invite to Confrence ");
            }
            else
            {
                char ch = this.Text[0];
                confName = this.Text;
                if (ch < 65 || (ch > 90 && ch < 97) || ch > 122)
                {
                    label1.Text = " به کنفرانس " + this.Text + "دعوت شده اید " + Inviter + " شماتوسط ";
                    this.Text = string.Format("{0} {1}", "دعوت به کنفرانس ", this.Text);
                }
                else {
                    label1.Text = "دعوت شده اید " + this.Text + " به کنفرانس " + Inviter + " شماتوسط ";
                    this.Text = string.Format("{0} {1}", this.Text, "دعوت به کنفرانس ");
                }
                button1.Text = "قبول";
                button2.Text = "رد";
                
            }
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password.AcceptOK = true;
            password.Confrences.Add(confName);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password.AcceptOK = false;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Resize(object sender, EventArgs e)
        {
            int left = (this.Width - label1.Width) / 2;
            label1.Location = new Point(left, label1.Location.Y);
        }
    }
}
