﻿using BitEd.Models.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityObject : EntityNode
    {
        public EntitySprite sprite;
        public bool isVisible;
        public bool isPersistent;
        public ObservableCollection<BaseEvent> Events {get; private set;}

        public override bool Validate
        {
            get { return Name == "New Object" ? false : true; }
        }
        public EntityObject(EntityNode parent, string name)
            :base(parent, EntityType.Object,name)
        {
            Events = new ObservableCollection<BaseEvent>();
        }

    }
    
}
