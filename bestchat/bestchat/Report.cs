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
using System.Net.Mail;

namespace bestchat
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        amirabbasi1Entities1 db = new amirabbasi1Entities1();
        MailMessage message = new MailMessage();
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        string cpuId;
        messagBox mymessage = new messagBox();
        private void button_crash_Click(object sender, EventArgs e)
        {
            string text = richTextBox_crash.Text;
            if (text.Length > 500)
            {
                if (password.language == "English")
                {
                    mymessage.label1.Text=("text must not be more than 500 character");
                    
                }
                else
                {
                    mymessage.label1.Text=("متن نباید طولانی تر از 500 حرف باشد");
                   
                }
                mymessage.ShowDialog();
                return;
            }
            var result = from p in db.CrashReport where p.report ==text  select p;
            if (result.Count() == 0)
            {
                if (!checkLimit())
                {
                    richTextBox_crash.Text = "";
                    return;
                }
                try {
                    message.Subject = "گزارش خرابی";
                    message.Body = richTextBox_crash.Text;
                    server.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                CrashReport tbl = new CrashReport();
                tbl.report = richTextBox_crash.Text;
                db.SaveChanges();
                richTextBox_crash.Text = "";

                addemailCount();
            }
        }

        private void button_suspect_Click(object sender, EventArgs e)
        {
            var result = from p in db.unImmoral where p.word == textBox_suspect.Text select p;
            if (result.Count() == 0)
            {
                if (!checkLimit())
                {
                    textBox_suspect.Text = "";
                    return;
                }
                try {
                    message.Subject = "کلمات مشتبه";
                    message.Body = textBox_suspect.Text;
                    server.Send(message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                unImmoral tbl = new unImmoral();
                tbl.word = textBox_suspect.Text;
                db.SaveChanges();
                textBox_suspect.Text = "";
                addemailCount();
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            cpuId = password.GetCpuId();
            server.Credentials = new System.Net.NetworkCredential("amir.abbasi.hafshejani.96", "09137159425");
            message.To.Add("amir.abbasi.hafshejani@gmail.com");
            message.From = new MailAddress("amir.abbasi.hafshejani.96@gmail.com");
            server.EnableSsl = true;
            if (password.language == "فارسی")
            {
                this.Text = "گزارش";
                label_crash.Text = "گزارش خرابی";
                label_suspect.Text = "کلمات مشتبه";
                label_comment.Font = new Font("Arial", 8, FontStyle.Italic);
                label_comment.Text = "کلمات مشتبه کلماتی هستند که زیر مجموعه ای از کلمات خلاف اخلاق دارند ولی خلاف اخلاق نیستند.";
                button_crash.Text = "بفرست";
                button_suspect.Text = "بفرست";
                button1.Text = "بفرست";
                label1.Text = "کلمات خلاف اخلاق";
            }
        }
        public bool checkLimit()
        {
            var r = from p in db.Limits where p.cpuId == cpuId select p;
            if (r.Count() == 0)
            {
                Limits l = new Limits();
                l.cpuId = cpuId;
                l.emailLimit = 0;
                db.Limits.Add(l);
                db.SaveChanges();
            }
            else
            {
                if (r.First().emailLimit == 30)
                    return false;
              
               
            }
            return true;
        }

        public void addemailCount()
        {
            var r = from p in db.Limits where p.cpuId == cpuId select p;
            r.First().emailLimit = r.First().emailLimit + 1;
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkLimit())
            {
                textBox1.Text = "";
                return;
            }
            try {
                message.Subject = "کلمات خلاف اخلاق";
                message.Body = textBox1.Text;
                server.Send(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            addemailCount();
        }
    }
}
