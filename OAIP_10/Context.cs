using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAIP_10
{
    class Context
    {
        public static int[] array;
        public IStrategy strategy;
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SortArr(bool flag = true)
        {
            strategy.SortArr(array, flag);
        }
    }
}
