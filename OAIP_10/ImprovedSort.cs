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
            sw.Start();

            FastSortArr(array, 0, array.Length - 1,flag);

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            Form1.ReadInfo(comprassions, permutations, time);

            string sortString = "";
            for (int k = 0; k < array.Length; k++)
                sortString += array[k] + " ";
            Form1.AddSortLine(sortString);
        }

        public void FastSortArr(int[] array,int a, int b, bool flag)
        {
            int i = a;
            int j = b;
            int middle = array[(a + b) / 2];
            while (i <= j)
            {
                while (Swap_Comp.Comprassions(array, i, (a + b) / 2, flag, comprassions))//array[i] < middle
                {
                    i++;
                    comprassions++;
                }
                while (Swap_Comp.Comprassions(array, (a + b) / 2, j, flag, comprassions))//array[j] > middle
                {
                    j--;
                    comprassions++;
                }
                if (i <= j)
                {
                    Swap_Comp.Swap(array, i, j, flag, permutations);
                    permutations++;
                    i++;
                    j--;
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
