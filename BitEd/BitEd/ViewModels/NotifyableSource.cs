using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.ViewModels
{
    public abstract class NotifyableSource:INotifyPropertyChanged
    {
        protected void NotifyProperty(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            else
            {
                Debug.WriteLine("ERROR: PropertyChanged " + prop + " was null in __NotifyProperty__ ");
            }
        }
        protected void NotifyProperty(string prop, string debugableInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            else
            {
                Debug.WriteLine("ERROR: PropertyChanged "+prop+" was null in __NotifyProperty__  in "+debugableInfo);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
