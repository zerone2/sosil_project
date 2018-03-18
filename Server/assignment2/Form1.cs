using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Shell32;
using packet;

namespace assignment2
{
    public partial class server_form : Form
    {
        private NetworkStream m_NetStream;
        private TcpListener m_Listener;

        private byte[] sendBuffer = new byte[Packet.Size];
        private byte[] readBuffer = new byte[Packet.Size];

        private bool mServer = false;
        private bool mRecv = false;

        private Thread m_Thread;
        private Thread cRead;       //client로 부터 받는 쓰레드.
        private mp3 mp3File;
        private string recvFileName;    //client로 부터 받은 파일 이름
        private const int bufferSize = Packet.Size;
        public Thread tDownload;

        public string IP;
        public int PORT = 13012;

        public string path = null;
        public string[] fullPath = null;
        public byte[] fileSize = null;
        public string[,] fileInfo = null;


        public string GetLocalIP()  //현재 pc의 IP주소 가져오는 함수.
        {
            string localIP = "Not available, please check your network settings!";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public void RUN()
        {
            try
            {
                m_Listener = new TcpListener(PORT);
                m_Listener.Start();

                if (!mServer)
                {
                    this.serverStat_textBox.AppendText("Server - Start\n");
                    this.serverStat_textBox.AppendText("Server Path : " + path + "\n");
                    this.serverStat_textBox.AppendText("waiting for client access\n");
                }

                mServer = true;

                while (mServer)
                {
                    Socket Client = this.m_Listener.AcceptSocket();     //클라이언트 접속

                    if (Client.Connected)
                    {
                        serverStat_textBox.AppendText("Client Access !!");
                    }
                    mRecv = true;

                    m_NetStream = new NetworkStream(Client);   //파일 옮길 네트워크 스트림

                    cRead = new Thread(new ThreadStart(Receive));
                    cRead.Start();

                    mp3 mp3File = new mp3();
                    mp3File.Type = (int)PacketType.mp3;
                    mp3File.path = path;            //파일이 들어있는 폴더의경로
                    mp3File.fullPath = fullPath;    //파일포함 전체경로 
                    mp3File.fileInfo = fileInfo;    //전역변수 fileInfo를 mp3File의 fileInfo로 넘겨줌.

                    DirectoryInfo di = new DirectoryInfo(path); //현재 경로의 디렉토리정보
                    FileInfo[] fiArray = di.GetFiles("*.wav");  //디렉토리에 있는 mp3파일을 가져와서 fiArray에 저장
                    mp3File.fi = fiArray;

                    Packet.Serialize(mp3File).CopyTo(sendBuffer, 0);
                    Send();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Server Start error");
                MessageBox.Show("Message : " + e.Message);
                return;
            }
            
        }   //서버와 클라이언트를 연결시켜주는 쓰레드

        public void Receive()
        {
            int nRead = 0;
            try
            {
                while (mRecv)
                {
                    try
                    {
                        nRead = this.m_NetStream.Read(readBuffer, 0, readBuffer.Length);
                    }
                    catch
                    {
                        MessageBox.Show("error");
                    }
                    Packet packet = (Packet)Packet.Deserialize(readBuffer);

                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.mp3:
                            {
                                mp3File = (mp3)Packet.Deserialize(readBuffer);
                                string fn = mp3File.filename;

                                FileInfo fInfo = new FileInfo(path + "\\" + fn);
                                if (!fInfo.Exists)
                                {
                                    fInfo = new FileInfo(path + "\\[Client]" + fn);
                                    if (fInfo.Exists)
                                    {
                                        MessageBox.Show("Client file is exist");
                                    }
                                    recvFileName = "[Client]" + fn;
                                    MessageBox.Show(recvFileName + " download start.");
                                    break;
                                }

                                serverStat_textBox.AppendText("\nDownload Requested!!");
                                serverStat_textBox.AppendText("\nSend File : " + path + "\\" + fn);

                                Thread th = new Thread(new ThreadStart(SendFile));
                                th.Start();
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
            }
            catch(Exception e)
            {
                MessageBox.Show("error in receive function");
                MessageBox.Show("error : " + e.Message);
            }
        }   //클라이언트로부터 전송 요청을 받았을 때의 함수

        public void fileDownload()
        {
            mp3FileTrans file_packet = (mp3FileTrans)Packet.Deserialize(readBuffer);

            FileStream mp3_fs = new FileStream(mp3Path_textbox.Text + "\\" + "fiName", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(mp3_fs);

            bw.Seek(0, SeekOrigin.End);
            bw.Write(file_packet.Data); //client가 할 부분

            mp3_fs.Close(); //client가 할 부분
            bw.Close(); //client가 할 부분
        }     //서버로 부터 받는 패킷 타입이 fileTran일 경우 호출 함수

        public void SendFile()
        {
            byte[] reader;

            try
            {
                FileStream fs = new FileStream(path + "\\" + mp3File.filename, FileMode.Open, FileAccess.Read);//server가 할 부분
                BinaryReader br = new BinaryReader(fs);     //server가 할 부분
                reader = br.ReadBytes(bufferSize - 500);    //server가 할 부분

                mp3FileTrans mp3_tran = new mp3FileTrans();
                mp3_tran.Data = reader;
                mp3_tran.Type = (int)PacketType.fTran;

                while (reader.Length == bufferSize - 500)
                {
                    sendBuffer = Packet.Serialize(mp3_tran);    //내부적으로 패킷화
                    Send();
                    Thread.Sleep(50);
                    reader = br.ReadBytes(bufferSize - 500);
                    mp3_tran.Type = (int)PacketType.fTran;
                    mp3_tran.Data = reader;
                }
                sendBuffer = Packet.Serialize(mp3_tran);//내부적으로 패킷화
                Send();
                Thread.Sleep(50);
                fs.Close();//server가 할 부분
                br.Close();//server가 할 부분

            }
            catch (Exception e)
            {
                MessageBox.Show("에러 메시지: " + e.Message);
            }
        }   //클라이언트로 파일을 전송하는 함수

        public void Send()
        {
            this.m_NetStream.Write(sendBuffer, 0, sendBuffer.Length);
            this.m_NetStream.Flush();

            for (int i = 0; i < sendBuffer.Length; i++)
                this.sendBuffer[i] = 0;
        }   //네트워크 스트림에 write해주는 함수

        public void STOP()
        {
            if (!mServer)
                return;

            m_Listener.Stop();  //서버 소켓 작동 중지
            m_NetStream.Close();    //스트림 닫기
            m_Thread.Abort();   //쓰레드 닫기
            tDownload.Abort();
            cRead.Abort();
        }   //서버 종료시 쓰레드 등을 같이 종료시켜주는 함수

        public server_form()
        {
            InitializeComponent();
        }

        private void server_form_Load(object sender, EventArgs e)
        {
            this.musicList_listView.View = View.Details;
            this.musicList_listView.Columns.Add("Music Name", 180, HorizontalAlignment.Left);
            this.musicList_listView.Columns.Add("Artist", 70, HorizontalAlignment.Center);
            this.musicList_listView.Columns.Add("Play Time", 120, HorizontalAlignment.Center);
            this.musicList_listView.Columns.Add("Bit Rate", 60, HorizontalAlignment.Center);

            IP = GetLocalIP();   //IP를 가져와서 변수에 저장
            ip_textbox.Text = IP;       //IP textbox에 써줌
            port_textbox.Text = PORT.ToString();    //port 번호를 port textbox에 써줌.
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (start_btn.Text == "Start")     //Start 버튼 누를 시 Client를 기다림. 
                {
                    if (mp3Path_textbox.Text != path)
                    {
                        MessageBox.Show("전송 가능한 MP3 파일이 없습니다. 경로를 다시 지정하십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); //에러메시지출력.
                    }
                    else
                    {
                        findPath_btn.Enabled = false;   //find path 버튼 비활성화
                        port_textbox.Enabled = false;   //port의 textbox 비활성화
                        start_btn.Text = "Stop";    //Start 버튼이 Stop으로 바뀜.

                        m_Thread = new Thread(new ThreadStart(RUN));
                        m_Thread.Start();
                    }
                }
                else
                {
                    mRecv = false;
                    mServer = false;

                    findPath_btn.Enabled = true;   //find path 버튼 활성화
                    port_textbox.Enabled = true;   //port의 textbox 활성화
                    m_Thread.Abort();
                    cRead.Abort();
                    tDownload.Abort();

                    start_btn.Text = "Start";
                    m_NetStream.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void findPath_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();

            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                mp3Path_textbox.Text = folderBrowse.SelectedPath;   //mp3 경로를 텍스트박스안에 보여줌
                path = folderBrowse.SelectedPath;   //경로를 path 변수안에 저장.

                musicList_listView.Items.Clear();   //새로 경로 설정시 리스트뷰 클리어

                string[] files = System.IO.Directory.GetFiles(path, "*.wav");   //확장자가 mp3인 모든 파일(경로포함)을 files 배열에 넣음
                fullPath = files;   //파일 이름까지 포함되어 있는 전체 경로

                fileInfo = getListItem(files);

                for (int i = 0; i < files.Length; i++)
                {
                    musicList_listView.Items.Add(new ListViewItem(new string[]
                    {
                        fileInfo[i,0], fileInfo[i,1],fileInfo[i,2],fileInfo[i,3]
                    }));
                }
             }
         }

       public string[ , ] getListItem(string[] files)
       {
            string[] filePath = files;
            string[,] fileInfo = new string[files.Length, 4];
            int i=0;
            
            ShellClass shell = new ShellClass();    //shell 선언.

            foreach (string s in filePath)
            {
                string filename = Path.GetFileName(s);              //파일 이름 추출.
                Folder folder = shell.NameSpace(path);              //shell32를 이용하여
                FolderItem mp3file = folder.ParseName(filename);    //mp3파일의 정보를 가져옴.
                
                string fArtist = folder.GetDetailsOf(mp3file, 20);
                string fDuration = folder.GetDetailsOf(mp3file, 27);
                string fBitRate = folder.GetDetailsOf(mp3file, 28);

                fileInfo[i, 0] = filename;
                fileInfo[i, 1] = fArtist;
                fileInfo[i, 2] = fDuration;
                fileInfo[i, 3] = fBitRate;

                i++;
             }
            return fileInfo;
        }   //mp3 파일의 속성을 가져오는 함수

        private void server_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_Listener.Stop();  //서버 소켓 작동 중지
                m_NetStream.Close();    //스트림 닫기
                m_Thread.Abort();   //쓰레드 닫기
                tDownload.Abort();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error in formClose");
                MessageBox.Show("error : " + ex.Message);
            }
        }

        private void serverStat_label_Click(object sender, EventArgs e)
        {

        }
    }
}
