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

        int seletedIndex;
        public int SelectedIndex
        {
            get => seletedIndex;
            set
            {
                if (value == seletedIndex) { return; }
                if (value > MaximumRange) { seletedIndex = MaximumRange; }
                else if (value < MinimumRange) { seletedIndex = MinimumRange; }
                else { seletedIndex = value; }
                
                txtPage.Text = string.Format("{0}/{1}", seletedIndex.ToString(), MaximumRange.ToString());
                
                btnFirst.Enabled = (seletedIndex != MinimumRange);
                btnPre.Enabled = btnFirst.Enabled;
                btnNxt.Enabled = (seletedIndex != MaximumRange);
                btnLast.Enabled = btnNxt.Enabled;
                
                SelectedIndexChanged(this, new EventArgs());
                Invalidate();
                Console.WriteLine("Select page " + SelectedIndex);
            }
        }

        private int maximumRange;
        public int MaximumRange
        {
            get => maximumRange;
            set
            {
                maximumRange = value;
                txtPage.Text = string.Format("{0}/{1}", seletedIndex.ToString(), MaximumRange.ToString());
                txtPage.Invalidate();
            }
        }
        public int MinimumRange;

        public event EventHandler SelectedIndexChanged;
        public PageSelector()
        {
            InitializeComponent();

            SelectedIndexChanged = new EventHandler((s, e) => { });

            seletedIndex = MinimumRange = 1;
            MaximumRange = 10;

            this.SizeChanged += PageSelector_SizeChanged;
            txtPage.MouseCaptureChanged += TxtPage_MouseCaptureChanged;
            txtPage.KeyDown += TxtPage_KeyDown1;
            txtPage.KeyPress += TxtPage_KeyPress;
            txtPage.KeyUp += TxtPage_KeyUp;

            btnFirst.Click += new EventHandler((s, e) => { SelectedIndex = MinimumRange; });
            AutoScale_ButtonImage(btnFirst);

            btnPre.Click += new EventHandler((s, e) => { SelectedIndex--; });
            AutoScale_ButtonImage(btnPre);

            btnNxt.Click += new EventHandler((s, e) => { SelectedIndex++; });
            AutoScale_ButtonImage(btnNxt);

            btnLast.Click += new EventHandler((s, e) => { SelectedIndex = MaximumRange; });
            AutoScale_ButtonImage(btnLast);
        }

        void AutoScale_ButtonImage(Button btn)
        {
            btn.SizeChanged += Btn_SizeChanged;
        }

        private void Btn_SizeChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Image temp = btn.Image;
            int bestSize = (btn.Height < btn.Width) ? btn.Height : btn.Width;
            btn.Image = new Bitmap(btn.Image, bestSize, bestSize );
            temp.Dispose();
        }

        private void TxtPage_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (txtPage.Focused)
            {
                txtPage.Text = SelectedIndex.ToString();

                txtPage.Select(txtPage.TextLength, 0); txtPage.Invalidate();
                txtPage.SelectAll();
            }
            else
            {
                SelectedIndex = seletedIndex;
            }
        }

        private void TxtPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isnonNumricalInput;
        }

        bool isnonNumricalInput = false;
        private void TxtPage_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                    {
                        if (e.KeyCode < Keys.Left || e.KeyCode > Keys.Down)
                        {
                            // It's non-numerical key down
                            Console.WriteLine("Non-numerical");
                            isnonNumricalInput = true;
                            return;
                        }
                    }
                }
            }
            isnonNumricalInput = false;
        }

        private void TxtPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedIndex = Int32.Parse(txtPage.Text);

                if (btnFirst.Enabled) { btnFirst.Focus(); }
                else { btnLast.Focus(); }
            }
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
