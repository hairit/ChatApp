using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private Client client;

        public LoginForm()
        {
            InitializeComponent();
            TcpClient tcpClient = new TcpClient(tbServer.Text, 2008);
            this.client = new Client(tcpClient, tcpClient.GetStream());
            this.client.Start();
            client.Send("");
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
            this.client.Send(request.ParseToJson());
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this.client,this);
            registerForm.Show();
            registerForm.StartPosition = FormStartPosition.CenterScreen;
            this.hideForm();
        }

        private void showForm()
        {
            this.Show();
        }

        private void hideForm()
        {
            this.Hide();
        }
    }
}
