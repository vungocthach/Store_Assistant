﻿namespace StoreAssitant
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
            this.lb_Signup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Name.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_Name.Location = new System.Drawing.Point(451, 14);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(97, 22);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "Họ và tên :";
            // 
            // txb_Name
            // 
            this.txb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Name.Location = new System.Drawing.Point(448, 39);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(281, 27);
            this.txb_Name.TabIndex = 1;
            // 
            // lb_Pass
            // 
            this.lb_Pass.AutoSize = true;
            this.lb_Pass.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Pass.Location = new System.Drawing.Point(451, 156);
            this.lb_Pass.Name = "lb_Pass";
            this.lb_Pass.Size = new System.Drawing.Size(93, 22);
            this.lb_Pass.TabIndex = 0;
            this.lb_Pass.Text = "Mật khẩu :";
            // 
            // txb_Pass
            // 
            this.txb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Pass.Location = new System.Drawing.Point(450, 181);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.PasswordChar = '*';
            this.txb_Pass.Size = new System.Drawing.Size(281, 27);
            this.txb_Pass.TabIndex = 3;
            // 
            // lb_ConfirmPassq
            // 
            this.lb_ConfirmPassq.AutoSize = true;
            this.lb_ConfirmPassq.BackColor = System.Drawing.SystemColors.Control;
            this.lb_ConfirmPassq.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_ConfirmPassq.Location = new System.Drawing.Point(451, 225);
            this.lb_ConfirmPassq.Name = "lb_ConfirmPassq";
            this.lb_ConfirmPassq.Size = new System.Drawing.Size(174, 22);
            this.lb_ConfirmPassq.TabIndex = 0;
            this.lb_ConfirmPassq.Text = "Xác nhận mật khẩu :";
            this.lb_ConfirmPassq.Click += new System.EventHandler(this.label3_Click);
            // 
            // TxB_IdentityPass
            // 
            this.TxB_IdentityPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.TxB_IdentityPass.Location = new System.Drawing.Point(450, 250);
            this.TxB_IdentityPass.Name = "TxB_IdentityPass";
            this.TxB_IdentityPass.PasswordChar = '*';
            this.TxB_IdentityPass.Size = new System.Drawing.Size(281, 27);
            this.TxB_IdentityPass.TabIndex = 4;
            // 
            // lb_Birth
            // 
            this.lb_Birth.AutoSize = true;
            this.lb_Birth.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Birth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Birth.Location = new System.Drawing.Point(451, 295);
            this.lb_Birth.Name = "lb_Birth";
            this.lb_Birth.Size = new System.Drawing.Size(100, 22);
            this.lb_Birth.TabIndex = 0;
            this.lb_Birth.Text = "Ngày sinh :";
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateTimeBirth.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateTimeBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBirth.Location = new System.Drawing.Point(450, 320);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(105, 27);
            this.dateTimeBirth.TabIndex = 5;
            // 
            // lb_Gender
            // 
            this.lb_Gender.AutoSize = true;
            this.lb_Gender.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Gender.Location = new System.Drawing.Point(606, 295);
            this.lb_Gender.Name = "lb_Gender";
            this.lb_Gender.Size = new System.Drawing.Size(86, 22);
            this.lb_Gender.TabIndex = 0;
            this.lb_Gender.Text = "Giới tính :";
            // 
            // lb_Phone
            // 
            this.lb_Phone.AutoSize = true;
            this.lb_Phone.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_Phone.Location = new System.Drawing.Point(446, 359);
            this.lb_Phone.Name = "lb_Phone";
            this.lb_Phone.Size = new System.Drawing.Size(57, 22);
            this.lb_Phone.TabIndex = 0;
            this.lb_Phone.Text = "SĐT :";
            // 
            // txb_Phone
            // 
            this.txb_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txb_Phone.Location = new System.Drawing.Point(449, 384);
            this.txb_Phone.Name = "txb_Phone";
            this.txb_Phone.Size = new System.Drawing.Size(281, 27);
            this.txb_Phone.TabIndex = 7;
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.BackColor = System.Drawing.Color.Orange;
            this.btn_SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SignUp.Location = new System.Drawing.Point(448, 428);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(281, 33);
            this.btn_SignUp.TabIndex = 8;
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
            this.cbx_Sex.Location = new System.Drawing.Point(606, 322);
            this.cbx_Sex.Name = "cbx_Sex";
            this.cbx_Sex.Size = new System.Drawing.Size(126, 28);
            this.cbx_Sex.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtUserName.Location = new System.Drawing.Point(451, 110);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(281, 27);
            this.txtUserName.TabIndex = 2;
            // 
            // lb_UserName
            // 
            this.lb_UserName.AutoSize = true;
            this.lb_UserName.BackColor = System.Drawing.SystemColors.Control;
            this.lb_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lb_UserName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_UserName.Location = new System.Drawing.Point(451, 85);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(148, 22);
            this.lb_UserName.TabIndex = 0;
            this.lb_UserName.Text = "Tên Đăng Nhập :";
            // 
            // lb_Signup
            // 
            this.lb_Signup.AutoSize = true;
            this.lb_Signup.BackColor = System.Drawing.Color.LightGray;
            this.lb_Signup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Signup.Font = new System.Drawing.Font("Times New Roman", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lb_Signup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lb_Signup.Location = new System.Drawing.Point(56, 265);
            this.lb_Signup.Name = "lb_Signup";
            this.lb_Signup.Size = new System.Drawing.Size(316, 84);
            this.lb_Signup.TabIndex = 17;
            this.lb_Signup.Text = "ĐĂNG KÝ\r\nTHÀNH VIÊN MỚI";
            this.lb_Signup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignUp_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::StoreAssitant.Properties.Resources.Background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(756, 473);
            this.Controls.Add(this.lb_Signup);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SignUp_form";
            this.ShowIcon = false;
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
        private System.Windows.Forms.Label lb_Signup;
    }
}