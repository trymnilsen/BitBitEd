using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityRoot:EntityNode
    {
        public EntityRoot()
            :base(null,EntityType.Root,"Project")
        {
            
        }
        public override bool Validate()
        {
            return true;
        }
    }
}
