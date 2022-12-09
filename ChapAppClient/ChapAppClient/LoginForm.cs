using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatAppServer.Model;

namespace ChapAppClient
{
    public partial class LoginForm : Form
    {
        private TcpClient socket;
        private Stream stream;
        private HomeForm homeForm;
        private RegisterForm registerForm;
        public LoginForm()
        {
            InitializeComponent();
            this.socket = new TcpClient(tbServer.Text, 2008);
            this.stream = socket.GetStream();
            Start();
            Send("");
            this.homeForm = new HomeForm(this);
            this.registerForm = new RegisterForm(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                lbWarning.Text = "Vui lòng nhập tên đăng nhập và mật khẩu";
                return;
            }

            if (tbServer.Text == "")
            {
                lbWarning.Text = "Vui lòng nhập IP server";
                return;
            }

            Login account = new Login()
            {
                UserName = tbUsername.Text,
                Password = tbPassword.Text
            };

            Base request = new Base()
            {
                action = "login",
                model = "user",
                content = account.ParseToJson()

            };
            Send(request.ParseToJson());
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.Show();
            registerForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }

        public void Start()
        {
            new Thread(Run).Start();
        }

        public void Send(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            this.stream.Write(buffer, 0, buffer.Length);
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
            Environment.Exit(0);
        }
    }
}
