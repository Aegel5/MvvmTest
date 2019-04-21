using MvvmTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest.VM
{
    class AllUsersVM : WorkspaceBaseVM
    {
        public ObservableCollection<User> UserVMList { get; private set; }
        UserRepository _userRepository;

        public AllUsersVM(UserRepository userRep)
        {
            IsClosable = false;

            _userRepository = userRep;
            DisplayName = "Список пользователей";
            _userRepository.UserListChanged += _userRepository_UserListChanged;

            RefreshUserList();
        }

        void RefreshUserList()
        {
            var allUsers = _userRepository.GetUsers();
            UserVMList = new ObservableCollection<User>(allUsers);
            base.OnPropertyChanged("UserVMList");
        }

        private void _userRepository_UserListChanged(object sender, UserListChangedEventArg e)
        {
            RefreshUserList();
        }
    }
}
