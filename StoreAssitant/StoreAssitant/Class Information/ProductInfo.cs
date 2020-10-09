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
        public int Id { get; set; }
        public Image Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public ProductInfo()
        {
            Id = 0;
            Image = null;
            Name = "productName";
            Price = 0;
            Description = string.Empty;
        }

        public ProductInfo(int id, string name, int price, string description, Image img = null)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Image = img;
        }

        public override string ToString()
        {
            StringBuilder buider = new StringBuilder();
            if (Image == null) { buider.Append("Image : null").AppendLine(); }
            else { buider.Append("Image : ").Append(Image.ToString()).AppendLine(); }
            buider.Append("Name : ").Append(Name).AppendLine();
            buider.Append("Price : ").Append(Price).AppendLine();
            buider.Append("Description : ").Append(Description).AppendLine();
            return buider.ToString();
        }
    }
}
