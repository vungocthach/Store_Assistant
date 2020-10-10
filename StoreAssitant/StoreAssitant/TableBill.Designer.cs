namespace StoreAssitant
{
    partial class TableBill
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
            this.tableTitle_pnl = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableTitle_lb = new System.Windows.Forms.Label();
            this.tableIcon_pnl = new System.Windows.Forms.Panel();
            this.tableTitle_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableTitle_pnl
            // 
            this.tableTitle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableTitle_pnl.Controls.Add(this.btn_Cancel);
            this.tableTitle_pnl.Controls.Add(this.tableIcon_pnl);
            this.tableTitle_pnl.Controls.Add(this.tableTitle_lb);
            this.tableTitle_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTitle_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableTitle_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableTitle_pnl.Name = "tableTitle_pnl";
            this.tableTitle_pnl.Size = new System.Drawing.Size(420, 50);
            this.tableTitle_pnl.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.AutoSize = true;
            this.btn_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancel.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(395, 26);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(24, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "X";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tableTitle_lb
            // 
            this.tableTitle_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTitle_lb.Location = new System.Drawing.Point(73, 7);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(287, 35);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "BÀN";
            this.tableTitle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableIcon_pnl
            // 
            this.tableIcon_pnl.BackgroundImage = global::StoreAssitant.Properties.Resources.thu_ngân;
            this.tableIcon_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableIcon_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableIcon_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableIcon_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableIcon_pnl.Name = "tableIcon_pnl";
            this.tableIcon_pnl.Size = new System.Drawing.Size(50, 48);
            this.tableIcon_pnl.TabIndex = 3;
            // 
            // TableBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableTitle_pnl);
            this.Name = "TableBill";
            this.Size = new System.Drawing.Size(420, 570);
            this.tableTitle_pnl.ResumeLayout(false);
            this.tableTitle_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tableTitle_pnl;
        private System.Windows.Forms.Panel tableIcon_pnl;
        private System.Windows.Forms.Label tableTitle_lb;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
