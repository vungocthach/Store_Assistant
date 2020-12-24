using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Markup;
using System.Drawing.Imaging;
using StoreAssitant.StoreAssistant_VoucherView;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant
{
    public partial class ProductBox : UserControl
    {
        private string Lang = "vn";
        private string Chosse = "Chọn hình ảnh";
        private string Wanrning = "Vui lòng chọn ảnh có kích thước < 26kb";
        private string bigfile = "File quá lớn";
        private string Onlychar = "Chỉ nhập chữ cái thường, số và khoảng trắng{0}Phân cách giữa các tag bằng dấu chấm phẩy ';'";
        private string EnterError = "Lỗi nhập";
        private string RequireInfo = "Đây là thông tin bắt buộc";
        private string NoEmpty = "Không để trống";
        private string NoSpecialChar = "Vui lòng không nhập các kí tự đặc biệt";
        private String Require_50_Char = "Vui lòng nhập tên có độ dài ngắn hơn 50 kí tự";
        private string Require_300_Char = "Vui lòng nhập phần mô tả có độ dài ngắn hơn 300 kí tự";
        private string PlusChar= "Vui lòng chỉ nhập số nguyên dương";
        private string Enter_From = "Vui lòng nhập giá trị từ 0 đến";


        [Category("My Properties"), Description("Image of product")]
        public Bitmap PDImage
        {
            get { if (label_Image.Image == null) { return null; } else { return (Bitmap)label_Image.Image; } }
            set
            {
                if (value == null)
                {
                    // Draw default image
                    label_Image.Image = null;
                    label_Image.Text = Chosse + Environment.NewLine + "(+)";
                    return;
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(value, label_Image.Size);
                    bmp.Save(memoryStream, ImageFormat.Jpeg);

                    if (memoryStream.Length > 25000)
                    {
                        MessageBox.Show(Wanrning,bigfile, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (label_Image.Image == null) { label_Image.Text = string.Empty; }
                        label_Image.Image = bmp;
                    }
                }
                Invalidate();
            }
        }

        int price = 1200;
        [Category("My Properties"), Description("Image of product")]
        public int PDPrice
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    textBoxPrice.Text = string.Format("{0}VND", value.ToString("N0"));
                    txtb_Price.Text = value.ToString("N0");
                    txtb_Price.Select(txtb_Price.TextLength, 0);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Should use SetCustomProductName/GetCustomProductName instead
        /// </summary>
        [Category("My Properties"), Description("Name of product")]
        public string PDName
        {
            get { return GetPDName(); }
            set { SetPDName(value); }
        }


        /// <summary>
        /// Get name of the product item
        /// </summary>
        public string GetPDName() { return txtb_Name.Text; }

        /// <exception cref = "InvalidNameException">Thrown when string-name contains invalid character</exception>
        /// <summary>
        /// Set name of the product item
        /// </summary>
        public void SetPDName(string value)
        {
            txtb_Name.Text = value.Trim();
            Invalidate();
        }

        [Category("My Properties"), Description("Text of description about product")]
        public string PDDescription
        {
            get { return txtb_Description.Text; }
            set
            {
                txtb_Description.Text = value.Trim();
            }
        }

        public bool IsReadOnlyPDName { get { return txtb_Name.ReadOnly; }set { txtb_Name.ReadOnly = value; } }
        public bool IsReadOnlyPDPrice { get { return txtb_Price.ReadOnly; } set { txtb_Price.ReadOnly = value; } }

        public ProductBox()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;

            label_Image.Click += new EventHandler((object sender, EventArgs e) => {
                string path = GetPath();
                if (path != null && File.Exists(path))
                {
                    this.PDImage = new Bitmap(path);
                }
            });

            txtb_Name.TextChanged += Name_UpdateChanged;
            txtb_Price.TextChanged += Price_UpdateChanged;
            txtb_Description.TextChanged += Description_UpdateChanged;

            toolTip_Name.ToolTipIcon = ToolTipIcon.Error;
            toolTip_Price.ToolTipIcon = ToolTipIcon.Error;
            toolTip_Des.ToolTipIcon = ToolTipIcon.Error;

            txtb_Name.Tag = pb_Err_Name;
            pb_Err_Name.Tag = toolTip_Name;
            txtb_Price.Tag = pb_Err_Price;
            pb_Err_Price.Tag = toolTip_Price;
            txtb_Description.Tag = pb_Err_Des;
            pb_Err_Des.Tag = toolTip_Des;

            this.SizeChanged += ProductBox_SizeChanged;

            textBoxPrice.SizeChanged += TextBoxPrice_SizeChanged;
            label_Image.LocationChanged += TextBoxPrice_SizeChanged;
            label_Image.SizeChanged += TextBoxPrice_SizeChanged;
 
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            label_Image.Text = Language.Rm.GetString("Add picture", Language.Culture);
            label1.Text = Language.Rm.GetString("PDName", Language.Culture);
            label2.Text = Language.Rm.GetString("Price:", Language.Culture);
            label4.Text = Language.Rm.GetString("Detailed description:", Language.Culture);
            Wanrning = Language.Rm.GetString("Wanrning", Language.Culture);
            bigfile = Language.Rm.GetString("bigfile", Language.Culture);
            Onlychar = Language.Rm.GetString("Onlychar", Language.Culture);
            EnterError = Language.Rm.GetString("EnterError", Language.Culture);
            RequireInfo = Language.Rm.GetString("RequireInfo", Language.Culture);
            NoEmpty = Language.Rm.GetString("NoEmpty", Language.Culture);
            NoSpecialChar = Language.Rm.GetString("NoSpecialChar", Language.Culture);
            Require_50_Char = Language.Rm.GetString("Require_50_Char", Language.Culture);
            Require_300_Char = Language.Rm.GetString("Require_300_Char", Language.Culture);
            PlusChar = Language.Rm.GetString("PlusChar", Language.Culture);
            Enter_From = Language.Rm.GetString("Enter_From", Language.Culture);
            Chosse = Language.Rm.GetString("Chosse", Language.Culture);
        }
        private void TextBoxPrice_SizeChanged(object sender, EventArgs e)
        {
            textBoxPrice.Location = new Point(label_Image.Location.X + label_Image.Width - textBoxPrice.Width, label_Image.Location.Y + label_Image.Height - textBoxPrice.Height);
        }

        public bool FullCheck()
        {
            Name_UpdateChanged(txtb_Name, null);
            Price_UpdateChanged(txtb_Price, null);

            if (pb_Err_Des.Visible || pb_Err_Name.Visible 
                || pb_Err_Price.Visible )
            {
                return false;
            }
            return true;
        }

        private void SetErrorState(Control control, string message, string title)
        {
            Control error_image = (Control)control.Tag;
            ToolTip toolTip = (ToolTip)error_image.Tag;

            if (message != null)
            {
                error_image.Visible = true;

                toolTip.RemoveAll();
                toolTip.ToolTipTitle = title;
                toolTip.SetToolTip(error_image, message);

                control.BackColor = Color.LightPink;
            }
            else
            {
                throw new NullReferenceException("Variable message must not null");
            }
        }

        private void RemoveErrorState(Control control)
        {
            Control error_image = (Control)control.Tag;
            ToolTip toolTip = (ToolTip)error_image.Tag;

            error_image.Visible = false;

            control.BackColor = Color.White;
        }

        private void ProductBox_SizeChanged(object sender, EventArgs e)
        {
            AutoCenterOnParent_SizeChanged(label_Image);

            textBoxPrice.Location = new Point(label_Image.Location.X + (label_Image.Width - textBoxPrice.Width), label_Image.Location.Y + (label_Image.Height - textBoxPrice.Height));

            pb_Err_Name.Location = new Point(this.Width - pb_Err_Name.Width - 5,
                                                txtb_Name.Location.Y + (txtb_Name.Height - pb_Err_Name.Height) / 2);
            pb_Err_Price.Location = new Point(this.Width - pb_Err_Price.Width - 5,
                                                txtb_Price.Location.Y + (txtb_Price.Height - pb_Err_Price.Height) / 2);

            txtb_Name.Width = pb_Err_Name.Location.X - txtb_Name.Location.X - 5;
            txtb_Price.Width = this.Height - txtb_Price.Location.X - (this.Height - lb_currency.Location.X) - 5;

            txtb_Description.Height = this.Height - txtb_Description.Location.Y - 5;
            txtb_Description.Width = this.Width - txtb_Description.Location.X * 2;
        }

        private void AutoCenterOnParent_SizeChanged(Control target)
        {
            target.Location = new Point((target.Parent.Width - target.Width) / 2, target.Location.Y);
        }

        private void Tag_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            if (!ThunderStudio.TSString.IsMadeFrom(txtb.Text, "0123456789qwertyuiopasdfghjklzxcvbnm; "))
            {
                string message = string.Format(Onlychar, Environment.NewLine);
                SetErrorState(txtb, message, EnterError);
            }
            else
            {
                RemoveErrorState(txtb);
            }

        }

        private void Txtb_CheckEmpty(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            if (txtb.Text == string.Empty)
            {
                string message = RequireInfo;
                SetErrorState(txtb, message, NoEmpty);
            }
            else
            {
                RemoveErrorState(txtb);
            }
        }

        private void Name_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            if (ThunderStudio.TSString.ContainAnyCharacterOf(txtb.Text, ("{}[]();.,><?/*&^%$#@!`~|\\")))
            {
                string message = NoSpecialChar;
                SetErrorState(txtb, message, EnterError);
            }
            else if (txtb.Text.Length > 50)
            {
                string message = Require_50_Char;
                SetErrorState(txtb, message, EnterError);
            }
            else if (txtb.Text == string.Empty)
            {
                string message = RequireInfo;
                SetErrorState(txtb, message, NoEmpty);
            }
            else
            {
                RemoveErrorState(txtb);
            }
        }

        private void Description_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;

            if (txtb.Text.Length > 300)
            {
                string message = Require_300_Char;
                SetErrorState(txtb, message, EnterError);
            }
            else
            {
                RemoveErrorState(txtb);
            }
        }

        private void Price_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            try
            {
                
                if (txtb.Text.Trim() == string.Empty)
                {
                    string message = RequireInfo;
                    SetErrorState(txtb, message, NoEmpty);
                }
                else
                {
                    PDPrice = int.Parse(txtb.Text, System.Globalization.NumberStyles.AllowThousands);
                    RemoveErrorState(txtb);
                }
            }
            catch (FormatException)
            {
                string message = PlusChar;
                SetErrorState(txtb, message, EnterError);
            }
            catch (OverflowException)
            {
                string message = string.Format(Enter_From + "{0}", int.MaxValue.ToString("N0"));
                SetErrorState(txtb, message, EnterError);
            }
        }

        private void ResizeImage(ref Image target)
        {
            if (label_Image.Image != null )
            {
                label_Image.Text = string.Empty;
                Bitmap bmp = new Bitmap(label_Image.Image, label_Image.Size);
                label_Image.Image = bmp;
            }
            else
            {
                // Draw default image
                label_Image.Text =Chosse  + Environment.NewLine + "(+)";
            }
        }
        private string GetPath()
        {
            string rs = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = Chosse;
            openFileDialog.Filter = "Image File (*.img, *.bmp, *.jpg, *.png)|*.img;*.bmp;*.jpg;*.png";
            openFileDialog.FileOk += new CancelEventHandler((object sender, CancelEventArgs e) =>
            {
                if (openFileDialog.CheckFileExists)
                {
                    rs = openFileDialog.FileName;
                }
            });
            openFileDialog.ShowDialog();
            return rs;
        }

        
    }

    
}
