using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapAppClient
{
    public partial class HomeForm : Form
    {
        private delegate void AddItemForListView(string name);

        private delegate void ClearListViewItems();

        private LoginForm loginFrom;

        public HomeForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginFrom = loginForm;
        }

        public void addItemForFriendListView(string name)
        {
            if (lvFriend.InvokeRequired)
            {
                var dlg = new AddItemForListView(addItemForFriendListView);
                this.Invoke(dlg, new object[] { name });
            }
            else
            {
                lvFriend.Items.Add(new ListViewItem() { Checked = true, Text = name });
            }
        }

        public void clearItems()
        {
            if (lvFriend.InvokeRequired)
            {
                var dlg = new ClearListViewItems(clearItems);
                this.Invoke(dlg, new object[] { });
            }
            else
            {
                lvFriend.Items.Clear();
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearchFriend.Text == "")
            {
                return;
            }

            loginFrom.searchUserByName(tbSearchFriend.Text);
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            this.loginFrom.Start();
        }
    }
}