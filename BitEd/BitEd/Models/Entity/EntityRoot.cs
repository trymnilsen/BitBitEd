using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityRoot : EntityNode
    {
        public override bool Validate
        {
            get { return true; }
        }

        public EntityRoot()
            :base(null,EntityType.Root,"Project")
        {
            
        }
    }
}
