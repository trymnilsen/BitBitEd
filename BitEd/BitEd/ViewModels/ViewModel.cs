using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.ViewModels
{
    public abstract class ViewModel:INotifyPropertyChanged
    {
        protected void NotifyProperty(string prop)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            else
            {
                Debug.WriteLine("ERROR: PropertyChanged was null in __NotifyProperty__ ");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
