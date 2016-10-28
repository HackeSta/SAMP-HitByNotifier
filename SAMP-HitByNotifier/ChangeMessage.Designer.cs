namespace SAMP_HitByNotifier
{
    partial class ChangeMessage
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
            this.dd_weaponid = new System.Windows.Forms.ComboBox();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.button_messageSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dd_weaponid
            // 
            this.dd_weaponid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd_weaponid.FormattingEnabled = true;
            this.dd_weaponid.Location = new System.Drawing.Point(39, 45);
            this.dd_weaponid.Name = "dd_weaponid";
            this.dd_weaponid.Size = new System.Drawing.Size(150, 21);
            this.dd_weaponid.TabIndex = 0;
            this.dd_weaponid.SelectedIndexChanged += new System.EventHandler(this.dd_weaponid_SelectedIndexChanged);
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(195, 45);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(297, 20);
            this.tb_Message.TabIndex = 1;
            // 
            // button_messageSet
            // 
            this.button_messageSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_messageSet.Location = new System.Drawing.Point(417, 71);
            this.button_messageSet.Name = "button_messageSet";
            this.button_messageSet.Size = new System.Drawing.Size(75, 38);
            this.button_messageSet.TabIndex = 2;
            this.button_messageSet.Text = "SET";
            this.button_messageSet.UseVisualStyleBackColor = true;
            this.button_messageSet.Click += new System.EventHandler(this.button_messageSet_Click);
            // 
            // ChangeMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 139);
            this.Controls.Add(this.button_messageSet);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.dd_weaponid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeMessage";
            this.Text = "Change Weapon Messages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dd_weaponid;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Button button_messageSet;
    }
}