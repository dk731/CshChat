using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;

namespace ChatServer
{
    public partial class MainServerForm : Form
    {

        public List<List<object>> textToOutput;
        public SynchronizedCollection<Socket> clients;
        static EventWaitHandle sendToClient;
        private int maxOutPutSize = 50;
        public Socket listener;


        public MainServerForm()
        {
            InitializeComponent();
            clients = new SynchronizedCollection<Socket>();
            textToOutput = new List<List<object>>();
            sendToClient = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        private void StartServerBtn_Click(object sender, EventArgs e)
        {
            StartServer();
        }


        private void SendToUserThread(object arg)
        {
            Array argArray = new object[2];
            argArray = (Array)arg;

            Socket myClient = (Socket)argArray.GetValue(0);
            MainServerForm myServer = (MainServerForm)argArray.GetValue(1);

            BinaryFormatter bf = new BinaryFormatter();

            while (true)
            {
                
                
                myServer.Invoke((MethodInvoker)delegate ()
                {

                    using (var ms = new MemoryStream())
                    {
                        bf.Serialize(ms, textToOutput);
                        myClient.Send(ms.ToArray());
                    }

                });
                sendToClient.WaitOne();
            }
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

        private void IsClientActive(object arg)
        {
            var rand = new Random();
            byte[] bytes = new byte[131072];
            Array argArray = new object[2];
            argArray = (Array)arg;
            String myName = "";

            Socket myClient = (Socket)argArray.GetValue(0);
            MainServerForm myServer = (MainServerForm)argArray.GetValue(1);

            Thread myListener = new Thread(ListenToClientThread);
            Thread myWriter = new Thread(SendToUserThread);

            while(true)
            {
                try
                {
                    int bytesRec = myClient.Receive(bytes);
                    String tmp = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    if (tmp.Contains("<NAME>"))
                    {
                        myName = tmp.Remove(tmp.Length-6, 6);
                        break;
                    }
                }
                catch (Exception e)
                {
                    return;
                }

            }
            Color myColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            Array listenerArgArray = new object[4] {myClient, myServer, myName, myColor};
            Array writerArgArray = new object[2] { myClient, myServer };
            myListener.Start(listenerArgArray);
            myWriter.Start(writerArgArray);

            while(SocketConnected(myClient))
            {
                continue;
            }
            myWriter.Abort();
            myListener.Abort();

           

            myClient.Close();

        }

        private void ListenForConnections(object arg)
        {
            MainServerForm myServer = (MainServerForm)arg;



            while (true)
            {
                Socket tmpHandler = listener.Accept();

                Debug.WriteLine("New user connect");

                Thread tmpThread = new Thread(IsClientActive);

                Array tmpArray = new object[2] { tmpHandler, myServer}; 

                tmpThread.Start(tmpArray);

                clients.Add(tmpHandler);
            }
            
        }



        private void ListenToClientThread(object arg)
        {
            Array argArray = new object[4];
            argArray = (Array)arg;

            Socket myClient = (Socket)argArray.GetValue(0);
            MainServerForm myServer = (MainServerForm)argArray.GetValue(1);
            String myName = (String)argArray.GetValue(2);
            Color myColor = (Color)argArray.GetValue(3);

            byte[] bytes = new byte[131072];


            while (true)
            {
                try
                {

                    int bytesRec = myClient.Receive(bytes);
                    myServer.Invoke((MethodInvoker)delegate ()
                    {
                        List<object> tmp = new List<object>();

                        tmp.Add(myName);
                        tmp.Add(myColor);
                        tmp.Add(Encoding.UTF8.GetString(bytes, 0, bytesRec) + "\r\n");

                        textToOutput.Add(tmp);

                        if (textToOutput.Count > maxOutPutSize)
                        {
                            textToOutput.RemoveAt(0);
                        }
                        
                    });
                    sendToClient.Set();
                    sendToClient.Reset();

                }
                catch (Exception e)
                {
                    return;

                }

                

            }
        }


        public void StartServer()
        {
            
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);


            try
            {

                // Create a Socket that will use Tcp protocol      
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                listener.Listen(20);

                Thread tmpThread = new Thread(ListenForConnections);
                tmpThread.Start(this);



            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            Debug.WriteLine("\n Press any key to continue...");
            
        }
    }
}
