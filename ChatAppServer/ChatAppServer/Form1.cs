using ChatAppServer.ServerSocket;
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
using System.Text;
using System.Text.Json;
using ChatAppServer.Model;
using ChatAppServer.Controller;

namespace ChatAppServer
{
    public partial class Form1 : Form
    {
        private delegate void CallDelegate(string text);
        private TcpListener serverSocket;
        private List<Worker> workers = new List<Worker>();
        private readonly UserController userController = new UserController();
        private readonly ChatController chatController = new ChatController();
        private readonly GroupController groupController = new GroupController();
        public Form1()
        {
            InitializeComponent();
            serverSocket = new TcpListener(IPAddress.Parse("192.168.31.163"), 2008);
            serverSocket.Start();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            new Thread(WaitForConnection) { IsBackground = true }.Start();
            listBox.Items.Add("Server is running!");
            var x = new Base { action = "get", model = "user", content = new Login { UserName = "abc@gmail.com", Password = "abc123@" }.ParseToJson() };
            var y = ParseToJson(x);
            Console.WriteLine(y);
            listBox.Items.Add(y);
        }

        public void WaitForConnection()
        {
            while (true)
            {
                TcpClient socket = serverSocket.AcceptTcpClient();
                Worker worker = new Worker(socket);
                AddWorker(worker);
                SetText(socket.Client.AddressFamily.ToString() + "is connected!");
                worker.Start();
            }
        }

        private void Worker_MessageReceived(object sender, MessageEventArgs e)
        {
            HandleMessage(sender as Worker, e.Message);
        }

        private void Worker_Disconnected(object sender, EventArgs e)
        {
            RemoveWorker(sender as Worker);
        }

        private void AddWorker(Worker worker)
        {
            SetText(worker.Username + "connected!");
            lock (this)
            {
                workers.Add(worker);
                worker.Disconnected += Worker_Disconnected;
                worker.MessageReceived += Worker_MessageReceived;
            }
        }

        private void RemoveWorker(Worker worker)
        {
            SetText(worker.Username + "disconnected!");
            lock (this)
            {
                worker.Disconnected -= Worker_Disconnected;
                worker.MessageReceived -= Worker_MessageReceived;
                workers.Remove(worker);
                worker.Close();
            }
        }

        private void SetText(string text)
        {
            if (listBox.InvokeRequired)
            {
                var dlg = new CallDelegate(SetText);
                listBox.Invoke(dlg, new object[] { text });
            }
            else
            {
                listBox.Items.Add(text + Environment.NewLine);
            }
        }
        private string ParseToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        private void HandleMessage(Worker from, String message)
        {
            SetText(from.Username + " : " + message);
            lock (this)
            {
                var request = JsonSerializer.Deserialize<Base>(message);
                if (request.model!=null && request.action!=null)
                {
                    switch (request.model.ToLower())
                    {
                        case "user":
                        {
                            userController.UserHandler(request, workers, from);
                        }
                            break;
                        case "group":
                            {
                                if (!groupController.GroupHandler(request, workers, from).Result)
                                {
                                    from.Send(new response { action = "Error", content = "Some thing went wrong, please try again later!" }.ParseToJson());
                                }
                            }
                            break;
                    default:
                            break;
                    }
                }
                
            }
        }
    }
}
