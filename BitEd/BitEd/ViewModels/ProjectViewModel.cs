using BitEd.Models;
using BitEd.Models.Entity;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.ViewModels
{
    public class ProjectViewModel:ViewModelBase
    {
        //Private storage variables
        EntityRoot rootNode;
        EntityNode selectedNode;

        //Bindable Properties
        public EntityRoot RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                rootNode = value;
            }
        }
        public EntityNode SelectedItem
        {
            get { return selectedNode; }
            set { 
                selectedNode = value; 
                RaisePropertyChanged("SelectedtsItem"); 
            }
        }
        public ObservableCollection<EntityNode> ProjectAssets { get; set; }
        public ProjectViewModel()
        {
            ProjectAssets = new ObservableCollection<EntityNode>();
            RootNode = new EntityRoot();
            ProjectAssets.Add(RootNode);
        }

    }
}
