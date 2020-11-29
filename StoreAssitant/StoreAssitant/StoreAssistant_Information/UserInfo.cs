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

        public string FullName { get; set; }
        public string Sex { get; set;}

        public DateTime Birth { get; set; }

        public String Phone { get; set; }

        public UserRole Role { get; set; }
        public enum UserRole
        {
            Manager, Cashier
        }

        public UserInfo ( string Name, string pass, string sex,  DateTime birth, string phone, string fullName)
        {
            UserName = Name;
            Pass = pass;
            Sex = sex;
            Birth = birth;
            Phone = phone;
            FullName = fullName;
        }
        public UserInfo()
        {

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
