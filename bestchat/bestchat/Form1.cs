using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using bestchat;
//using bestchat.Properties;
using System.Threading;
using bestchat.Properties;

namespace totalchat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //amirabbasi1Entities1 db = new amirabbasi1Entities1();
        messagBox message = new messagBox();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                int ch = Convert.ToInt32(textBox1.Text[i]);
                if (ch < 65 || (ch > 90 && ch < 97) || ch > 122)
                {
                    if (password.language == "English")
                    {
                        message.label1.Text=("English characters please");
                        
                    }
                    else {
                       message.label1.Text=("لطفا نام را به لاتین وارد کنید");
                        
                    }
                    message.ShowDialog();
                    textBox1.Text = "";
                    return;
                }
            }

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Name" || textBox1.Text == "نام")
            {
                if (button1.Text == "Enter")
                    message.label1.Text=("Please input name");
                else
                    message.label1.Text=("لطفا نام را وارد کنید");
                message.ShowDialog();
                return;
            }
            if (textBox2.Text == "" || textBox2.Text == "Family" || textBox2.Text == "نام خانوادگی")
            {
                if (button1.Text == "Enter")
                    message.label1.Text=("Please input family");
                else
                    message.label1.Text=("لطفا نام خانوادگی را وارد کنید");
                message.ShowDialog();
                return;
            }
            if (textBox3.Text == "" || textBox3.Text == "Password" || textBox3.Text == "رمز عبور")
            {
                if (button1.Text == "Enter")
                    message.label1.Text=("Please input password");
                else
                    message.label1.Text=("لطفا رمز عبور را وارد کنید");
                message.ShowDialog();
                return;
            }
            password.ValidateText(textBox1.Text);
            password.ValidateText(textBox2.Text);  
             
                
            password.pass = textBox3.Text;
            password.Name = textBox1.Text;
            password.Fimily = textBox2.Text;
            using (bestchat.amirabbasi1Entities1 db = new amirabbasi1Entities1())
            {
                var result = from p in db.user select p;
                foreach (var r in result)
                {
                    if (r.Name == textBox1.Text && r.Family == textBox1.Text)
                    {
                        if (button1.Text == "OK")
                           message.label1.Text=("user alrady exists");
                        else
                            message.label1.Text=("این کاربر ثبت شده است");
                        message.ShowDialog();
                        return;
                    }
                }
                if (password.Name.IndexOf("_") != -1 || password.Fimily.IndexOf("_") != -1)
                {
                    messagBox message = new messagBox();
                    if (password.language == "English")
                    {
                        message.label1.Text = "you cant use _ in name or family";
                    }
                    else
                    {
                        message.label1.Text = "شما نمی توانید از _ در نام یا فامیل استفاده کنید";
                        message.Text = "پیغام";
                    }
                    message.ShowDialog();
                    return;
                }
                if (password.Name.Length + password.Fimily.Length > 20)
                {
                    if (password.language == "English")
                    {
                        message.label1.Text=("the name+family is more than 20 character");
                    }
                    else
                    {
                        message.label1.Text=("نام + فامیل طولانی تر از 20 کاراکتر است");
                    }
                    message.ShowDialog();
                    return;
                }
            }
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/language";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter stw = File.AppendText(path);
            stw.Write("English");
            stw.Close();
            password.language = "English";
            ChangMainformLanguage("English");
        }

        private void فارسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/language";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter stw = File.AppendText(path);
            stw.Write("فارسی");
            stw.Close();
            password.language = "فارسی";
            ChangMainformLanguage("فارسی");
        }
        void ChangMainformLanguage(string language)
        {
            if (language == "فارسی")
            {
                menu1.Items[0].Text = "&زبان";
                menu1.Items[1].Text = "&عملیات";
                reportToolStripMenuItem.Text = "&گزارش";
                changPasswordToolStripMenuItem.Text = "تغییر رمز";
                //timersToolStripMenuItem.Text = "تایمرها";
                textBox1.Text = "Name";
                textBox2.Text = "Family";
                textBox3.Text = "رمز عبور";
                button1.Text = "ورود";
                button2.Text = "ثبت نام";
            }
            else if (language == "English")
            {
                menu1.Items[0].Text = "&Language";
                menu1.Items[1].Text = "&Action";
                reportToolStripMenuItem.Text = "&Report";
                changPasswordToolStripMenuItem.Text = "ChangPassword";
                //timersToolStripMenuItem.Text = "Timers";
                textBox1.Text = "Name";
                textBox2.Text = "Family";
                textBox3.Text = "Password";
                button1.Text = "Enter";
                button2.Text = "Register";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string timerpath = Application.StartupPath + "/Timers.txt";
            if(File.Exists(timerpath))
            {
                string content=File.ReadAllText(timerpath);
                string[] nums = content.Split(' ');
                password.Timer_room = Convert.ToInt32(nums[0]);
                password.Timer_friends = Convert.ToInt32(nums[1]);
                password.Timer_private = Convert.ToInt32(nums[2]);
            }
            string path = Application.StartupPath + "/language";
            string text = "";
            if (File.Exists(path))
            {
                StreamReader str = new StreamReader(path);
                text = str.ReadToEnd();
            }
            if (text == "English" || text == "")
            {
                ChangMainformLanguage("English");
                password.language = "English";
            }
            else
            {
                ChangMainformLanguage("فارسی");
                password.language = "فارسی";
            }
            
            using(bestchat.amirabbasi1Entities1 db=new bestchat.amirabbasi1Entities1())
            {
                var r = (from p in db.version select p).First();
                if ((float)r.version1 > password.version)
                {
                    if (password.language == "English")
                       message.label1.Text=("newer version of this application is available in " + r.address);
                    else
                        message.label1.Text=("موجود است " + r.address+ " نسخه جدید این نرم افزار در سایت");
                    message.ShowDialog();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            login();
           
            
        }
        private void onFrameChanged(object o , EventArgs e)
        {
            this.Invalidate();
        }
        static bool loadpicvisible = true;
        static bool prv_loadpicvisible = true;
        delegate void makevisibility();
        System.Threading.Thread thread1 = new System.Threading.Thread(new System.Threading.ThreadStart(showload));
        static loding lodform = new loding();
        public static void showload()
        {
           
            setloading();
        }
        static int choice = -1;
        static void makerand()
        {
            Random rnd = new Random();
            choice= rnd.Next(0,3);
        }
        static void setloading()
        {
            Image image=new Bitmap(Resources.loading);
            makerand();
            switch (choice)
            {
                case 0:
                    {
                        image = new Bitmap(bestchat.Properties.Resources.loading);
                        break;
                    }
                case 1:
                    {
                        image = new Bitmap(bestchat.Properties.Resources.abi, new Size(500, 500));
                        break;
                    }
                case 2:
                    {
                        image = new Bitmap(Resources.loadingAzul);
                        break;
                    }
            }
            Size size = new Size(image.Width, image.Height);
            
            lodform.Size = size;
            pic.Size = size;
            pic.Image = image;
            lodform.Controls.Add(pic);
            thread2 = new Thread(loadpicoff);
            thread2.Start();
            lodform.ShowDialog();
           
            
            
         }
        static Thread thread2 = new Thread(loadpicoff);
       static PictureBox pic = new PictureBox();
        delegate void picdelegate(bool onoff);
        static void onoff(bool onoff)
        {
            if (onoff) pic.Visible = true;
            else pic.Visible = false; ;
        }
        public static IAsyncResult result;
        static void loadpicoff()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (prv_loadpicvisible = !loadpicvisible)
                {
                    result = lodform.BeginInvoke(new picdelegate(onoff), loadpicvisible);
                    prv_loadpicvisible = loadpicvisible;
                }
            }
        }
        void login()
        {
           FormCollection c = Application.OpenForms;
            foreach (Form ctrl in c)
            {
                if (ctrl.Name == "chatroom")
                {
                    return;
                }
            }
           
            makevisibility delegat = new makevisibility(setloading);
            using (amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                if (textBox1.Text == "" || textBox1.Text == "Name" || textBox1.Text == "نام")
                {
                    if (button1.Text == "Enter")
                        message.label1.Text=("Please input name");
                    else
                        message.label1.Text=("لطفا نام را وارد کنید");
                    message.ShowDialog();
                    return;
                }
                if (textBox2.Text == "" || textBox2.Text == "Family" || textBox2.Text == "نام خانوادگی")
                {
                    if (button1.Text == "Enter")
                        message.label1.Text=("Please input family");
                    else
                       message.label1.Text=("لطفا نام خانوادگی را وارد کنید");
                    message.ShowDialog();
                    return;
                }
                if (textBox3.Text == "" || textBox3.Text == "Password" || textBox3.Text == "رمز عبور")
                {
                    if (button1.Text == "Enter")
                       message.label1.Text=("Please input password");
                    else
                        message.label1.Text=("لطفا رمز عبور را وارد کنید");
                    message.ShowDialog();
                    return;
                }
                thread1 = new Thread(showload);
               thread1.Start();
               
                password.pass = textBox3.Text;
                password.Name = textBox1.Text;
                password.Fimily = textBox2.Text;

                var r = from p in db.user where p.Name == password.Name && p.Family == password.Fimily && p.Password == password.pass select p;
                //IQueryable<user> r = Queries.getUser(db, password.Name, password.Fimily, password.pass);
                if (r.Count() == 0)
                {
                    loadpicvisible = false;
                    if (password.language == "English")
                    {
                        message.label1.Text=("Login failed");
                    }
                    else
                    {
                        message.label1.Text=("اطلاعات کاربری نادرست می باشد");

                    }
                    message.ShowDialog();
                    textBox1.Text = "Name";
                    textBox2.Text = "Family";
                    textBox3.Text = "Password";
                    return;
                }
                else
                {
                    loadpicvisible = false;
                    if (r.First().online == true)
                    {
                        
                        if (password.language == "English")
                            message.label1.Text=("you have been logined from else where or improperly shutdown");
                        else
                            message.label1.Text=(" شما در جای دیگری لاگین کرده اید یا خروج تامناسب داشته اید");
                        message.ShowDialog();
                        loadpicvisible = true;
                    }
                   
                    r.First().online = true;
                    db.SaveChanges();
                    chatroom form = new chatroom();
                    form.Show();

                }
                loadpicvisible = false;
                thread2.Abort();
                thread2 = null;
                if (thread1 != null)
                {
                    thread1.Abort();
                    thread1 = null;
                }
            }
            this.Visible = false;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                int ch = Convert.ToInt32(textBox2.Text[i]);
                if (ch < 65 || (ch > 90 && ch < 97) || ch > 122)
                {
                    if (password.language == "English")
                    {
                       message.label1.Text=("English characters please");
                        
                    }
                    else
                    {
                        message.label1.Text=("لطفا نام را به لاتین وارد کنید");
                        
                    }
                    message.ShowDialog();
                    textBox2.Text = "";
                    return;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                login();
            }
        }
        bool animated = false;
        bool start = false;
        Bitmap image = new Bitmap(Resources._10);
        void AnimateImage()
        {
            if (!animated)
            {
                ImageAnimator.Animate(image, new EventHandler(this.onFrameChanged));
                animated = true;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (start)
            {
                AnimateImage();
                ImageAnimator.UpdateFrames();
                Graphics hdc = Graphics.FromHwnd(IntPtr.Zero);
                hdc.DrawImage(image, this.Size.Width / 2 - 100, this.Size.Height / 2 - 100);
            }
        }
        public void startdraw()
        {
           
                AnimateImage();
                ImageAnimator.UpdateFrames();
                Graphics hdc = Graphics.FromHwnd(IntPtr.Zero);
                hdc.DrawImage(image, this.Size.Width / 2 - 100, this.Size.Height / 2 - 100);
          
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void changPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangPassword form = new ChangPassword();
            form.ShowDialog();
        }

        private void timersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timers_Form form = new Timers_Form();
            form.ShowDialog();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report form = new Report();
            form.ShowDialog();
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Visible=false;
        }*/
    }
}
   

