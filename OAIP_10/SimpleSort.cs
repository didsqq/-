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
        private int permutations = 0;
        private int comprassions = 0;
        public void SortArr(int[] mas, bool flag)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (Swap_Comp.Comprassions(mas, j, min, flag, comprassions))
                    {
                        min = j;
                        comprassions++;
                    }
                }

                Swap_Comp.Swap(mas, min, i, flag, permutations);
                permutations++;
            }

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            Form1.ReadInfo(comprassions, permutations, time);

            string sortString = "";
            for (int i = 0; i < mas.Length; i++)
                sortString += mas[i] + " ";
            Form1.AddSortLine(sortString);
        }

        public void AnalSortArr(AnalInfo analinfo)
        {
            Random random = new Random();
            int[] mas = new int[analinfo.count];
            for (int i = 0; i < analinfo.count; i++)
                mas[i] = random.Next(0, 1000);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (Comprassions(mas, j, min))
                    {
                        min = j;
                        comprassions++;
                    }
                }

                Swap(mas, min, i);
                permutations++;
            }

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00};{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            analinfo.permutations = permutations;
            analinfo.comprassions = comprassions;
            analinfo.time = time;
        }

        public void Swap(int[] arr, int ind1, int ind2)
        {
            permutations++;
            int temp = arr[ind1];
            arr[ind1] = arr[ind2];
            arr[ind2] = temp;
        }

        public bool Comprassions(int[] arr, int ind1, int ind2)
        {
            comprassions++;
            return arr[ind1] > arr[ind2];
        }
    }
}

