using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace totalchat
{
    public partial class Form_sub_subjects : Form
    {
        public Form_sub_subjects()
        {
            InitializeComponent();
        }

        private void Form_sub_subjects_Load(object sender, EventArgs e)
        {
            string[] sprten = { "Fottball", "Valyball", "Basketball", "Swiming", "Track and Field", "Airubic", "Bodybuilding", "Handball", "Teniss", "Badminton", "Ship", "weightlifting", "Shooting", "Gymnastics", "ragby", "Basball", "Chess", "Hokky", "Horseriding", "Car Racing", "Olympic", "Worldcups" };
            string[]  sprtfa={"فوتبال","والیبال","بسکتبال","شنا","دو و ومیدانی","ایروبیک","بدنسازی","هندبال","تنیس","بدمینتون","کشتی","وزنه برداری","تیر اندازی","ژیمناستیک","راگبی","بیسبال","شطرنج","هاکی","اسب سواری","ماشسن رانی","المپیک","جام های جهانی"};
            string[]  compen={ "Windows", "Linux", "MacOs", "c#", "Delphi", "Java", "Vb", "PHP", "VisualStudio", "ASP", "Jomla", "Wordpress", "Drupbal", "Antivirus", "Hardware", "Game", "Graphic&Animation", "Network", "Internet", "Microsoft", "Google", "Oracle" };
            string[] Sincfa = { "کامپیوتر", "فیزیک", "شیمی", "برق", "مکانیک", "متالوژی", "عمران", "صنایع", "نجوم", "هوافضا", "پزشکی", "دندانپزشکی", "متافیزیک", "فلسفه", "نساجی", "معماری" };
            string[] sincen = { "Computer", "Physics", "Chemistry", "Electric", "Mechanics", "Metalogy", "Building", "Crafts", "Stars", "Aerospace", "Medical", "Dental", "Metaphysics", "Philosophy", "Textile", "Architecture"};
            string[]  artfa={"نقاشی","خوشنویسی","تاتر","نگارگری","معرق کاری","مجسمه سازی"};
            string[] arten = { "Painting", "Theater", "Sculpture" };
            string[] musicen = { "Piano", "ClassicGitar", "ElectricGitar", "Violon", "Floot", "Keyboard", "Jaz" };
            string[] musicfa = { "پیانو", "گیتار کلاسیک", "گیتار الکتریک", "ویولن", "فلوت", "کیبورد", "جاز", "کمانچه", "سنتور", "تار", "سه تار", "نی", "دف" };
            ArrayList subs2=new ArrayList();
            switch (this.Text)
            {
                case ("Sport"):
                    {
                        if (password.language == "English")
                            foreach(string s in sprten)
                                subs2.Add(s);
                        else
                           foreach(string s in sprtfa)
                                subs2.Add(s);
                        break;
                    }
                case ("ورزش"):
                    {
                        if (password.language == "English")
                            foreach (string s in sprten)
                                subs2.Add(s);
                        else
                            foreach (string s in sprtfa)
                                subs2.Add(s);
                        break;
                    }
                case"Computer":
                    {
                         foreach(string s in compen)
                                subs2.Add(s);
                        break;
                    }
                case "کامپیوتر":
                    {
                        foreach (string s in compen)
                            subs2.Add(s);
                        break;
                    }
                case "Science":{
                    if (password.language == "English")
                            foreach(string s in sincen)
                                subs2.Add(s);
                        else
                           foreach(string s in Sincfa)
                                subs2.Add(s);
                        break;
                }
                case "علوم":
                    {
                        if (password.language == "English")
                            foreach (string s in sincen)
                                subs2.Add(s);
                        else
                            foreach (string s in Sincfa)
                                subs2.Add(s);
                        break;
                    }
                case "Art":{
                    if (password.language == "English")
                            foreach(string s in arten)
                                subs2.Add(s);
                        else
                           foreach(string s in artfa)
                                subs2.Add(s);
                        break;
                }
                case "هنر":
                    {
                        if (password.language == "English")
                            foreach (string s in arten)
                                subs2.Add(s);
                        else
                            foreach (string s in artfa)
                                subs2.Add(s);
                        break;
                    }
                case "Music":
                    {
                        if (password.language == "English")
                            foreach (string s in musicen)
                                subs2.Add(s);
                        else
                            foreach (string s in musicfa)
                                subs2.Add(s);
                        break;
                    }
                case "موسیقی":
                    {
                        if (password.language == "English")
                            foreach (string s in musicen)
                                subs2.Add(s);
                        else
                            foreach (string s in musicfa)
                                subs2.Add(s);
                        break;
                    }
            }
            int x=29;int y=37;
           foreach(string subject in subs2){

               RadioButton r=new RadioButton();
               r.Text=subject;
               r.Location=new Point(x,y);
               y+=40;
               if(y>200){
                   y=37;
                   x+=150;
                   this.Width+=150;
                   button1.Location=new Point(button1.Location.X+75,button1.Location.Y);
                   button2.Location=new Point(button2.Location.X+75,button2.Location.Y);
               }
               r.CheckedChanged+=r_CheckedChanged;
               this.Controls.Add(r);
           }
            
        }

        void r_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = new RadioButton();
            r = (RadioButton)sender;
            if(r.Checked==true)
                password.subject2 =password.Translate( r.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password.subject2 = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
