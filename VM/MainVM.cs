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
    class MainVM : ViewModelBase
    {
        RelayCommand _NewUser;
        public MainVM()
        {
            _NewUser = new RelayCommand(param => MessageBox.Show("Create new user"));
            NewUser = _NewUser;
        }
        public ICommand NewUser { get; private set; }
    }
}
