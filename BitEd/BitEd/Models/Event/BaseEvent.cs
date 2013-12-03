using BitEd.Models.Action;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Event
{
    public class BaseEvent
    {
        public ObservableCollection<BaseAction> Actions { get; set; }
        public string Id { get; set; }
        public object Argument { get; set; }
        public string Name { get; set; }
        public BaseEvent()
        {
            Actions = new ObservableCollection<BaseAction>();
        }
        public BaseEvent GetActionlessClone()
        {
            BaseEvent clone = new BaseEvent();
            clone.Name = this.Name;
            clone.Id = this.Id;
            clone.Argument = this.Argument;
            return clone;
        }
        public override string ToString()
        {
            return Name == null ? "No Name given" : Name;
        }
        
    }
}
