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
        Pre,
        Normal,
        Post
    }
    class BaseAction
    {
        public ExecutionPriority ExecutionPriority { get; set; }
        public ObservableCollection<ActionProperty> ActionProperties { get; set; }

        public BaseAction()
            : this(ExecutionPriority.Normal) { }

        public BaseAction(ExecutionPriority priority)
        {
            ActionProperties = new ObservableCollection<ActionProperty>();
            ExecutionPriority = priority;
        }
    }
}
