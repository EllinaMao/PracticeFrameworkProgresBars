using PracticeFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Task2
{
    public partial class Form1 : Form
    {
        private SynchronizationContext ctx;

        public Form1()
        {
            InitializeComponent();
            ctx = SynchronizationContext.Current;
            TaskProgressBar.finish += addToResult;

            dataGridView1.Columns.Add("Place", "Место");
            dataGridView1.Columns.Add("Horse", "Конь");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            TaskProgressBar.StartProgressBar(ctx, tableLayoutPanel1);

        }
        private void addToResult(object sender, EventEventArgs e)
        {
            dataGridView1.Rows.Add(e.Place, e.HorseName);

        }
    }
}