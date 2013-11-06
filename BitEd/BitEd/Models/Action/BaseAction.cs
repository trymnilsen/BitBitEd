﻿using System;
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
    public enum ActuionCategory
    {
        Transform,
        Rendering
    }

    class BaseAction
    {
        
        //List of available Actions
        static ReadOnlyCollection<BaseAction> AvailableActions = new ReadOnlyCollection<BaseAction>(new BaseAction[]{
            new RenderSprite(),
        });

        protected string name;

        public ExecutionPriority ExecutionOrder { get; set; }
        public ObservableCollection<ActionProperty> ActionProperties { get; set; }
        public bool isExclusive { get; set; }
        public BaseAction()
            : this(ExecutionPriority.Normal) { }

        public BaseAction(ExecutionPriority priority)
        {
            ActionProperties = new ObservableCollection<ActionProperty>();
            ExecutionOrder = priority;
        }
    }
}