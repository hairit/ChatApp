using ChatAppServer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

        private delegate void SetTextDelegate(List<string> text);
        private LoginForm loginFrom;

        public HomeForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginFrom = loginForm;
        }

        public void addItemForFriendListView(string name)
        {
            if (dgvFriend.InvokeRequired)
            {
                var dlg = new AddItemForListView(addItemForFriendListView);
                this.Invoke(dlg, new object[] { name });
            }
            else
            {
                dgvFriend.Rows.Add(false,name);
            }
        }

        public void clearItems()
        {
            if (dgvFriend.InvokeRequired)
            {
                var dlg = new ClearListViewItems(clearItems);
                this.Invoke(dlg, new object[] { });
            }
            else
            {
                dgvFriend.Rows.Clear();
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

        public void SetTextToLvGroup(List<string> text)
        {
            if (lvGroup.InvokeRequired)
            {
                var dlg = new SetTextDelegate(SetTextToLvGroup);
                lvGroup.Invoke(dlg, new object[] { text });
            }
            else
            {
                lvGroup.Items.Clear();
                lvGroup.Columns.Add("Group", -2, HorizontalAlignment.Center);
                lvGroup.FullRowSelect = true;
                lvGroup.GridLines = true;
                lvGroup.View = System.Windows.Forms.View.List;
                foreach(var item in text)
                {
                    var lvi = new ListViewItem(item);
                    lvGroup.Items.Add(lvi);
                }
                lvGroup.Focus();
                lvGroup.Items[0].Selected = true;

            }
        }


        private void btApprove_Click(object sender, EventArgs e)
        {
            var user = this.loginFrom.user;
            var request = new Base { action = "getall", model = "group", content = new GetGroupByUser { userID = user.UserId }.ParseToJson() };
            this.loginFrom.Send(request.ParseToJson());
        }

        private void lvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lvGroup.SelectedItems[0];
            var group = this.loginFrom.listGr.Find(x => x.GroupName == item.Text);

        }
    }
}