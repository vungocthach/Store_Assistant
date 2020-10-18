using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Pass { get; set; }
        public UserRole Role { get; set; }
        public enum UserRole
        {
            Manager, Cashier
        }

        public static UserRole GetUserRole(int value)
        {
            switch (value)
            {
                case ((int)UserRole.Manager):
                    return UserRole.Manager;

                case ((int)UserRole.Cashier):
                    return UserRole.Cashier;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
