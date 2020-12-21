using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace StoreAssitant
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();

            cbx_Language.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach( Form form in Application.OpenForms)
            {
                MethodInfo info = form.GetType().GetMethod("SetLanguage");
                if ( info != null)
                {
                    info.Invoke(form, null);
                }    
            }    
        }
    }
}
