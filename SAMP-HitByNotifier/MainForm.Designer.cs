namespace SAMP_HitByNotifier
{
    partial class MainForm
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
            this.rtb_Display = new System.Windows.Forms.RichTextBox();
            this.btn_Link = new System.Windows.Forms.Button();
            this.button_Color = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Spam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Color = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Messages = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_Display
            // 
            this.rtb_Display.Location = new System.Drawing.Point(12, 12);
            this.rtb_Display.Name = "rtb_Display";
            this.rtb_Display.Size = new System.Drawing.Size(525, 96);
            this.rtb_Display.TabIndex = 0;
            this.rtb_Display.Text = "";
            // 
            // btn_Link
            // 
            this.btn_Link.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Link.Location = new System.Drawing.Point(462, 114);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(75, 31);
            this.btn_Link.TabIndex = 1;
            this.btn_Link.Text = "LINK";
            this.btn_Link.UseVisualStyleBackColor = true;
            this.btn_Link.Click += new System.EventHandler(this.btn_Link_Click);
            // 
            // button_Color
            // 
            this.button_Color.Location = new System.Drawing.Point(49, 19);
            this.button_Color.Name = "button_Color";
            this.button_Color.Size = new System.Drawing.Size(115, 26);
            this.button_Color.TabIndex = 2;
            this.button_Color.UseVisualStyleBackColor = true;
            this.button_Color.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Spam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_Color);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Color);
            this.groupBox1.Location = new System.Drawing.Point(12, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "seconds";
            // 
            // tb_Spam
            // 
            this.tb_Spam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Spam.Location = new System.Drawing.Point(102, 53);
            this.tb_Spam.MaxLength = 2;
            this.tb_Spam.Name = "tb_Spam";
            this.tb_Spam.Size = new System.Drawing.Size(30, 20);
            this.tb_Spam.TabIndex = 6;
            this.tb_Spam.TextChanged += new System.EventHandler(this.tb_Spam_TextChanged);
            this.tb_Spam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Spam_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "AntiSpam Interval:";
            // 
            // tb_Color
            // 
            this.tb_Color.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Color.Location = new System.Drawing.Point(171, 24);
            this.tb_Color.MaxLength = 6;
            this.tb_Color.Name = "tb_Color";
            this.tb_Color.Size = new System.Drawing.Size(100, 20);
            this.tb_Color.TabIndex = 4;
            this.tb_Color.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color: ";
            // 
            // button_Messages
            // 
            this.button_Messages.Location = new System.Drawing.Point(462, 167);
            this.button_Messages.Name = "button_Messages";
            this.button_Messages.Size = new System.Drawing.Size(75, 23);
            this.button_Messages.TabIndex = 4;
            this.button_Messages.Text = "Messages";
            this.button_Messages.UseVisualStyleBackColor = true;
            this.button_Messages.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 246);
            this.Controls.Add(this.button_Messages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Link);
            this.Controls.Add(this.rtb_Display);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SAMP-HitByNotifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Display;
        private System.Windows.Forms.Button btn_Link;
        private System.Windows.Forms.Button button_Color;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Spam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Messages;
    }
}

