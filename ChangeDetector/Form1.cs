using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDetector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form d = new SampleDialog();
            var result = d.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            changeDetector1.InformationMessage = "Do you want to save the changes you made in Document1?";
            e.Cancel = changeDetector1.CancelFormClosing(sender);
        }

        private void changeDetector1_Change(object sender, ChangeDetectorControlLibrary.ChangeOccurredEventArgs e)
        {
            e.ChangedOccurred = true;
        }
    }
}
