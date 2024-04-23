using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAIP_10
{
    static class Swap_Comp
    {
        public static void Swap(int[] mas, int i1, int i2, bool flag, int permutations)
        {
            permutations++;
            if (flag)
                FileOut.fileString += $"Перемещение {permutations}: " + $"[{i1}] - {mas[i1]} и [{i2}] - {mas[i2]}\n";

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
            if(flag)
                FileOut.Fill();
        }

        public static bool Comprassions(int[] arr, int ind1, int ind2, bool flag, int comprassions)
        {
            comprassions++;
            if (flag && FileOut.fileString == null)
            {
                FileOut.fileString = "Исходный массив: ";
                FileOut.Fill();
            }
            if (flag)
                FileOut.fileString += $"Сравнение {comprassions}: " + $"{arr[ind1]} и {arr[ind2]}\n";
            return arr[ind1] < arr[ind2];
        }

        public static void SwapAnal(int[] arr, int ind1, int ind2)
        {
            int temp = arr[ind1];
            arr[ind1] = arr[ind2];
            arr[ind2] = temp;
        }

        public static bool ComprassionsAnal(int[] arr, int ind1, int ind2)
        {
            return arr[ind1] < arr[ind2];
        }
    }
}
