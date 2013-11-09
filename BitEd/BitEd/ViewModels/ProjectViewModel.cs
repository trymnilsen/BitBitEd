using BitEd.Models;
using BitEd.Models.Entity;
using BitEd.Models.ViewModelStores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.ViewModels
{
    class ProjectViewModel:ViewModel
    {
        ProjectStore model;

        public EntityRoot RootNode
        {
            get
            {
                return model.RootNode;
            }
            set
            {
                model.RootNode = value;
            }
        }
        public EntityNode SelectedProjectItem
        {
            get { return model.SelectedNode; }
            set { 
                model.SelectedNode = value; 
                NotifyProperty("SelectedProjectItem"); 
            }
        }
        public ObservableCollection<EntityNode> ProjectAssets { get; set; }
        public ProjectViewModel()
        {
            model = StoreService.GetStore<ProjectStore>();
            ProjectAssets = new ObservableCollection<EntityNode>();
            ProjectAssets.Add(RootNode);
        }

    }
}
