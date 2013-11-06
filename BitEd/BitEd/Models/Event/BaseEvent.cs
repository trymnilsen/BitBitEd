using BitEd.Models.Action;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Event
{
    class BaseEvent
    {
        protected string name;

        public ObservableCollection<BaseAction> Actions { get; set; }
        public BaseEvent()
        {
            Actions = new ObservableCollection<BaseAction>();
        }
        
    }
}
