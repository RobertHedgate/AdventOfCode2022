using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class Monkey
    {
        public List<int> Items = new List<int>();
        public string OperationItem = "";
        public int OperationNumber = 0;
        public bool OperationNumberOld = false;
        public int Divisible = 1;
        public int DivTrue = 0;
        public int DivFalse = 0;
        public int HandeldItems = 0;
    }
}
