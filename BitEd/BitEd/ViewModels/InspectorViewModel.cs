using BitEd.Core;
using BitEd.Messages.Project;
using BitEd.Models;
using BitEd.Models.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitEd.ViewModels
{
    public class InspectorViewModel:ViewModelBase
    {
        private EntityNode activeNode;
        private EntityDummy noSelectedNode;
        private string entityTexboxName = "No Entity Selected";

        public EntityNode ActiveNode
        {
            get { return activeNode; }
            set
            {
                if(value==null)
                {
                    activeNode = noSelectedNode;
                }
                else if(activeNode!=value)
                {
                    activeNode = value;
                    RaisePropertyChanged("ActiveNode");
                }
            }
        }
        public string TextBoxEntityName
        {
            get
            {
                return entityTexboxName;
            }
            set
            {
                if (entityTexboxName != value)
                {
                    entityTexboxName = value;
                    RaisePropertyChanged("TextBoxEntityName");
                }
                else
                {
                    Debug.WriteLine("TextBoxEntityName was the same("+value+") no change");
                }
            }
        }


        public InspectorViewModel()
        {
            noSelectedNode = new EntityDummy();
            SetEntityNameOnEnter = new ActionCommand(SetEntityName, CanSetEntityName);
            //Register message
            Messenger.Default.Register<SelectedItemChangeMessage>(this, ChangedSelectedProjectTreeItem);
        }
        //Messages Callback
        void ChangedSelectedProjectTreeItem(SelectedItemChangeMessage message)
        {
            //Set active Node
            //Set textboxtext based on active node
            ActiveNode = message.Item;
            TextBoxEntityName = ActiveNode.Name;
        }
        //Commands
        void SetEntityName()
        {
            ActiveNode.Name = TextBoxEntityName; 
            RaisePropertyChanged("TextBoxEntityName");
        }
        bool CanSetEntityName()
        {
            if (ActiveNode == null || ActiveNode == noSelectedNode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Command Properties
        public ICommand SetEntityNameOnEnter { get; private set; }
    }
}
