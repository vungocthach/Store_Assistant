using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace StoreAssitant
{
    public partial class TableControl : UserControl
    {
        public TableControl()
        {
            InitializeComponent();

            this.SizeChanged += TableControl_SizeChanged;
            table_Name.TextChanged += Table_Name_TextChanged;

            table_Image.MouseEnter += TableControl_MouseEnter;
            table_Name.MouseEnter += TableControl_MouseEnter;
            this.MouseEnter += TableControl_MouseEnter;

            table_Image.MouseLeave += TableControl_MouseLeave;
            table_Name.MouseLeave += TableControl_MouseLeave;
            this.MouseLeave += TableControl_MouseLeave;

            table_Image.MouseDown += TableControl_MouseDown;
            table_Name.MouseDown += TableControl_MouseDown;
            this.MouseDown += TableControl_MouseDown;

            table_Image.MouseUp += TableControl_MouseUp;
            table_Name.MouseUp += TableControl_MouseUp;
            this.MouseUp += TableControl_MouseUp;

            this.MouseClick += TableControl_MouseClick;
            table_Image.MouseClick += TableControl_MouseClick;
            table_Name.MouseClick += TableControl_MouseClick;

            this.MinimumSize = new Size(table_Name.Size.Width, table_Name.Size.Height * 4);
            table_Name.Location = new Point((this.Size.Width - table_Name.Size.Width) / 2, (this.Size.Height + table_Image.Height - table_Name.Size.Height) / 2);

        }
        public void setData(TableControlInfor Infor)
        {
            table_Name.Text = Infor.Table_name;
            table_Image.BackgroundImage = Infor.Table_image;
        }

        private void TableControl_MouseClick(object sender, MouseEventArgs e)
        {
            TableView link;
            Control parent = this.Parent as UserControl;
            if (parent==null)
            {
                link = this.Parent.Parent as TableView;
            } else
            {
                link = parent.Parent.Parent as TableView;
            }
            if (link != null) link.on_btnTableClick();
        }

        #region EVENT MOUSE
        private void TableControl_MouseEnter(object sender, EventArgs e)
        {
            table_Image.BackColor = this.BackColor = System.Drawing.SystemColors.Window;
            Invalidate();
        }
        private void TableControl_MouseLeave(object sender, EventArgs e)
        {
            table_Image.BackColor = this.BackColor = Color.PapayaWhip;
        }
        private void TableControl_MouseDown(object sender, EventArgs e)
        {
            table_Image.BackColor = this.BackColor = Color.LightSalmon;
        }
        private void TableControl_MouseUp(object sender, EventArgs e)
        {
            TableControl_MouseEnter(this, e);
        }
        #endregion

        #region EVENT CHANGE
        private void Table_Name_TextChanged(object sender, EventArgs e)
        {
            table_Name.Location = new Point((this.Size.Width - table_Name.Size.Width) / 2, (this.Size.Height + table_Image.Height - table_Name.Size.Height) / 2);
        }

        private void TableControl_SizeChanged(object sender, EventArgs e)
        {
            table_Image.Size = new Size(this.Size.Width, this.Size.Height * 3 / 4);
            table_Name.Location = new Point((this.Size.Width - table_Name.Size.Width) / 2, (this.Size.Height + table_Image.Height - table_Name.Size.Height) / 2);
        }
        #endregion

        #region SETTING PROPERTIES
        [Category("My properties"), Description("Change Name of table")]
        public string nameTable
        {
            get => table_Name.Text;
            set
            {
                table_Name.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change Image of table")]
        public Image imageTable
        {
            get => table_Image.BackgroundImage;
            set
            {
                table_Image.BackgroundImage = value;
                Invalidate();
            }
        }
        #endregion
    }
    public class TableControlInfor
    {
        public string Table_name;
        public Image Table_image;
    }
}
