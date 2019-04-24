using MvvmTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest.VM
{
    class UserVM : BaseVM
    {
        public User userModel;

        public UserVM(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            userModel = user;
        }

        public string Name
        {
            get { return userModel.Name; }
            set
            {
                userModel.Name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get { return userModel.Email; }
            set
            {
                if (value == userModel.Email)
                    return;

                userModel.Email = value;

                base.OnPropertyChanged("Email");
            }
        }
    }
}
