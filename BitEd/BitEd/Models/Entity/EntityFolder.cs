using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityFolder : EntityNode
    {
        public override bool Validate
        {
            get { return true; }
        }
        public EntityFolder(string name, EntityNode parent)
            :base(parent,EntityType.Folder,name)
        {
            
        }

    }
}
