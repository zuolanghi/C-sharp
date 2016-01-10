using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        private Socket sock;
        private int port;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = this.textBox1.Text;
            if (sock != null && sock.Connected)
            {
                sock.Send(Encoding.Default.GetBytes(msg.ToCharArray()));
            }
            else
            {
                this.richTextBox1.Text = "服务未启动,连接失败！";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sock == null)
                {
                    string portText = this.textBox1.Text.Trim().Length < 1 ? "8000" : this.textBox1.Text;
                    port = Int32.Parse(portText);
                    EndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                    sock = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    sock.Connect(ep);
                }
               
            }
            catch (Exception)
            {
                this.richTextBox1.Text = "服务未启动";
            }
           
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sock != null && sock.Connected)
            {
                sock.Disconnect(true);
                sock = null;
            }
        }
    }
}
