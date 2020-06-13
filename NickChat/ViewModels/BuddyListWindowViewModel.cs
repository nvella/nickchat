using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Xml.Schema;
using PropertyChanged;

namespace NickChat.ViewModels
{
    public class BuddyListWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

        public ObservableCollection<BuddyListViewModel> BuddyListViewModels { get; set; } = new ObservableCollection<BuddyListViewModel>()
        {
            new BuddyListViewModel() {Title="Favourites"}
        };
    }
}
