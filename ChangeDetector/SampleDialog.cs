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
    public partial class SampleDialog : Form
    {
        public SampleDialog()
        {
            InitializeComponent();
        }

        private void SampleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult.Equals(DialogResult.Cancel))
            {
                e.Cancel = changeDetector1.CancelFormClosing(sender);
            }
               
        }
    }
}
