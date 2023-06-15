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
    public partial class frmPopupRubberCheck : Form
    {
        private string check;

        public string Check
        {
            get { return check; }
            set { check = value; }
        }
        public frmPopupRubberCheck()
        {
            InitializeComponent();
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '1' || e.KeyChar == '0')
            {

                //string a = txtInput.Text;
                this.Check = e.KeyChar == '1' ? "OK" : "NG";
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();



            }
            else
            {
                bool CheckNG = true;
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    CheckNG = false;
                }

                // only allow one decimal point
                if ((((sender as TextBox).Text.IndexOf('.') > -1)))
                {
                    e.Handled = true;
                    CheckNG = false;
                }
                textBox1.Clear();
                //if (CheckNG)
                //{
                //    TextBox tb = (TextBox)sender;
                //    tb.BackColor = Color.Yellow;
                //}
            }



        }
    }
}
