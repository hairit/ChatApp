﻿using System;
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
        private delegate void SetTextDelegate(string text);

        private delegate void HideFormDelegate();

        private delegate void ShowFormDelegate();

        private TcpClient socket;
        private Stream stream;
        private HomeForm homeForm;
        private RegisterForm registerForm;

        public LoginForm()
        {
            InitializeComponent();
            this.socket = new TcpClient("192.168.1.106", 2008);
            this.stream = socket.GetStream();
            this.homeForm = new HomeForm(this);
            this.registerForm = new RegisterForm(this);
            Start();
            Send("");
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

            Login account = new Login() { UserName = tbUsername.Text, Password = tbPassword.Text };

            Base request = new Base() { action = "login", model = "user", content = account.ParseToJson() };
            Send(request.ParseToJson());
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            this.registerForm.Show();
            this.registerForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }

        private void setTextForTbUserName(string text)
        {
            if (tbUsername.InvokeRequired)
            {
                var dlg = new SetTextDelegate(setTextForTbUserName);
                tbUsername.Invoke(dlg, new object[] { text });
            }
            else
            {
                tbUsername.Text = text;
            }
        }

        private void setTextForTbPassword(string text)
        {
            if (tbPassword.InvokeRequired)
            {
                var dlg = new SetTextDelegate(setTextForTbPassword);
                tbPassword.Invoke(dlg, new object[] { text });
            }
            else
            {
                tbPassword.Text = text;
            }
        }

        private void hideLoginForm()
        {
            if (this.InvokeRequired)
            {
                var dlg = new HideFormDelegate(hideLoginForm);
                this.Invoke(dlg, new object[] { });
            }
            else
            {
                this.Hide();
            }
        }

        private void showLoginForm()
        {
            if (this.InvokeRequired)
            {
                var dlg = new ShowFormDelegate(showLoginForm);
                this.Invoke(dlg, new object[] { });
            }
            else
            {
                this.Show();
            }
        }

        private void hideRegisterForm()
        {
            if (this.InvokeRequired)
            {
                var dlg = new HideFormDelegate(hideRegisterForm);
                this.Invoke(dlg, new object[] { });
            }
            else
            {
                this.registerForm.Hide();
            }
        }

        private void setRegisterWarning(string text)
        {
            if (this.InvokeRequired)
            {
                var dlg = new SetTextDelegate(setRegisterWarning);
                this.Invoke(dlg, new object[] { text });
            }
            else
            {
                this.registerForm.lbWarning.Text = text;
            }
        }

        private void setLoginWarning(string text)
        {
            if (this.InvokeRequired)
            {
                var dlg = new SetTextDelegate(setLoginWarning);
                this.Invoke(dlg, new object[] { text });
            }
            else
            {
                lbWarning.Text = text;
            }
        }

        public void Start()
        {
            new Thread(Run).Start();
        }

        public void Send(string message)
        {
            var a = 1;
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
                    if (receivedBytes < 1) break;
                    string response = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    handleResponse(response);
                }
            }
            catch (IOException)
            {
            }
            catch (ObjectDisposedException)
            {
            }

            Environment.Exit(0);
        }

        private void handleResponse(string responseJson)
        {
            Response response = new Response().GetFromJson(responseJson);
            switch (response.action)
            {
                case "login":
                    try
                    {
                        ChatUser user = new ChatUser().GetFromJson(response.content);
                        this.homeForm.Show();
                        hideLoginForm();
                        Application.Run();
                    }
                    catch (Exception e)
                    {
                        setLoginWarning("Sai tài khoản hoặc mật khẩu.");
                    }

                    break;
                case "register":
                    if (response.content == "successfully created")
                    {
                        setTextForTbUserName(this.registerForm.tbUsername.Text);
                        setTextForTbPassword(this.registerForm.tbPassword.Text);
                        hideRegisterForm();
                        showLoginForm();
                        return;
                    }

                    if (response.content == "account conflict")
                    {
                        setRegisterWarning("Tên đăng nhập đã tồn tại.");
                        return;
                    }
                    else
                    {
                        setRegisterWarning("Tạo tài khoản thất bại.");
                        return;
                    }
                    break;
                case "user":
                    break;
                default:
                    break;
            }
        }
    }
}