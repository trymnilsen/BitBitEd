using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public class EntityPresenter:INotifyPropertyChanged
    {
        private EntityNode node;

        public EntityNode Node
        {
            get { return node; }
        }
        public string Name
        {
            get { return node.Name; }
            set
            {
                if(node.Name!=value)
                {
                    node.Name = value;
                    Notify("Name");
                }
            }
        }
        private void Notify(string prop)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            else
            {
                Debug.WriteLine("PropertyChanged == NULL");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
