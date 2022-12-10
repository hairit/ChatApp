namespace ChapAppClient
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.btSendMessage = new System.Windows.Forms.Button();
            this.btApprove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearchFriend = new System.Windows.Forms.RichTextBox();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.dgvFriend = new System.Windows.Forms.DataGridView();
            this.pickColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(240, 10);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(689, 429);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(240, 443);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(2);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(628, 38);
            this.tbMessage.TabIndex = 2;
            this.tbMessage.Text = "";
            // 
            // btSendMessage
            // 
            this.btSendMessage.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSendMessage.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btSendMessage.Location = new System.Drawing.Point(872, 443);
            this.btSendMessage.Margin = new System.Windows.Forms.Padding(2);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(56, 37);
            this.btSendMessage.TabIndex = 3;
            this.btSendMessage.Text = "Send";
            this.btSendMessage.UseVisualStyleBackColor = false;
            // 
            // btApprove
            // 
            this.btApprove.Location = new System.Drawing.Point(9, 443);
            this.btApprove.Margin = new System.Windows.Forms.Padding(2);
            this.btApprove.Name = "btApprove";
            this.btApprove.Size = new System.Drawing.Size(110, 37);
            this.btApprove.TabIndex = 4;
            this.btApprove.Text = "Làm mới";
            this.btApprove.UseVisualStyleBackColor = true;
            this.btApprove.Click += new System.EventHandler(this.btApprove_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 443);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "Từ chối";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(184, 218);
            this.btSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(52, 26);
            this.btSearch.TabIndex = 7;
            this.btSearch.Text = "Tìm";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSearchFriend
            // 
            this.tbSearchFriend.Location = new System.Drawing.Point(9, 218);
            this.tbSearchFriend.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchFriend.Name = "tbSearchFriend";
            this.tbSearchFriend.Size = new System.Drawing.Size(171, 27);
            this.tbSearchFriend.TabIndex = 8;
            this.tbSearchFriend.Text = "";
            // 
            // lvGroup
            // 
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(9, 249);
            this.lvGroup.Margin = new System.Windows.Forms.Padding(2);
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(228, 190);
            this.lvGroup.TabIndex = 9;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            // 
            // dgvFriend
            // 
            this.dgvFriend.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvFriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pickColumn,
            this.colUsers});
            this.dgvFriend.Location = new System.Drawing.Point(9, 10);
            this.dgvFriend.Name = "dgvFriend";
            this.dgvFriend.RowHeadersVisible = false;
            this.dgvFriend.Size = new System.Drawing.Size(227, 203);
            this.dgvFriend.TabIndex = 10;
            // 
            // pickColumn
            // 
            this.pickColumn.HeaderText = "";
            this.pickColumn.Name = "pickColumn";
            this.pickColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colUsers
            // 
            this.colUsers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUsers.HeaderText = "Users";
            this.colUsers.Name = "colUsers";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 488);
            this.Controls.Add(this.lvGroup);
            this.Controls.Add(this.tbSearchFriend);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btApprove);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.RichTextBox tbMessage;
        public System.Windows.Forms.Button btSendMessage;
        public System.Windows.Forms.Button btApprove;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btSearch;
        public System.Windows.Forms.RichTextBox tbSearchFriend;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.DataGridView dgvFriend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pickColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsers;
    }
}