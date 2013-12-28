using BitEd.Core;
using BitEd.Messages.Project;
using BitEd.Models;
using BitEd.Models.Action;
using BitEd.Models.Action.Actions;
using BitEd.Models.Entity;
using BitEd.Models.Event;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BitEd.ViewModels
{
    public class ProjectViewModel:ViewModelBase
    {
        //Private storage variables
        EntityRoot rootNode;
        EntityNode selectedNode;

        //Bindable Properties
        public EntityRoot RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                rootNode = value;
            }
        }
        public EntityNode SelectedItem
        {
            get { return selectedNode; }
            set { 
                selectedNode = value; 
                RaisePropertyChanged("SelectedItem");
                Debug.WriteLine("Changing Selected Item");
                SelectedItemChangeMessage.Send(value);
            }
        }
        public ObservableCollection<EntityNode> ProjectAssets { get; set; }
        public ProjectViewModel()
        {
            ProjectAssets = new ObservableCollection<EntityNode>();
            RootNode = new EntityRoot();
            ProjectAssets.Add(RootNode);
            EntityObject testObj = new EntityObject(rootNode, "Object01");
            RootNode.Childs.Add(testObj);

            AddCommands();
        }
        private void AddCommands()
        {
            AddObject = new ParamCommand(addObjectEntity, null);
            AddSprite = new ParamCommand(addSprite, null);
            AddScreen = new ParamCommand(addScreen, null);
            DoubleClickedOnEntity = new ParamCommand(openEntity, null);
        }
        void openEntity(object param)
        {
            EntityNode source = param as EntityNode;
            Debug.WriteLine("Double Clicked on:" + source.Name);
            OpenItemMessage.Send(source);
        }
        void addObjectEntity(object param)
        {
            if (param.GetType() == typeof(EntityObject))
            {
                Debug.WriteLine("Clicked add object" + param);
                EntityObject source = param as EntityObject;
                source.AddObject();
            }
        }
        void addSprite(object param)
        {
            EntityNode source = param as EntityNode;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Sprite Files (*.png, *.bmp)|*.png;*.bmp";
            bool? dialogOpen = dialog.ShowDialog();
            dialog.Multiselect = false;
            
            if(dialogOpen==true)
            {
                using (new WaitCursorHelper())
                {
                    Debug.WriteLine("Filepath:" + dialog.FileName);
                    byte[] image = File.ReadAllBytes(dialog.FileName);
                    MemoryStream imageMemoryStream = new MemoryStream(image);
                    BitmapImage loadedImage = new BitmapImage();
                    loadedImage.CacheOption = BitmapCacheOption.OnLoad;
                    loadedImage.BeginInit();
                    loadedImage.StreamSource = imageMemoryStream;
                    loadedImage.EndInit();
                    
                    //Entity
                    EntitySprite entitySprite = new EntitySprite(source, Path.GetFileNameWithoutExtension(dialog.FileName), loadedImage);
                    source.Childs.Add(entitySprite);
                }
            }
        }
        void addScreen(object param)
        {
            EntityNode source = param as EntityNode;
            EntityScreen newScreen = new EntityScreen("Foo", source);
            source.Childs.Add(newScreen);
        }
        public ParamCommand DoubleClickedOnEntity { get; private set; }
        public ParamCommand AddObject { get; private set; }
        public ParamCommand AddSprite { get; private set; }
        public ParamCommand AddScreen { get; private set; }

    }
}
