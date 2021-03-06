﻿namespace StoreAssitant.StoreAssistant_AccountView
{
    partial class AccountView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gr_user = new System.Windows.Forms.GroupBox();
            this.txb_role = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_SignOut = new System.Windows.Forms.Button();
            this.btn_ResetPass = new System.Windows.Forms.Button();
            this.lb_role = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gr_manager = new System.Windows.Forms.GroupBox();
            this.btn_DeleteAccount = new System.Windows.Forms.Button();
            this.btn_AddAccount = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitile = new System.Windows.Forms.Label();
            this.gr_user.SuspendLayout();
            this.gr_manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gr_user
            // 
            this.gr_user.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gr_user.Controls.Add(this.txb_role);
            this.gr_user.Controls.Add(this.txt_username);
            this.gr_user.Controls.Add(this.btn_SignOut);
            this.gr_user.Controls.Add(this.btn_ResetPass);
            this.gr_user.Controls.Add(this.lb_role);
            this.gr_user.Controls.Add(this.lb_username);
            this.gr_user.Controls.Add(this.label1);
            this.gr_user.Controls.Add(this.label2);
            this.gr_user.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_user.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gr_user.Location = new System.Drawing.Point(8, 3);
            this.gr_user.MaximumSize = new System.Drawing.Size(650, 100);
            this.gr_user.MinimumSize = new System.Drawing.Size(400, 100);
            this.gr_user.Name = "gr_user";
            this.gr_user.Size = new System.Drawing.Size(650, 100);
            this.gr_user.TabIndex = 0;
            this.gr_user.TabStop = false;
            this.gr_user.Text = "Tài Khoản Hiện Tại";
            // 
            // txb_role
            // 
            this.txb_role.BackColor = System.Drawing.Color.White;
            this.txb_role.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_role.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txb_role.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txb_role.Location = new System.Drawing.Point(156, 54);
            this.txb_role.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txb_role.Name = "txb_role";
            this.txb_role.ReadOnly = true;
            this.txb_role.Size = new System.Drawing.Size(267, 22);
            this.txb_role.TabIndex = 7;
            this.txb_role.TabStop = false;
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.White;
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txt_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_username.Location = new System.Drawing.Point(158, 26);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txt_username.Name = "txt_username";
            this.txt_username.ReadOnly = true;
            this.txt_username.Size = new System.Drawing.Size(349, 22);
            this.txt_username.TabIndex = 4;
            this.txt_username.TabStop = false;
            // 
            // btn_SignOut
            // 
            this.btn_SignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SignOut.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_SignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SignOut.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SignOut.Location = new System.Drawing.Point(530, 55);
            this.btn_SignOut.Name = "btn_SignOut";
            this.btn_SignOut.Size = new System.Drawing.Size(107, 28);
            this.btn_SignOut.TabIndex = 3;
            this.btn_SignOut.Text = "Đăng xuất";
            this.btn_SignOut.UseVisualStyleBackColor = false;
            // 
            // btn_ResetPass
            // 
            this.btn_ResetPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetPass.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_ResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetPass.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ResetPass.Location = new System.Drawing.Point(530, 25);
            this.btn_ResetPass.Name = "btn_ResetPass";
            this.btn_ResetPass.Size = new System.Drawing.Size(107, 28);
            this.btn_ResetPass.TabIndex = 2;
            this.btn_ResetPass.Text = "Đổi mật khẩu";
            this.btn_ResetPass.UseVisualStyleBackColor = false;
            this.btn_ResetPass.Click += new System.EventHandler(this.btn_ResetPass_Click_1);
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_role.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_role.Location = new System.Drawing.Point(41, 59);
            this.lb_role.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(82, 19);
            this.lb_role.TabIndex = 1;
            this.lb_role.Text = "Phân cấp : ";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_username.Location = new System.Drawing.Point(41, 30);
            this.lb_username.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(116, 19);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "Tên đăng nhập :";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(148, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "________________________________________________________________________________";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(152, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "________________________________________________________________________________";
            // 
            // gr_manager
            // 
            this.gr_manager.Controls.Add(this.btn_DeleteAccount);
            this.gr_manager.Controls.Add(this.btn_AddAccount);
            this.gr_manager.Controls.Add(this.dataGridView1);
            this.gr_manager.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_manager.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gr_manager.Location = new System.Drawing.Point(10, 161);
            this.gr_manager.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.gr_manager.MaximumSize = new System.Drawing.Size(650, 3000);
            this.gr_manager.MinimumSize = new System.Drawing.Size(400, 200);
            this.gr_manager.Name = "gr_manager";
            this.gr_manager.Size = new System.Drawing.Size(650, 409);
            this.gr_manager.TabIndex = 2;
            this.gr_manager.TabStop = false;
            // 
            // btn_DeleteAccount
            // 
            this.btn_DeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DeleteAccount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_DeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteAccount.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_DeleteAccount.Location = new System.Drawing.Point(537, 378);
            this.btn_DeleteAccount.Name = "btn_DeleteAccount";
            this.btn_DeleteAccount.Size = new System.Drawing.Size(107, 27);
            this.btn_DeleteAccount.TabIndex = 5;
            this.btn_DeleteAccount.Text = "Xóa";
            this.btn_DeleteAccount.UseVisualStyleBackColor = false;
            // 
            // btn_AddAccount
            // 
            this.btn_AddAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddAccount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_AddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAccount.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AddAccount.Location = new System.Drawing.Point(421, 378);
            this.btn_AddAccount.Name = "btn_AddAccount";
            this.btn_AddAccount.Size = new System.Drawing.Size(107, 27);
            this.btn_AddAccount.TabIndex = 4;
            this.btn_AddAccount.Text = "Thêm";
            this.btn_AddAccount.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_username,
            this.colFullname,
            this.col_role});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(3, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 3, 2, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(650, 399);
            this.dataGridView1.TabIndex = 1;
            // 
            // col_username
            // 
            this.col_username.DividerWidth = 2;
            this.col_username.FillWeight = 274.1117F;
            this.col_username.HeaderText = "Tên đăng nhập";
            this.col_username.MinimumWidth = 180;
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            this.col_username.Width = 180;
            // 
            // colFullname
            // 
            this.colFullname.DividerWidth = 2;
            this.colFullname.FillWeight = 12.94417F;
            this.colFullname.HeaderText = "Họ Và Tên";
            this.colFullname.MinimumWidth = 200;
            this.colFullname.Name = "colFullname";
            this.colFullname.ReadOnly = true;
            this.colFullname.Width = 300;
            // 
            // col_role
            // 
            this.col_role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_role.DividerWidth = 2;
            this.col_role.FillWeight = 12.94417F;
            this.col_role.HeaderText = "Phân cấp";
            this.col_role.MinimumWidth = 100;
            this.col_role.Name = "col_role";
            this.col_role.ReadOnly = true;
            // 
            // labelTitile
            // 
            this.labelTitile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelTitile.Font = new System.Drawing.Font("Snap ITC", 15F, System.Drawing.FontStyle.Bold);
            this.labelTitile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelTitile.Location = new System.Drawing.Point(11, 103);
            this.labelTitile.Name = "labelTitile";
            this.labelTitile.Size = new System.Drawing.Size(647, 55);
            this.labelTitile.TabIndex = 3;
            this.labelTitile.Text = "Thông tin nhân viên";
            this.labelTitile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitile.Click += new System.EventHandler(this.label3_Click);
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.labelTitile);
            this.Controls.Add(this.gr_manager);
            this.Controls.Add(this.gr_user);
            this.Name = "AccountView";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Size = new System.Drawing.Size(674, 579);
            this.gr_user.ResumeLayout(false);
            this.gr_user.PerformLayout();
            this.gr_manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gr_user;
        private System.Windows.Forms.Button btn_SignOut;
        private System.Windows.Forms.Button btn_ResetPass;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.GroupBox gr_manager;
        private System.Windows.Forms.Button btn_DeleteAccount;
        private System.Windows.Forms.Button btn_AddAccount;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTitile;
        private System.Windows.Forms.TextBox txb_role;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_role;
    }
}
