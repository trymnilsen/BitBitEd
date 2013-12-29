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
        private int gridSizeX;
        private int gridSizeY;
        private int screenRotation;
        private double screenScale;
        private bool showGrid;
        private bool canEditOptions;

        private EntityScreen selectedScreenTab;
        public int GridSizeX {
            get { return gridSizeX; }
            set
            {
                if(value!=gridSizeX)
                {
                    gridSizeX = value;
                    RaisePropertyChanged("GridSizeX");
                }
            }
        }
        public int GridSizeY
        {
            get { return gridSizeY; }
            set
            {
                if (value != gridSizeY)
                {
                    gridSizeY = value;
                    RaisePropertyChanged("GridSizeY");
                }
            }
        }
        public int ScreenRotation
        {
            get { return screenRotation; }
            set
            {
                if (value != screenRotation)
                {
                    screenRotation = value;
                    RaisePropertyChanged("ScreenRotation");
                }
            }
        }
        public double ScreenScale { get; set; }
        public bool ShowGrid { get; set; }

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
