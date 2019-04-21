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
        public ICommand ShowAllUsersCmd { get; private set; }
        public ObservableCollection<WorkspaceBaseVM> Workspaces { get; private set; }
        

        void AddNewUser()
        {
            var user = User.CreateNewUser();
            user.Name = "new user";
            user.Email = "new email";
            //var userVM = new UserVM(user);
            _userRepository.AddUser(user);
        }

        void ShowAllUsers()
        {

        }


        public MainVM()
        {
            _userRepository = new UserRepository();

            AddNewUserCmd = new RelayCommand(param => AddNewUser());
            ShowAllUsersCmd = new RelayCommand(param => ShowAllUsers());

            Workspaces = new ObservableCollection<WorkspaceBaseVM>();
            Workspaces.Add(new AllUsersVM(_userRepository));

        }




    }
}
