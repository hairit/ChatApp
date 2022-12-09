using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Chatroom
{
    class Client
    {
        private TcpClient socket;
        private Stream stream;

        public Client(string serverAddress, int serverPort)
        {
            socket = new TcpClient(serverAddress, serverPort);
            stream = socket.GetStream();
        }

        private void Send(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }

        public void Start()
        {
            new Thread(Run).Start();
        }

        private void Run()
        {
            byte[] buffer = new byte[2048];
            try
            {
                while (true)
                {
                    int receivedBytes = stream.Read(buffer, 0, buffer.Length);
                    if (receivedBytes < 1)
                        break;
                    string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    Console.WriteLine(message);
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            Close();
            Environment.Exit(0);
        }

        private void Close()
        {
            socket.Close();
        }

        static void Main(string[] args)
        {
            Client client = null;
            string username = Console.ReadLine();
            try
            {
                client = new Client("192.168.3.65", 2008);
                client.Send(username);
                client.Start();
                while (true)
                {
                    string message = Console.ReadLine();
                    client.Send(message);
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            if (client != null)
                client.Close();
        }
    }
}