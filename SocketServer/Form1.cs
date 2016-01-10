using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        private int port;   //监听端口
        private int len=2;    //监听线程数量
        private Socket sock;
        public bool isrun = true;
        Socket socket;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int kc = (int)e.KeyChar;
                if ((kc < 48 || kc > 57) && kc != 8)
                    e.Handled = true;
            }
            catch (Exception )
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string portText = this.textBox1.Text.Trim().Length < 1 ? "8000" : this.textBox1.Text;
            port = Int32.Parse(portText);
            Thread th = new Thread(new ThreadStart(start));
            th.Start();

        }
        #region
        delegate void SetTextCallback(string str);
        public void SetText(string msg)
        {
            this.richTextBox1.Text = msg;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            isrun = false;
            if (sock!=null&&sock.Connected)
                sock.Close();
            this.richTextBox1.Text = "服务器停止监听";
                    
        }       
        private void start()
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr =IPAddress.Parse("127.0.0.1");
            EndPoint en = new IPEndPoint(ipaddr, port);
            socket.Bind(en);
            socket.Listen(len);
            string text =  "开始监听端口"+port;
            this.Invoke(new SetTextCallback(SetText),new object[] { text});
            while (isrun)
            {
                sock = socket.Accept();
                string res = "收到连接请求：" + sock.AddressFamily;
                this.Invoke(new SetTextCallback(SetText), new object[] { res });

                Thread th = new Thread(new ThreadStart(Process));
                th.Start();
            }
           

        }
        private void Process()
        {
            Byte[] rece = new Byte[256];

            if (sock.Connected)
            {
                while (isrun)
                {
                    int len = sock.Receive(rece, rece.Length, 0);
                    string msg = Encoding.Default.GetString(rece);
                    string res = "收到：" + msg;
                    sock.Send(Encoding.Default.GetBytes(res.ToCharArray()));
                    this.Invoke(new SetTextCallback(SetText),new object[] { res});
                }
            }
        }
    }
}
