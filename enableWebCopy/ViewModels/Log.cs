using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace enableWebCopy.ViewModels
{
    public class Log : INotifyPropertyChanged
    {
        private string _FullLog;
        public string FullLog
        {
            get
            {
                return _FullLog;
            }
            set
            {
                if (value != _FullLog)
                {
                    _FullLog = value;
                    NotifyPropertyChanged("FullLog");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}