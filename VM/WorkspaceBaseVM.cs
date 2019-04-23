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
        MainVM _parent;
        public WorkspaceBaseVM(MainVM parent)
        {
            _parent = parent;
        }

        ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => _parent.CloseRequest(this));

                return _closeCommand;
            }
        }
    }
}

