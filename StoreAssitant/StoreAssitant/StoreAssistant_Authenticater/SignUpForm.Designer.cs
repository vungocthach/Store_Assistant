namespace StoreAssitant.StoreAssistant_Authenticater
{
    partial class SignUpForm
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
            this.txt_PassCurrent = new System.Windows.Forms.TextBox();
            this.txt_PassNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PassNew2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txt_PassCurrent
            // 
            this.txt_PassCurrent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PassCurrent.Location = new System.Drawing.Point(138, 10);
            this.txt_PassCurrent.MaxLength = 50;
            this.txt_PassCurrent.Name = "txt_PassCurrent";
            this.txt_PassCurrent.Size = new System.Drawing.Size(294, 26);
            this.txt_PassCurrent.TabIndex = 1;
            // 
            // txt_PassNew
            // 
            this.txt_PassNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PassNew.Location = new System.Drawing.Point(138, 42);
            this.txt_PassNew.MaxLength = 50;
            this.txt_PassNew.Name = "txt_PassNew";
            this.txt_PassNew.PasswordChar = '*';
            this.txt_PassNew.Size = new System.Drawing.Size(294, 26);
            this.txt_PassNew.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txt_PassNew2
            // 
            this.txt_PassNew2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PassNew2.Location = new System.Drawing.Point(138, 74);
            this.txt_PassNew2.MaxLength = 50;
            this.txt_PassNew2.Name = "txt_PassNew2";
            this.txt_PassNew2.PasswordChar = '*';
            this.txt_PassNew2.Size = new System.Drawing.Size(294, 26);
            this.txt_PassNew2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập lại lần 2";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(113, 115);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(105, 26);
            this.btn_Submit.TabIndex = 6;
            this.btn_Submit.Text = "Xác Nhận";
            this.btn_Submit.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(248, 115);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(105, 26);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Hủy";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 153);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.txt_PassNew2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_PassNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_PassCurrent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignUpForm";
            this.ShowIcon = false;
            this.Text = "Tạo tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PassCurrent;
        private System.Windows.Forms.TextBox txt_PassNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PassNew2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Close;
    }
}