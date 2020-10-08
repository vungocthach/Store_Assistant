﻿namespace StoreAssitant
{
    partial class MenuView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.controlProduct = new StoreAssitant.ControlProduct();
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.ControlTitle = new StoreAssitant.TitleControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.controlProduct);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 76);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(569, 464);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // controlProduct
            // 
            this.controlProduct.BackColor = System.Drawing.Color.Azure;
            this.controlProduct.ForeColor = System.Drawing.SystemColors.Control;
            this.controlProduct.Location = new System.Drawing.Point(5, 5);
            this.controlProduct.Margin = new System.Windows.Forms.Padding(5);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(220, 178);
            this.controlProduct.TabIndex = 0;
            // 
            // controlSearch
            // 
            this.controlSearch.Location = new System.Drawing.Point(5, 40);
            this.controlSearch.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(559, 36);
            this.controlSearch.TabIndex = 2;
            // 
            // ControlTitle
            // 
            this.ControlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlTitle.Location = new System.Drawing.Point(0, 0);
            this.ControlTitle.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.ControlTitle.MinimumSize = new System.Drawing.Size(0, 40);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.Size = new System.Drawing.Size(569, 40);
            this.ControlTitle.TabIndex = 0;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ControlTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(569, 540);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TitleControl ControlTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ControlProduct controlProduct;
        private ControlSearch controlSearch;
    }
}