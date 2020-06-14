using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using NickChat.Models;
using PropertyChanged;

namespace NickChat.ViewModels
{
    public class ChatWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
        public Buddy Buddy { get; set; }

        public string Message { get; set; } = "";
        public ICommand CommandSend { get; set; }

        public ChatWindowViewModel()
        {
            Buddy = null!; // For Designer

            CommandSend = new SendCommand(this);
        }

        public ChatWindowViewModel(Buddy buddy) : this()
        {
            Buddy = buddy;
        }

        public class SendCommand : ICommand
        {
            private ChatWindowViewModel _viewModel;
            
            public event EventHandler CanExecuteChanged = (_, __) => { };

            public SendCommand(ChatWindowViewModel viewModel)
            {
                _viewModel = viewModel;
                _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }

            public bool CanExecute(object parameter) => !string.IsNullOrWhiteSpace(_viewModel.Message);

            public void Execute(object parameter)
            {
                _viewModel.Buddy.Name = _viewModel.Message;
                _viewModel.Buddy.Online = true;
            }

            private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(_viewModel.Message)) CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
