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
                    Swap(array, i, j);
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

        private void Swap(int[] array, int j, int i)
        {
            int temporaryVariable = array[i];
            array[i] = array[j];
            array[j] = temporaryVariable;
        }
    }
}
