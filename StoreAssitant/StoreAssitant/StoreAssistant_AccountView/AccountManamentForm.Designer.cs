
namespace StoreAssitant.StoreAssistant_AccountView
{
    partial class AccountManamentForm
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
            this.accountView1 = new StoreAssitant.StoreAssistant_AccountView.AccountView();
            this.SuspendLayout();
            // 
            // accountView1
            // 
            this.accountView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.accountView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountView1.Location = new System.Drawing.Point(0, 0);
            this.accountView1.Name = "accountView1";
            this.accountView1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.accountView1.Size = new System.Drawing.Size(608, 597);
            this.accountView1.TabIndex = 0;
            // 
            // AccountManamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 597);
            this.Controls.Add(this.accountView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountManamentForm";
            this.Text = "Quản Lý Nhân Sự";
            this.ResumeLayout(false);

        }

        #endregion

        private AccountView accountView1;
    }
}