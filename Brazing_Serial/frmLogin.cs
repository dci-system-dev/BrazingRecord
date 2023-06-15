
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LineMonitorDemo.Connection;

namespace Brazing_Serial
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        ConnectDB oConn = new ConnectDB();
        CGenaral CGR = new CGenaral();
        public static string _EmpLine = "";

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtEmpCode.Text = "";
        }

        private void Login()
        {
            if (txtEmpCode.Text.Trim() != "" && txtEmpCode.Text.Trim().Length >= 5)
            {


                if (CGenaral.empAdmin.Contains(txtEmpCode.Text.Trim()))
                {
                    
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("คุณไม่ได้รับสิทธิ์ในการแก้ไข กรุณาติดต่อแผนกไอที เพื่อขอรับสิทธิ์ โทร 133");
                    txtEmpCode.Text = "";
                }
            }
            else
            {
                MessageBox.Show("รหัสพนักงานไม่ถูกต้อง");
                txtEmpCode.Text = "";
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool CheckNG = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                CheckNG = false;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                CheckNG = false;
            }

            //if (CheckNG)
            //{
            //    TextBox tb = (TextBox)sender;
            //    tb.BackColor = Color.Yellow;
            //}

        }

        private void txt_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            if (!String.IsNullOrEmpty(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }
        
    }
}
