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
    public partial class ChangPassword : Form
    {
        public ChangPassword()
        {
            InitializeComponent();
        }
        messagBox message = new messagBox();
        private void ChangPassword_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                this.Text = "تغییر رمز";
                textBox1.Text = "رمز قبلی";
                textBox2.Text = "رمز جدید";
                textBox3.Text = "تکرار رمز";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.UseSystemPasswordChar = true;
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
            textBox3.UseSystemPasswordChar = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Old Password" || textBox1.Text == "رمز قبلی" ||
                textBox2.Text == "" || textBox2.Text == "New Password" || textBox2.Text == "رمز جدید" ||
                textBox3.Text == "" || textBox3.Text == "Confirm Password" || textBox3.Text == "نکرار رمز")
            {

                if (password.language == "English")
                {
                    message.label1.Text = ("Please fill all of fields");
                }
                else
                    message.label1.Text = ("لطفا تمام گزینه ها را پر کنید");
                message.ShowDialog();
                return;

            }
            if (textBox2.Text != textBox3.Text)
            {
                if (password.language == "English")
                {
                    message.label1.Text=("Passwords not match");
                }
                else
                    message.label1.Text=("تکرار رمز اشتباه است");
                message.ShowDialog();
                return;
            }
            using(amirabbasi1Entities1 db=new amirabbasi1Entities1())
            {
                var result = from p in db.user where p.Name == password.Name && p.Family == password.Fimily && p.Password == textBox1.Text select p;
                if (result.Count() == 0)
                {
                    if (password.language == "English")
                    {
                        message.label1.Text=("Old Passwords not correct or not loged in");
                    }
                    else
                        message.label1.Text=(" رمز قبلی اشتباه است یا وارد نشده اید");
                    message.ShowDialog();
                    return;
                }
                else
                {
                    result.First().Password = textBox2.Text;
                    db.SaveChanges();
                    if (password.language == "English")
                    {
                        message.label1.Text=("Password successfuly changed");
                    }
                    else
                        message.label1.Text=("عملیات تغییر رمز با موفقیت خاتمه یافت");
                    message.ShowDialog();
                }
            }
        }
    }
}
