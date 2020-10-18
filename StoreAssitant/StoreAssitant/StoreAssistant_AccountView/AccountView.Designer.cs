namespace StoreAssitant.StoreAssistant_AccountView
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
            this.gr_user = new System.Windows.Forms.GroupBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_role = new System.Windows.Forms.Label();
            this.btn_ResetPass = new System.Windows.Forms.Button();
            this.btn_SignOut = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gr_manager = new System.Windows.Forms.GroupBox();
            this.btn_AddAccount = new System.Windows.Forms.Button();
            this.btn_DeleteAccount = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.gr_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gr_manager.SuspendLayout();
            this.SuspendLayout();
            // 
            // gr_user
            // 
            this.gr_user.Controls.Add(this.txt_username);
            this.gr_user.Controls.Add(this.btn_SignOut);
            this.gr_user.Controls.Add(this.btn_ResetPass);
            this.gr_user.Controls.Add(this.lb_role);
            this.gr_user.Controls.Add(this.lb_username);
            this.gr_user.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_user.Location = new System.Drawing.Point(8, 3);
            this.gr_user.MaximumSize = new System.Drawing.Size(650, 100);
            this.gr_user.MinimumSize = new System.Drawing.Size(400, 100);
            this.gr_user.Name = "gr_user";
            this.gr_user.Size = new System.Drawing.Size(650, 100);
            this.gr_user.TabIndex = 0;
            this.gr_user.TabStop = false;
            this.gr_user.Text = "Thông tin tài khoản";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(41, 30);
            this.lb_username.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(105, 19);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "Tên đăng nhập :";
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_role.Location = new System.Drawing.Point(41, 59);
            this.lb_role.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(76, 19);
            this.lb_role.TabIndex = 1;
            this.lb_role.Text = "Phân cấp : ";
            // 
            // btn_ResetPass
            // 
            this.btn_ResetPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetPass.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetPass.Location = new System.Drawing.Point(544, 30);
            this.btn_ResetPass.Name = "btn_ResetPass";
            this.btn_ResetPass.Size = new System.Drawing.Size(100, 25);
            this.btn_ResetPass.TabIndex = 2;
            this.btn_ResetPass.Text = "Đổi mật khẩu";
            this.btn_ResetPass.UseVisualStyleBackColor = true;
            // 
            // btn_SignOut
            // 
            this.btn_SignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SignOut.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignOut.Location = new System.Drawing.Point(544, 57);
            this.btn_SignOut.Name = "btn_SignOut";
            this.btn_SignOut.Size = new System.Drawing.Size(100, 25);
            this.btn_SignOut.TabIndex = 3;
            this.btn_SignOut.Text = "Đăng xuất";
            this.btn_SignOut.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_username,
            this.col_role});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(633, 369);
            this.dataGridView1.TabIndex = 1;
            // 
            // col_username
            // 
            this.col_username.HeaderText = "Tên đăng nhập";
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            // 
            // col_role
            // 
            this.col_role.HeaderText = "Phân cấp";
            this.col_role.Name = "col_role";
            this.col_role.ReadOnly = true;
            // 
            // gr_manager
            // 
            this.gr_manager.Controls.Add(this.btn_DeleteAccount);
            this.gr_manager.Controls.Add(this.btn_AddAccount);
            this.gr_manager.Controls.Add(this.dataGridView1);
            this.gr_manager.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr_manager.Location = new System.Drawing.Point(8, 133);
            this.gr_manager.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.gr_manager.MaximumSize = new System.Drawing.Size(650, 450);
            this.gr_manager.MinimumSize = new System.Drawing.Size(400, 450);
            this.gr_manager.Name = "gr_manager";
            this.gr_manager.Size = new System.Drawing.Size(650, 450);
            this.gr_manager.TabIndex = 2;
            this.gr_manager.TabStop = false;
            this.gr_manager.Text = "Thông tin nhân viên";
            // 
            // btn_AddAccount
            // 
            this.btn_AddAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddAccount.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAccount.Location = new System.Drawing.Point(421, 419);
            this.btn_AddAccount.Name = "btn_AddAccount";
            this.btn_AddAccount.Size = new System.Drawing.Size(100, 25);
            this.btn_AddAccount.TabIndex = 4;
            this.btn_AddAccount.Text = "Thêm";
            this.btn_AddAccount.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteAccount
            // 
            this.btn_DeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DeleteAccount.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteAccount.Location = new System.Drawing.Point(537, 419);
            this.btn_DeleteAccount.Name = "btn_DeleteAccount";
            this.btn_DeleteAccount.Size = new System.Drawing.Size(100, 25);
            this.btn_DeleteAccount.TabIndex = 5;
            this.btn_DeleteAccount.Text = "Xóa";
            this.btn_DeleteAccount.UseVisualStyleBackColor = true;
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.White;
            this.txt_username.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(152, 31);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txt_username.Name = "txt_username";
            this.txt_username.ReadOnly = true;
            this.txt_username.Size = new System.Drawing.Size(378, 24);
            this.txt_username.TabIndex = 4;
            this.txt_username.TabStop = false;
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gr_manager);
            this.Controls.Add(this.gr_user);
            this.Name = "AccountView";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Size = new System.Drawing.Size(674, 592);
            this.gr_user.ResumeLayout(false);
            this.gr_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gr_manager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gr_user;
        private System.Windows.Forms.Button btn_SignOut;
        private System.Windows.Forms.Button btn_ResetPass;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_role;
        private System.Windows.Forms.GroupBox gr_manager;
        private System.Windows.Forms.Button btn_DeleteAccount;
        private System.Windows.Forms.Button btn_AddAccount;
        private System.Windows.Forms.TextBox txt_username;
    }
}
