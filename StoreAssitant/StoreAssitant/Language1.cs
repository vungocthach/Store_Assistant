using StoreAssitant.StoreAssistant_Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
namespace StoreAssitant
{
    public static class Language
    {
        static private CultureInfo culture;
        //static private string cultureName = "vn";
        static private ResourceManager rm;
        public static void onChangeLanguage(string typelang)
        {
            ChangeLanguage?.Invoke(null, typelang);
        }
        public static event EventHandler<string> ChangeLanguage = new EventHandler<string>((s,e)=> { });

        static public CultureInfo Culture { get => culture; set => culture = value; }
        //static public string CultureName { get => cultureName; set => cultureName = value; }
        static public ResourceManager Rm { get => rm; set => rm = value; }
        static public void InitLanguage(object type)
        {
            Type T = type.GetType();
            if (AppManager._CurrentLanguage == StoreAssistant_SettingView.LanguageMode.VN)
            {
                culture = CultureInfo.CreateSpecificCulture("VI");
            }
            else if (AppManager._CurrentLanguage == StoreAssistant_SettingView.LanguageMode.EN)
            {
                culture = CultureInfo.CreateSpecificCulture("EN");
            }
            else { Culture = CultureInfo.CreateSpecificCulture(AppManager.CurrentLanguage); }
            Rm = new
                ResourceManager("StoreAssitant.string", T.Assembly);
        }
    }
}



