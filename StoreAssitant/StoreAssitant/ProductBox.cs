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

namespace StoreAssitant
{
    public partial class ProductBox : UserControl
    {

        [Category("My Properties"), Description("Image of product")]
        public Image PDImage
        {
            get { return label_Image.Image; }
            set
            {
                label_Image.Image = value;
                ResizeImage();
                Invalidate();
            }
        }

        [Category("My Properties"), Description("Image of product")]
        public int PDPrice
        {
            get { return int.Parse(txtb_Price.Text.Trim()); }
            set
            {
                txtb_Price.Text = value.ToString();
                Invalidate();
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

        public char SeperateCharacter;

        [Category("My Properties"), Description("Array of tags about product")]
        public string[] PDTags
        {
            get { return ThunderStudio.TSString.SeperateString(txtb_Tag.Text.Trim(), this.SeperateCharacter); }
            set
            {
                StringBuilder builder = new StringBuilder();
                foreach (string str in value)
                {
                    builder.Append(str);
                    builder.Append(SeperateCharacter);
                }
                txtb_Tag.Text = builder.ToString();
            }
        }

        public ProductBox()
        {
            InitializeComponent();

            SeperateCharacter = ';';

            label_Image.Click += new EventHandler((object sender, EventArgs e) => {
                string path = GetPath();
                if (path != null && File.Exists(path))
                {
                    this.PDImage = Image.FromFile(path);
                }
            });

            txtb_Name.TextChanged += Name_UpdateChanged;
            txtb_Price.TextChanged += Price_UpdateChanged;
            txtb_Tag.TextChanged += Tag_UpdateChanged;

            toolTip_Name.ToolTipIcon = ToolTipIcon.Error;
            toolTip_Price.ToolTipIcon = ToolTipIcon.Error;
            toolTip_Tag.ToolTipIcon = ToolTipIcon.Error;
            toolTip_Des.ToolTipIcon = ToolTipIcon.Error;

            txtb_Name.Tag = pb_Err_Name;
            pb_Err_Name.Tag = toolTip_Name;
            txtb_Price.Tag = pb_Err_Price;
            pb_Err_Price.Tag = toolTip_Price;
            txtb_Tag.Tag = pb_Err_Tag;
            pb_Err_Tag.Tag = toolTip_Tag;
            txtb_Description.Tag = pb_Err_Des;
            pb_Err_Des.Tag = toolTip_Des;

            this.SizeChanged += ProductBox_SizeChanged;
        }

        public bool FullCheck()
        {
            Name_UpdateChanged(txtb_Name, null);
            Price_UpdateChanged(txtb_Price, null);
            Tag_UpdateChanged(txtb_Tag, null);

            if (pb_Err_Des.Visible || pb_Err_Name.Visible 
                || pb_Err_Price.Visible || pb_Err_Tag.Visible)
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

            pb_Err_Name.Location = new Point(this.Width - pb_Err_Name.Width - 5,
                                                txtb_Name.Location.Y + (txtb_Name.Height - pb_Err_Name.Height) / 2);
            pb_Err_Price.Location = new Point(this.Width - pb_Err_Price.Width - 5,
                                                txtb_Price.Location.Y + (txtb_Price.Height - pb_Err_Price.Height) / 2);
            pb_Err_Tag.Location = new Point(this.Width - pb_Err_Tag.Width - 5,
                                                txtb_Tag.Location.Y + (txtb_Tag.Height - pb_Err_Tag.Height) / 2);
            
            txtb_Name.Width = pb_Err_Name.Location.X - txtb_Name.Location.X - 5;
            txtb_Price.Width = pb_Err_Price.Location.X - txtb_Price.Location.X - 5;
            txtb_Tag.Width = pb_Err_Tag.Location.X - txtb_Tag.Location.X - 5;

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
                string message = string.Format("Chỉ nhập chữ cái thường, số và khoảng trắng{0}Phân cách giữa các tag bằng dấu chấm phẩy ';'", Environment.NewLine);
                SetErrorState(txtb, message, "Lỗi nhập");
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
                string message = "Đây là thông tin bắt buộc.";
                SetErrorState(txtb, message, "Không thể để trống");
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
                string message = "Vui lòng không nhập các kí tự đặc biệt";
                SetErrorState(txtb, message, "Lỗi nhập");
            }
            else if (txtb.Text.Length > 50)
            {
                string message = "Vui lòng nhập tên có độ dài ngắn hơn 50 kí tự";
                SetErrorState(txtb, message, "Lỗi nhập");
            }
            else if (txtb.Text == string.Empty)
            {
                string message = "Đây là thông tin bắt buộc";
                SetErrorState(txtb, message, "Không thể để trống");
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
                    string message = "Đây là thông tin bắt buộc";
                    SetErrorState(txtb, message, "Không thể để trống");
                }
                else
                {
                    int.Parse(txtb.Text);
                    RemoveErrorState(txtb);
                }
            }
            catch (FormatException)
            {
                string message = "Vui lòng chỉ nhập số nguyên dương";
                SetErrorState(txtb, message, "Lỗi nhập");
            }
            catch (OverflowException)
            {
                string message = string.Format("Vui lòng nhập giá trị từ 0 đến {0}", int.MaxValue);
                SetErrorState(txtb, message, "Lỗi nhập");
            }
        }

        private void ResizeImage()
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
                label_Image.Text = "Chọn hình ảnh" + Environment.NewLine + "(+)";
            }
        }
        private string GetPath()
        {
            string rs = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image File (*.img, *.bmp, *.jpg)|*.img;*.bmp;*.jpg";
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
