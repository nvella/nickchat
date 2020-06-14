using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Windows.Input;
using NickChat.Models;
using PropertyChanged;

namespace NickChat.ViewModels
{
    public class BuddyListWindowViewModel : INotifyPropertyChanged
    {
        private ChatApp _app;

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
        public ObservableCollection<BuddyList> BuddyListViewModels { get; set; } = new ObservableCollection<BuddyList>();

        public BuddyList FavouritesList { get; set; } = new BuddyList()
        {
            Title = "Favourites"
        };

        public BuddyListWindowViewModel()
        {
            _app = null!;

            BuddyListViewModels.Add(FavouritesList);
        }

        public BuddyListWindowViewModel(ChatApp app) : this()
        {
            _app = app;

            // Listen to app Favourites
            app.Favourites.CollectionChanged += Favourites_CollectionChanged;
        }

        private void Favourites_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Regenerate the Favourites BuddyList
            FavouritesList.Buddies = _app.Favourites.Select(buddy => new BuddyList.BuddyListEntry(_app, buddy));
        }

        public class BuddyList : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

            public string Title { get; set; } = "Unknown";
            public IEnumerable<BuddyListEntry> Buddies { get; set; } = Array.Empty<BuddyListEntry>();

            public class BuddyListEntry : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

                private ChatApp _app;

                public Buddy Buddy { get; set; }
                public ICommand OpenCommand { get; }

                public BuddyListEntry(ChatApp app, Buddy buddy)
                {
                    _app = app;
                    Buddy = buddy;
                    OpenCommand = new AlwaysExecutableCommand(() => _app.ShowChatForBuddy(Buddy));

                    // Buddy.PropertyChanged += (_, __) => PropertyChanged(this, new PropertyChangedEventArgs(nameof(Buddy)));
                }
            }
        }
    }
}
