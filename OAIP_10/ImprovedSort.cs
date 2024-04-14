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
        private int permutations = 0;
        private int comprassions = 0;
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
            int middle = (a + b) / 2;
            while (i <= j)
            {
                while (Swap_Comp.Comprassions(array, i, middle, flag, comprassions))//array[i] < middle
                {
                    i++;
                    comprassions++;
                }
                while (Swap_Comp.Comprassions(array, middle, j, flag, comprassions))//array[j] > middle
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
        public void AnalSortArr(AnalInfo analinfo)
        {
            Random random = new Random();
            int[] arr = new int[analinfo.count];
            for (int i = 0; i < analinfo.count; i++)
                arr[i] = random.Next(0, 1000);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Anal_FastSortArr(arr, 0, arr.Length - 1);

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00};{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            analinfo.permutations = permutations;
            analinfo.comprassions = comprassions;
            analinfo.time = time;
        }
        public void Anal_FastSortArr(int[] array, int a, int b)
        {
            int i = a;
            int j = b;
            int middle = (a + b) / 2;
            while (i <= j)
            {
                while (Swap_Comp.ComprassionsAnal(array, i, middle))//array[i] < middle
                {
                    comprassions++;
                    i++;
                }
                while (Swap_Comp.ComprassionsAnal(array, middle, j))//array[j] > middle
                {
                    comprassions++;
                    j--;
                }
                if (i <= j)
                {
                    permutations++;
                    Swap_Comp.SwapAnal(array, i, j);
                    i++;
                    j--;
                }
            }
            if (a < j)
            {
                Anal_FastSortArr(array, a, j);
            }
            if (i < b)
            {
                Anal_FastSortArr(array, i, b);
            }
        }
    }
}
