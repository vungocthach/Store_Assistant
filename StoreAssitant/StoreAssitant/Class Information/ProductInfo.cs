using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    public class ProductInfo
    {
        public Image Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder buider = new StringBuilder();
            if (Image == null) { buider.Append("Image : null").AppendLine(); }
            else { buider.Append("Image : ").Append(Image.ToString()).AppendLine(); }
            buider.Append("Name : ").Append(Name).AppendLine();
            buider.Append("Price : ").Append(Price).AppendLine();
            buider.Append("Tags : ");
            foreach (string str in Tags)
            {
                buider.AppendLine(str);
            }
            buider.Append("Description : ").Append(Description).AppendLine();
            return buider.ToString();
        }
    }
}
