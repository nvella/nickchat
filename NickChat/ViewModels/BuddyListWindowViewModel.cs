using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using NickChat.Models;
using PropertyChanged;

namespace NickChat.ViewModels
{
    public class BuddyListWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

        public ObservableCollection<BuddyList> BuddyListViewModels { get; set; } = new ObservableCollection<BuddyList>()
        {
            new BuddyList() {Title="Favourites"}
        };

        public class BuddyList : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

            public string Title { get; set; } = "Unknown";
            public ObservableCollection<BuddyListEntry> Buddies { get; set; } = new ObservableCollection<BuddyListEntry>();

            public class BuddyListEntry : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

                public Buddy Buddy { get; set; }
                public ICommand OpenCommand { get; }

                public BuddyListEntry(Buddy buddy)
                {
                    Buddy = buddy;
                    OpenCommand = new AlwaysExecutableCommand(() => ChatApp.Instance.ShowChatForBuddy(Buddy));
                }
            }
        }
    }
}
