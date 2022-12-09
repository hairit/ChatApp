using System;
using System.Windows.Forms;
using ChatAppServer.DTO;
using ChatAppServer.Model;

namespace ChapAppClient
{
    public partial class RegisterForm : Form
    {
        private readonly LoginForm _loginForm;
        private delegate void CallDelegate(string text);
        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
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
                UserId = Guid.NewGuid(),
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

            this._loginForm.Send(request.ParseToJson());
        }

        public void SetText(string text)
        {
            if (tbUsername.InvokeRequired)
            {
                var dlg = new CallDelegate(SetText);
                tbUsername.Invoke(dlg, new object[] { text });
            }
            else
            {
                tbUsername.Text = text + Environment.NewLine;
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Show();
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
