namespace StoreAssitant
{
    partial class TableLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableLine));
            this.lbName = new System.Windows.Forms.Label();
            this.lbSinglePrice = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlNumber = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(130, 30);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Tên";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSinglePrice
            // 
            this.lbSinglePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSinglePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSinglePrice.Location = new System.Drawing.Point(130, 0);
            this.lbSinglePrice.Name = "lbSinglePrice";
            this.lbSinglePrice.Size = new System.Drawing.Size(100, 30);
            this.lbSinglePrice.TabIndex = 1;
            this.lbSinglePrice.Text = "Đơn giá";
            this.lbSinglePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumber
            // 
            this.lbNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.Location = new System.Drawing.Point(34, 3);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(41, 20);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "0";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.Location = new System.Drawing.Point(340, 0);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(100, 30);
            this.lbTotalPrice.TabIndex = 3;
            this.lbTotalPrice.Text = "Tổng tiền";
            this.lbTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(6, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(80, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = false;
            // 
            // pnlNumber
            // 
            this.pnlNumber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNumber.Controls.Add(this.btnRemove);
            this.pnlNumber.Controls.Add(this.btnAdd);
            this.pnlNumber.Controls.Add(this.lbNumber);
            this.pnlNumber.Location = new System.Drawing.Point(230, 0);
            this.pnlNumber.Name = "pnlNumber";
            this.pnlNumber.Size = new System.Drawing.Size(110, 30);
            this.pnlNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 8);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // TableLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.lbSinglePrice);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pnlNumber);
            this.Controls.Add(this.label1);
            this.Name = "TableLine";
            this.Size = new System.Drawing.Size(442, 35);
            this.pnlNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSinglePrice;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel pnlNumber;
        private System.Windows.Forms.Label label1;
    }
}
