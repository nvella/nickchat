using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using PropertyChanged;

namespace NickChat.Models
{
    public class Buddy : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

        public string Name { get; set; }

        public bool Online { get; set; }

        public PictureFileType DisplayPictureFileType { get; set; } = PictureFileType.Unknown;
        public byte[]? DisplayPicture { get; set; }

        /// <summary>
        /// DateTime of last online - null if currently online or not available
        /// </summary>
        public DateTime? LastOnline { get; set; }

        public Conversation Conservation { get; set; } = new Conversation();

        public Buddy(string name)
        {
            Name = name;

            PropertyChanged += Buddy_PropertyChanged;
        }

        public string StatusString
        {
            get
            {
                if (Online) return "online";
                if (LastOnline.HasValue) return $"last online at {LastOnline.Value}";
                return "offline";
            }
        }

        private void Buddy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Online) || (!Online && e.PropertyName == nameof(LastOnline)))
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(StatusString)));
        }
    }

    public enum PictureFileType
    {
        Unknown,
        Jpg,
        Png
    }
}
