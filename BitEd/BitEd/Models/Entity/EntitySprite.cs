using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BitEd.Models.Entity
{
    public class EntitySprite : EntityNode
    {
        private BitmapImage imageSource;
        private int height;
        private int width;
        private int centerX;
        private int centerY;
        private int ID;

        public BitmapImage ImageSource
        {
            get
            {
                return imageSource;
            }
        }

        public override bool Validate
        {
            get { return imageSource == null ? false : true; }
        }

        public EntitySprite(EntityNode node, string name, BitmapImage imageSource)
            :base(node,EntityType.Sprite,name)
        {
            this.imageSource = imageSource;
        }
        
    }
}
