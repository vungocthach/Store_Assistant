﻿namespace StoreAssitant
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
            this.pnlCashier = new System.Windows.Forms.Panel();
            this.btnCashier = new System.Windows.Forms.Button();
            this.flpProductInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lbSumPrice = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.titelLine1 = new StoreAssitant.StoreAssistant_TableView.TitelLine();
            this.tableTitle_pnl.SuspendLayout();
            this.pnlCashier.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableTitle_pnl
            // 
            this.tableTitle_pnl.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tableTitle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableTitle_pnl.Controls.Add(this.btn_Cancel);
            this.tableTitle_pnl.Controls.Add(this.tableTitle_lb);
            this.tableTitle_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTitle_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableTitle_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableTitle_pnl.Name = "tableTitle_pnl";
            this.tableTitle_pnl.Size = new System.Drawing.Size(420, 34);
            this.tableTitle_pnl.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancel.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(393, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(20, 20);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "X";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tableTitle_lb
            // 
            this.tableTitle_lb.AutoSize = true;
            this.tableTitle_lb.Font = new System.Drawing.Font("Snap ITC", 16F, System.Drawing.FontStyle.Bold);
            this.tableTitle_lb.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableTitle_lb.Location = new System.Drawing.Point(184, 2);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(73, 29);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "BÀN";
            this.tableTitle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCashier
            // 
            this.pnlCashier.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCashier.Controls.Add(this.btnCashier);
            this.pnlCashier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCashier.Location = new System.Drawing.Point(0, 527);
            this.pnlCashier.MinimumSize = new System.Drawing.Size(0, 40);
            this.pnlCashier.Name = "pnlCashier";
            this.pnlCashier.Size = new System.Drawing.Size(420, 43);
            this.pnlCashier.TabIndex = 6;
            // 
            // btnCashier
            // 
            this.btnCashier.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCashier.BackColor = System.Drawing.Color.Red;
            this.btnCashier.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCashier.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCashier.Location = new System.Drawing.Point(294, 0);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(126, 43);
            this.btnCashier.TabIndex = 0;
            this.btnCashier.Text = "THANH TOÁN";
            this.btnCashier.UseVisualStyleBackColor = false;
            // 
            // flpProductInfo
            // 
            this.flpProductInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flpProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpProductInfo.Location = new System.Drawing.Point(0, 64);
            this.flpProductInfo.Name = "flpProductInfo";
            this.flpProductInfo.Size = new System.Drawing.Size(420, 429);
            this.flpProductInfo.TabIndex = 7;
            // 
            // lbSumPrice
            // 
            this.lbSumPrice.AutoSize = true;
            this.lbSumPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumPrice.Location = new System.Drawing.Point(3, 500);
            this.lbSumPrice.Name = "lbSumPrice";
            this.lbSumPrice.Size = new System.Drawing.Size(99, 24);
            this.lbSumPrice.TabIndex = 8;
            this.lbSumPrice.Text = "Tổng tiền";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(352, 500);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(20, 24);
            this.lbPrice.TabIndex = 9;
            this.lbPrice.Text = "0";
            // 
            // titelLine1
            // 
            this.titelLine1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titelLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titelLine1.Location = new System.Drawing.Point(0, 34);
            this.titelLine1.MinimumSize = new System.Drawing.Size(348, 23);
            this.titelLine1.Name = "titelLine1";
            this.titelLine1.Size = new System.Drawing.Size(420, 30);
            this.titelLine1.TabIndex = 3;
            // 
            // TableBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbSumPrice);
            this.Controls.Add(this.flpProductInfo);
            this.Controls.Add(this.titelLine1);
            this.Controls.Add(this.pnlCashier);
            this.Controls.Add(this.tableTitle_pnl);
            this.Name = "TableBill";
            this.Size = new System.Drawing.Size(420, 570);
            this.tableTitle_pnl.ResumeLayout(false);
            this.tableTitle_pnl.PerformLayout();
            this.pnlCashier.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tableTitle_pnl;
        private System.Windows.Forms.Label tableTitle_lb;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Panel pnlCashier;
        private System.Windows.Forms.Button btnCashier;
        private StoreAssistant_TableView.TitelLine titelLine1;
        private System.Windows.Forms.FlowLayoutPanel flpProductInfo;
        private System.Windows.Forms.Label lbSumPrice;
        private System.Windows.Forms.Label lbPrice;
    }
}
