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
using Task4_wirdInFile;

namespace Task5_All_files
{
    public partial class Form1 : Form
    {
        private SynchronizationContext ctx;


        public Form1()
        {
            InitializeComponent();
            ctx = SynchronizationContext.Current;
        }

        private void RefreshDataGrid(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {

            string folderPath = textBoxPath.Text;
            string word = textBoxWord.Text;
            RefreshDataGrid(sender, e);
            FileFind.CountWordInDirectory(ctx, folderPath, word, dataGridView1);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }



        }
    }
}
