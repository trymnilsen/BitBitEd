using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Action.Actions
{
    class RenderSprite:BaseAction
    {
        public RenderSprite()
            :base(ExecutionPriority.Rendering)
        {
            base.Name = "Render Sprite";
            ActionProperty assetProperty = new ActionProperty();
            assetProperty.Name = "Foo";
            this.ActionProperties = assetProperty;
        }
    }
}
