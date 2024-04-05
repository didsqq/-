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
                    if (mas[j] < mas[min] && Comprassions(mas, j, min, flag))
                    {
                        min = j;
                    }
                }

                Swap(mas, min,i, flag);
            }

            sw.Stop();
            var resultTime = sw.Elapsed;
            string time = String.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            Form1.ReadInfo(comprassions, permutations, time);
        }

        private void Swap(int[] mas, int i1, int i2, bool flag)
        {
            permutations++;
            //if (flag)
            //FileOut.filestring += $"Перемещение {permutations}: " + $"[{i1}] - {mas[i1]} и [{i2}] - {mas[i2]}\n";

            string swapString = "";
            for (int i = 0; i < mas.Length; i++)
                if (i == i1 || i == i2)
                    swapString += $"[{mas[i]}]";
                else
                    swapString += mas[i] + " ";
            Form1.AddSortLine(swapString);

            int temp = mas[i1];
            mas[i1] = mas[i2];
            mas[i2] = temp;
        }

        private bool Comprassions(int[] arr, int ind1, int ind2, bool flag)
        {
            comprassions++;

            /*if(flag && FileOut.fileString = null)
            {
                FileOut.fileString = "Исходный массив: ";
                FileOut.Fill;
            }
            if (flag)
                FileOut.fileString += $"Сравнение {comprassions}: " + $"{arr[ind1]} и {arr[ind2]}\n";*/
            return true;
        }
    }
}

