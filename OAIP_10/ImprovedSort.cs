using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIP_10
{
    class ImprovedSort: IStrategy
    {
        private int permutations;
        private int comprassions;
        public void SortArr(int[] array, bool flag)
        {
            int a = 0;
            int b = array.Length-1;
            int i = a;
            int j = b;
            int middle = array[(a + b) / 2];
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    i++;
                }
                while (array[j] > middle)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap_Comp.Swap(array, i, j, flag, permutations);
                    i++;
                    j--;
                }
            }
            if (a < j)
            {
                SortArr(array, true);
            }
            if (i < b)
            {
                SortArr(array, false);
            }
        }
    }
}
