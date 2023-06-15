using LineMonitorDemo.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brazing_Serial
{
    public partial class Form1 : Form
    {
        ConnectDB conn = new ConnectDB();
        ConnectDBIoT connIoT = new ConnectDBIoT();
        CGenaral CGR = new CGenaral();
        TcpClient client;
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void txtBZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Enter key pressed");
            }
            if (e.KeyChar == 13)
            {
                MessageBox.Show("Enter key pressed");
            }
        }
        private void GetCountTopButtomWelding()
        {
            try
            {
                if (Properties.Settings.Default.topbot == true)
                {
                    SqlCommand sql = new SqlCommand();
                    DataTable dt = new DataTable();
                    string ST = "";
                    string ED = "";
                    if (DateTime.Now.Hour >= 08 && DateTime.Now.Hour <= 20)
                    {
                        ST = DateTime.Now.ToString("yyyy-MM-dd 08:00");
                        ED = DateTime.Now.ToString("yyyy-MM-dd 20:00");
                    }
                    else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 24)
                    {
                        ST = DateTime.Now.ToString("yyyy-MM-dd 20:00");
                        ED = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 08:00");
                    }
                    else if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour <= 08)
                    {
                        ST = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 20:00");
                        ED = DateTime.Now.ToString("yyyy-MM-dd 08:00");
                    }
                    sql.CommandText = Properties.Settings.Default.Query;
                    sql.Parameters.Add(new SqlParameter("@ST", ST));
                    sql.Parameters.Add(new SqlParameter("@ED", ED));
                    dt = connIoT.Query(sql);
                    if (dt.Rows.Count > 0)
                    {
                        lbCountWelding.Invoke(new Action(() => lbCountWelding.Text = dt.Rows[0]["PartSerialNo"].ToString()));
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        private void GeTDatatogridview()
        {

            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 25, FontStyle.Bold);
            this.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            string ST = "";
            string ED = "";
            if (DateTime.Now.Hour >= 08 && DateTime.Now.Hour <= 20)
            {
                ST = DateTime.Now.ToString("yyyy-MM-dd 08:00");
                ED = DateTime.Now.ToString("yyyy-MM-dd 20:00");
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 24)
            {
                ST = DateTime.Now.ToString("yyyy-MM-dd 20:00");
                ED = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 08:00");
            }
            else if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour <= 08)
            {
                ST = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 20:00");
                ED = DateTime.Now.ToString("yyyy-MM-dd 08:00");
            }
            dt = new DataTable();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @" SELECT CASE WHEN SerialNo = '' THEN CONCAT('No Serial',' : (',EmpCode,')',' ',FORMAT(StampTime,'dd/MM/yyyy HH:mm:ss')) ELSE CONCAT(SerialNo,' : (',EmpCode,')',' ',FORMAT(StampTime,'dd/MM/yyyy HH:mm:ss')) END  Serial FROM [dbIoTFac2].[dbo].[etd_leak_check] where LineName =@Line and StampTime between @startdate and @enddate order by StampTime desc";
            sql.Parameters.Add(new SqlParameter("@Line", Properties.Settings.Default.Line));
            sql.Parameters.Add(new SqlParameter("@startdate", ST));
            sql.Parameters.Add(new SqlParameter("@enddate", ED));
            dt = conn.Query(sql);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = dt));

            }
            else
            {
                dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = null));
            }
            lbActual.Invoke(new Action(() => lbActual.Text = dt.Rows.Count.ToString()));
            txtBZ.Invoke(new Action(() => txtBZ.SelectAll()));
            txtBZ.Invoke(new Action(() => txtBZ.Focus()));





        }
        [DllImport("user32.dll")]
        static extern int MapVirtualKey(int uCode, uint uMapType);

        const uint MAPVK_VK_TO_CHAR = 0x02;
        private void txtBZ_KeyUp(object sender, KeyEventArgs e)
        {
            int key = MapVirtualKey((int)e.KeyCode, MAPVK_VK_TO_CHAR);
            string Value = ((char)key).ToString();
            string Value2 = txtBZ.Text;

            lb_Alarm.Hide();
            if (Value2 == "1" || Value2 == "2" || Value2 == "3")
            {
                string Number = Value2;
                //string a = txtInput.Text;
                SaveData(Number);
                LB_CHECK.Text = "KEY_UP";
            }
            else
            {
                lb_Alarm.Text = "กรุณากรอก Station ให้ถูกต้อง";
                lb_Alarm.Show();
                txtBZ.Text = "";
                txtBZ.SelectAll();
                txtBZ.Focus();
                //bool CheckNG = true;
                //if (!char.IsControl(e.KeyData) && !char.IsDigit(e.KeyValue))
                //{
                //    e.Handled = true;
                //    CheckNG = false;
                //}

                //// only allow one decimal point
                //if ((((sender as TextBox).Text.IndexOf('.') > -1)))
                //{
                //    e.Handled = true;
                //    CheckNG = false;
                //}

                //if (CheckNG)
                //{
                //    TextBox tb = (TextBox)sender;
                //    tb.BackColor = Color.Yellow;
                //}
            }

        }
        private void SaveData(string Brazing_No)
        {

            txtBZ.Text = txtBZ.Text.Replace("\r\n", "");
            StringBuilder std = new StringBuilder();
            //if (txtSerial.Text != "" && !txtSerial.Text.Contains("ERROR"))
            if (txtSerial.Text != "" && !txtSerial.Text.Contains("ERROR"))
            {
                //  string CheckRubber = "1";
                // frmPopupRubberCheck frmrb = new frmPopupRubberCheck();
                //frmrb.ShowDialog();
                //if (frmrb.DialogResult == System.Windows.Forms.DialogResult.OK)
                //{
                //    CheckRubber = frmrb.Check;
                //}
                //if (CGR.GetcheckBrazing(txtBZ.Text, Properties.Settings.Default.Line) == true)
                //{
                if (Brazing_No.Trim() != "")
                {
                    // PRE MODIFY string emp = CGR.GetcheckBrazing(Brazing_No.Trim(), "main" + Properties.Settings.Default.Line);

                    // MODIFY > ปรับมาใช้ 226.86 dbSCM SKC_CHECKINOUTLOG BY.PEERAPONG.K
                    string emp = CGR.GetcheckBrazing(Brazing_No.Trim(),Properties.Settings.Default.Line,LB_LI,LB_ST);
                    // END MODIFY > PEERAPONG.K
                   
                    if (emp != "")
                    {
                        std.AppendLine("insert into [dbIoTFac2].[dbo].[etd_leak_check]([SerialNo],[Brazing],[LineName],[StampTime],[EmpCode]) values('" + txtSerial.Text.Trim() + "','" + Brazing_No.Trim() + "','" + Properties.Settings.Default.Line + "',GETDATE(),'" + emp + "')");
                        conn.Query(std.ToString());
                        if (!backgroundWorker2.IsBusy)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                        ChangeColorGrid();
                        lb_Alarm.Hide();
                        txtSerial.Text = "";
                        txtBZ.Text = "";
                        txtBZ.SelectAll();
                        txtBZ.Focus();
                    }
                    else
                    {
                        lb_Alarm.Text = "ไม่มีข้อมูลพนักงานที่ Station นี้";
                        lb_Alarm.Show();
                        txtBZ.Text = "";
                        txtBZ.SelectAll();
                        txtBZ.Focus();
                    }
                }
                else
                {
                    lb_Alarm.Text = "กรุณากรอก Station ให้ถูกต้อง";
                    lb_Alarm.Show();
                    txtBZ.Text = "";
                    txtBZ.SelectAll();
                    txtBZ.Focus();
                }


                //}
                //else
                //{

                //    txtBZ.Text = "";
                //    txtBZ.SelectAll();
                //    txtBZ.Focus();

                //    lb_Alarm.Text = "กรอก Brazing No ให้ถูกต้องด้วยครับ";
                //    lb_Alarm.Show();
                //}
            }
            else
            {
                lb_Alarm.Text = "กรุณากรอกเลข Brazing No ก่อนครับ";
                lb_Alarm.Show();
                txtBZ.Text = "";
                txtBZ.SelectAll();
                txtBZ.Focus();
            }
        }
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //string emp = CGR.GetcheckBrazing("1","1");
            if (Properties.Settings.Default.topbot == false)
            {
                PN_topbot.Hide();
                lbOperationg.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Bold);
            }
            //this.TopMost = true;



            this.WindowState = FormWindowState.Maximized;
            txtSerial.Text = "";
            //  txtSerial.Text = "012601062671080006";
            txtBZ.Text = "";
            lb_Alarm.Hide();
            // StartConnection(CGenaral.IP, CGenaral.Port);
            //  frmLine frmline = new frmLine();
            //  frmline.ShowDialog();
            lb_Line.Text = Properties.Settings.Default.Line;

            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            GetCountTopButtomWelding();
            GeTDatatogridview();
            ChangeColorGrid();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            timer1.Start();
            timer2.Start();
            timer3.Start();
            //timer4.Start();
            txtBZ.SelectAll();
            txtBZ.Focus();
        }

        private void ChangeColorGrid()
        {

            for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
            {
                var row = dataGridView1.Rows[x];

                if (row.Cells["Serial"].Value.ToString().Contains("ERROR") || row.Cells["Serial"].Value.ToString().Contains("No Serial"))
                {
                    row.Cells["Serial"].Style.BackColor = Color.Red;

                }
                else
                {
                    row.Cells["Serial"].Style.BackColor = Color.Lime;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (client.Connected == true)
                    {
                        Byte[] data = new Byte[256];
                        NetworkStream stream = client.GetStream(); // Stream Recieve TCP 
                        String responseData = String.Empty;
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = Encoding.ASCII.GetString(data, 0, bytes);
                        LB_SERIAL.Text = responseData;
                        //txtSerial.Invoke(new Action(() => txtSerial.Text = responseData));

                        //MODIFY BY.PEERAPONG_K
                        txtSerial.Invoke(new Action(() => txtSerial.Text = (responseData.Contains("ERROR") ? "" : responseData)));
                        //END
                        //SaveData("1");
                        LB_CHECK.Text = "VISION";
                    }
                }
                catch (Exception)
                {
                    StartConnection(Properties.Settings.Default.IP, Properties.Settings.Default.Port);

                }
            }
        }
        private void StartConnection(string IP, int Port)
        {
            LB_IP.Text = IP;
            try
            {
                if (client == null)
                {
                    client = new TcpClient(IP, Port);
                }
                else
                {
                    client.Close();
                    client = new TcpClient(IP, Port);
                }

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                StartConnection(IP, Port);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                StartConnection(IP, Port);
            }




        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!backgroundWorker3.IsBusy)
            {
                backgroundWorker3.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            GeTDatatogridview();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            ChangeColorGrid();
            txtBZ.Invoke(new Action(() => txtBZ.SelectAll()));
            txtBZ.Invoke(new Action(() => txtBZ.Focus()));
        }

        private void lb_Line_Click(object sender, EventArgs e)
        {
            using (var fromLine = new frmLine())
            {
                var result = fromLine.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    lb_Line.Text = Properties.Settings.Default.Line;
                    LB_LI.Text = ("LINE : " + Properties.Settings.Default.Line);
                }
            }
            //frmLine frmline = new frmLine();
            //frmline.ShowDialog();
            

            //if (!backgroundWorker2.IsBusy)
            //{
            //    backgroundWorker2.RunWorkerAsync();
            //}
            GeTDatatogridview();
            ChangeColorGrid();
            txtBZ.SelectAll();
            txtBZ.Focus();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (client.Connected == false)
                {
                    if (PingHost(CGenaral.IP) == false)
                    {
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.Text = "OFF"));
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.BackColor = Color.Red));
                    }
                    else if (PingHost(CGenaral.IP) == true)
                    {
                        StartConnection(Properties.Settings.Default.IP, Properties.Settings.Default.Port);
                    }
                }
                else
                {
                    if (PingHost(CGenaral.IP) == false)
                    {
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.Text = "OFF"));
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.BackColor = Color.Red));
                        StartConnection(Properties.Settings.Default.IP, Properties.Settings.Default.Port);


                    }
                    else
                    {
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.Text = "ON"));
                        lb_SR1000.Invoke(new Action(() => lb_SR1000.BackColor = Color.Lime));
                    }
                }
            }
            catch (Exception)
            {
                StartConnection(Properties.Settings.Default.IP, Properties.Settings.Default.Port);
            }
        }
       
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
        public static bool PingHost_port(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch
            {

                return false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker4.IsBusy)
            {
                backgroundWorker4.RunWorkerAsync();
            }
            if (txtSerial.Text == "")
            {
                lb_Status.Invoke(new Action(() => lb_Status.BackColor = Color.Yellow));
                lb_Status.Invoke(new Action(() => lb_Status.Text = "WAIT"));
            }
            else if (txtSerial.Text.Contains("ERROR"))
            {
                lb_Status.Invoke(new Action(() => lb_Status.BackColor = Color.Red));
                lb_Status.Invoke(new Action(() => lb_Status.Text = "ERROR"));
            }
            else if (txtSerial.Text != "" && !txtSerial.Text.Contains("ERROR"))
            {
                lb_Status.Invoke(new Action(() => lb_Status.BackColor = Color.Lime));
                lb_Status.Invoke(new Action(() => lb_Status.Text = "OK"));
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            lbtime.Invoke(new Action(() => lbtime.Text = "" + DateTime.Now.ToString("dd-MM-yyyy \nHH:mm:ss") + ""));
            if (DateTime.Now.Hour == 08 && DateTime.Now.Minute == 00)
            {
                GeTDatatogridview();
                ChangeColorGrid();

                txtBZ.SelectAll();
                txtBZ.Focus();
            }

        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            lb_SR1000.Invoke(new Action(() => lb_SR1000.Text = "OFF"));
            lb_SR1000.Invoke(new Action(() => lb_SR1000.BackColor = Color.Red));
            StartConnection(Properties.Settings.Default.IP, Properties.Settings.Default.Port);
        }

     

        private void timer4_Tick(object sender, EventArgs e)
        {
            GeTDatatogridview();
            ChangeColorGrid();

            txtBZ.SelectAll();
            txtBZ.Focus();
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            GetCountTopButtomWelding();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker6.IsBusy)
            {
                backgroundWorker6.RunWorkerAsync();
            }
        }






    }
}
