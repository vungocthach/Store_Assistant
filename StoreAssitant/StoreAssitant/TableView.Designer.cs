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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableView));
            this.tableGUI_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.tableAdd_btn = new System.Windows.Forms.Panel();
            this.tableTitle_lb = new System.Windows.Forms.Label();
            this.tableTitle_pnl = new System.Windows.Forms.Panel();
            this.tableIcon_pnl = new System.Windows.Forms.Panel();
            this.tableControl1 = new StoreAssitant.TableControl();
            this.tableGUI_pnl.SuspendLayout();
            this.tableTitle_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableGUI_pnl
            // 
            this.tableGUI_pnl.AutoScroll = true;
            this.tableGUI_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableGUI_pnl.Controls.Add(this.tableAdd_btn);
            this.tableGUI_pnl.Controls.Add(this.tableControl1);
            this.tableGUI_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableGUI_pnl.Location = new System.Drawing.Point(0, 50);
            this.tableGUI_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableGUI_pnl.Name = "tableGUI_pnl";
            this.tableGUI_pnl.Size = new System.Drawing.Size(420, 520);
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
            this.tableTitle_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTitle_lb.Location = new System.Drawing.Point(73, 7);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(287, 35);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "THANH TOÁN BÀN";
            this.tableTitle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableTitle_pnl
            // 
            this.tableTitle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableTitle_pnl.Controls.Add(this.tableIcon_pnl);
            this.tableTitle_pnl.Controls.Add(this.tableTitle_lb);
            this.tableTitle_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTitle_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableTitle_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableTitle_pnl.Name = "tableTitle_pnl";
            this.tableTitle_pnl.Size = new System.Drawing.Size(420, 50);
            this.tableTitle_pnl.TabIndex = 3;
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
            // tableControl1
            // 
            this.tableControl1.BackColor = System.Drawing.Color.PapayaWhip;
            this.tableControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableControl1.ID = 0;
            this.tableControl1.ImageTable = ((System.Drawing.Image)(resources.GetObject("tableControl1.ImageTable")));
            this.tableControl1.Location = new System.Drawing.Point(119, 2);
            this.tableControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tableControl1.MinimumSize = new System.Drawing.Size(77, 52);
            this.tableControl1.Name = "tableControl1";
            this.tableControl1.nameTable = "Name of Table";
            this.tableControl1.Size = new System.Drawing.Size(111, 120);
            this.tableControl1.TabIndex = 2;
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableTitle_pnl);
            this.Controls.Add(this.tableGUI_pnl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(420, 570);
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
        private TableControl tableControl1;
    }
}
