using BitEd.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.ViewModelStores
{
    class ProjectStore:ViewModelStore
    {
        //Private values
        private EntityRoot rootNode;

        //Properties
        public EntityRoot RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                if(rootNode!=value)
                {
                    rootNode = value;
                    NotifyProperty("RootNode");
                }
            }
        }
        
        public ProjectStore()
        {
            rootNode = EntityNode.CreateRoot();
            rootNode.Childs.Add(rootNode.CreateFolder(rootNode, "TestFolder"));
        }

    }
}
