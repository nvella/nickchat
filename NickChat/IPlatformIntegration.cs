using NickChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NickChat
{
    public interface IPlatformIntegration
    {
        void ShowBuddyList(BuddyListWindowViewModel viewModel);
        void CloseBuddyList();

        void ShowChatWindow(ChatWindowViewModel viewModel);
        void CloseChatWindow(ChatWindowViewModel viewModel);
    }
}
