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
        private int size;

        public BitmapImage ImageSource
        {
            get
            {
                return imageSource;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
        }
        public int CenterX
        {
            get
            {
                return centerX;
            }
        }
        public int CenterY
        {
            get
            {
                return centerY;
            }
        }
        public int Size
        {
            get
            {
                return size;
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
            width = imageSource.PixelWidth;
            height = imageSource.PixelHeight;
            centerX = width / 2;
            centerY = height / 2;
            size = (int)imageSource.StreamSource.Length;
        }
        
    }
}
