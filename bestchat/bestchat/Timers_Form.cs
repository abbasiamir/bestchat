using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using totalchat;

namespace bestchat
{
    public partial class Timers_Form : Form
    {
        public Timers_Form()
        {
            InitializeComponent();
        }

        private void Timers_Form_Load(object sender, EventArgs e)
        {
            if (password.language == "فارسی")
            {
                this.Text = "تایمرها";
                label1.Text = "سرعت چک کردن رسیدن پیامهای چت روم(کمتر سریع تر) ";
                label2.Text = "بازه چک کردن ورود دوستان لیست افراد ورسیدن پیام خصوصی";
                label3.Text = "سرعت چک کردن رسیدن چیام ها در پنجره خصوصی";
                label4.Text = "توجه :";
                label5.Text = "اگر برنامه شماکند است شما میتوانید با افزایش این مقادیر";
                label6.Text = "گیر زدن برنامه را مرتفع کنیدمقادیر کمتر بازه چک کردن کوتاهتر";
                label7.Text = "برحسب ثانیه";
            }
            string path= Application.StartupPath + "/Timers.txt";
            if (File.Exists(path))
            {
                string content=File.ReadAllText(path);
                string[] nums = content.Split(' ');
                numericUpDown1.Value = Convert.ToInt32(nums[0]);
                numericUpDown2.Value = Convert.ToInt32(nums[1]);
                numericUpDown3.Value = Convert.ToInt32(nums[2]);
            }
        }

        private void Timers_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/Timers.txt";
            string content=numericUpDown1.Value.ToString()+" "+numericUpDown2.Value.ToString()+" "+numericUpDown3.Value.ToString();
             File.WriteAllText(path, content, Encoding.Unicode);
            password.Timer_room = numericUpDown1.Value;
            password.Timer_friends = numericUpDown2.Value;
            password.Timer_private = numericUpDown3.Value;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 3;
            numericUpDown2.Value = 10;
            numericUpDown3.Value = 3;
        }
    }
}
