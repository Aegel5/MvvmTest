using MvvmTest.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class WorkspaceBaseVM : BaseVM
    {
        public MainVM Parent { get; private set; }
        public WorkspaceBaseVM(MainVM parent)
        {
            Parent = parent;
        }
        ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => Parent.CloseRequest(this));

                return _closeCommand;
            }
        }
    }
}

