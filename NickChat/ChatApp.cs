using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NickChat.Models;
using NickChat.ViewModels;

namespace NickChat
{
    public class ChatApp
    {
        private IPlatformIntegration _platform;

        public BuddyListWindowViewModel BuddyListWvm { get; }
        public Dictionary<Buddy, ChatWindowViewModel> ChatViewModels { get; } = new Dictionary<Buddy, ChatWindowViewModel>();

        public ObservableCollection<Buddy> Favourites { get; } = new ObservableCollection<Buddy>();

        public ChatApp(IPlatformIntegration platform)
        {
            _platform = platform;

            BuddyListWvm = new BuddyListWindowViewModel(this);

            Favourites.Add(new Buddy("Buddy A"));
            Favourites.Add(new Buddy("Buddy B"));
            Favourites.Add(new Buddy("Buddy C"));
        }

        public void Start()
        {
            _platform.ShowBuddyList(BuddyListWvm);
        }

        public void ShowChatForBuddy(Buddy buddy)
        {
            if (!ChatViewModels.ContainsKey(buddy))
                ChatViewModels.Add(buddy, new ChatWindowViewModel(buddy));

            var chatViewModel = ChatViewModels[buddy];
            _platform.ShowChatWindow(chatViewModel);
        }

        #region Singleton implementation
        private static ChatApp? _instance;
        public static ChatApp Instance { 
            get
            {
                if (_instance == null) throw new InvalidOperationException("app singleton not yet instantiated");
                return _instance;
            }

            set
            {
                if (_instance != null) throw new InvalidOperationException("app singleton already instantiated");
                _instance = value;
            }
        }
        #endregion
    }
}
