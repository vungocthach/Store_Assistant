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
    }
}
