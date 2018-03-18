using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Shell32;
using packet;

namespace TP_Form
{
    public partial class Conn : Form
    {
        public Conn()
        {
            InitializeComponent();
        }
        private NetworkStream client_NetStream;
        private TcpClient m_Client;
        private Thread receive;

        private byte[] sendBuffer = new byte[Packet.Size];
        private byte[] readBuffer = new byte[Packet.Size];

        private bool mRecv = false;

        public Thread m_Thread;
        public Thread tDownload;
        public mp3 mp3Class;

        private int PORT;
        private string IP;
        private const int bufferSize = Packet.Size;
        private int focusedItemIndex;
        private FileInfo[] fi;
        Packet packet;

        public string fileName;
        public string savePath;
        public string filePath;
        public string[] fullPath;
        public string[,] fileInfo;

        public string receivedPath; //전달받은 경로.

        public void Send()
        {
            this.client_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.client_NetStream.Flush();

            for (int i = 0; i < sendBuffer.Length; i++)
                this.sendBuffer[i] = 0;
        }   //네트워크 스트림에 데이터를 write하는 함수

        public void Receive()
        {
            int nRead = 0;
            while (mRecv)
            {
                try
                {
                    nRead = client_NetStream.Read(readBuffer, 0, readBuffer.Length);
                }
                catch
                {
                    MessageBox.Show("Error");
                }

                packet = (Packet)Packet.Deserialize(readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.mp3:
                        {
                            this.mp3Class = (mp3)Packet.Deserialize(this.readBuffer);

                            fileInfo = mp3Class.fileInfo;
                            filePath = mp3Class.path;
                            fullPath = mp3Class.fullPath;
                            fi = mp3Class.fi;
                            fileName = mp3Class.filename;

                            for (int i = 0; i < fileInfo.GetLength(0); i++)
                            {
                                this.serverMusic_listView.Items.Add(new ListViewItem(new string[]
                                {
                                    fileInfo[i,0], fileInfo[i,1], fileInfo[i,2], fileInfo[i,3]
                                }));
                            }
                            break;
                        }

                    case (int)PacketType.fTran:
                        {
                            tDownload = new Thread(new ThreadStart(fileDownload));
                            tDownload.Start();
                            tDownload.Join();
                            break;
                        }
                }

            }
        }   //서버로부터 데이터를 받는 함수

