using MvvmTest.Model;
using MvvmTest.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class UserWorkspace : WorkspaceBaseVM
    {
        public ICommand SaveCommand { get; private set; }
        User _user;
        UserRepository _userRep;
        public UserWorkspace(User user, MainVM parent, UserRepository userRep) : base(parent)
        {
            DisplayName = user.Name;
            _user = user;
            _userRep = userRep;
            SaveCommand = new RelayCommand(param => SaveUser());
        }

        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }

        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public void SaveUser()
        {
            _userRep.ChangeUser(_user);
        }
    }
}
