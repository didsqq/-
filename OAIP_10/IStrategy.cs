using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAIP_10
{
    interface IStrategy
    {
        void SortArr(int[] arr, bool flag);
        void AnalSortArr(AnalInfo analInfo);
    } 
}
