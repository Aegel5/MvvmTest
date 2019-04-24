using MvvmTest.Model;
using MvvmTest.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmTest.View
{
    /// <summary>
    /// Interaction logic for AllUsersList.xaml
    /// </summary>
    public partial class AllUserListView : UserControl
    {
        public AllUserListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ctrl = e?.OriginalSource as FrameworkElement;
            if (ctrl == null)
                return;
            UserVM userVM = ctrl.DataContext as UserVM;
            if (userVM == null)
                return;
            var vm = this.DataContext as AllUsersVM;
            vm.ShowUserCmd.Execute(userVM);


        }
    }
}
