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
            Table_Image.MouseEnter += TableControl_MouseEnter;
            Table_Name.MouseEnter += TableControl_MouseEnter;
            this.MouseEnter += TableControl_MouseEnter;

            Table_Image.MouseLeave += TableControl_MouseLeave;
            Table_Name.MouseLeave += TableControl_MouseLeave;
            this.MouseLeave += TableControl_MouseLeave;

            Table_Image.MouseDown += TableControl_MouseDown;
            Table_Name.MouseDown += TableControl_MouseDown;
            this.MouseDown += TableControl_MouseDown;

            Table_Image.MouseUp += TableControl_MouseUp;
            Table_Name.MouseUp += TableControl_MouseUp;
            this.MouseUp += TableControl_MouseUp;

            this.MouseClick += TableControl_MouseClick;
            Table_Image.MouseClick += TableControl_MouseClick;
            Table_Name.MouseClick += TableControl_MouseClick;
            this.MinimumSize = new Size(Table_Name.Size.Width, Table_Name.Size.Height * 4);
        }
        //private dynamic link2 = null;
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

        private void TableControl_MouseEnter(object sender, EventArgs e)
        {
            Table_Image.BackColor = this.BackColor = System.Drawing.SystemColors.Window;
            Invalidate();
        }
        private void TableControl_MouseLeave(object sender, EventArgs e)
        {
            Table_Image.BackColor = this.BackColor = Color.PapayaWhip;
        }
        private void TableControl_MouseDown(object sender, EventArgs e)
        {
            Table_Image.BackColor = this.BackColor = Color.LightSalmon;
        }
        private void TableControl_MouseUp(object sender, EventArgs e)
        {
            TableControl_MouseEnter(this, e);
        }

        public void setData(TableControlInfor Infor)
        {
            Table_Name.Text = Infor.Table_name;
            Table_Image.BackgroundImage = Infor.Table_image;
        }

        private void TableControl_SizeChanged(object sender, EventArgs e)
        {
            Table_Image.Size = new Size(this.Size.Width, this.Size.Height * 3 / 4);
            Table_Name.Location = new Point((this.Size.Width - Table_Name.Size.Width) / 2, (this.Size.Height + Table_Image.Height - Table_Name.Size.Height) / 2);
        }

        [Category("My properties"), Description("Change Name of table")]
        public string nameTable
        {
            get => Table_Name.Text;
            set
            {
                Table_Name.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change Image of table")]
        public Image imageTable
        {
            get => Table_Image.BackgroundImage;
            set
            {
                Table_Image.BackgroundImage = value;
                Invalidate();
            }
        }
    }
    public class TableControlInfor
    {
        public string Table_name;
        public Image Table_image;
    }
}
