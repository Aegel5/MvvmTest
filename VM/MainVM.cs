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

        public ICommand NewUser { get; private set; }
        public ObservableCollection<UserVM> UserVMList { get; private set; }


        RelayCommand _NewUser;
        public MainVM()
        {
            _userRepository = new UserRepository();

            _NewUser = new RelayCommand(param => MessageBox.Show("Create new user"));
            NewUser = _NewUser;

            var allUsers = _userRepository.GetUsers();
            UserVMList = new ObservableCollection<UserVM>(allUsers.Select(x => new UserVM(x)));
        }

    }
}
