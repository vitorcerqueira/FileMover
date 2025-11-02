using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMover
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fbd.SelectedPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
