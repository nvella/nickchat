using NickChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NickChat.WinWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IPlatformIntegration
    {
        private BuddyListWindow? _buddyListWindow;
        private Dictionary<ChatWindowViewModel, ChatWindow> _chatWindows = new Dictionary<ChatWindowViewModel, ChatWindow>();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the ChatApp and start
            ChatApp.Instance = new ChatApp(this);
            ChatApp.Instance.Start();
        }

        public void ShowBuddyList(BuddyListWindowViewModel viewModel)
        {
            if(_buddyListWindow == null)
                _buddyListWindow = new BuddyListWindow();

            _buddyListWindow.DataContext = viewModel;
            _buddyListWindow.Show();
        }

        public void CloseBuddyList()
        {
            if (_buddyListWindow == null) return;
            _buddyListWindow.Close();
        }

        public void ShowChatWindow(ChatWindowViewModel viewModel)
        {
            if (!_chatWindows.ContainsKey(viewModel))
                _chatWindows.Add(viewModel, new ChatWindow());

            var window = _chatWindows[viewModel];
            window.DataContext = viewModel;
            window.Show();
        }

        public void CloseChatWindow(ChatWindowViewModel viewModel)
        {
            if (!_chatWindows.ContainsKey(viewModel)) return;
            
            var window = _chatWindows[viewModel];
            window.Close();
        }
    }
}
