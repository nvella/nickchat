using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

using PropertyChanged;

namespace NickChat.Models
{
    public class Conversation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

        public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();
    }
}
