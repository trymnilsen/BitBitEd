using BitEd.Core;
using BitEd.Models.Action;
using BitEd.Models.Action.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            AddActionToEvent = new ParamCommand(AddAction, null);
        }
        /// <summary>
        /// Does a deep copy and retunrs an equal event without actions
        /// </summary>
        /// <returns></returns>
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
        private void AddAction(object action)
        {
            BaseAction selectedAction = action as BaseAction;
            Debug.WriteLine("Adding action" + selectedAction.Name);
            Actions.Add(selectedAction.getClone());
        }
        public ParamCommand AddActionToEvent { get; set; }
        
    }
}
