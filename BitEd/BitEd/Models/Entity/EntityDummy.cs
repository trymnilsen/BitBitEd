﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    class EntityDummy : EntityNode
    {
        public override bool Validate
        {
            get { return true; }
        }
        public EntityDummy():
            base(null,EntityType.Dummy,"No Entity Selected")
        {
            
        }
    }
}
