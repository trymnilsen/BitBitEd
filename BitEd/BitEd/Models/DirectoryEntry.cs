using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models
{
    class DirectoryEntry
    {
        public string Name {get; set;}
        public bool IsFolder { get; set; }
        public string Path { get; set; }

        public DirectoryEntry(string name, string path, bool isFolder)
        {
            this.Path = path;
            this.Name = name;
            this.IsFolder = isFolder;
        }
    }
}
