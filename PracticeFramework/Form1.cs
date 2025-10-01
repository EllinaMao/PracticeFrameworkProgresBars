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
/*Use BeginInvoke, Or Threads, Or ThreadPool WPF Or WinForms
*/
namespace PracticeFramework
{
    public partial class Form1 : Form
    {
        private SynchronizationContext ctx;

        public Form1()
        {
            InitializeComponent();
            ctx = SynchronizationContext.Current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count == 0) {
                MessageBox.Show("You dont have any Progress bars");
            }
            TaskProgressBar.StartProgressBar(ctx, flowLayoutPanel1);
        }
        private void createProgressBar_Click(object sender, EventArgs e)
        {
            ProgressBar pb = new ProgressBar
            {
                Width = 770,
                Height = 39,
                Minimum = 0,
                Maximum = 100,
                Value = 0
            };
            flowLayoutPanel1.Controls.Add(pb);
        }

        private void DeletePB_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                Control last = flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];
                if (last is ProgressBar)
                {
                    flowLayoutPanel1.Controls.Remove(last);
                    last.Dispose();
                }
            }
            else
            {
                MessageBox.Show("You dont have any Progress bars");
            }
        }
    }
}
