using BitEd.Models.Action;
using BitEd.Models.Action.Actions;
using BitEd.Models.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public static class EntityCollections
    {
        public static List<BaseAction> AvailableActions = new List<BaseAction>(new BaseAction[]{
            new RenderSprite(),

        });
        public static List<BaseEvent> AvailableEvents = new List<BaseEvent>(new BaseEvent[]{
            new BaseEvent() {Name="OnRender"}
        });
    }
}
