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
        readonly User _user;
        //readonly UserRepository _userRepository;

        public UserVM(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            //if (customerRepository == null)
            //    throw new ArgumentNullException("customerRepository");

            _user = user;
            //_customerRepository = customerRepository;
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                if (value == _user.Name)
                    return;

                _user.Name = value;

                base.OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get { return _user.Email; }
            set
            {
                if (value == _user.Email)
                    return;

                _user.Email = value;

                base.OnPropertyChanged("Email");
            }
        }
    }
}
