using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Helper
{
    public partial class TabSelector : UserControl
    {
        string Lang = "vn";

        public event EventHandler SelectedTabChanged;
        public string SelectedTabKey
        {
            get
            {
                return SelectedButton.Name;
            }
        }
        Button SelectedButton;

        Color colorButtonSelected;
        public Color ColorButtonSelected
        {
            get => colorButtonSelected;
            set
            {
                colorButtonSelected = value;
                SelectedButton.BackColor = colorButtonSelected;
            }
        }
        public Color ColorButtonSelected_MouseOn;

        Color colorButonPressed;
        public Color ColorButtonPressed
        {
            get => colorButonPressed;
            set
            {
                colorButonPressed = value;
                foreach (Button btn in flowLayoutPanel1.Controls)
                {
                    btn.FlatAppearance.MouseDownBackColor = colorButonPressed;
                }
            }
        }
        Color colorButtonMouseOn;
        public Color ColorButtonMouseOn
        {
            get => colorButtonMouseOn;
            set
            {
                colorButtonMouseOn = value;
                foreach (Button btn in flowLayoutPanel1.Controls)
                {
                    btn.FlatAppearance.MouseOverBackColor = colorButtonMouseOn;
                }
                SelectedButton.FlatAppearance.MouseOverBackColor = ColorButtonSelected_MouseOn;
            }
        }
        public Color ColorButtonNormal = Color.Transparent;

        public TabSelector()
        {
            InitializeComponent();

            Language.ChangeLanguage += Language_ChangeLanguage;
            SelectedTabChanged = new EventHandler((s, e) => { });

            this.SizeChanged += TabSelector_SizeChanged;

            foreach (Button button in flowLayoutPanel1.Controls)
            {
                button.BackColor = ColorButtonNormal;
                button.FlatAppearance.MouseOverBackColor = ColorButtonMouseOn;
                button.FlatAppearance.MouseDownBackColor = ColorButtonPressed;
                button.Click += Button_Click;
            }

            SelectedButton = btnCashier;
            Button_Click(btnCashier, null);
        }

        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        public void SetLanguage()
        {
            LoadFont();
            Language.InitLanguage(this);
            btnCashier.Text = Language.Rm.GetString("Cashier", Language.Culture);
            btnHistory.Text = " " + Language.Rm.GetString("History", Language.Culture);
            btnManager.Text = Language.Rm.GetString("Manage", Language.Culture);
            btnStatistic.Text = " " + Language.Rm.GetString("Statistical", Language.Culture);
            btnVoucher.Text = " " + Language.Rm.GetString("Voucher", Language.Culture);
          
            foreach (Button btn in flowLayoutPanel1.Controls)
            {
                btn.Width = btn.Image.Width + 5 + GetTextWidth(btn);
            }
            this.Invalidate();
        }

        int GetTextWidth(Button btn)
        {
            return TextRenderer.MeasureText(btn.Text, btn.Font).Width;
        }

        public void CheckUser()
        {
            if (StoreAssistant_Authenticater.Authenticator.CurrentUser.Role != UserInfo.UserRole.Manager)
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(btnCashier);
            }
        }

        private void TabSelector_SizeChanged(object sender, EventArgs e)
        {
            foreach (Button button in flowLayoutPanel1.Controls)
            {
                button.Height = flowLayoutPanel1.Height;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Deselect(SelectedButton);

            SelectedButton = btn;

            Select(btn);
            // Throw event
            SelectedTabChanged(this, EventArgs.Empty);
        }

        void Select(Button button)
        {
            button.BackColor = ColorButtonSelected;
            button.FlatAppearance.MouseOverBackColor = ColorButtonSelected_MouseOn;
        }

        void Deselect(Button button)
        {
            button.BackColor = ColorButtonNormal;
            button.FlatAppearance.MouseOverBackColor = ColorButtonMouseOn;
        }

        public void LoadTheme()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.ForeColor = AppManager.GetColors("Main_Plaintext");
            }
            this.ColorButtonSelected = AppManager.GetColors("Tab_Selected");
            this.ColorButtonMouseOn = AppManager.GetColors("Tab_MouseOn");
            this.ColorButtonPressed = AppManager.GetColors("Tab_Clicked");
        }

        internal void LoadFont()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.Font = new Font(AppManager.GetPrivate_FontFamily("Gentium Book Basic"),
                                            control.Font.Size, control.Font.Style);
            }
        }
    }
}
