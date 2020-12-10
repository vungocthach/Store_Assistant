namespace StoreAssitant
{
    partial class TableView
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
            this.tableGUI_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.tableAdd_btn = new System.Windows.Forms.Panel();
            this.tableTitle_lb = new System.Windows.Forms.Label();
            this.tableTitle_pnl = new System.Windows.Forms.Panel();
            this.tableIcon_pnl = new System.Windows.Forms.Panel();
            this.tableGUI_pnl.SuspendLayout();
            this.tableTitle_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableGUI_pnl
            // 
            this.tableGUI_pnl.AutoScroll = true;
            this.tableGUI_pnl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableGUI_pnl.Controls.Add(this.tableAdd_btn);
            this.tableGUI_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableGUI_pnl.Location = new System.Drawing.Point(0, 48);
            this.tableGUI_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableGUI_pnl.Name = "tableGUI_pnl";
            this.tableGUI_pnl.Size = new System.Drawing.Size(418, 520);
            this.tableGUI_pnl.TabIndex = 0;
            // 
            // tableAdd_btn
            // 
            this.tableAdd_btn.BackgroundImage = global::StoreAssitant.Properties.Resources.button_add;
            this.tableAdd_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableAdd_btn.Location = new System.Drawing.Point(2, 2);
            this.tableAdd_btn.Margin = new System.Windows.Forms.Padding(2);
            this.tableAdd_btn.Name = "tableAdd_btn";
            this.tableAdd_btn.Size = new System.Drawing.Size(113, 122);
            this.tableAdd_btn.TabIndex = 1;
            // 
            // tableTitle_lb
            // 
            this.tableTitle_lb.Font = new System.Drawing.Font("Snap ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTitle_lb.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableTitle_lb.Location = new System.Drawing.Point(73, 7);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(287, 35);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "DANH SÁCH BÀN";
            this.tableTitle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableTitle_pnl
            // 
            this.tableTitle_pnl.BackColor = System.Drawing.Color.Orange;
            this.tableTitle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableTitle_pnl.Controls.Add(this.tableIcon_pnl);
            this.tableTitle_pnl.Controls.Add(this.tableTitle_lb);
            this.tableTitle_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTitle_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableTitle_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableTitle_pnl.Name = "tableTitle_pnl";
            this.tableTitle_pnl.Size = new System.Drawing.Size(418, 50);
            this.tableTitle_pnl.TabIndex = 3;
            // 
            // tableIcon_pnl
            // 
            this.tableIcon_pnl.BackgroundImage = global::StoreAssitant.Properties.Resources.thu_ngan;
            this.tableIcon_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableIcon_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableIcon_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableIcon_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableIcon_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableIcon_pnl.Name = "tableIcon_pnl";
            this.tableIcon_pnl.Size = new System.Drawing.Size(50, 48);
            this.tableIcon_pnl.TabIndex = 3;
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableGUI_pnl);
            this.Controls.Add(this.tableTitle_pnl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(418, 568);
            this.tableGUI_pnl.ResumeLayout(false);
            this.tableTitle_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tableGUI_pnl;
        private System.Windows.Forms.Label tableTitle_lb;
        private System.Windows.Forms.Panel tableTitle_pnl;
        private System.Windows.Forms.Panel tableIcon_pnl;
        private System.Windows.Forms.Panel tableAdd_btn;
    }
}
