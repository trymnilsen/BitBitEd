using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.StatusBar
{
    public class StatusBarMessage:ObservableObject
    {
        private int similarMessages;
        public int Similar
        {
            get { return similarMessages; }
            set
            {
                if(similarMessages<value)
                {
                    similarMessages = value;
                    RaisePropertyChanged("Similar");
                }
            }
        }
        //Should not change
        public string MessageString { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public StatusBarMessage(string MessageText)
        {
            MessageString = MessageText;
            Similar = 0;
            TimeStamp = DateTime.Now;
        }
    }
}
