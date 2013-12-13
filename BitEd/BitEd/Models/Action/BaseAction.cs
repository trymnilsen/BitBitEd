using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Action
{
    public enum ExecutionPriority
    {
        Pre, //Before normal calculations should only be used to save current values etc
        Normal,//Normal execution scope
        Late,//Executed after normal execution but before rendering, for calculation on transformations etc that is need when rendering
        Rendering,
        Post//After both rendering and all other execution
    }
    public enum ActionCategory
    {
        Transform,
        Rendering
    }

    public class BaseAction
    {
        public ExecutionPriority ExecutionOrder { get; set; }
        public ObservableCollection<ActionProperty> ActionProperties { get; set; }
        public bool isExclusive { get; set; }
        public string Name { get; set; }
        public BaseAction()
            : this(ExecutionPriority.Normal) { }

        public BaseAction(ExecutionPriority priority)
        {
            ActionProperties = new ObservableCollection<ActionProperty>();
            ExecutionOrder = priority;
        }
        public BaseAction getClone()
        {
            BaseAction clone = new BaseAction();
            clone.ExecutionOrder = this.ExecutionOrder;
            clone.isExclusive = this.isExclusive;
            clone.Name = this.Name;
            //Add the properties
            clone.ActionProperties = new ObservableCollection<ActionProperty>();
            foreach(ActionProperty ap in this.ActionProperties)
            {
                clone.ActionProperties.Add(new ActionProperty() { Name = ap.Name, Value = ap.Value });
            }
            return clone;
        }
        /// <summary>
        /// Needd for correct display of Action name
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
