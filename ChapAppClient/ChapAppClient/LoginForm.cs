using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using ChatAppServer.DTO;
using ChatAppServer.Model;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace ChapAppClient
{
    public partial class LoginForm : Form
    {
        private delegate void SetTextDelegate(string text);

        private delegate void HideFormDelegate();

        private delegate void ShowFormDelegate();

        private delegate void AddItemForListView(string name);

        private TcpClient socket;
        private Stream stream;
        private HomeForm homeForm;
        private RegisterForm registerForm;
        public ChatUser user;
        public List<ChatGroup> listGr;
        public LoginForm()
        {
            InitializeComponent();
            this.socket = new TcpClient("192.168.31.163", 2008);
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
                        user = new ChatUser().GetFromJson(response.content);
                        hideLoginForm();
                        this.homeForm.Show();
                        Application.Run();
                        this.socket = new TcpClient("192.168.1.24", 2008);
                        this.stream = socket.GetStream();
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
                case "getbyname":
                    try
                    {
                        var users = JsonSerializer.Deserialize<List<ChatUser>>(response.content);
                        if (users.Count > 0)
                        {
                            for (int i = 0; i < users.Count; i++)
                            {
                                this.homeForm.addItemForFriendListView(users[i].Name);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return;
                    }

                    break;
                case "getall":
                    {
                        listGr = new AllGroup().GetFromJson(response.content).list;
                        if (listGr.Count!=0)
                        {
                            var listItem = listGr.Select(x => x.GroupName).ToList();
                            this.homeForm.SetTextToLvGroup(listItem);
                        }
                    }
                    break;
                default:
                    break;
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

        public void searchUserByName(string name)
        {
            GetUserByName userByName = new GetUserByName() { Name = name };
            Base request = new Base() { model = "user", action = "getbyname", content = userByName.ParseToJson() };
            Send(request.ParseToJson());
        }
    }
}