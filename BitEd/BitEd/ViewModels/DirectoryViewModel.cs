using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BitEd.Core;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using BitEd.Models.Directory;

namespace BitEd.ViewModels
{
    public class DirectoryViewModel:ViewModelBase
    {
        private string currentDirectory;
        public string DirectoryPath
        {
            get
            {
                if (currentDirectory == null)
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                else
                {
                    return currentDirectory;
                }
            }
            set
            {
                if(currentDirectory!=value)
                {
                    Debug.WriteLine("Setting currentDirectory: "+currentDirectory+" to "+value);
                    currentDirectory = value;
                    RaisePropertyChanged("DirectoryPath");
                    RaisePropertyChanged("DirectoryListing");
                }
            }

        }
        public ObservableCollection<DirectoryEntry> DirectoryListing
        {
            get
            {
                return generateListings(DirectoryPath);
            }
        }

        //Not relevant for view
        private DirectoryEntry upDirectory = new DirectoryEntry("..","..", true);

        public DirectoryViewModel()
        {

        }
        private ObservableCollection<DirectoryEntry> generateListings(string path)
        {
            //get directories
            //get files
            //combine and add back
            ObservableCollection<DirectoryEntry> tmpCollection = new ObservableCollection<DirectoryEntry>();
            
            //Add the up a directory
            tmpCollection.Add(upDirectory);

            //as the observable collection has no add range we need to do it manually
            DirectoryInfo directory = new DirectoryInfo(path);
            
            foreach(DirectoryInfo dir in directory.GetDirectories())
            {
                if (dir.Attributes.HasFlag(FileAttributes.Directory) && !dir.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    tmpCollection.Add(new DirectoryEntry(dir.Name,dir.FullName, true));
                    //Debug.WriteLine("Adding Directory : " + dir + " with atributes: "+dir.Attributes);
                }
                else
                {
                    //Debug.WriteLine(dir.FullName + " Rejected because its type : " + dir.Attributes + " Was not valid");
                }
            }

            //Add the files
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Attributes.HasFlag(FileAttributes.Archive) && !file.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    tmpCollection.Add(new DirectoryEntry(file.Name, file.FullName, false));
                   
                }
                //Debug.WriteLine("File : " + file.Name+" has atributes: "+file.Attributes);
            }
            return tmpCollection;
        }

        //Commands
        void clickedDirectory(object param)
        {
            DirectoryEntry pressedEntry = param as DirectoryEntry;
            Debug.WriteLine("PRESSED: " + pressedEntry.Name);
            if (pressedEntry.IsFolder)
            {
                //Explicit handling of the back ".." entry
                if (pressedEntry.Path.Equals("..") && DirectoryPath!="C:\\")
                {
                    DirectoryPath = new DirectoryInfo(currentDirectory).Parent.FullName;
                }
                else
                {
                    DirectoryPath = pressedEntry.Path;
                }
            }

        }
        
        //Command Properties
        public ParamCommand ClickDirectory { get { return new ParamCommand(clickedDirectory, null); } }
    }
}
