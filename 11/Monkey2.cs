using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class Monkey2
    {
        public List<ulong> Items = new List<ulong>();
        public string OperationItem = "";
        public ulong OperationNumber = 0;
        public bool OperationNumberOld = false;
        public ulong Divisible = 1;
        public int DivTrue = 0;
        public int DivFalse = 0;
        public int HandeldItems = 0;
    }
}
