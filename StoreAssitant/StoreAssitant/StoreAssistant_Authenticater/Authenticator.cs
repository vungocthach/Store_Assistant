using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
    }
}
