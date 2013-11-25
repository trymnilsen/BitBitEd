using BitEd.Messages.Project;
using BitEd.Models;
using BitEd.Models.Entity;
using BitEd.Models.Event;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
                RaisePropertyChanged("SelectedItem");
                Debug.WriteLine("Changing Selected Item");
                SelectedItemChangeMessage.Send(value);
            }
        }
        public ObservableCollection<EntityNode> ProjectAssets { get; set; }
        public ProjectViewModel()
        {
            ProjectAssets = new ObservableCollection<EntityNode>();
            RootNode = new EntityRoot();
            ProjectAssets.Add(RootNode);
            RootNode.Childs.Add(new EntityFolder("TestFolder", RootNode));
            RootNode.Childs.Add(new EntityFolder("TestFolder", RootNode));
            EntityObject testObj = new EntityObject(rootNode, "Sprite1");
            testObj.Events.Add(new BaseEvent() { Name = "lol" });
            RootNode.Childs.Add(testObj);
        }

    }
}
