using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.VM
{
    class CommandView
    {
        public ICommand Command { get; private set; }
        public string Name { get; private set; }

        public CommandView(ICommand command, string name)
        {
            this.Command = command;
            this.Name = name;
        }
    }
}
