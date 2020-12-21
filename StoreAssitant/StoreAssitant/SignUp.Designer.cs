namespace StoreAssitant
{
    partial class SignUp_form
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
            this.lb_Name = new System.Windows.Forms.Label();
            this.txb_Name = new System.Windows.Forms.TextBox();
            this.lb_Pass = new System.Windows.Forms.Label();
            this.txb_Pass = new System.Windows.Forms.TextBox();
            this.lb_ConfirmPassq = new System.Windows.Forms.Label();
            this.TxB_IdentityPass = new System.Windows.Forms.TextBox();
            this.lb_Birth = new System.Windows.Forms.Label();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.lb_Gender = new System.Windows.Forms.Label();
            this.lb_Phone = new System.Windows.Forms.Label();
            this.txb_Phone = new System.Windows.Forms.TextBox();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.cbx_Sex = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lb_UserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.BackColor = System.Drawing.Color.Orange;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Name.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_Name.Location = new System.Drawing.Point(405, 14);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(92, 22);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "Họ và tên:";
            // 
            // txb_Name
            // 
            this.txb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Name.Location = new System.Drawing.Point(402, 39);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(281, 27);
            this.txb_Name.TabIndex = 1;
            // 
            // lb_Pass
            // 
            this.lb_Pass.AutoSize = true;
            this.lb_Pass.BackColor = System.Drawing.Color.Orange;
            this.lb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Pass.Location = new System.Drawing.Point(405, 156);
            this.lb_Pass.Name = "lb_Pass";
            this.lb_Pass.Size = new System.Drawing.Size(88, 22);
            this.lb_Pass.TabIndex = 2;
            this.lb_Pass.Text = "Mật khẩu:";
            // 
            // txb_Pass
            // 
            this.txb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Pass.Location = new System.Drawing.Point(404, 181);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.Size = new System.Drawing.Size(281, 27);
            this.txb_Pass.TabIndex = 3;
            // 
            // lb_ConfirmPassq
            // 
            this.lb_ConfirmPassq.AutoSize = true;
            this.lb_ConfirmPassq.BackColor = System.Drawing.Color.Orange;
            this.lb_ConfirmPassq.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_ConfirmPassq.Location = new System.Drawing.Point(405, 225);
            this.lb_ConfirmPassq.Name = "lb_ConfirmPassq";
            this.lb_ConfirmPassq.Size = new System.Drawing.Size(169, 22);
            this.lb_ConfirmPassq.TabIndex = 4;
            this.lb_ConfirmPassq.Text = "Xác nhận mật khẩu:";
            this.lb_ConfirmPassq.Click += new System.EventHandler(this.label3_Click);
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
            // lb_Birth
            // 
            this.lb_Birth.AutoSize = true;
            this.lb_Birth.BackColor = System.Drawing.Color.Orange;
            this.lb_Birth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Birth.Location = new System.Drawing.Point(405, 295);
            this.lb_Birth.Name = "lb_Birth";
            this.lb_Birth.Size = new System.Drawing.Size(100, 22);
            this.lb_Birth.TabIndex = 6;
            this.lb_Birth.Text = "Ngày sinh :";
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
            // lb_Gender
            // 
            this.lb_Gender.AutoSize = true;
            this.lb_Gender.BackColor = System.Drawing.Color.Orange;
            this.lb_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Gender.Location = new System.Drawing.Point(560, 295);
            this.lb_Gender.Name = "lb_Gender";
            this.lb_Gender.Size = new System.Drawing.Size(81, 22);
            this.lb_Gender.TabIndex = 12;
            this.lb_Gender.Text = "Giới tính:";
            // 
            // lb_Phone
            // 
            this.lb_Phone.AutoSize = true;
            this.lb_Phone.BackColor = System.Drawing.Color.Orange;
            this.lb_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Phone.Location = new System.Drawing.Point(400, 359);
            this.lb_Phone.Name = "lb_Phone";
            this.lb_Phone.Size = new System.Drawing.Size(47, 22);
            this.lb_Phone.TabIndex = 8;
            this.lb_Phone.Text = "SĐT";
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
            // lb_UserName
            // 
            this.lb_UserName.AutoSize = true;
            this.lb_UserName.BackColor = System.Drawing.Color.Orange;
            this.lb_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_UserName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_UserName.Location = new System.Drawing.Point(405, 76);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(148, 22);
            this.lb_UserName.TabIndex = 15;
            this.lb_UserName.Text = "Tên Đăng Nhập :";
            // 
            // SignUp_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::StoreAssitant.Properties.Resources.SUPBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(756, 473);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lb_UserName);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.cbx_Sex);
            this.Controls.Add(this.lb_Gender);
            this.Controls.Add(this.txb_Phone);
            this.Controls.Add(this.dateTimeBirth);
            this.Controls.Add(this.lb_Phone);
            this.Controls.Add(this.lb_Birth);
            this.Controls.Add(this.TxB_IdentityPass);
            this.Controls.Add(this.lb_ConfirmPassq);
            this.Controls.Add(this.txb_Pass);
            this.Controls.Add(this.lb_Pass);
            this.Controls.Add(this.txb_Name);
            this.Controls.Add(this.lb_Name);
            this.Name = "SignUp_form";
            this.Text = "Đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.Label lb_Pass;
        private System.Windows.Forms.TextBox txb_Pass;
        private System.Windows.Forms.Label lb_ConfirmPassq;
        private System.Windows.Forms.TextBox TxB_IdentityPass;
        private System.Windows.Forms.Label lb_Birth;
        private System.Windows.Forms.DateTimePicker dateTimeBirth;
        private System.Windows.Forms.Label lb_Gender;
        private System.Windows.Forms.Label lb_Phone;
        private System.Windows.Forms.TextBox txb_Phone;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.ComboBox cbx_Sex;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lb_UserName;
    }
}