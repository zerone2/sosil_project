namespace assignment2
{
    partial class server_form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ip_label = new System.Windows.Forms.Label();
            this.ip_textbox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.port_textbox = new System.Windows.Forms.TextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.mp3Path_label = new System.Windows.Forms.Label();
            this.mp3Path_textbox = new System.Windows.Forms.TextBox();
            this.findPath_btn = new System.Windows.Forms.Button();
            this.serverStat_label = new System.Windows.Forms.Label();
            this.serverStat_textBox = new System.Windows.Forms.TextBox();
            this.musicList_listView = new System.Windows.Forms.ListView();
            this.musicList_label = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.ip_label.ForeColor = System.Drawing.Color.White;
            this.ip_label.Location = new System.Drawing.Point(12, 29);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(53, 24);
            this.ip_label.TabIndex = 0;
            this.ip_label.Text = "IP :";
            // 
            // ip_textbox
            // 
            this.ip_textbox.BackColor = System.Drawing.Color.RoyalBlue;
            this.ip_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ip_textbox.Enabled = false;
            this.ip_textbox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold);
            this.ip_textbox.Location = new System.Drawing.Point(71, 28);
            this.ip_textbox.Name = "ip_textbox";
            this.ip_textbox.Size = new System.Drawing.Size(391, 18);
            this.ip_textbox.TabIndex = 1;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.port_label.ForeColor = System.Drawing.Color.White;
            this.port_label.Location = new System.Drawing.Point(485, 29);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(89, 24);
            this.port_label.TabIndex = 2;
            this.port_label.Text = "Port : ";
            // 
            // port_textbox
            // 
            this.port_textbox.BackColor = System.Drawing.Color.RoyalBlue;
            this.port_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.port_textbox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold);
            this.port_textbox.Location = new System.Drawing.Point(566, 28);
            this.port_textbox.Name = "port_textbox";
            this.port_textbox.Size = new System.Drawing.Size(97, 18);
            this.port_textbox.TabIndex = 3;
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.MidnightBlue;
            this.start_btn.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.start_btn.ForeColor = System.Drawing.Color.White;
            this.start_btn.Location = new System.Drawing.Point(682, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(199, 51);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // mp3Path_label
            // 
            this.mp3Path_label.AutoSize = true;
            this.mp3Path_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.mp3Path_label.ForeColor = System.Drawing.Color.White;
            this.mp3Path_label.Location = new System.Drawing.Point(12, 92);
            this.mp3Path_label.Name = "mp3Path_label";
            this.mp3Path_label.Size = new System.Drawing.Size(93, 24);
            this.mp3Path_label.TabIndex = 5;
            this.mp3Path_label.Text = "Path : ";
            // 
            // mp3Path_textbox
            // 
            this.mp3Path_textbox.BackColor = System.Drawing.Color.RoyalBlue;
            this.mp3Path_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mp3Path_textbox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold);
            this.mp3Path_textbox.Location = new System.Drawing.Point(111, 92);
            this.mp3Path_textbox.Name = "mp3Path_textbox";
            this.mp3Path_textbox.Size = new System.Drawing.Size(552, 18);
            this.mp3Path_textbox.TabIndex = 6;
            // 
            // findPath_btn
            // 
            this.findPath_btn.BackColor = System.Drawing.Color.MidnightBlue;
            this.findPath_btn.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.findPath_btn.ForeColor = System.Drawing.Color.White;
            this.findPath_btn.Location = new System.Drawing.Point(682, 77);
            this.findPath_btn.Name = "findPath_btn";
            this.findPath_btn.Size = new System.Drawing.Size(199, 53);
            this.findPath_btn.TabIndex = 7;
            this.findPath_btn.Text = "Find Path";
            this.findPath_btn.UseVisualStyleBackColor = false;
            this.findPath_btn.Click += new System.EventHandler(this.findPath_btn_Click);
            // 
            // serverStat_label
            // 
            this.serverStat_label.AutoSize = true;
            this.serverStat_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.serverStat_label.ForeColor = System.Drawing.Color.White;
            this.serverStat_label.Location = new System.Drawing.Point(12, 147);
            this.serverStat_label.Name = "serverStat_label";
            this.serverStat_label.Size = new System.Drawing.Size(168, 24);
            this.serverStat_label.TabIndex = 8;
            this.serverStat_label.Text = "Server state";
            this.serverStat_label.Click += new System.EventHandler(this.serverStat_label_Click);
            // 
            // serverStat_textBox
            // 
            this.serverStat_textBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.serverStat_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverStat_textBox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold);
            this.serverStat_textBox.Location = new System.Drawing.Point(13, 182);
            this.serverStat_textBox.Multiline = true;
            this.serverStat_textBox.Name = "serverStat_textBox";
            this.serverStat_textBox.Size = new System.Drawing.Size(359, 268);
            this.serverStat_textBox.TabIndex = 9;
            // 
            // musicList_listView
            // 
            this.musicList_listView.BackColor = System.Drawing.Color.RoyalBlue;
            this.musicList_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.musicList_listView.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold);
            this.musicList_listView.FullRowSelect = true;
            this.musicList_listView.Location = new System.Drawing.Point(385, 182);
            this.musicList_listView.Name = "musicList_listView";
            this.musicList_listView.Size = new System.Drawing.Size(497, 268);
            this.musicList_listView.TabIndex = 10;
            this.musicList_listView.UseCompatibleStateImageBehavior = false;
            // 
            // musicList_label
            // 
            this.musicList_label.AutoSize = true;
            this.musicList_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.musicList_label.ForeColor = System.Drawing.Color.White;
            this.musicList_label.Location = new System.Drawing.Point(387, 147);
            this.musicList_label.Name = "musicList_label";
            this.musicList_label.Size = new System.Drawing.Size(60, 24);
            this.musicList_label.TabIndex = 11;
            this.musicList_label.Text = "List";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // server_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(896, 466);
            this.Controls.Add(this.musicList_label);
            this.Controls.Add(this.musicList_listView);
            this.Controls.Add(this.serverStat_textBox);
            this.Controls.Add(this.serverStat_label);
            this.Controls.Add(this.findPath_btn);
            this.Controls.Add(this.mp3Path_textbox);
            this.Controls.Add(this.mp3Path_label);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.port_textbox);
            this.Controls.Add(this.port_label);
            this.Controls.Add(this.ip_textbox);
            this.Controls.Add(this.ip_label);
            this.Name = "server_form";
            this.Text = "Music Player - Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.server_form_FormClosed);
            this.Load += new System.EventHandler(this.server_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.TextBox ip_textbox;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.TextBox port_textbox;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label mp3Path_label;
        private System.Windows.Forms.TextBox mp3Path_textbox;
        private System.Windows.Forms.Button findPath_btn;
        private System.Windows.Forms.Label serverStat_label;
        private System.Windows.Forms.TextBox serverStat_textBox;
        private System.Windows.Forms.ListView musicList_listView;
        private System.Windows.Forms.Label musicList_label;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

