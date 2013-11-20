using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Action
{
    public enum PropertyType
    {
        Boolean,
        Asset,
        String,
        Int,
        Float,
        Number,
        Enum
    }
    public class ActionProperty
    {
        public PropertyType PropertyType { get; set; }
    }
}
