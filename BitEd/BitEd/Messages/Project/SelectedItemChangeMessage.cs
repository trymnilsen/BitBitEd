using BitEd.Models.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Messages.Project
{
    public class SelectedItemChangeMessage
    {
        public EntityNode Item { get; set; }

        private SelectedItemChangeMessage(EntityNode item)
        {
            this.Item = item;
        }
        public static void Send(EntityNode newSelectedItem)
        {
            Messenger.Default.Send<SelectedItemChangeMessage>(new SelectedItemChangeMessage(newSelectedItem));
        }
    }
}
