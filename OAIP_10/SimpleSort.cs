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
        public void SortArr(int[] mas, bool flag)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }

                Swap(mas, min,i);
            }

            sw.Stop();
            var resultTime = sw.Elapsed;
            Form1.time = String.Format("{{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
        }

        private void Swap(int[] mas, int min, int i)
        {
            int temp = mas[min];
            mas[min] = mas[i];
            mas[i] = temp;
        }
    }
}

