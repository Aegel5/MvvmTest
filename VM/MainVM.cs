using MvvmTest.Model;
using MvvmTest.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class MainVM : BaseVM
    {
        readonly UserRepository _userRepository;

        public ICommand AddNewUserCmd { get; private set; }
        public ObservableCollection<UserVM> UserVMList { get; private set; }

        void AddNewUser()
        {
            var user = User.CreateNewUser();
            user.Name = "new user";
            user.Email = "new email";
            //var userVM = new UserVM(user);
            _userRepository.AddUser(user);
        }


        public MainVM()
        {
            _userRepository = new UserRepository();

            AddNewUserCmd = new RelayCommand(param => AddNewUser());

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
