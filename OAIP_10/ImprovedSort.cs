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
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            FastSortArr(array, 0, array.Length - 1,flag);

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            Form1.ReadInfo(comprassions, permutations, time);
        }

        public void FastSortArr(int[] array,int a, int b, bool flag)
        {
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
                    permutations++;
                }
            }
            if (a < j)
            {
                FastSortArr(array, a, j, flag);
            }
            if (i < b)
            {
                FastSortArr(array, i, b, flag);
            }
        }
    }
}
