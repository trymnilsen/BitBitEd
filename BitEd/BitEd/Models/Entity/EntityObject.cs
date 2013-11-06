using BitEd.Models.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    class EntityObject:EntityNode
    {
        private EntitySprite sprite;
        private bool isVisible;
        private bool isPersistent;
        private ObservableCollection<BaseEvent> events; 
        public EntityObject(EntityNode parent, string name)
            :base(parent, EntityType.Object,name)
        {
            events = new ObservableCollection<BaseEvent>();
        }

    }
    
}
