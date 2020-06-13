using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using PropertyChanged;

namespace NickChat.ViewModels
{
    public class ChatWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
