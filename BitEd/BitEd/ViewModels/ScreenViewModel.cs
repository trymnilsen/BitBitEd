using BitEd.Models.Entity;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitEd.ViewModels
{
    public class ScreenViewModel:ViewModelBase
    {
        public EntityScreen SelectedScreen { get; set; }
        public ObservableCollection<EntityScreen> OpenScreens { get; set; }

        public ScreenViewModel()
        {
            OpenScreens = new ObservableCollection<EntityScreen>();
            OpenScreens.Add(new EntityScreen());
            OpenScreens.Add(new EntityScreen());
        }

        public ICommand CloseAllWindows { get; private set; }
        public ICommand CloseWindow { get; private set; }
        public ICommand CloseAllButThisWindow { get; private set; }
    }
}
