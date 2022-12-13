using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    internal class Folder
    {
        public string Name = "";
        public List<Folder> Folders = new List<Folder>();
        public List<ElfFile> Files = new List<ElfFile>();
        public Folder? Parent = null;

        public Folder(Folder parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        internal Folder FindFolder(string name)
        {
            foreach (Folder folder in Folders)
            {
                if (folder.Name == name)
                {
                    return folder;
                }
            }
            throw new Exception("folder not found");
        }

        internal int Size()
        {
            var size = 0;

            foreach (var file in Files)
            {
                size += file.Size;
            }
            foreach (var folder in Folders)
            {
                size += folder.Size();
            }

            return size;
        }

        internal List<ElfFile> FolderSizes()
        {
            var size = 0;
            var list = new List<ElfFile>();
            size = Size();
            list.Add(new ElfFile(Name, size));
            foreach (var folder in Folders)
            {
                var sublist = folder.FolderSizes();
                list.AddRange(sublist);
            }
            return list;
        }
    }
}
