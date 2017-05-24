using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDiZO_2
{
    public partial class FormDisplay : Form
    {
        public FormDisplay(string graph) 
        {
            InitializeComponent();
            textBoxDisplay.Text = graph;
        }
    }
}
