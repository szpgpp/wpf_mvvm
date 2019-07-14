using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_MVVM.Code
{
    class NotificationBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteCommand != null)
                return this.CanExecuteCommand(parameter);
            else
                return true;
        }
        public void Execute(object parameter)
        {
            if (this.ExecuteCommand != null) this.ExecuteCommand(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, EventArgs.Empty);
        }
    }
    class Model : NotificationBase
    {
        private string _NowTime = "Now Time";
        public string NowTime
        {
            get { return this._NowTime; }
            set { this._NowTime = value; this.RaisePropertyChanged("NowTime"); }
        }
        public void PrintNowTime(object obj)
        {
            this.NowTime += "Now Time:" + String.Format("{0:yyyy-MM-dd HH:mm:ss}",DateTime.Now) + System.Environment.NewLine;
        }
        
    }
    class ViewModel
    {
        public DelegateCommand PrintCmd { get; set; }
        public Model model { get; set; }
        public ViewModel()
        {
            this.model = new Model();
            this.PrintCmd = new DelegateCommand();
            this.PrintCmd.ExecuteCommand = new Action<Object>(this.model.PrintNowTime);
        }
    }
}
