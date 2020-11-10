using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_HistoryView
{
    public partial class PageSelector : UserControl
    {
        public Size PageBoxSize
        {
            get => txtPage.Size;
            set
            {
                txtPage.Size = value;
                RePosition();
                Invalidate();
            }
        }

        public Font PageBoxFont
        {
            get => txtPage.Font;
            set
            {
                txtPage.Font = value;
                RePosition();
                Invalidate();
            }
        }

        public Padding PageBoxMargin
        {
            get => txtPage.Margin;
            set
            {
                txtPage.Margin = value;
                RePosition();
                Invalidate();
            }
        }

        public Padding ButtonFirstMargin
        {
            get => btnFirst.Margin;
            set
            {
                btnFirst.Margin = value;
                RePosition();
                Invalidate();
            }
        }

        public Padding ButtonPreviousMargin
        {
            get => btnPre.Margin;
            set
            {
                btnPre.Margin = value;
                RePosition();
                Invalidate();
            }
        }

        public Padding ButtonNextMargin
        {
            get => btnNxt.Margin;
            set
            {
                btnNxt.Margin = value;
                RePosition();
                Invalidate();
            }
        }

        public Padding ButtonLastMargin
        {
            get => btnLast.Margin;
            set
            {
                btnLast.Margin = value;
                RePosition();
                Invalidate();
            }
        }
        public PageSelector()
        {
            InitializeComponent();

            this.SizeChanged += PageSelector_SizeChanged;
        }

        private void PageSelector_SizeChanged(object sender, EventArgs e)
        {
            RePosition();
        }

        void RePosition()
        {
            txtPage.Location = new Point((this.Width - txtPage.Width) / 2, (this.Height - txtPage.Height) /2);

            SetSize_WithMargin(btnFirst, txtPage.Location.X / 2, this.Height);
            btnFirst.Location = new Point(btnFirst.Margin.Left, btnFirst.Margin.Top);

            SetSize_WithMargin(btnPre, txtPage.Location.X / 2, this.Height);
            btnPre.Location = new Point(txtPage.Location.X / 2 + btnPre.Margin.Left, btnPre.Margin.Top);

            int startFrom = txtPage.Location.X + txtPage.Width;
            int spaceLeft = this.Width - startFrom;

            SetSize_WithMargin(btnNxt, spaceLeft/2, this.Height);
            btnNxt.Location = new Point(startFrom + btnNxt.Margin.Left, btnNxt.Margin.Top);

            SetSize_WithMargin(btnLast, spaceLeft / 2, this.Height);
            btnLast.Location = new Point(startFrom + spaceLeft /2 + btnLast.Margin.Left, btnLast.Margin.Top);
        }

        void SetSize_WithMargin(Control control, int width, int height)
        {
            control.Size = new Size(width - control.Margin.Left - control.Margin.Right, height - control.Margin.Top - control.Margin.Bottom);
        }
    }
}
