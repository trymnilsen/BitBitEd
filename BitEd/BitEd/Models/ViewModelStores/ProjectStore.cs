using BitEd.Models.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.ViewModelStores
{
    class ProjectStore:ViewModelStore
    {
        //Private values
        private EntityRoot rootNode;
        private EntityNode selectedNode;

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
                }
            }
        }
        public EntityNode SelectedNode
        {
            get
            {
                return selectedNode;
            }
            set
            {
                if(SelectedNode!=value)
                {
                    Debug.WriteLine("Lol");
                    selectedNode = value;
                    NotifyProperty("SelectedNode");
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
