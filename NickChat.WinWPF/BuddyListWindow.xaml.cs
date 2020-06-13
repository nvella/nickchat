using NickChat.ViewModels;
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

namespace NickChat.WinWPF
{
    /// <summary>
    /// Interaction logic for BuddyListWindow.xaml
    /// </summary>
    public partial class BuddyListWindow : Window
    {
        public BuddyListWindow()
        {
            InitializeComponent();
        }

        public BuddyListWindowViewModel ViewModel => (BuddyListWindowViewModel)DataContext;

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DebugOpenChatMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var chatWindow = new ChatWindow();
            chatWindow.Show();
        }

        private void BuddiesListView_ItemDoubleClick(object sender, RoutedEventArgs e)
        {
            var item = (ListViewItem)e.Source;
            var buddyEntry = (BuddyListViewModel.BuddyEntry)item.DataContext;
            buddyEntry.OpenCommand.Execute(null);
        }
    }
}
