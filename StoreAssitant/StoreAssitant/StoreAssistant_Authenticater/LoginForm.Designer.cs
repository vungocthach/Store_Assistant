namespace StoreAssitant
{
    partial class LoginForm
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
            this.logInView = new StoreAssitant.LogInView();
            this.lbDB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logInView
            // 
            this.logInView.Location = new System.Drawing.Point(0, 0);
            this.logInView.Name = "logInView";
            this.logInView.Size = new System.Drawing.Size(409, 474);
            this.logInView.TabIndex = 0;
            // 
            // lbDB
            // 
            this.lbDB.AutoSize = true;
            this.lbDB.BackColor = System.Drawing.Color.Transparent;
            this.lbDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDB.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbDB.Location = new System.Drawing.Point(311, 449);
            this.lbDB.Name = "lbDB";
            this.lbDB.Size = new System.Drawing.Size(89, 16);
            this.lbDB.TabIndex = 1;
            this.lbDB.Text = "Server Config";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 473);
            this.Controls.Add(this.lbDB);
            this.Controls.Add(this.logInView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LogInView logInView;
        private System.Windows.Forms.Label lbDB;
    }
}