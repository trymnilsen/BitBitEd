using BitEd.Models.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Messages.Project
{
    public class OpenItemMessage
    {
        public EntityNode Item { get; set; }

        private OpenItemMessage(EntityNode item)
        {
            this.Item = item;
        }
        public static void Send(EntityNode newSelectedItem)
        {
            Messenger.Default.Send<OpenItemMessage>(new OpenItemMessage(newSelectedItem));
        }
    }
}
