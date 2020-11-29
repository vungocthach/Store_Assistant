namespace StoreAssitant
{
    partial class SignUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.txb_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_Pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxB_IdentityPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_Phone = new System.Windows.Forms.TextBox();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.cbx_Sex = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(405, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // txb_Name
            // 
            this.txb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Name.Location = new System.Drawing.Point(402, 39);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(281, 27);
            this.txb_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(405, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txb_Pass
            // 
            this.txb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Pass.Location = new System.Drawing.Point(404, 181);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.Size = new System.Drawing.Size(281, 27);
            this.txb_Pass.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Orange;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(405, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xác nhận mật khẩu:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TxB_IdentityPass
            // 
            this.TxB_IdentityPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.TxB_IdentityPass.Location = new System.Drawing.Point(404, 250);
            this.TxB_IdentityPass.Name = "TxB_IdentityPass";
            this.TxB_IdentityPass.PasswordChar = '*';
            this.TxB_IdentityPass.Size = new System.Drawing.Size(281, 27);
            this.TxB_IdentityPass.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Orange;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(405, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày sinh :";
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateTimeBirth.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateTimeBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBirth.Location = new System.Drawing.Point(404, 320);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(105, 27);
            this.dateTimeBirth.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(560, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Giới tính:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Orange;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(400, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "SĐT";
            // 
            // txb_Phone
            // 
            this.txb_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Phone.Location = new System.Drawing.Point(403, 384);
            this.txb_Phone.Name = "txb_Phone";
            this.txb_Phone.Size = new System.Drawing.Size(281, 27);
            this.txb_Phone.TabIndex = 11;
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btn_SignUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_SignUp.Location = new System.Drawing.Point(402, 428);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(281, 33);
            this.btn_SignUp.TabIndex = 14;
            this.btn_SignUp.Text = "Đăng kí";
            this.btn_SignUp.UseVisualStyleBackColor = false;
            // 
            // cbx_Sex
            // 
            this.cbx_Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cbx_Sex.FormattingEnabled = true;
            this.cbx_Sex.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbx_Sex.Location = new System.Drawing.Point(560, 322);
            this.cbx_Sex.Name = "cbx_Sex";
            this.cbx_Sex.Size = new System.Drawing.Size(126, 28);
            this.cbx_Sex.TabIndex = 13;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtUserName.Location = new System.Drawing.Point(405, 101);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(281, 27);
            this.txtUserName.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Orange;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(405, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 22);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tên Đăng Nhập :";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::StoreAssitant.Properties.Resources.SUPBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(756, 473);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.cbx_Sex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_Phone);
            this.Controls.Add(this.dateTimeBirth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxB_IdentityPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_Pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_Name);
            this.Controls.Add(this.label1);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_Pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxB_IdentityPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeBirth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_Phone;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.ComboBox cbx_Sex;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
    }
}