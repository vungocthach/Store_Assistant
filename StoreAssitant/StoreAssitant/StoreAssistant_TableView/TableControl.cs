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
using StoreAssitant.Class_Information;

namespace StoreAssitant
{
    public partial class TableControl : UserControl
    {
        public enum status { Empty, Using };
        #region CREATE EVENTS
        [Category("My Event"),Description("When click the table control")]
        public event EventHandler ClickTableControl;
        void OnClickTableControl(object sender, EventArgs e) { }
        [Category("My Event"), Description("When the table control is removed")]
        public event EventHandler TableRemoved;
        void OnTableRemoved(object sender, EventArgs e) { }
        #endregion


        #region SETTING FIELDS
        public TableBillInfo Info;
        private status sta;
        private Color defaultColor;
        private bool isManager;
        #endregion


        public TableControl()
        {
            InitializeComponent();

            this.Info = new TableBillInfo();

            Init_Event_Available();
            Init_Event_ToolStrip();

            Init_DefautValue();
        }

        /// <summary>
        /// Init when form is creating
        /// </summary>
        #region Init Form
        private void Init_Event_Available()
        {
            //Event customize
            ClickTableControl = new EventHandler(OnClickTableControl);
            TableRemoved = new EventHandler(OnTableRemoved);

            //Event available in form
            this.SizeChanged += TableControl_SizeChanged;
            tableName_lb.TextChanged += Table_Name_TextChanged;

            tableImage_pnl.MouseEnter += TableControl_MouseEnter;
            tableName_lb.MouseEnter += TableControl_MouseEnter;
            this.MouseEnter += TableControl_MouseEnter;

            tableImage_pnl.MouseLeave += TableControl_MouseLeave;
            tableName_lb.MouseLeave += TableControl_MouseLeave;
            this.MouseLeave += TableControl_MouseLeave;

            tableImage_pnl.MouseDown += TableControl_MouseDown;
            tableName_lb.MouseDown += TableControl_MouseDown;
            this.MouseDown += TableControl_MouseDown;

            tableImage_pnl.MouseUp += TableControl_MouseUp;
            tableName_lb.MouseUp += TableControl_MouseUp;
            this.MouseUp += TableControl_MouseUp;

            this.MouseClick += TableControl_MouseClick;
            tableImage_pnl.MouseClick += TableControl_MouseClick;
            tableName_lb.MouseClick += TableControl_MouseClick;
        }
        private void Init_Event_ToolStrip()
        {
            tsDelete.Click += TsDelete_Click;
        }
        private void Init_DefautValue()
        {
            this.MinimumSize = new Size(tableName_lb.Size.Width, tableName_lb.Size.Height * 4);
            tableName_lb.Location = new Point((this.Size.Width - tableName_lb.Size.Width) / 2, (this.Size.Height + tableImage_pnl.Height - tableName_lb.Size.Height) / 2);

            Status = status.Empty;
        }
        #endregion


        /// <summary>
        /// Create event for tool strip menu
        /// </summary>
        #region EVENTS TOOL STRIP
        private void TsDelete_Click(object sender, EventArgs e)
        {
            TableRemoved(this, e);
            GC.SuppressFinalize(this);
        }
        #endregion


        /// <summary>
        /// Create events mouse for table control
        /// </summary>
        #region EVENT MOUSE
        private void TableControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) ClickTableControl(this, e);
        }
        private void TableControl_MouseEnter(object sender, EventArgs e)
        {
            tableImage_pnl.BackColor = this.BackColor = System.Drawing.SystemColors.Window;
        }
        private void TableControl_MouseLeave(object sender, EventArgs e)
        {
            tableImage_pnl.BackColor = this.BackColor = defaultColor;
        }
        private void TableControl_MouseDown(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left) tableImage_pnl.BackColor = this.BackColor = Color.LightSalmon;
        }
        private void TableControl_MouseUp(object sender, EventArgs e)
        {
            tableImage_pnl.BackColor = this.BackColor = System.Drawing.SystemColors.Window;
        }
        #endregion


        #region EVENT CHANGE
        private void Table_Name_TextChanged(object sender, EventArgs e)
        {
            tableName_lb.Location = new Point((this.Size.Width - tableName_lb.Size.Width) / 2, (this.Size.Height + tableImage_pnl.Height - tableName_lb.Size.Height) / 2);
        }

        private void TableControl_SizeChanged(object sender, EventArgs e)
        {
            tableImage_pnl.Size = new Size(this.Size.Width, this.Size.Height * 3 / 4);
            tableName_lb.Location = new Point((this.Size.Width - tableName_lb.Size.Width) / 2, (this.Size.Height + tableImage_pnl.Height - tableName_lb.Size.Height) / 2);
        }
        #endregion


        #region SETTING PROPERTIES
        [Category("My properties"), Description("Change Name of table")]
        public string NameTable
        {
            get => tableName_lb.Text;
            set
            {
                tableName_lb.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change Image of table")]
        public Image ImageTable
        {
            get => tableImage_pnl.BackgroundImage;
            set
            {
                if (tableImage_pnl.BackgroundImage != null) tableImage_pnl.BackgroundImage.Dispose();
                tableImage_pnl.BackgroundImage = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Check is manager?")]
        public bool IsManager
        {
            get => isManager;
            set
            {
                tsDelete.Visible =  isManager = value;
            }
        }
        [Category("My properties"), Description("The status of table")]
        public status Status
        {
            get => sta;
            set
            {
                sta = value;
                switch(sta)
                {
                    case status.Empty:
                        defaultColor = Color.PapayaWhip;
                        tableImage_pnl.BackColor = this.BackColor = defaultColor;
                        break;
                    case status.Using:
                        defaultColor = Color.Cyan;
                        tableImage_pnl.BackColor = this.BackColor = defaultColor;
                        break;
                }
            }
        }
        #endregion
    }
}
