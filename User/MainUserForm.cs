using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MainUserForm : Form
    {
        private Socket sender;
        private Thread listener;
        public string inp = "";
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        public MainUserForm()
        {
            this.InitializeComponent();
        }

        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        private void ListenServerThread(object arg)
        {
            MainUserForm myForm = (MainUserForm)arg;
            byte[] bytes = new byte[131072];

            while (SocketConnected(sender))
            {

                int bytesRec = sender.Receive(bytes);

                myForm.Invoke((MethodInvoker)delegate ()
                {
                    OutputText.Text = "";
                    List<List<object>> myText;
                    using (var memStream = new MemoryStream())
                    {
                        var binForm = new BinaryFormatter();
                        memStream.Write(bytes, 0, bytes.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                        var obj = binForm.Deserialize(memStream);
                        myText = (List<List<object>>)obj;
                    }

                    foreach (List<object> l in myText)
                    {
                        OutputText.SelectionStart = OutputText.Text.Length;
                        OutputText.SelectionColor = (Color)l[1];
                        OutputText.AppendText((String)l[0]);
                        OutputText.SelectionColor = Color.Green;
                        OutputText.AppendText(" : ");
                        OutputText.SelectionColor = Color.Black;
                        OutputText.AppendText((String)l[2]);
                        OutputText.SelectionColor = Color.Black;
                    }


                });

            }

        }



        public void StartClient()
        {
            byte[] bytes = new byte[131072];

            try
            {
                IPHostEntry host = Dns.GetHostEntry(IpInputTB.Text);
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, int.Parse(textBox1.Text));

                // Create a TCP/IP  socket.    
                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);

                Debug.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());



                listener = new Thread(ListenServerThread);
                listener.Start(this);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                StatusLabel.Text = "Status : Unable to connect";
                return;
            }

            NameTB.Enabled = true;
            SetNameBtn.Enabled = true;
            ConnectBtn.Enabled = false;
            IpInputTB.Enabled = false;
            textBox1.Enabled = false;
            StatusLabel.Text = "Status : Connected, \n  enter username to start chat";





        }

        private void sendFunc()
        {
            if (InputText.Text != "")
            {
                int bytesSent = sender.Send(Encoding.UTF8.GetBytes(InputText.Text));
            }
            InputText.Text = "";
        }

        private void SendBtn_Click(object senderz, EventArgs e)
        {

            sendFunc();


        }

        private void SetNameBtn_Click(object senderz, EventArgs e)
        {
            if (NameTB.Text != "")
            {
                sender.Send(Encoding.UTF8.GetBytes(NameTB.Text + "<NAME>"));
                OutputText.Enabled = true;
                InputText.Enabled = true;
                SendBtn.Enabled = true;
                NameTB.Enabled = false;
                SetNameBtn.Enabled = false;
                StatusLabel.Text = "Status : Connected";
            }
        }

        private void InputText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (InputText.Text.Substring(InputText.Text.Length - 2) == "\r\n")
                {
                    InputText.Text = InputText.Text.Remove(InputText.Text.Length - 2, 2);
                }

                sendFunc();
                InputText.Text = "";
            }

        }
    }

}
