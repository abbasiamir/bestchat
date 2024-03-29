using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using totalchat;
using bestchat.Properties;

namespace bestchat
{
    public partial class messagBox : Form
    {
        public messagBox()
        {
            InitializeComponent();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            int space = (this.Width - label1.Width) / 2;
            label1.Location=new Point(space,label1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void messagBox_Shown(object sender, EventArgs e)
        {
            int space = (this.Width - label1.Width) / 2;
            label1.Location = new Point(space, label1.Location.Y);
            space = (this.Width - button1.Width) / 2;
            button1.Location = new Point(space, button1.Location.Y);
            
        }

        private void messagBox_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            if (password.language != "English")
                this.Text = "پیغام";
            SoundPlayer player = new SoundPlayer(Resources.Windows_Notify_System_Generic);
            player.Play();
        }
    }
}
