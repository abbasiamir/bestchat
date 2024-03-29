using bestchat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace totalchat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       private void Form2_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/language";
            string text="";
            if (File.Exists(path))
            {
               StreamReader str=new StreamReader(path);
               text=str.ReadToEnd();
            }
            if (text=="English"||text=="")
            {
                this.Text = "Registration";
                label1.Text = "Please retype your password";
                label1.Location=new Point(62,27);
                button1.Text = "OK";
                button2.Text = "Cancel";
            }
            else
            {
                this.Text = "ثبت نام";
                label1.Text = "لطفا رمز عبور را دوباره وارد کنید";
                label1.Location = new Point(57, 27);
                button1.Text = "انجام";
                button2.Text = "انصراف";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        messagBox message = new messagBox();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (button1.Text == "OK")
                    message.label1.Text = ("Please retype password");
                else
                    message.label1.Text = ("لطفا پسورد را وارد کنید");
                message.ShowDialog();
                return;
            }
            if (textBox1.Text != password.pass)
            {
                if (button1.Text == "OK")
                    message.label1.Text = ("passwords dont match");
                else
                    message.label1.Text = ("تکرار رمز عبور اشتباه است");
                message.ShowDialog();
                return;
            }

            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {

                string cpuId = password.GetCpuId();
                var res = from p in db.Limits where p.cpuId == cpuId select p;
                if (res.Count() == 0)
                {
                    Limits i = new Limits();
                    i.cpuId = cpuId;
                    i.userLimit = 1;
                    db.Limits.Add(i);
                    db.SaveChanges();
                }
                else
                {
                    if (res.First().userLimit == 20)
                        return;
                    res.First().userLimit = res.First().userLimit + 1;
                    db.SaveChanges();
                }
                bestchat.user u = new bestchat.user();
                u.Name = password.Name;
                u.Family = password.Fimily;
                u.Password = password.pass;
                u.online = false;
                db.user.Add(u);
                db.SaveChanges();
            }
            if (button1.Text == "OK")
                message.label1.Text = ("user successfuly registered");
            else
                message.label1.Text = ("کاربر با موفقیت ثبت شد");

            message.ShowDialog();
            this.Close();

        }
    }
}
