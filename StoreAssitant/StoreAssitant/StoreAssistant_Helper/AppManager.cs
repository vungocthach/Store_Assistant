using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAssitant.StoreAssistant_SettingView;

namespace StoreAssitant.StoreAssistant_Helper
{
    public class AppManager
    {
        static StoreInformation storeInformation;
        public static StoreInformation StoreInformation
        {
            get
            {
                if (storeInformation == null)
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        storeInformation = databaseController.GetStoreInformation();
                    }
                }
                return storeInformation;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("StoreInformation must not be null"); }
                storeInformation = value;
                using (DatabaseController databaseController = new DatabaseController())
                {
                    databaseController.UpdateStoreInfo(storeInformation);
                }
            }
        }
        static ThemeMode theme = ThemeMode.Light;
        public static ThemeMode CurrentTheme
        {
            get
            {
                return theme;
            }
        }
        static LanguageMode language = LanguageMode.VN;
        public static LanguageMode CurrentLanguage
        {
            get
            {
                return language;
            }
        }
        static SizeMode windowSize = SizeMode._1024x768;
        public static SizeMode CurrentWindowSize
        {
            get
            {
                return windowSize;
            }
        }

        public static void LoadPreferences()
        {
            string path = Path.GetFullPath("./Preferences/setting.txt");
            if (File.Exists(path))
            {
                string[] preferences = File.ReadAllLines(path);
                try
                {
                    // Check wrong-formated file
                    if (preferences.Length < 3) { throw new FormatException(); }
                    // Load data
                    ChangeLanguage((LanguageMode)int.Parse(preferences[0].Trim()), false);
                    ChangeTheme((ThemeMode)int.Parse(preferences[1].Trim()), false);
                    ChangeWindowSize((SizeMode)int.Parse(preferences[2].Trim()), false);
                }
                catch (FormatException)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Mẫ lỗi: 0x159.{1}Đường dẫn tập tin: {0}", path, Environment.NewLine),
                                "Lỗi định dạng", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    Restart();
                }
            }
            else { CreateDefaultPreferences(); }
        }

        static void CreateDefaultPreferences()
        {
            ChangeLanguage(LanguageMode.VN, false);
            ChangeTheme(ThemeMode.Light, false);
            ChangeWindowSize(SizeMode._1366x768, false);

            DirectoryInfo directory = Directory.CreateDirectory("./Preferences");
            //string path = Path.Combine(directory.FullName, "setting.txt");
            //File.Create(path).Close();

            SaveCurrentPreferences();
        }

        public static void SaveCurrentPreferences()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(((int)CurrentLanguage).ToString());
            builder.AppendLine(((int)CurrentTheme).ToString());
            builder.AppendLine(((int)CurrentWindowSize).ToString());

            byte[] bytes = Encoding.UTF8.GetBytes(builder.ToString());

            string path = Path.GetFullPath("./Preferences/setting.txt");

            FileStream stream = File.OpenWrite(path);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        public static void Restart()
        {
            System.Windows.Forms.Application.Restart();
        }

        public static void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }

        public static void ChangeTheme(ThemeMode value, bool needSave = true)
        {
            if (CurrentTheme != value)
            {
                theme = value;
                if (needSave) { SaveCurrentPreferences(); }
                //
                // Write code change UI here
                //
            }
        }

        public static void ChangeLanguage(LanguageMode value, bool needSave = true)
        {
            if (CurrentLanguage != value)
            {
                language = value;
                if (needSave) { SaveCurrentPreferences(); }
                //
                // Write code change UI here
                //
            }
        }

        public static void ChangeWindowSize(SizeMode value, bool needSave = true)
        {
            if (CurrentWindowSize != value)
            {
                windowSize = value;
                if (needSave) { SaveCurrentPreferences(); }
                var mainForm = GetMainForm();
                // Check whether app has been ready
                if (mainForm != null)
                {
                    if (CurrentWindowSize == SizeMode.FullScreen)
                    {
                        mainForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    }
                    else
                    {
                        System.Drawing.Size size;
                        switch (CurrentWindowSize)
                        {
                            case StoreAssistant_SettingView.SizeMode._1024x768:
                                size = new System.Drawing.Size(1024, 768);
                                break;
                            case StoreAssistant_SettingView.SizeMode._1366x768:
                                size = new System.Drawing.Size(1366, 768);
                                break;
                            case StoreAssistant_SettingView.SizeMode._1680x1050:
                                size = new System.Drawing.Size(1680, 1050);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        mainForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                        mainForm.DesktopLocation = new System.Drawing.Point(mainForm.Location.X + (mainForm.Width - size.Width) / 2,
                                                        mainForm.Location.Y + (mainForm.Height - size.Height) / 2);
                        mainForm.Size = size;
                    }
                }
            }

        }

        public static System.Windows.Forms.Form GetMainForm()
        {
            return System.Windows.Forms.Application.OpenForms["mainForm"];
        }
    }
}
