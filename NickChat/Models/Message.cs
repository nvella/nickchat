using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NickChat.Models
{
    public class Message : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
        
        public Buddy Buddy { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

        public Message(Buddy buddy, DateTime date, string body)
        {
            Buddy = buddy;
            Date = date;
            Body = body;
        }
    }
}
