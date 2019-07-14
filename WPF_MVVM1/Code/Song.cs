using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WPF_MVVM1.Code
{
    public class Song
    {
        string _artistname;
        string _songTitle;
        public string ArtistName
        {
            get { return this._artistname; }
            set { this._artistname = value; }
        }
        public string SongTitle
        {
            get { return this._songTitle; }
            set { this._songTitle = value; }
        }
    }
    public class SongViewModel : INotifyPropertyChanged
    {
        public Song Song { get; set; }
        public String ArtistName { get { return this.Song.ArtistName; } set { this.Song.ArtistName = value; RaisePropertyChanged("ArtistName"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            //得到一个副本以预防线程问题
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
