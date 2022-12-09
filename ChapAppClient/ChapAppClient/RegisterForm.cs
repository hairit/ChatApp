using System;
using System.Windows.Forms;
using ChatAppServer.Model;

namespace ChapAppClient
{
    public partial class RegisterForm : Form
    {
        private readonly Client _client;
        private readonly LoginForm _loginForm;

        public RegisterForm(Client client, LoginForm loginForm)
        {
            InitializeComponent();
            this._client = client;
            this._loginForm = loginForm;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "" || tbRePassword.Text == "" || tbName.Text == "")
            {
                lbWarning.Text = "Vui lòng nhập đầy đủ thông tin.";
                return;
            }

            if (tbPassword.Text != tbRePassword.Text)
            {
                lbWarning.Text = "Nhập lại password không giống.";
                return;
            }

            ChatUser user = new ChatUser()
            {
                UserId = new Guid(),
                Name = tbName.Text,
                UserName = tbUsername.Text,
                Password = tbPassword.Text
            };

            Base request = new Base()
            {
                action = "register",
                model = "user",
                content = user.ParseToJson()
            };

            _client.Send(request.ParseToJson());
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Show();
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
