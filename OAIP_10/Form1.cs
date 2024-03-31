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
            trackBar1.Scroll += trackBar1_Scroll;
        }

        private int[] mas;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mas != null)
                Sort(mas);
            else
                MessageBox.Show("Создайте массив");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int value = trackBar1.Value;
            mas = GenerateArray(value, 1, 50);
            output(mas);
        }

        private void Sort(int[] mas){
            if (radioButton1.Checked == true)
            {
                ViborSort(mas);
            }
            else if (radioButton2.Checked == true)
            {
                QuickSort(mas, 0, mas.Length - 1);
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

        private void ViborSort(int[] mas)
        {
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
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
                richTextBox1.Text += "\n";
                output(mas);
            }
        }

        private void QuickSort(int[] array, int a, int b)
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
                    richTextBox1.Text += "\n";
                    output(array);
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
        }
        
        private void output(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (i != mas.Length - 1)
                    richTextBox1.Text += mas[i] + " ";
                else
                    richTextBox1.Text += mas[i];
            }
        }
    }
}
