namespace bestchat
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.label_crash = new System.Windows.Forms.Label();
            this.richTextBox_crash = new System.Windows.Forms.RichTextBox();
            this.button_crash = new System.Windows.Forms.Button();
            this.label_suspect = new System.Windows.Forms.Label();
            this.textBox_suspect = new System.Windows.Forms.TextBox();
            this.button_suspect = new System.Windows.Forms.Button();
            this.label_comment = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_crash
            // 
            this.label_crash.AutoSize = true;
            this.label_crash.Location = new System.Drawing.Point(31, 35);
            this.label_crash.Name = "label_crash";
            this.label_crash.Size = new System.Drawing.Size(64, 13);
            this.label_crash.TabIndex = 0;
            this.label_crash.Text = "Crash report";
            // 
            // richTextBox_crash
            // 
            this.richTextBox_crash.Location = new System.Drawing.Point(34, 51);
            this.richTextBox_crash.Name = "richTextBox_crash";
            this.richTextBox_crash.Size = new System.Drawing.Size(356, 53);
            this.richTextBox_crash.TabIndex = 1;
            this.richTextBox_crash.Text = "";
            // 
            // button_crash
            // 
            this.button_crash.Location = new System.Drawing.Point(156, 110);
            this.button_crash.Name = "button_crash";
            this.button_crash.Size = new System.Drawing.Size(75, 23);
            this.button_crash.TabIndex = 2;
            this.button_crash.Text = "&Send";
            this.button_crash.UseVisualStyleBackColor = true;
            this.button_crash.Click += new System.EventHandler(this.button_crash_Click);
            // 
            // label_suspect
            // 
            this.label_suspect.AutoSize = true;
            this.label_suspect.Location = new System.Drawing.Point(31, 154);
            this.label_suspect.Name = "label_suspect";
            this.label_suspect.Size = new System.Drawing.Size(72, 13);
            this.label_suspect.TabIndex = 3;
            this.label_suspect.Text = "Suspect word";
            // 
            // textBox_suspect
            // 
            this.textBox_suspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox_suspect.Location = new System.Drawing.Point(144, 149);
            this.textBox_suspect.Name = "textBox_suspect";
            this.textBox_suspect.Size = new System.Drawing.Size(131, 23);
            this.textBox_suspect.TabIndex = 4;
            // 
            // button_suspect
            // 
            this.button_suspect.Location = new System.Drawing.Point(315, 149);
            this.button_suspect.Name = "button_suspect";
            this.button_suspect.Size = new System.Drawing.Size(75, 23);
            this.button_suspect.TabIndex = 5;
            this.button_suspect.Text = "&Send";
            this.button_suspect.UseVisualStyleBackColor = true;
            this.button_suspect.Click += new System.EventHandler(this.button_suspect_Click);
            // 
            // label_comment
            // 
            this.label_comment.AutoSize = true;
            this.label_comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label_comment.ForeColor = System.Drawing.Color.DarkRed;
            this.label_comment.Location = new System.Drawing.Point(31, 201);
            this.label_comment.Name = "label_comment";
            this.label_comment.Size = new System.Drawing.Size(365, 13);
            this.label_comment.TabIndex = 6;
            this.label_comment.Text = "Suspect word is a word that contain immoral subsequence but is not immoral";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox1.Location = new System.Drawing.Point(144, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 23);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Immoral word";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(106, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "email:amir.abbasi.hafshejani@gmail.com";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(415, 309);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_comment);
            this.Controls.Add(this.button_suspect);
            this.Controls.Add(this.textBox_suspect);
            this.Controls.Add(this.label_suspect);
            this.Controls.Add(this.button_crash);
            this.Controls.Add(this.richTextBox_crash);
            this.Controls.Add(this.label_crash);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_crash;
        private System.Windows.Forms.RichTextBox richTextBox_crash;
        private System.Windows.Forms.Button button_crash;
        private System.Windows.Forms.Label label_suspect;
        private System.Windows.Forms.TextBox textBox_suspect;
        private System.Windows.Forms.Button button_suspect;
        private System.Windows.Forms.Label label_comment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}