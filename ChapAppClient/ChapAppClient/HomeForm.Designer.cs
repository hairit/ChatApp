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
            this.lvNotification = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(320, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(917, 527);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lvFriend
            // 
            this.lvFriend.HideSelection = false;
            this.lvFriend.Location = new System.Drawing.Point(12, 12);
            this.lvFriend.Name = "lvFriend";
            this.lvFriend.Size = new System.Drawing.Size(302, 250);
            this.lvFriend.TabIndex = 1;
            this.lvFriend.UseCompatibleStateImageBehavior = false;
            this.lvFriend.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(320, 545);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(836, 46);
            this.tbMessage.TabIndex = 2;
            this.tbMessage.Text = "";
            // 
            // btSendMessage
            // 
            this.btSendMessage.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSendMessage.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btSendMessage.Location = new System.Drawing.Point(1162, 545);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(75, 46);
            this.btSendMessage.TabIndex = 3;
            this.btSendMessage.Text = "Send";
            this.btSendMessage.UseVisualStyleBackColor = false;
            // 
            // btApprove
            // 
            this.btApprove.Location = new System.Drawing.Point(12, 545);
            this.btApprove.Name = "btApprove";
            this.btApprove.Size = new System.Drawing.Size(147, 46);
            this.btApprove.TabIndex = 4;
            this.btApprove.Text = "Đồng ý";
            this.btApprove.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 545);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "Từ chối";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(245, 268);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(69, 32);
            this.btSearch.TabIndex = 7;
            this.btSearch.Text = "Tìm";
            this.btSearch.UseVisualStyleBackColor = true;
            // 
            // tbSearchFriend
            // 
            this.tbSearchFriend.Location = new System.Drawing.Point(12, 268);
            this.tbSearchFriend.Name = "tbSearchFriend";
            this.tbSearchFriend.Size = new System.Drawing.Size(227, 32);
            this.tbSearchFriend.TabIndex = 8;
            this.tbSearchFriend.Text = "";
            // 
            // lvNotification
            // 
            this.lvNotification.HideSelection = false;
            this.lvNotification.Location = new System.Drawing.Point(12, 306);
            this.lvNotification.Name = "lvNotification";
            this.lvNotification.Size = new System.Drawing.Size(302, 233);
            this.lvNotification.TabIndex = 9;
            this.lvNotification.UseCompatibleStateImageBehavior = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 601);
            this.Controls.Add(this.lvNotification);
            this.Controls.Add(this.tbSearchFriend);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btApprove);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lvFriend);
            this.Controls.Add(this.listView1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView lvFriend;
        private System.Windows.Forms.RichTextBox tbMessage;
        private System.Windows.Forms.Button btSendMessage;
        private System.Windows.Forms.Button btApprove;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.RichTextBox tbSearchFriend;
        private System.Windows.Forms.ListView lvNotification;
    }
}