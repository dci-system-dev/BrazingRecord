using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brazing_Serial
{
    public partial class frmLine : Form
    {
        public frmLine()
        {
            InitializeComponent();
        }

        private void frmLine_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                CGenaral.Line = comboBox1.SelectedItem.ToString();
                this.Close();
            }

        }

    }
}
