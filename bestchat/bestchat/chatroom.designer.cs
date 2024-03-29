namespace totalchat
{
    partial class chatroom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatroom));
            this.friends_panel = new System.Windows.Forms.Panel();
            this.label_friends = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rooms_panel = new System.Windows.Forms.Panel();
            this.comboBox_cities = new System.Windows.Forms.ComboBox();
            this.comboBox_states = new System.Windows.Forms.ComboBox();
            this.comboBox_countries = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelQueue = new System.Windows.Forms.Label();
            this.panel_users = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer_thread = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer_bunish = new System.Windows.Forms.Timer(this.components);
            this.timer_answer = new System.Windows.Forms.Timer(this.components);
            this.timer_friends = new System.Windows.Forms.Timer(this.components);
            this.timer_addfriend = new System.Windows.Forms.Timer(this.components);
            this.friends_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rooms_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // friends_panel
            // 
            this.friends_panel.AutoScroll = true;
            this.friends_panel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.friends_panel.Controls.Add(this.label_friends);
            this.friends_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.friends_panel.Location = new System.Drawing.Point(0, 0);
            this.friends_panel.Name = "friends_panel";
            this.friends_panel.Size = new System.Drawing.Size(1013, 78);
            this.friends_panel.TabIndex = 0;
            this.friends_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.friends_panel_Paint);
            // 
            // label_friends
            // 
            this.label_friends.AutoSize = true;
            this.label_friends.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_friends.ForeColor = System.Drawing.Color.DarkRed;
            this.label_friends.Location = new System.Drawing.Point(3, 9);
            this.label_friends.Name = "label_friends";
            this.label_friends.Size = new System.Drawing.Size(73, 22);
            this.label_friends.TabIndex = 0;
            this.label_friends.Text = "Friends";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(937, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(66, 44);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::bestchat.Properties.Resources.flesh3;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(51, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 44);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::bestchat.Properties.Resources.add;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rooms_panel
            // 
            this.rooms_panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rooms_panel.Controls.Add(this.panel2);
            this.rooms_panel.Controls.Add(this.comboBox_cities);
            this.rooms_panel.Controls.Add(this.comboBox_states);
            this.rooms_panel.Controls.Add(this.comboBox_countries);
            this.rooms_panel.Controls.Add(this.button1);
            this.rooms_panel.Controls.Add(this.linkLabel1);
            this.rooms_panel.Controls.Add(this.button2);
            this.rooms_panel.Controls.Add(this.label3);
            this.rooms_panel.Controls.Add(this.label2);
            this.rooms_panel.Controls.Add(this.label1);
            this.rooms_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rooms_panel.Location = new System.Drawing.Point(0, 78);
            this.rooms_panel.Name = "rooms_panel";
            this.rooms_panel.Size = new System.Drawing.Size(1013, 521);
            this.rooms_panel.TabIndex = 1;
            // 
            // comboBox_cities
            // 
            this.comboBox_cities.FormattingEnabled = true;
            this.comboBox_cities.Location = new System.Drawing.Point(389, 24);
            this.comboBox_cities.Name = "comboBox_cities";
            this.comboBox_cities.Size = new System.Drawing.Size(121, 21);
            this.comboBox_cities.TabIndex = 12;
            this.comboBox_cities.SelectedValueChanged += new System.EventHandler(this.comboBox_cities_SelectedValueChanged);
            this.comboBox_cities.SizeChanged += new System.EventHandler(this.chatroom_SizeChanged);
            this.comboBox_cities.TextChanged += new System.EventHandler(this.comboBox_cities_TextChanged);
            // 
            // comboBox_states
            // 
            this.comboBox_states.FormattingEnabled = true;
            this.comboBox_states.Location = new System.Drawing.Point(557, 24);
            this.comboBox_states.Name = "comboBox_states";
            this.comboBox_states.Size = new System.Drawing.Size(121, 21);
            this.comboBox_states.TabIndex = 11;
            this.comboBox_states.TextUpdate += new System.EventHandler(this.comboBox_states_TextUpdate);
            this.comboBox_states.SelectedValueChanged += new System.EventHandler(this.comboBox_states_SelectedValueChanged);
            this.comboBox_states.SizeChanged += new System.EventHandler(this.chatroom_SizeChanged);
            // 
            // comboBox_countries
            // 
            this.comboBox_countries.FormattingEnabled = true;
            this.comboBox_countries.Location = new System.Drawing.Point(745, 24);
            this.comboBox_countries.Name = "comboBox_countries";
            this.comboBox_countries.Size = new System.Drawing.Size(121, 21);
            this.comboBox_countries.TabIndex = 10;
            this.comboBox_countries.Text = "Iran";
            this.comboBox_countries.SelectedValueChanged += new System.EventHandler(this.comboBox_countries_SelectedValueChanged);
            this.comboBox_countries.SizeChanged += new System.EventHandler(this.chatroom_SizeChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(146, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Enter roomposts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(291, 27);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 19);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Subjects";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Enter chatroom";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(516, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(684, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(872, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Country";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.labelQueue);
            this.panel1.Controls.Add(this.panel_users);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 421);
            this.panel1.TabIndex = 2;
            // 
            // labelQueue
            // 
            this.labelQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelQueue.AutoSize = true;
            this.labelQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelQueue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelQueue.Location = new System.Drawing.Point(4, 388);
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.Size = new System.Drawing.Size(0, 13);
            this.labelQueue.TabIndex = 3;
            // 
            // panel_users
            // 
            this.panel_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_users.AutoScroll = true;
            this.panel_users.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_users.BackColor = System.Drawing.Color.White;
            this.panel_users.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_users.Location = new System.Drawing.Point(885, 0);
            this.panel_users.Name = "panel_users";
            this.panel_users.Size = new System.Drawing.Size(129, 385);
            this.panel_users.TabIndex = 2;
            this.panel_users.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_users_MouseClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(886, 385);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            this.richTextBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDoubleClick);
            this.richTextBox1.MouseHover += new System.EventHandler(this.richTextBox1_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(926, 544);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 44);
            this.button3.TabIndex = 1;
            this.button3.Text = "&Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button3_MouseClick);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.DetectUrls = false;
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 544);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(917, 59);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            this.richTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox2_KeyDown);
            this.richTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox2_KeyPress);
            this.richTextBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox2_MouseDown);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer_thread
            // 
            this.timer_thread.Interval = 2000;
            this.timer_thread.Tick += new System.EventHandler(this.timer_thread_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 5000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer_bunish
            // 
            this.timer_bunish.Interval = 10000;
            this.timer_bunish.Tick += new System.EventHandler(this.timer_bunish_Tick);
            // 
            // timer_answer
            // 
            this.timer_answer.Interval = 10000;
            this.timer_answer.Tick += new System.EventHandler(this.timer_answer_Tick);
            // 
            // timer_friends
            // 
            this.timer_friends.Interval = 10000;
            this.timer_friends.Tick += new System.EventHandler(this.timer_friends_Tick);
            // 
            // timer_addfriend
            // 
            this.timer_addfriend.Interval = 5000;
            this.timer_addfriend.Tick += new System.EventHandler(this.timer_addfriend_Tick);
            // 
            // chatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1013, 599);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rooms_panel);
            this.Controls.Add(this.friends_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chatroom";
            this.Text = "chatroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatroom_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chatroom_FormClosed);
            this.Load += new System.EventHandler(this.chatroom_Load);
            this.SizeChanged += new System.EventHandler(this.chatroom_SizeChanged);
            this.friends_panel.ResumeLayout(false);
            this.friends_panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rooms_panel.ResumeLayout(false);
            this.rooms_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel friends_panel;
        private System.Windows.Forms.Panel rooms_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel_users;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label_friends;
        private System.Windows.Forms.Timer timer_thread;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_bunish;
        private System.Windows.Forms.ComboBox comboBox_states;
        private System.Windows.Forms.ComboBox comboBox_cities;
        private System.Windows.Forms.ComboBox comboBox_countries;
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_answer;
        private System.Windows.Forms.Timer timer_friends;
        private System.Windows.Forms.Timer timer_addfriend;
    }
}