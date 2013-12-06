using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BitEd.Models.Entity
{
    public class EntitySprite:EntityNode
    {
        private BitmapImage imageSource;
        private int height;
        private int width;
        private int centerX;
        private int centerY;
        private int ID;
        
        public EntitySprite(EntityNode node, string name, BitmapImage imageSource)
            :base(node,EntityType.Sprite,name)
        {
           
        }
        public override bool Validate()
        {
            return true;
        }
    }
}
