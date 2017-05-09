using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ping_tray
{
    public partial class Form1 : Form
    {
        String IpAddr = "127.0.0.1";
        System.Drawing.Icon iconGreen, iconRed;
        public Form1()
        {
            InitializeComponent();
            iconGreen = new Icon("policegreen.ico");
            iconRed = new Icon("policereed.ico");
            notifyIcon1.Icon = iconGreen;
            IpAddr = textBox1.Text;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply;
            try
            {
                reply = pingSender.Send(IpAddr, timeout, buffer, options);
            }
             catch (System.Net.NetworkInformation.PingException)
            {
                notifyIcon1.Icon = iconRed;
                return;
            }
            catch (System.ArgumentNullException)
            {
                notifyIcon1.Icon = iconRed;
                return;
            }

            notifyIcon1.Text = "Ping: "+ textBox1.Text;
            if (reply.Status == IPStatus.Success)
            {
                notifyIcon1.Icon = iconGreen;
            }
            if(reply.Status == IPStatus.TimedOut || reply.Status == IPStatus.BadDestination
                || reply.Status == IPStatus.BadHeader
                || reply.Status == IPStatus.BadOption
                || reply.Status == IPStatus.BadRoute
                || reply.Status == IPStatus.DestinationHostUnreachable
                || reply.Status == IPStatus.DestinationNetworkUnreachable
                || reply.Status == IPStatus.DestinationPortUnreachable
                || reply.Status == IPStatus.DestinationProhibited
                || reply.Status == IPStatus.DestinationProtocolUnreachable
                || reply.Status == IPStatus.DestinationScopeMismatch
                || reply.Status == IPStatus.DestinationUnreachable
                || reply.Status == IPStatus.HardwareError
                || reply.Status == IPStatus.IcmpError
                || reply.Status == IPStatus.NoResources
                || reply.Status == IPStatus.PacketTooBig
                || reply.Status == IPStatus.ParameterProblem
                || reply.Status == IPStatus.SourceQuench
                || reply.Status == IPStatus.TimeExceeded
                || reply.Status == IPStatus.TtlExpired
                || reply.Status == IPStatus.TtlReassemblyTimeExceeded
                || reply.Status == IPStatus.Unknown
                || reply.Status == IPStatus.UnrecognizedNextHeader)
            {
                notifyIcon1.Icon = iconRed;       
            }

        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IpAddr = textBox1.Text;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
            Hide();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Normal;
            Show();
        }
    }
}
