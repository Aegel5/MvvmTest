using MvvmTest.Model;
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
            //ListView lv = sender as ListView;
            //var selected = lv.SelectedItems;
            //if (selected == null)
            //    return;
            //User user;
            //selected.
        }
    }
}
