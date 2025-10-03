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

namespace Task4_wirdInFile
{
    public partial class Form1 : Form
    {
        SynchronizationContext ctx;
        public Form1()
        {
            InitializeComponent();
            ctx = SynchronizationContext.Current;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            var word = textBoxWord.Text.ToLower().Trim();
            var filepath = textBoxFile.Text.Trim();

            FileFind.FindCountWord(ctx, word, filepath, labelResult);


        }
    }
}
