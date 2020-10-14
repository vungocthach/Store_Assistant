using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class MenuControl : UserControl
    {
        ProductInfo Infor;
        #region create event Click_AddControlProduct, Click_Delete

        public event EventHandler CLick_Delete;

        private void onCLick_Delete(object sender, EventArgs e)
        {

        }
        public event EventHandler Click_AddControlProduct;

        private void on_Click_AddControlProduct(object sender, EventArgs e)
        { }
        #endregion
        #region Create properties
        [Category("My Properties"), Description("Name of Title")]
        public string NameTitle
        {
            get => textBoxName.Name;
            set
            {
                Name = value;
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Inmage of Menu title ")]
        public Image image
        {
            get => pictureBox.BackgroundImage;
            set
            {
                pictureBox.BackgroundImage = value;
                Invalidate();
            }
        }

#endregion
        public void SetData(ProductInfo info)
        {
            Infor = info;
            textBoxName.Text = info.Name;
            textBoxPrice.Text = Convert.ToString( info.Price);
            if (info.Image != null) pictureBox.Image = info.Image;
        }
        
        public MenuControl()
        {
            InitializeComponent();

            // this.MinimumSize = new Size(125, 140);

            CLick_Delete += new EventHandler(onCLick_Delete);
            Click_AddControlProduct = new EventHandler(on_Click_AddControlProduct);

            this.Layout += MenuControl_Layout;

            this.Click += MenuControl_Click;

            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            #region MouseClick_Control

            pictureBox.MouseClick += _MouseClick;
            textBoxName.MouseClick += _MouseClick;
            textBoxPrice.MouseClick += _MouseClick;
            #endregion

            #region Click_Control
            pictureBox.Click += pictureBox_Click;
            textBoxName.Click += TextBoxName_Click;
            textBoxPrice.Click += TextBoxPrice_Click;
            #endregion
           
            #region MouseHover_Control

            pictureBox.MouseHover += MenuControl_MouseHover;
            textBoxName.MouseHover += MenuControl_MouseHover;
            textBoxPrice.MouseHover += MenuControl_MouseHover;
            #endregion

            #region MouseLeave_Control

            pictureBox.MouseLeave += MenuControl_MouseLeave;
            textBoxPrice.MouseLeave += MenuControl_MouseLeave;
            textBoxName.MouseLeave += MenuControl_MouseLeave;
            #endregion
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CLick_Delete(this, e);
        }

        private void _MouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void MenuControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.PapayaWhip;
            textBoxName.Size -= new Size (0, 2);
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void MenuControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            textBoxName.Size += new Size(0, 2);
            this.BorderStyle = BorderStyle.None;
        }

        private void MenuControl_Click(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        private void TextBoxPrice_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void MenuControl_Layout(object sender, EventArgs e)
        {
            pictureBox.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.6));
            textBoxPrice.Location = new Point(0, pictureBox.Height);
            textBoxName.Location = new Point(0, pictureBox.Height + textBoxPrice.Height);
            textBoxName.Size = textBoxPrice.Size = new Size(this.Width, (this.Height - pictureBox.Height)/2);
        }

        private void textBoxName_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_Click_1(object sender, EventArgs e)
        {

        }

        private void MenuControl_Load(object sender, EventArgs e)
        {

        }
    }
}
