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
            }
        }
        public Color ColorButtonNormal = Color.Transparent;

        public TabSelector()
        {
            InitializeComponent();

            SelectedTabChanged = new EventHandler((s, e) => { });

            this.SizeChanged += TabSelector_SizeChanged;
            this.Load += TabSelector_Load;

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

        private void TabSelector_Load(object sender, EventArgs e)
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
    }
}
