using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityScreen:EntityNode
    {
        private int gridSizeX;
        private int gridSizeY;
        private int screenRotation;
        private double screenScale;
        private bool showGrid;

        public int GridSizeX
        {
            get { return gridSizeX; }
            set
            {
                if (value != gridSizeX)
                {
                    gridSizeX = value;
                    RaisePropertyChanged("GridSizeX");
                }
            }
        }
        public int GridSizeY
        {
            get { return gridSizeY; }
            set
            {
                if (value != gridSizeY)
                {
                    gridSizeY = value;
                    RaisePropertyChanged("GridSizeY");
                }
            }
        }
        public int ScreenRotation
        {
            get { return screenRotation; }
            set
            {
                if (value != screenRotation)
                {
                    screenRotation = value;
                    RaisePropertyChanged("ScreenRotation");
                }
            }
        }
        public double ScreenScale
        {
            get { return screenScale; }
            set
            {
                if(value!=screenScale)
                {
                    screenScale = value;
                    RaisePropertyChanged("ScreenScale");
                }
            }
        }
        public bool ShowGrid
        {
            get { return showGrid; }
            set
            {
                if(value!=showGrid)
                {
                    showGrid = value;
                    RaisePropertyChanged("ShowGrid");
                }
            }
        }

        public ObservableCollection<EntityScreenObjectInstance> Instances { get; private set; }
        public string Header { get; set; }
        public int ScreenSizeX { get; set; }
        public int ScreenSizeY { get; set; }
        

        public override bool Validate
        {
            get { return true; }
        }
        public EntityScreen(string name, EntityNode parent)
            :base(parent, EntityType.Screen,name)
        {
            //Default values
            Header = "Test Screen";
            ScreenSizeX = 320;
            ScreenSizeY = 280;
            ShowGrid = true;
            ScreenScale = 1;
        }
    }
}
