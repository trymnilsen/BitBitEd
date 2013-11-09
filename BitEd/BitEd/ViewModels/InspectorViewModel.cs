using BitEd.Core;
using BitEd.Models;
using BitEd.Models.Entity;
using BitEd.Models.ViewModelStores;
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
    class InspectorViewModel:ViewModel
    {
        private ProjectStore projectStoreModel;
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
                    NotifyProperty("TextBoxEntityName");
                }
            }
        }


        public InspectorViewModel()
        {
            noSelectedNode = new EntityDummy();
            projectStoreModel = StoreService.GetStore<ProjectStore>();
            projectStoreModel.PropertyChanged += projectStoreModel_PropertyChanged;
        }

        void projectStoreModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("Changed");
            //Trigger set
            if (projectStoreModel.SelectedNode != null)
            {
                TextBoxEntityName = projectStoreModel.SelectedNode.Name;
            }
        }
        //Commands
        void SetEntityName()
        {
            projectStoreModel.SelectedNode.Name = TextBoxEntityName;
            projectStoreModel
            NotifyProperty("TextBoxEntityName");
        }
        bool CanSetEntityName()
        {
            if(projectStoreModel.SelectedNode!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Command Properties
        public ICommand SetEntityNameOnEnter { get { return new ActionCommand(SetEntityName, CanSetEntityName); } }
    }
}
