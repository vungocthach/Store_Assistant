namespace StoreAssitant
{
    partial class ControlSearch
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.cbx_Search = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Font = new System.Drawing.Font("Snap ITC", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSearch.Location = new System.Drawing.Point(269, 0);
            this.buttonSearch.MinimumSize = new System.Drawing.Size(52, 29);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(85, 34);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // cbx_Search
            // 
            this.cbx_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cbx_Search.Location = new System.Drawing.Point(0, 1);
            this.cbx_Search.Name = "cbx_Search";
            this.cbx_Search.Size = new System.Drawing.Size(272, 32);
            this.cbx_Search.TabIndex = 2;
            // 
            // ControlSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx_Search);
            this.Controls.Add(this.buttonSearch);
            this.Name = "ControlSearch";
            this.Size = new System.Drawing.Size(354, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox cbx_Search;
    }
}
