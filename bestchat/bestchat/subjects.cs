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
    public partial class subjects : Form
    {
        public subjects()
        {
            InitializeComponent();
        }

        private void music_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (music_radio.Checked)
                password.subject1 = "Music";
            else
            {
                password.subject1 = "";
                password.subject2 = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.subject1 == "Music" || password.subject1 == "موسیقی")
            {
                Form_sub_subjects form = new Form_sub_subjects();
                form.Text = password.subject1;
                form.ShowDialog();
            }
        }
        void addevents()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Text != "sub"&&c.Text!="OK"&&c.Text!="Cancel")
                {
                    RadioButton r = new RadioButton();
                    r = (RadioButton) c;
                    r.CheckedChanged += r_CheckedChanged;
                }
                else if (c.Text == "sub")
                {
                    Button b = new Button();
                    b = (Button)c;
                    if (password.language == "فارسی")
                       c.Text = "زیر مجموعه";
                    //c.Click += c_Click;
                }
            }
        }

        void c_Click(object sender, EventArgs e)
        {
            RadioButton r=new RadioButton();
            r=(RadioButton)sender;
            Form_sub_subjects form = new Form_sub_subjects();
            form.Text = r.Text;
            form.ShowDialog();
        }

        void r_CheckedChanged(object sender, EventArgs e)

        {
            RadioButton r=new RadioButton();
            r=(RadioButton)sender;
            if(r.Checked==true)
                password.subject1 = r.Text;
        }
        private void sport_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (sport_radio.Checked)
                password.subject1 = "Sport";
            else
            {
                password.subject1 = "";
                password.subject2 = "";
            }
        }

        private void subjects_Load(object sender, EventArgs e)
        {
            music_radio.Checked = false;
            addevents();
            if (password.language == "فارسی")
            {
                string[] s = { "موسیقی", "ورزش", "علوم", "کامپیوتر", "موتور سیکلت", "خودرو", "هنر", "هواپیما", "موبایل", "ازدواج", "سیاست", "اقتصاد", "آب وهوا", "مسافرت", "کتاب", "بورس","رمان" ,"طنز","سرگرمی", "دوستیابی_پسرها"};
                int i = s.Count()-1;
                foreach (Control c in this.Controls)
                {
                    if (c.Name.IndexOf("radio") != -1)
                    {
                        c.Text = s[i--];
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            password.subject1 = "";
            this.Close();
        }

        private void sub_sport_Click(object sender, EventArgs e)
        {

            
            if (password.subject1 == "Sport" || password.subject1 == "ورزش")
            {
                Form_sub_subjects form = new Form_sub_subjects();
                form.Text = password.subject1;
                form.ShowDialog();
            }
        }

        private void sience_sub_Click(object sender, EventArgs e)
        {
            if (password.subject1 == "Science" || password.subject1 == "علوم")
            {
                Form_sub_subjects form = new Form_sub_subjects();
                form.Text = password.subject1;
                form.ShowDialog();
            }
        }

        private void computer_sub_Click(object sender, EventArgs e)
        {
            if (password.subject1 == "Computer" || password.subject1 == "کامپیوتر")
            {
                Form_sub_subjects form = new Form_sub_subjects();
                form.Text = password.subject1;
                form.ShowDialog();
            }
        }

        private void art_sub_Click(object sender, EventArgs e)
        {
            if (password.subject1 == "Art" || password.subject1 == "هنر")
            {
                Form_sub_subjects form = new Form_sub_subjects();
                form.Text = password.subject1;
                form.ShowDialog();
            }
        }

        private void sience_radio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
