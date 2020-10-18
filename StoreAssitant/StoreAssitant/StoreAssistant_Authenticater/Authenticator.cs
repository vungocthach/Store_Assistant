using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Authenticater
{
    internal class Authenticator
    {
        internal static byte[] GetPass(UserInfo info)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] encripted_pass = sha256.ComputeHash(Encoding.Unicode.GetBytes(info.Pass));
                return encripted_pass;
            }
        }
        internal static bool CheckLogin(ref UserInfo userInfo)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                return databaseController.GetUserRole(ref userInfo);
            }
        }

        internal static bool RegistUser(UserInfo userInfo)
        {
            string filter = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_";
            foreach (char c in userInfo.UserName)
            {
                if (filter.IndexOf(c) == -1)
                {
                    MessageBox.Show("Vui lòng chỉ nhập : a->z, A->Z, 0->9 và dấu '_'", "Tên đăng nhập không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            using (DatabaseController databaseController = new DatabaseController())
            {
                if (databaseController.CheckExistUsername(userInfo.UserName))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác", "Tên đăng nhập không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return databaseController.InsertUser(userInfo);
                }
            }
        }

        internal static bool ChangePassword(ref UserInfo user, string newPass)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                user.Pass = newPass;
                return databaseController.UpdatePassword(user);
            }
        }
    }
}
