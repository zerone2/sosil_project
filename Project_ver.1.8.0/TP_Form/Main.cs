using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

using IrrKlang;
using System.Speech;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace TP_Form
{
    public partial class Main : Form
    {
        //녹음을 위한 import
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string strReturnString, int uReturnLength, int hwndCallback);
        //재생을 위한 import
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        
        Piano piano;
        Drum drum;
        Guitar guitar;
        Conn client;

        string fileName;

        ISoundEngine engine1 = new ISoundEngine();
        ISoundEngine engine2 = new ISoundEngine();
        ISoundEngine engine3 = new ISoundEngine();

        bool engine1_b = false;
        bool engine2_b = false;
        bool engine3_b = false;
        bool allplay = false;
        bool allrecording = false;

        public class Alltime
        {
            public string button { get; set; }
            public int time { get; set; }

            public Alltime(string button, int time)
            {
                this.button = button;
                this.time = time;
            }
        }

        public Main()
        {
            InitializeComponent();
            //String ip = GetLocalIP();
            //MessageBox.Show(ip);

            /*string strconn = "Server=localhost;Database=sosil_team;Uid=root;Pwd=3039;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(strconn);
            try
            {
                conn.Open();
                MessageBox.Show("connection success!!");
                string query = "SELECT * FROM rcv_file";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MessageBox.Show("Name : " + rdr["file_name"] + "\ndir route : " + rdr[1] + "\nfile size : " + rdr[2] + "\nfile type : " + rdr[3] + "\nuploader : " + rdr["uploader"]);
                }
                rdr.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("mysql connection failed" + ex);
            }*/

            piano_creat_btn.BackColor = Color.Transparent;
            piano_creat_btn.Parent = pictureBox1;
            guitar_creat_btn.BackColor = Color.Transparent;
            guitar_creat_btn.Parent = pictureBox1;
            drum_creat_btn.BackColor = Color.Transparent;
            drum_creat_btn.Parent = pictureBox1;
            piano_play_btn.BackColor = Color.Transparent;
            piano_play_btn.Parent = pictureBox1;
            guitar_play_btn.BackColor = Color.Transparent;
            guitar_play_btn.Parent = pictureBox1;
            drum_play_btn.BackColor = Color.Transparent;
            drum_play_btn.Parent = pictureBox1;
            piano_pause_btn.BackColor = Color.Transparent;
            piano_pause_btn.Parent = pictureBox1;
            guitar_pause_btn.BackColor = Color.Transparent;
            guitar_pause_btn.Parent = pictureBox1;
            drum_pause_btn.BackColor = Color.Transparent;
            drum_pause_btn.Parent = pictureBox1;
            piano_stop_btn.BackColor = Color.Transparent;
            piano_stop_btn.Parent = pictureBox1;
            guitar_stop_btn.BackColor = Color.Transparent;
            guitar_stop_btn.Parent = pictureBox1;
            drum_stop_btn.BackColor = Color.Transparent;
            drum_stop_btn.Parent = pictureBox1;
            all_play.BackColor = Color.Transparent;
            all_play.Parent = pictureBox1;
            save_btn.BackColor = Color.Transparent;
            save_btn.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;
        }

        public string GetLocalIP()
        {
            string localIP = "Not available, please check your network seetings!";
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
        private void mysqlTest()
        {
            String ip = GetLocalIP();
            string strconn = "Server="+ip+";Database=sosil_team;Uid=root;Pwd=0805;Charset=utf8;";
            MySqlConnection conn = new MySqlConnection(strconn);
            try {
                conn.Open();
                MessageBox.Show("connection success");
                string query = "SELECT * FROM rcv_file where file_name='"+fileName+"'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MessageBox.Show("Name : " + rdr["file_name"] + "\ndir route : " + rdr[1] + "\nfile size : " + rdr[2] + "\nfile type : " + rdr[3] + "\nuploader : " + rdr["uploader"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("connection error");
                MessageBox.Show("error : " + ex);
            }
        }

        private void piano_creat_btn_Click(object sender, EventArgs e)
        {
            piano = new TP_Form.Piano();
            //piano.MdiParent = this;
            
            //piano.Text = "My Piano";
            //piano.Show();

            if (piano.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                piano_TB.Text = piano.pathTxt;
            }
        }

        private void guitar_creat_btn_Click(object sender, EventArgs e)
        {
            guitar = new TP_Form.Guitar();
            //guitar.Text = "My Guitar";
            //guitar.Show();


            if (guitar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                guitar_TB.Text = guitar.pathTxt;
            }
        }

        private void drum_creat_btn_Click(object sender, EventArgs e)
        {
            drum = new TP_Form.Drum();
            //drum.Text = "My Drum";
            //drum.Show();

            if (drum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                drum_TB.Text = drum.pathTxt;
            }
        }

        private void piano_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                piano_TB.Text = open.FileName;
            }
        }

        private void guitar_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                guitar_TB.Text = open.FileName;
            }
        }

        private void drum_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                drum_TB.Text = open.FileName;
            }
        }

        private void piano_play_btn_Click(object sender, EventArgs e)
        {
            //Delay(Convert.ToInt32(pianoTime.Text));
            engine1.Play2D(piano_TB.Text);
        }

        private void guitar_play_btn_Click(object sender, EventArgs e)
        {
            //Delay(Convert.ToInt32(guitarTime.Text));
            engine2.Play2D(guitar_TB.Text);
        }

        private void drum_play_btn_Click(object sender, EventArgs e)
        {
            //Delay(Convert.ToInt32(drumTime.Text));
            engine3.Play2D(drum_TB.Text);
        }

        private void piano_pause_btn_Click(object sender, EventArgs e)
        {
            if (engine1_b == true)
                engine1_b = false;
            else if (engine1_b == false)
                engine1_b = true;

            engine1.SetAllSoundsPaused(engine1_b);
        }

        private void piano_stop_btn_Click(object sender, EventArgs e)
        {
            engine1.StopAllSounds();
        }

        private void guitar_pause_btn_Click(object sender, EventArgs e)
        {
            if (engine2_b == true)
                engine2_b = false;
            else if (engine2_b == false)
                engine2_b = true;

            engine2.SetAllSoundsPaused(engine2_b);
        }

        private void guitar_stop_btn_Click(object sender, EventArgs e)
        {
            engine2.StopAllSounds();
        }

        private void drum_pause_btn_Click(object sender, EventArgs e)
        {
            if (engine3_b == true)
                engine3_b = false;
            else if (engine3_b == false)
                engine3_b = true;

            engine3.SetAllSoundsPaused(engine3_b);
        }

        private void drum_stop_btn_Click(object sender, EventArgs e)
        {
            engine3.StopAllSounds();
        }

        private void all_play_Click(object sender, EventArgs e)
        {
            if(allplay)
            {
                all_play.Image = TP_Form.Properties.Resources.all_play;
                allplay = false;
                engine1.StopAllSounds();
                engine2.StopAllSounds();
                engine3.StopAllSounds();
            }
            else
            {
                all_play.Image = TP_Form.Properties.Resources.all_stop1;
                allplay = true;

                List<Alltime> alltime = new List<Alltime>();

                alltime.Add(new Alltime(piano_TB.Text, Convert.ToInt32(pianoTime.Text)));
                alltime.Add(new Alltime(guitar_TB.Text, Convert.ToInt32(guitarTime.Text)));
                alltime.Add(new Alltime(drum_TB.Text, Convert.ToInt32(drumTime.Text)));

                alltime.Sort((left, right) => { return left.time - right.time; });
                int i = 1;
                int beforeTime = 0;
                int totTime = 0;
                foreach (Alltime atime in alltime)
                {
                    if (beforeTime != atime.time)
                    {
                        Delay(Convert.ToInt32(atime.time - beforeTime));
                        beforeTime = atime.time;
                        totTime += atime.time;
                    }
                    if (i == 1)
                        engine1.Play2D(atime.button);
                    else if (i == 2)
                        engine2.Play2D(atime.button);
                    else
                        engine3.Play2D(atime.button);
                    i++;
                }
            }
            
        }

        private static DateTime Delay(int S)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, S, 0);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            save_btn.Image = TP_Form.Properties.Resources.all_Rec;

            if (allrecording)
            {
                SaveFileDialog save = new SaveFileDialog();

                DialogResult dr = save.ShowDialog();

                if (dr == DialogResult.OK)

                {

                    mciSendString(@"save recsound " + save.FileName + ".wav", "", 0, 0);

                    mciSendString("close recsound ", "", 0, 0);
                }

                all_play_Click(this, e);

                allrecording = false;
            }

            else
            {
                save_btn.Image = TP_Form.Properties.Resources.save;

                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);

                mciSendString("record recsound", "", 0, 0);


                all_play_Click(this, e);

                allrecording = true;

                

            }
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            if (filename_comboBox.SelectedItem != null)
            {
                object file_name = filename_comboBox.SelectedItem;
                fileName = file_name.ToString();
                mysqlTest();
            }
            else
                MessageBox.Show("select your wav file from combo box");
        }

        private void conn_Click(object sender, EventArgs e)
        {
            client = new TP_Form.Conn();
            client.Text = "Connect";
            client.Show();
        }
    }
}
