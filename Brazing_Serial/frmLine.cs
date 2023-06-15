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
            int index = comboBox1.Items.IndexOf(Properties.Settings.Default.Line);
            this.comboBox1.SelectedIndex = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                DialogResult = DialogResult.OK;
                Properties.Settings.Default.Line = comboBox1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                this.Close();
            }

        }

    }
}
