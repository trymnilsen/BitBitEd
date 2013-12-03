using BitEd.Core;
using BitEd.Messages.StatusBar;
using BitEd.Models.StatusBar;
using BitEd.Windows;
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
    public class StatusBarViewModel:ViewModelBase
    {
        private bool collapseSimilar;
        private StatusMessagesWindow messagesWindow;

        public bool Collapse { 
            get{ return collapseSimilar;}
            set
            {
               if(collapseSimilar!=value)
               {
                    collapseSimilar = value;
                    RaisePropertyChanged("Collapse");
               }
            } 
        }

        public ObservableCollection<StatusBarMessage> StatusMessageCollection { get; private set; }

        public string StatusBarText {
            get 
            {
                if (StatusMessageCollection.Count > 0)
                {
                    return StatusMessageCollection.Last().MessageString;
                }
                return "None";
            }
        }

        public StatusBarViewModel()
        {
            StatusMessageCollection = new ObservableCollection<StatusBarMessage>();
            Messenger.Default.Register<SetStatusBarText>(this, StatusAdded);
            Collapse = true;
            OpenWindow = new ActionCommand(OpenMessagesWindow, CanOpenMessagesWindow);
        }
        void StatusAdded(SetStatusBarText message)
        {
            Debug.WriteLine("Got it!");
            //Get the message
            string statusText = message.messageText;
            //Check if last is the same, if so add it and append the number of simial messages
            if (StatusMessageCollection.Count > 0 && StatusMessageCollection.Last().MessageString == statusText && Collapse)
            {
                StatusMessageCollection.Last().Similar++;
            }
            else
            {
                //The last one was not equal or it was but collapse was false enabled
                StatusMessageCollection.Add(new StatusBarMessage(statusText));
            }
            RaisePropertyChanged("StatusBarText");
             
        }
        void OpenMessagesWindow()
        {
            Debug.WriteLine("Open Window");
            this.messagesWindow = new StatusMessagesWindow();
            this.messagesWindow.Closed += (sender, args) => this.messagesWindow = null;
            this.messagesWindow.Show();
        }
        bool CanOpenMessagesWindow()
        {
            if (messagesWindow == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ActionCommand  OpenWindow { get; private set; }
    }
}
