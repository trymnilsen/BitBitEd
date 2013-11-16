using BitEd.Core;
using BitEd.Models;
using BitEd.Models.Entity;
using GalaSoft.MvvmLight;
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
        private EntityDummy noSelectedNode;
        private string entityTexboxName = "No Entity Selected";

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
                    Debug.WriteLine("Setting EntityName to: " + value);
                    entityTexboxName = value;
                    RaisePropertyChanged("TextBoxEntityName");
                }
            }
        }


        public InspectorViewModel()
        {
            noSelectedNode = new EntityDummy();
        }


        //Commands
        void SetEntityName()
        {
            //projectStoreModel.SelectedNode.Name = TextBoxEntityName;
            RaisePropertyChanged("TextBoxEntityName");
        }
        bool CanSetEntityName()
        {
            return false;
            //if(projectStoreModel.SelectedNode!=null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        //Command Properties
        public ICommand SetEntityNameOnEnter { get { return new ActionCommand(SetEntityName, CanSetEntityName); } }
    }
}
