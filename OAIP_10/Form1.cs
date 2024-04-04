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
        Random random = new Random();

        private static int comparissons = 0;
        private static int permutations = 0;
        public static string time = "MM:SS:MS";
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
            trackBar1.Scroll += trackBar1_Scroll;
            Instance = this;
        }

        public static void ReadInfo(int comp, int perm, string ti)
        {
            comparissons = comp;
            permutations = perm;
            time = ti;
        }
        public static void AddSortLine(string str)
        {
            Instance.richTextBox1.Text += str + '\n';
        }
        public static void FillFirstLine()
        {
            Instance.richTextBox1.Text = "Исходный массив:\n";
            foreach (var i in Context.array)
                Instance.richTextBox1.Text += i + " ";
            Instance.richTextBox1.Text += "\n\n";
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", trackBar1.Value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var newArr = new int[trackBar1.Value];

            for(int i = 0; i < newArr.Length; i++)
                newArr[i] = random.Next(0,100);

            Context.array = newArr;
            FillFirstLine();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var mboxResult = MessageBox.Show("Подготовить файл для сохранения?", "Внимание", MessageBoxButtons.YesNo);

            var flag = mboxResult == DialogResult.Yes;

            Context context;
            if (radioButton2.Checked)
                context = new Context(new ImprovedSort());
            else
                context = new Context(new SimpleSort());
            context.SortArr(flag);
            output(Context.array);
            //FileOut.sorted = true;
            PrintInfo(comparissons, permutations, time);
        }
        private void PrintInfo(int comparissons, int permutations, string time)
        {
            label_permutations.Text = Convert.ToString(permutations);
            label_comparissons.Text = Convert.ToString(comparissons);
            label_time.Text = time;
        }
        


        
        public void output(int[] mas)
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
