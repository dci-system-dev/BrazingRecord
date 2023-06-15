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
    public partial class frmSetting : Form
    {
        CGenaral CGen = new CGenaral();
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string line;

        public string Line
        {
            get { return line; }
            set { line = value; }
        }
        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        
        
        public frmSetting()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CGenaral.IP = IP1.Text + "." + IP2.Text + "." + IP3.Text + "." + IP4.Text;
            CGenaral.Port = Int32.Parse(lbPort.Text);
            CGenaral.Line = lbLine.Text;
            this.Ip = IP1.Text + "." + IP2.Text + "." + IP3.Text + "." + IP4.Text;
            this.Line = lbLine.Text;
            this.Port = Int32.Parse(lbPort.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {

            IP1.Text = CGenaral.IP.Split('.')[0];
            IP2.Text = CGenaral.IP.Split('.')[1];
            IP3.Text = CGenaral.IP.Split('.')[2];
            IP4.Text = CGenaral.IP.Split('.')[3];
            lbPort.Text = CGenaral.Port.ToString();
            lbLine.Text = CGenaral.Line;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
