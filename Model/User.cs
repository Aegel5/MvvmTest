using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest.Model
{
    class User
    {
        public User Clone()
        {
            return (User)MemberwiseClone();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static User CreateNewUser()
        {
            return new User();
        }
    }
}
