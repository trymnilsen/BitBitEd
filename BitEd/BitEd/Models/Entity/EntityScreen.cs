using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityScreen
    {
        public ObservableCollection<EntityScreenObjectInstance> Instances { get; private set; }
        public string Header { get; set; }
        public EntityScreen()
        {
            Header = "Test Screen";
        }
    }
}
