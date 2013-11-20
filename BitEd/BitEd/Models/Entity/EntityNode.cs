﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models.Entity
{
    public enum EntityType
    {
        Tile,
        TileSheet,
        Screen,
        Folder,
        Root,
        Sprite,
        Object,
        Dummy,
    }
    public abstract class EntityNode:INotifyPropertyChanged
    {
        [NonSerialized]
        private String name;

        private EntityNode parent;

        public EntityType Type { get; set; }
        public ObservableCollection<EntityNode> Childs { get; set; }
        public String Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    Debug.WriteLine("Changing to: " + value);
                }
            } 
        }
        
        public String ToolTip { get; set; }
        public EntityNode Parent
        {
            get { return parent; }
        }

        public EntityNode(EntityNode parent, EntityType type, string Name)
        {
            this.parent = parent;
            this.Childs = new ObservableCollection<EntityNode>();
            this.Name = Name;
            this.Type = type;
        }
        public EntityFolder CreateFolder(EntityNode parent, String name)
        {
            return new EntityFolder(name,parent);
        }
        public static EntityRoot CreateRoot()
        {
            return new EntityRoot();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
   
}
