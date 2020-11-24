
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Authenticater
{
    internal class Authenticator
    {
        private static UserInfo user = null;
        internal static UserInfo CurrentUser
        {
            get => user;
        }
        internal static byte[] GetPass(UserInfo info)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] encripted_pass = sha256.ComputeHash(Encoding.Unicode.GetBytes(info.Pass));
                return encripted_pass;
            }
        }
        internal static bool Login(ref UserInfo userInfo)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                if (databaseController.GetUserRole(ref userInfo))
                {
                    user = userInfo;
                    return true;
                }
                else { return false; }
            }
        }

        internal static bool RegistUser(UserInfo userInfo)
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.Role == UserInfo.UserRole.Manager)
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
                else { throw new UnauthorizedAccessException("Must login as manager account to create new account"); }
            }
            else { throw new NullReferenceException("Current login user must not be null"); }
        }

        internal static bool ChangeCurrentPassword(string newPass)
        {
            return ChangePassword(ref user, newPass);
        }

        internal static bool ChangePassword(ref UserInfo userInfo, string newPass)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                userInfo.Pass = newPass;
                return databaseController.UpdatePassword(userInfo);
            }
        }
    }
}
