namespace StoreAssitant
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.split_Cashier = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.toolView1 = new StoreAssitant.StoreAssistant_SettingView.ToolView();
            this.tabSelector1 = new StoreAssitant.StoreAssistant_Helper.TabSelector();
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).BeginInit();
            this.split_Cashier.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_Cashier
            // 
            this.split_Cashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Cashier.Location = new System.Drawing.Point(0, 0);
            this.split_Cashier.Name = "split_Cashier";
            // 
            // split_Cashier.Panel1
            // 
            this.split_Cashier.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // split_Cashier.Panel2
            // 
            this.split_Cashier.Panel2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.split_Cashier.Size = new System.Drawing.Size(1178, 581);
            this.split_Cashier.SplitterDistance = 572;
            this.split_Cashier.SplitterWidth = 5;
            this.split_Cashier.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 624);
            this.panel1.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(24)))));
            this.pnlMenu.Controls.Add(this.toolView1);
            this.pnlMenu.Controls.Add(this.tabSelector1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1184, 60);
            this.pnlMenu.TabIndex = 3;
            // 
            // toolView1
            // 
            this.toolView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolView1.BackColor = System.Drawing.Color.Transparent;
            this.toolView1.Location = new System.Drawing.Point(821, 12);
            this.toolView1.Name = "toolView1";
            this.toolView1.Size = new System.Drawing.Size(341, 35);
            this.toolView1.TabIndex = 1;
            // 
            // tabSelector1
            // 
            this.tabSelector1.BackColor = System.Drawing.Color.Transparent;
            this.tabSelector1.ColorButtonMouseOn = System.Drawing.Color.Empty;
            this.tabSelector1.ColorButtonPressed = System.Drawing.Color.Empty;
            this.tabSelector1.ColorButtonSelected = System.Drawing.Color.Yellow;
            this.tabSelector1.Location = new System.Drawing.Point(0, 0);
            this.tabSelector1.Name = "tabSelector1";
            this.tabSelector1.Size = new System.Drawing.Size(829, 59);
            this.tabSelector1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).EndInit();
            this.split_Cashier.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer split_Cashier;
        private System.Windows.Forms.Panel panel1;
        private StoreAssistant_Helper.TabSelector tabSelector1;
        private System.Windows.Forms.Panel pnlMenu;
        private StoreAssistant_SettingView.ToolView toolView1;
    }
}

