using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    internal class ElfFile
    {
        public string Name = "";
        public int Size;

        public ElfFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
