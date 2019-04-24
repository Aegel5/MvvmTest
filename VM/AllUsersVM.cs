using MvvmTest.Model;
using MvvmTest.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class AllUsersVM : WorkspaceBaseVM
    {
        public ObservableCollection<UserVM> UserVMList { get; private set; }
        UserRepository _userRepository;
        public ICommand ShowUserCmd { get; private set; }

        void ShowUser(object userVM)
        {
            UserVM vm = userVM as UserVM;
            Parent.ShowUser(vm);
        }

        public AllUsersVM(UserRepository userRep, MainVM parent):base(parent)
        {
            ShowUserCmd = new RelayCommand(param => ShowUser(param));

            _userRepository = userRep;
            DisplayName = "Список пользователей";
            _userRepository.UserListChanged += _userRepository_UserListChanged;

            RefreshUserList();
        }

        void RefreshUserList()
        {
            var allUsers = _userRepository.GetUsers();
            UserVMList = new ObservableCollection<UserVM>(allUsers.Select(x => new UserVM(x)));
            base.OnPropertyChanged("UserVMList");
        }

        private void _userRepository_UserListChanged(object sender, UserListChangedEventArg e)
        {
            RefreshUserList();
        }
    }
}
