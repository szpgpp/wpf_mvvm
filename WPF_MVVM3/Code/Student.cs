using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WPF_MVVM3.Code
{
    public class Student : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _Name = null;
        public string Name { get { return this._Name; } set { this._Name = value; this.RaisePropertyChanged("Name"); } }
        public int Age { get; set; }

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
