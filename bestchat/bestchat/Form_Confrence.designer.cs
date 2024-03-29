namespace bestchat
{
    partial class Form_Confrence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Confrence));
            this.panel_chat = new System.Windows.Forms.Panel();
            this.richTextBox_chat = new System.Windows.Forms.RichTextBox();
            this.panel_users = new System.Windows.Forms.Panel();
            this.panel_send = new System.Windows.Forms.Panel();
            this.richTextBox_send = new System.Windows.Forms.RichTextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.timer_chat = new System.Windows.Forms.Timer(this.components);
            this.label_Queue = new System.Windows.Forms.Label();
            this.timer_istyping = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer_userlist = new System.Windows.Forms.Timer(this.components);
            this.panel_chat.SuspendLayout();
            this.panel_send.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_chat
            // 
            this.panel_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_chat.Controls.Add(this.richTextBox_chat);
            this.panel_chat.Location = new System.Drawing.Point(3, 12);
            this.panel_chat.Name = "panel_chat";
            this.panel_chat.Size = new System.Drawing.Size(397, 336);
            this.panel_chat.TabIndex = 0;
            // 
            // richTextBox_chat
            // 
            this.richTextBox_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_chat.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_chat.Name = "richTextBox_chat";
            this.richTextBox_chat.Size = new System.Drawing.Size(397, 336);
            this.richTextBox_chat.TabIndex = 0;
            this.richTextBox_chat.Text = "";
            // 
            // panel_users
            // 
            this.panel_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_users.BackColor = System.Drawing.Color.White;
            this.panel_users.Location = new System.Drawing.Point(423, 12);
            this.panel_users.Name = "panel_users";
            this.panel_users.Size = new System.Drawing.Size(136, 336);
            this.panel_users.TabIndex = 1;
            // 
            // panel_send
            // 
            this.panel_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_send.Controls.Add(this.richTextBox_send);
            this.panel_send.Location = new System.Drawing.Point(3, 369);
            this.panel_send.Name = "panel_send";
            this.panel_send.Size = new System.Drawing.Size(498, 55);
            this.panel_send.TabIndex = 2;
            // 
            // richTextBox_send
            // 
            this.richTextBox_send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_send.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.richTextBox_send.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_send.Name = "richTextBox_send";
            this.richTextBox_send.Size = new System.Drawing.Size(498, 55);
            this.richTextBox_send.TabIndex = 0;
            this.richTextBox_send.Text = "";
            this.richTextBox_send.TextChanged += new System.EventHandler(this.richTextBox_send_TextChanged);
            this.richTextBox_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox_send_KeyPress);
            // 
            // button_Send
            // 
            this.button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button_Send.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Send.Location = new System.Drawing.Point(507, 366);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(61, 58);
            this.button_Send.TabIndex = 3;
            this.button_Send.Text = "&Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // timer_chat
            // 
            this.timer_chat.Interval = 1000;
            this.timer_chat.Tick += new System.EventHandler(this.timer_chat_Tick);
            // 
            // label_Queue
            // 
            this.label_Queue.AutoSize = true;
            this.label_Queue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label_Queue.ForeColor = System.Drawing.Color.Blue;
            this.label_Queue.Location = new System.Drawing.Point(0, 353);
            this.label_Queue.Name = "label_Queue";
            this.label_Queue.Size = new System.Drawing.Size(0, 13);
            this.label_Queue.TabIndex = 4;
            // 
            // timer_istyping
            // 
            this.timer_istyping.Interval = 500;
            this.timer_istyping.Tick += new System.EventHandler(this.timer_istyping_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // timer_userlist
            // 
            this.timer_userlist.Interval = 3000;
            this.timer_userlist.Tick += new System.EventHandler(this.timer_userlist_Tick);
            // 
            // Form_Confrence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(571, 425);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Queue);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.panel_send);
            this.Controls.Add(this.panel_users);
            this.Controls.Add(this.panel_chat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Confrence";
            this.Text = "Form_Confrence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Confrence_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Confrence_FormClosed);
            this.Load += new System.EventHandler(this.Form_Confrence_Load);
            this.panel_chat.ResumeLayout(false);
            this.panel_send.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_chat;
        private System.Windows.Forms.RichTextBox richTextBox_chat;
        private System.Windows.Forms.Panel panel_users;
        private System.Windows.Forms.Panel panel_send;
        private System.Windows.Forms.RichTextBox richTextBox_send;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Timer timer_chat;
        private System.Windows.Forms.Label label_Queue;
        private System.Windows.Forms.Timer timer_istyping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_userlist;
    }
}