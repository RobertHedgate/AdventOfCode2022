using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    internal class Extra
    {
        public int TestCycle(int cycle, int x, int result)
        {
            if (cycle == 20)
            {
                result += x * cycle;
            }
            if (cycle == 60)
            {
                result += x * cycle;
            }
            if (cycle == 100)
            {
                result += x * cycle;
            }
            if (cycle == 140)
            {
                result += x * cycle;
            }
            if (cycle == 180)
            {
                result += x * cycle;
            }
            if (cycle == 220)
            {
                result += x * cycle;
            }

            return result;
        }
    }
}
