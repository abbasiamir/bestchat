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
    public partial class Music : Form
    {
        public Music()
        {
            InitializeComponent();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
                password.subject2 = "keyboard";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password.subject2 = "";
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                password.subject2 = "piano";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                password.subject2 = "gitar classic";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                password.subject2 = "gitar electric";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                password.subject2 = "violon";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
                password.subject2 = "jaz";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
                password.subject2 = "floot";
        }

        private void Music_Load(object sender, EventArgs e)
        {
            password.subject2 = "piano";
            if (password.language == "فارسی")
            {
                RadioButton r1 = new RadioButton();
                r1.Text = "تار";
                r1.CheckedChanged += r1_CheckedChanged;
                r1.Location = new Point(214, 115);
                this.Controls.Add(r1);
                RadioButton r2 = new RadioButton();
                r2.Text = "سه تار";
                r2.CheckedChanged += r2_CheckedChanged;
                r2.Location = new Point(214, 68);
                this.Controls.Add(r2);
                RadioButton r3 = new RadioButton();
                r3.Text = "کمانچه";
                r3.CheckedChanged += r3_CheckedChanged;
                r3.Location = new Point(309, 27);
                this.Controls.Add(r3);
                RadioButton r4 = new RadioButton();
                r4.Text = " نی";
                r4.CheckedChanged += r4_CheckedChanged;
                r4.Location = new Point(309, 68);
                this.Controls.Add(r4);
                this.Width +=220;
                button1.Location = new Point(button1.Location.X+115, button1.Location.Y);
                button2.Location = new Point(button2.Location.X+115, button2.Location.Y);
                string[] saz = { "دف", "سنتور", "تنبک" };
                int x = 309;
                int y = 68;
                foreach (string s in saz)
                {
                    y += 41;
                    if(y>115){
                        y = 27;
                        x += 97;
                    }
                    RadioButton r = new RadioButton();
                    r.Text =s;
                    r.CheckedChanged += r_CheckedChanged;
                    r.Location = new Point(x,y);
                    this.Controls.Add(r);
                }
            }
        }

        void r_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r = (RadioButton)sender;
            if (r.Checked == true)
                password.subject2 = r.Text;
        }

        void r4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r = (RadioButton)sender;
            if (r.Checked == true)
                password.subject2 = "نی";
        }

        void r3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r = (RadioButton)sender;
            if (r.Checked == true)
                password.subject2 = "کمانچه";
        }

        void r2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r = (RadioButton)sender;
            if (r.Checked == true)
                password.subject2 = "سه تار";
        }

        void r1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r=(RadioButton)sender;
            if (r.Checked == true)
                password.subject2 = "تار";
        }
    }
}
