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
            this.lvFriend = new System.Windows.Forms.ListView();
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.btSendMessage = new System.Windows.Forms.Button();
            this.btApprove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearchFriend = new System.Windows.Forms.RichTextBox();
            this.lvGroup = new System.Windows.Forms.ListView();
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
            // lvFriend
            // 
            this.lvFriend.HideSelection = false;
            this.lvFriend.Location = new System.Drawing.Point(9, 10);
            this.lvFriend.Margin = new System.Windows.Forms.Padding(2);
            this.lvFriend.Name = "lvFriend";
            this.lvFriend.Size = new System.Drawing.Size(228, 204);
            this.lvFriend.TabIndex = 1;
            this.lvFriend.UseCompatibleStateImageBehavior = false;
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
            this.lvGroup.BackColor = System.Drawing.SystemColors.Menu;
            this.lvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.GridLines = true;
            this.lvGroup.HideSelection = false;
            this.lvGroup.HoverSelection = true;
            this.lvGroup.LabelWrap = false;
            this.lvGroup.Location = new System.Drawing.Point(9, 249);
            this.lvGroup.Margin = new System.Windows.Forms.Padding(2);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(228, 190);
            this.lvGroup.TabIndex = 0;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.SelectedIndexChanged += new System.EventHandler(this.lvGroup_SelectedIndexChanged);
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
            this.Controls.Add(this.lvFriend);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ListView lvFriend;
        public System.Windows.Forms.RichTextBox tbMessage;
        public System.Windows.Forms.Button btSendMessage;
        public System.Windows.Forms.Button btApprove;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btSearch;
        public System.Windows.Forms.RichTextBox tbSearchFriend;
        public System.Windows.Forms.ListView lvGroup;
    }
}