        public void fileDownload()
        {
            mp3FileTrans file_packet = (mp3FileTrans)Packet.Deserialize(readBuffer);

            FileStream mp3_fs = new FileStream(savePath + "\\" + fi[focusedItemIndex].Name, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(mp3_fs);

            bw.Seek(0, SeekOrigin.End);
            bw.Write(file_packet.Data); //client가 할 부분
            Thread th = new Thread(new ThreadStart(progress));
            th.Start();
            th.Join();

            mp3_fs.Close(); //client가 할 부분
            bw.Close(); //client가 할 부분
        }     //서버로 부터 받는 패킷 타입이 fileTran일 경우 호출 함수

        public void progress()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                progressBar1.Maximum = (int)(fi[focusedItemIndex].Length / (bufferSize - 384)) + 1;
                if (progressBar1.Value < progressBar1.Maximum)
                    progressBar1.Value++;
                else
                {
                    connect_button.Enabled = true;
                    findPath_button.Enabled = true;
                }
            }));

        }   //progress bar 함수.
        

        private void client_form_Load(object sender, EventArgs e)
        {
            this.serverMusic_listView.View = View.Details;
            this.serverMusic_listView.Columns.Add("Music Name", 160, HorizontalAlignment.Left);
            this.serverMusic_listView.Columns.Add("Artist", 110, HorizontalAlignment.Left);
            this.serverMusic_listView.Columns.Add("Play Time", 80, HorizontalAlignment.Center);
            this.serverMusic_listView.Columns.Add("Bit Rate", 75, HorizontalAlignment.Left);

            this.play_listView.View = View.Details;
            this.play_listView.Columns.Add("Music Name", 160, HorizontalAlignment.Left);
            this.play_listView.Columns.Add("Artist", 110, HorizontalAlignment.Left);
            this.play_listView.Columns.Add("Play Time", 80, HorizontalAlignment.Center);
            this.play_listView.Columns.Add("Bit Rate", 75, HorizontalAlignment.Left);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //pictureBox4.Visible = true;
            //pictureBox2.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //pictureBox2.Visible = true;
            //pictureBox4.Visible = false;
        }

        private void connect_button_Click(object sender, EventArgs e)
        {

            if (ip_textBox.Text == "" || port_textBox.Text == "")
            {
                MessageBox.Show("Ip 혹은 Port Number가 설정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (connect_button.Text == "Connect")
                {
                    serverMusic_listView.Items.Clear();   //연결 되면 리스트뷰 클리어.

                    m_Client = new TcpClient();

                    try
                    {
                        IP = ip_textBox.Text;
                        PORT = Convert.ToInt32(port_textBox.Text);
                        m_Client.Connect(IP, PORT);
                        mRecv = true;
                    }
                    catch
                    {
                        MessageBox.Show("Can not Connect...", "", MessageBoxButtons.OK);
                        mRecv = false;
                        return;
                    }

                    client_NetStream = m_Client.GetStream();

                    receive = new Thread(new ThreadStart(this.Receive));    //server로 부터 list받는 쓰레드
                    receive.Start();

                    connect_button.Text = "Disconnect";
                    connect_button.ForeColor = Color.Red;
                    ip_textBox.Enabled = false;
                    port_textBox.Enabled = false;
                }
                else
                {
                    mRecv = false;

                    m_Client.Close();
                    client_NetStream.Close();
                    receive.Abort();
                    tDownload.Abort();

                    connect_button.Text = "Connect";
                    connect_button.ForeColor = Color.Black;
                    ip_textBox.Enabled = true;
                    port_textBox.Enabled = true;
                }
            }
        }


        private void findPath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                path_textBox.Text = folderBrowse.SelectedPath;   //mp3 경로를 텍스트박스안에 보여줌
                savePath = folderBrowse.SelectedPath;   //경로를 path 변수안에 저장.
            }
        }

        private void listAdd_button_Click(object sender, EventArgs e)
        {
            focusedItemIndex = serverMusic_listView.FocusedItem.Index;
            string filename = this.fi[focusedItemIndex].Name;
            progressBar1.Value = 0;             //progress bar 초기화

            if (path_textBox.Text == "")
            {
                MessageBox.Show("파일을 다운로드받을 위치를 정하지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (progressBar1.Value != 0)        //progress bar가 진행중이면 더이상 다운 안됨
                return;

            connect_button.Enabled = false;
            findPath_button.Enabled = false;

            mp3 clientMp3 = new mp3();
            clientMp3.Type = (int)PacketType.mp3;
            clientMp3.filename = filename;
            clientMp3.fi = null;

            FileInfo fInfo = new FileInfo(savePath + "\\" + filename);
            if (fInfo.Exists)
            {
                MessageBox.Show("이미 파일이 존재합니다.");
                connect_button.Enabled = true;
                findPath_button.Enabled = true;
                return;
            }

            Packet.Serialize(clientMp3).CopyTo(sendBuffer, 0);
            Send();
        }

        private void serverMusic_listView_DoubleClick(object sender, EventArgs e)
        {

            focusedItemIndex = serverMusic_listView.FocusedItem.Index;
            string filename = this.fi[focusedItemIndex].Name;
            progressBar1.Value = 0;             //progress bar 초기화

            if (path_textBox.Text == "")
            {
                MessageBox.Show("파일을 다운로드받을 위치를 정하지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (progressBar1.Value != 0)
                return;

            connect_button.Enabled = false;
            findPath_button.Enabled = false;

            mp3 clientMp3 = new mp3();
            clientMp3.Type = (int)PacketType.mp3;
            clientMp3.filename = filename;
            clientMp3.fi = null;

            FileInfo fInfo = new FileInfo(savePath + "\\" + filename);
            if (fInfo.Exists)
            {
                MessageBox.Show("이미 파일이 존재합니다.");
                connect_button.Enabled = true;
                findPath_button.Enabled = true;
                return;
            }

            Packet.Serialize(clientMp3).CopyTo(sendBuffer, 0);
            Send();


            this.play_listView.Items.Add(new ListViewItem(new string[]
            {
                 fileInfo[focusedItemIndex,0], fileInfo[focusedItemIndex,1],
                 fileInfo[focusedItemIndex,2], fileInfo[focusedItemIndex,3]
            }));
        }

        private void Conn_Load(object sender, EventArgs e)
        {
            this.serverMusic_listView.View = View.Details;
            this.serverMusic_listView.Columns.Add("Music Name", 180, HorizontalAlignment.Left);
            this.serverMusic_listView.Columns.Add("Artist", 70, HorizontalAlignment.Center);
            this.serverMusic_listView.Columns.Add("Play Time", 120, HorizontalAlignment.Center);
            this.serverMusic_listView.Columns.Add("Bit Rate", 60, HorizontalAlignment.Center);

            this.play_listView.View = View.Details;
            this.play_listView.Columns.Add("Music Name", 180, HorizontalAlignment.Left);
            this.play_listView.Columns.Add("Artist", 70, HorizontalAlignment.Center);
            this.play_listView.Columns.Add("Play Time", 120, HorizontalAlignment.Center);
            this.play_listView.Columns.Add("Bit Rate", 60, HorizontalAlignment.Center);
        }
    }
}
