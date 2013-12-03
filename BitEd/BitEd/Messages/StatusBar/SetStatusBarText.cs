using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Messages.StatusBar
{
    public class SetStatusBarText
    {
        public string messageText { get; set; }

        private SetStatusBarText(string item)
        {
            this.messageText = item;
        }
        public static void Send(string StatusText)
        {
            Messenger.Default.Send<SetStatusBarText>(new SetStatusBarText(StatusText));
        }
    }
}
