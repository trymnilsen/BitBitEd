using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Action
{
    public static class ActionCollection
    {
        public static ReadOnlyCollection<BaseAction> AvailableActions = new ReadOnlyCollection<BaseAction>(new BaseAction[]{
            new RenderSprite(),
        });
    }
}
