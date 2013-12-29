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
        }
    }
}
