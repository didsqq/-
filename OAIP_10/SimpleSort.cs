using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIP_10
{
    class SimpleSort : IStrategy
    {
        private int permutations;
        private int comprassions;
        public void SortArr(int[] mas, bool flag)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min] && Swap_Comp.Comprassions(mas, j, min, flag, comprassions))
                    {
                        min = j;
                        comprassions++;
                    }
                }

                Swap_Comp.Swap(mas, min,i, flag, permutations);
                permutations++;
            }

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            Form1.ReadInfo(comprassions, permutations, time);
        }
    }
}

