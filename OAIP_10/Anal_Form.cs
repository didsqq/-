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
    public partial class Anal_Form : Form
    {
        public Anal_Form()
        {
            InitializeComponent();

            dataGridView1.Dock = DockStyle.Fill;

            var columnSort = new DataGridViewTextBoxColumn();
            columnSort.HeaderText = " Сортировка";
            dataGridView1.Columns.Add(columnSort);

            var columnCount = new DataGridViewTextBoxColumn();
            columnCount.HeaderText = "Кол-во элементов";
            dataGridView1.Columns.Add(columnCount);

            var columnComparisons = new DataGridViewTextBoxColumn();
            columnComparisons.HeaderText = "Кол-во Сравнений";
            dataGridView1.Columns.Add(columnComparisons);

            var columnPermutations = new DataGridViewTextBoxColumn();
            columnPermutations.HeaderText = "Кол-во перемещений";
            dataGridView1.Columns.Add(columnPermutations);

            var columnTime = new DataGridViewTextBoxColumn();
            columnTime.HeaderText = "Время сортировки";
            dataGridView1.Columns.Add(columnTime);

        }

        public void Analysis()
        {
            AnalInfo[] InsertSorts =
                {
                new AnalInfo() { count = 10},
                new AnalInfo() { count = 100},
                new AnalInfo() { count = 1000},
                new AnalInfo() { count = 10000}
                };
            foreach (var sort in InsertSorts)
            {
                new Context(new SimpleSort()).AnalSortArr(sort);

                dataGridView1.Rows.Add("Метод вставок", sort.count, sort.comprassions, sort.permutations, sort.time);
            }

            AnalInfo[] ShellSorts =
                {
                new AnalInfo() { count = 10},
                new AnalInfo() { count = 100},
                new AnalInfo() { count = 1000},
                new AnalInfo() { count = 10000}
                };
            foreach (var sort in ShellSorts)
            {
                new Context(new ImprovedSort()).AnalSortArr(sort);

                dataGridView1.Rows.Add("Метод быстрой", sort.count, sort.comprassions, sort.permutations, sort.time);
            }
        }

        private void Anal_Form_Load(object sender, EventArgs e)
        {
            Analysis();
        }
    }
}
