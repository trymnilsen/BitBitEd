using BitEd.Messages.Project;
using BitEd.Models.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitEd.ViewModels
{
    public class ScreenViewModel:ViewModelBase
    {
        private bool canEditOptions;

        private EntityScreen selectedScreenTab;

        public EntityScreen SelectedScreen {
            get { return selectedScreenTab; }
            set
            {
                if(selectedScreenTab!=value)
                {
                    selectedScreenTab = value;
                    RaisePropertyChanged("SelectedScreen");
                }
            }
        }
        public ObservableCollection<EntityScreen> OpenScreens { get; set; }

        public ScreenViewModel()
        {
            OpenScreens = new ObservableCollection<EntityScreen>();
            OpenScreens.Add(new EntityScreen("Tesg",null));
            OpenScreens.Add(new EntityScreen("Too",null));
            SelectedScreen = OpenScreens[0];
            Messenger.Default.Register<OpenItemMessage>(this, screenOpened);
        }
        void screenOpened(OpenItemMessage message)
        {
            //is the opened item an entity screen type?
            if (message.Item.GetType() == typeof(EntityScreen))
            {
                //Is the screen open/Does the openscreens collection contain our doubleclicked(or requested screen to be opened)
                if (OpenScreens.Contains(message.Item))
                {
                    //yes it does
                    //set it as the active one/show it
                    SelectedScreen = message.Item as EntityScreen;
                }
                //Nope it does not
                else
                {
                    //add it to the Collection
                    OpenScreens.Add(message.Item as EntityScreen);
                    SelectedScreen = message.Item as EntityScreen;
                }
            }
        }
        public ICommand CloseAllWindows { get; private set; }
        public ICommand CloseWindow { get; private set; }
        public ICommand CloseAllButThisWindow { get; private set; }
    }
}
