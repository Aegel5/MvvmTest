using MvvmTest.Model;
using MvvmTest.MVVM;
using MvvmTest.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class MainVM : BaseVM
    {
        readonly UserRepository _userRepository;

        //public ICommand AddNewUserCmd { get; private set; }
        //public ICommand ShowAllUsersCmd { get; private set; }
        public ObservableCollection<WorkspaceBaseVM> Workspaces { get; private set; }
        public ObservableCollection<CommandView> Commands { get; private set; }

        

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
            WorkspaceBaseVM workspace = this.Workspaces.FirstOrDefault(vm => vm is AllUsersVM) as WorkspaceBaseVM;
            if(workspace == null)
            {
                workspace = new AllUsersVM(_userRepository, this);
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        public void ShowUser(UserVM userVM)
        {
            Workspaces.Add(new UserWorkspace(userVM.userModel.Clone(), this, _userRepository));
            SetActiveWorkspace(Workspaces.Last());
        }

        void SetActiveWorkspace(WorkspaceBaseVM workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        public void CloseRequest(WorkspaceBaseVM workspace)
        {
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }




        public MainVM()
        {
            _userRepository = new UserRepository();

            //AddNewUserCmd = ;
            //ShowAllUsersCmd = ;

            Commands = new ObservableCollection<CommandView>();
            Commands.Add(new CommandView(new RelayCommand(param => AddNewUser()), Resources.MainVM_Command_CreateNewUser));
            Commands.Add(new CommandView(new RelayCommand(param => ShowAllUsers()), Resources.MainVM_Command_ShowAllUsers));

            Workspaces = new ObservableCollection<WorkspaceBaseVM>();

            ShowAllUsers();
        }




    }
}
