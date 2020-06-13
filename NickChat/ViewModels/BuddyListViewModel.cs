using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using PropertyChanged;

namespace NickChat.ViewModels
{
    public class BuddyListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
        
        public string Title { get; set; }
        public ObservableCollection<BuddyEntry> Buddies { get; set; } = new ObservableCollection<BuddyEntry>()
        {
            new BuddyEntry() { Name = "Nathanael", Status = "online" }
        };

        public class BuddyEntry : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

            public string Name { get; set; }
            public string Status { get; set; }

            public ICommand OpenCommand { get; } = new AlwaysExecutableCommand(() => Trace.WriteLine("Hello world!"));
        }
    }
}
