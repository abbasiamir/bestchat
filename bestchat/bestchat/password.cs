using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Management;
using bestchat;
using System.Windows.Forms;
using System.Net;

namespace totalchat
{
    static class password
    {
        static public string pass = "";
        static public string Name = "";
        static public string Fimily = "";
        static public string language = "";
        static public string country = "";
        static public string Province = "";
        static public string city = "";
        static public string subject1 = "";
        static public string subject2 = "";
        static public string subject3 = "";
        static public string chat = "";
        static public int color;
        static public bool AddConfrenceOK = false;
        static public bool AcceptOK = false;
        static public decimal Timer_room=3;
        static public decimal Timer_friends=10;
        static public decimal Timer_private=3;
        static public int lastid = -1;
        static public int lastpid = -1;
        public static int userid = 0;
        static public ArrayList Offlines = new ArrayList();
        public static ArrayList Confrences = new ArrayList();
        public static ArrayList openedforms = new ArrayList();
        public static ArrayList ConfrenceThreads = new ArrayList();
        static ArrayList forbid = null;
        public static double version = 1.0;
        public static string farsidate(DateTime now)
        {
            PersianCalendar cal = new PersianCalendar();
            return (cal.GetYear(now).ToString("0000") + "/" + cal.GetMonth(now).ToString("00") + "/" + cal.GetDayOfMonth(now).ToString("00"));
        }
        static public string Translate(string word)
        {
            switch (word){
                case "piano":
                    return "پیانو";
                case "gitar electic":
                    return "گیتار الکتریک";
                case "gitar classic":
                    return "گیتار کلاسیک";
                case "violon":
                    return "ویولن";
                case "jaz":
                    return "جاز";
                case "floot":
                    return "فلوت";
                case"keyboard":
                    return "کیبورد";
                case"music":
                    return "موزیک";
                case"football":
                    return "فوتبال";
                case"sport":
                    return "ورزش";
                case"فوتبال":
                    return "Football";

                    
            }
            return word;
        }
        static public bool ValidateText(string text)
        {
            amirabbasi1Entities1 db = new amirabbasi1Entities1();
            text = text.ToLower();
            //string[] forbids = { "sex","سکس","fuck","lesbian","gay","xxx","tits","ass","slave","hot","babe","لزبین","پستان","کون","کس","کیر","گایید","pool","kun","koon","kir","penis","cock" };
            if (forbid == null)
            {
                forbid = new ArrayList();
                var r = from p in db.Immoral select p;
                foreach (var item in r)
                {
                    string word = item.word;
                    if (word.IndexOf(";") != -1)
                        word = word.Remove(word.IndexOf(";"));
                    forbid.Add(word);
                }
            }
           foreach (string t in forbid)
            {
                if (text.IndexOf(t,StringComparison.OrdinalIgnoreCase) != -1)
                {
                    bunish();
                    return false;
                }

            }
            return true;
        }
        static public string GetCpuId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_processor");
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["ProcessorID"].ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }
        static public int CompareDate(DateTime date1,DateTime date2)
        {
            if (date1.Year < date2.Year)
            {
                if (date2.Month < date1.Month)
                {
                    return (date2.Month-1)*31+(12-date1.Month)*30+date2.Day + 31 - date1.Day+(date2.Year-date1.Year-1)*365;
                }
                else
                {
                    return (date2.Month - date1.Month - 1) * 30 + date2.Day + 30 - date1.Day+(date2.Year - date1.Year - 1) * 365;
                }
            }
            else
            {
                if (date2.Month > date1.Month)
                {
                    return (date2.Month - date1.Month - 1) * 30 + date2.Day + 30 - date1.Day;
                }
                else
                {
                    return date2.Day - date1.Day;
                }
            }
           
        }
        public static void bunish()
        {
            int warnings = 0;
            int days = 0;
            string cpuid = password.GetCpuId();
            using (bestchat.amirabbasi1Entities1 db = new bestchat.amirabbasi1Entities1())
            {
                var res = from p in db.Machin where p.CpuID == cpuid select p;
                if (res.Count() > 0)
                {
                    res.First().WarningCount += 1;
                    res.First().WarningDate =now();
                    db.SaveChanges();
                    warnings =(int) res.First().WarningCount;
                }
                else
                {
                    Machin mchn = new Machin();
                    mchn.CpuID = password.GetCpuId();
                    mchn.WarningCount = 1;
                    mchn.WarningDate =now();
                    db.Machin.Add(mchn);
                    db.SaveChanges();
                    warnings = 1;
                }

            }
            switch (warnings)
            {
                case 1:
                    {
                        days = 1;
                        break;
                    }
                case 2:
                    {
                        days = 3;
                        break;
                    }
                case 3:
                    {
                        days = 7;
                        break;
                    }
                case 4:
                    {
                        days = 30;
                        break;
                    }
                case 5:
                    {
                        days = 1000000;
                        break;
                    }
            }
            if (days == 1000000)
            {
                messagBox message = new messagBox();
                if (password.language == "English")
                {
                    message.label1.Text = "you bunished from chat for ever!!!";
                }
                else
                {
                    message.label1.Text = "شما برای همیشه از چت اخراج شدید";
                    message.Text = "پیغام";
                }
                message.ShowDialog();
            }
            else {
                messagBox message = new messagBox();
                if (password.language == "English")
                    message.label1.Text = ("you bunished from chat for " + days + " day!!!");
                else {
                    message.label1.Text=(" شما بمدت" + days + " روز از چت اخراج شدید");
                    message.Text = "پیغام";
                }
                message.ShowDialog();
            }
            Application.Exit();
        }
        public static DateTime now()
        {
            try
            {
                using (var response =
                  WebRequest.Create("http://www.google.com").GetResponse())
                    //string todaysDates =  response.Headers["date"];
                    return DateTime.ParseExact(response.Headers["date"],
                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat,
                        DateTimeStyles.AssumeUniversal);
            }
            catch (WebException)
            {
                //MessageBox.Show("error");
                //return DateTime.Now; //In case something goes wrong.
                Application.Exit(); 
            }
            return DateTime.Now;
        }
        public  class Confrence
        {
            public int ConfrenceId;
            public List<int> userIds = new List<int>();
        }
        public static List<Confrence> confrenceUsers = new List<password.Confrence>();
    }
}
