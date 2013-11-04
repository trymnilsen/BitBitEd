using System;
using System.Collections.Generic;
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
        public EntityObject(EntityNode parent, string name)
            :base(parent, EntityType.Object,name)
        {
            
        }
    }
}
