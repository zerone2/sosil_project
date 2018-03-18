namespace TP_Form
{
    partial class Conn
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
            this.serverMusic_listView = new System.Windows.Forms.ListView();
            this.musicList_label = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.path_textBox = new System.Windows.Forms.TextBox();
            this.downloadPath_label = new System.Windows.Forms.Label();
            this.findPath_button = new System.Windows.Forms.Button();
            this.connect_button = new System.Windows.Forms.Button();
            this.port_textBox = new System.Windows.Forms.TextBox();
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.ip_label = new System.Windows.Forms.Label();
            this.play_listView = new System.Windows.Forms.ListView();
            this.playList_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverMusic_listView
            // 
            this.serverMusic_listView.BackColor = System.Drawing.Color.MidnightBlue;
            this.serverMusic_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverMusic_listView.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serverMusic_listView.FullRowSelect = true;
            this.serverMusic_listView.Location = new System.Drawing.Point(28, 201);
            this.serverMusic_listView.Name = "serverMusic_listView";
            this.serverMusic_listView.Size = new System.Drawing.Size(414, 241);
            this.serverMusic_listView.TabIndex = 22;
            this.serverMusic_listView.UseCompatibleStateImageBehavior = false;
            this.serverMusic_listView.DoubleClick += new System.EventHandler(this.serverMusic_listView_DoubleClick);
            // 
            // musicList_label
            // 
            this.musicList_label.AutoSize = true;
            this.musicList_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.musicList_label.ForeColor = System.Drawing.Color.White;
            this.musicList_label.Location = new System.Drawing.Point(27, 174);
            this.musicList_label.Name = "musicList_label";
            this.musicList_label.Size = new System.Drawing.Size(153, 24);
            this.musicList_label.TabIndex = 21;
            this.musicList_label.Text = "Server List";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(30, 129);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(853, 30);
            this.progressBar1.TabIndex = 20;
            // 
            // path_textBox
            // 
            this.path_textBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.path_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.path_textBox.Enabled = false;
            this.path_textBox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.path_textBox.Location = new System.Drawing.Point(370, 86);
            this.path_textBox.Name = "path_textBox";
            this.path_textBox.Size = new System.Drawing.Size(513, 18);
            this.path_textBox.TabIndex = 19;
            // 
            // downloadPath_label
            // 
            this.downloadPath_label.AutoSize = true;
            this.downloadPath_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.downloadPath_label.ForeColor = System.Drawing.Color.White;
            this.downloadPath_label.Location = new System.Drawing.Point(26, 81);
            this.downloadPath_label.Name = "downloadPath_label";
            this.downloadPath_label.Size = new System.Drawing.Size(338, 24);
            this.downloadPath_label.TabIndex = 18;
            this.downloadPath_label.Text = "MP3 File Download Path :";
            // 
            // findPath_button
            // 
            this.findPath_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.findPath_button.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.findPath_button.ForeColor = System.Drawing.Color.White;
            this.findPath_button.Location = new System.Drawing.Point(742, 12);
            this.findPath_button.Name = "findPath_button";
            this.findPath_button.Size = new System.Drawing.Size(142, 56);
            this.findPath_button.TabIndex = 17;
            this.findPath_button.Text = "Find Path";
            this.findPath_button.UseVisualStyleBackColor = false;
            this.findPath_button.Click += new System.EventHandler(this.findPath_button_Click);
            // 
            // connect_button
            // 
            this.connect_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.connect_button.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.connect_button.ForeColor = System.Drawing.Color.White;
            this.connect_button.Location = new System.Drawing.Point(548, 12);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(179, 56);
            this.connect_button.TabIndex = 16;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = false;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // port_textBox
            // 
            this.port_textBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.port_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.port_textBox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.port_textBox.Location = new System.Drawing.Point(422, 34);
            this.port_textBox.Name = "port_textBox";
            this.port_textBox.Size = new System.Drawing.Size(105, 18);
            this.port_textBox.TabIndex = 15;
            // 
            // ip_textBox
            // 
            this.ip_textBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.ip_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ip_textBox.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ip_textBox.Location = new System.Drawing.Point(83, 37);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(237, 18);
            this.ip_textBox.TabIndex = 14;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.port_label.ForeColor = System.Drawing.Color.White;
            this.port_label.Location = new System.Drawing.Point(335, 31);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(81, 24);
            this.port_label.TabIndex = 13;
            this.port_label.Text = "Port :";
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.ip_label.ForeColor = System.Drawing.Color.White;
            this.ip_label.Location = new System.Drawing.Point(24, 33);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(53, 24);
            this.ip_label.TabIndex = 12;
            this.ip_label.Text = "IP :";
            // 
            // play_listView
            // 
            this.play_listView.BackColor = System.Drawing.Color.MidnightBlue;
            this.play_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.play_listView.Font = new System.Drawing.Font("MD아롱체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.play_listView.Location = new System.Drawing.Point(469, 201);
            this.play_listView.Name = "play_listView";
            this.play_listView.Size = new System.Drawing.Size(414, 241);
            this.play_listView.TabIndex = 25;
            this.play_listView.UseCompatibleStateImageBehavior = false;
            // 
            // playList_label
            // 
            this.playList_label.AutoSize = true;
            this.playList_label.Font = new System.Drawing.Font("HY견고딕", 13.8F);
            this.playList_label.ForeColor = System.Drawing.Color.White;
            this.playList_label.Location = new System.Drawing.Point(467, 174);
            this.playList_label.Name = "playList_label";
            this.playList_label.Size = new System.Drawing.Size(104, 24);
            this.playList_label.TabIndex = 24;
            this.playList_label.Text = "My List";
            // 
            // Conn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(909, 466);
            this.Controls.Add(this.play_listView);
            this.Controls.Add(this.playList_label);
            this.Controls.Add(this.serverMusic_listView);
            this.Controls.Add(this.musicList_label);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.path_textBox);
            this.Controls.Add(this.downloadPath_label);
            this.Controls.Add(this.findPath_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.port_textBox);
            this.Controls.Add(this.ip_textBox);
            this.Controls.Add(this.port_label);
            this.Controls.Add(this.ip_label);
            this.Name = "Conn";
            this.Text = "Conn";
            this.Load += new System.EventHandler(this.Conn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView serverMusic_listView;
        private System.Windows.Forms.Label musicList_label;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox path_textBox;
        private System.Windows.Forms.Label downloadPath_label;
        private System.Windows.Forms.Button findPath_button;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.TextBox port_textBox;
        private System.Windows.Forms.TextBox ip_textBox;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.ListView play_listView;
        private System.Windows.Forms.Label playList_label;
    }
}