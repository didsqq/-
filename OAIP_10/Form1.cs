using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIP_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void Sort(){
            if (radioButton1.Checked == true)
            {
                int[] mas = GenerateArray(10, 1, 100);
                mas = ViborSort(mas);

                richTextBox1.Text = "";
                for (int i = 0; i < mas.Length; i++)
                {
                    if (i != mas.Length - 1)
                        richTextBox1.Text += mas[i] + " ";
                    else
                        richTextBox1.Text += mas[i];
                }

            }
            else if (radioButton2.Checked == true)
            {
                int[] mas = GenerateArray(10, 1, 100);
                mas = QuickSort(mas, 0, mas.Length - 1);

                richTextBox1.Text = "";
                for (int i = 0; i < mas.Length; i++)
                {
                    if (i != mas.Length - 1)
                        richTextBox1.Text += mas[i] + " ";
                    else
                        richTextBox1.Text += mas[i];
                }
            }
            else
            {
                MessageBox.Show("Выберите метод");
            }
        }
        static int[] GenerateArray(int length, int minValue, int maxValue)
        {
            int[] array = new int[length];
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }

            return array;
        }

        static int[] ViborSort(int[] mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for(int j = 0; j < mas.Length - 1; j++)
                {
                    richTextBox1.Text += mas[i];
                }
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return mas;
        }

        static int[] QuickSort(int[] array, int a, int b)
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
                    int temporaryVariable = array[i];
                    array[i] = array[j];
                    array[j] = temporaryVariable;
                    i++;
                    j--;
                }
            }
            if (a < j)
            {
                QuickSort(array, a, j);
            }
            if (i < b)
            {
                QuickSort(array, i, b);
            }
            return array;
        }
    }
}
