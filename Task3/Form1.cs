using FormMain;
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

namespace Task3
{
    public partial class Form1 : Form
    {
        private SynchronizationContext ctx;
        int start;
        int end;
        public Form1()
        {
            InitializeComponent();
            ctx = SynchronizationContext.Current;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Fibbonachi.Items.Clear();

            start = (int)numericUpDown1.Value;
            end = (int)numericUpDown2.Value;
            ThreadNumberTask.Generate(Fibbonachi, start, end);
            
        }


    }
}
