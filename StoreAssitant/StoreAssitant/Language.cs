using StoreAssitant.StoreAssistant_AccountView;
using StoreAssitant.StoreAssistant_VoucherView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
     static public class Language
    {
        static private CultureInfo culture;
        static private string cultureName = "vn";
        static private ResourceManager rm;

        static public CultureInfo Culture { get => culture; set => culture = value; }
        static public string CultureName { get => cultureName; set => cultureName = value; }
        static public ResourceManager Rm { get => rm; set => rm = value; }
        static public void InitLanguage(object type)
        {
            Type T = type.GetType();
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            Rm = new
                ResourceManager("StoreAssitant.string", T.Assembly);
        }        
    }
}
