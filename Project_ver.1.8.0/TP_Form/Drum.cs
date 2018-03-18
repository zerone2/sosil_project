using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

using System.Speech;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using IrrKlang;

namespace TP_Form
{
    public partial class Drum : Form
    {
        //녹음을 위한 import
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string strReturnString, int uReturnLength, int hwndCallback);
        //재생을 위한 import
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        ISoundEngine engine2 = new ISoundEngine();
        bool engine2_b = false;

        public Drum()
        {
            InitializeComponent();
            pictureBox_sTom.Parent = pictureBox1;
            pictureBox_sTom.BackColor = Color.Transparent;
            pictureBox_lTom.Parent = pictureBox1;
            pictureBox_lTom.BackColor = Color.Transparent;
            pictureBox_hhCymbal.Parent = pictureBox1;
            pictureBox_hhCymbal.BackColor = Color.Transparent;
            pictureBox_fTom.Parent = pictureBox1;
            pictureBox_fTom.BackColor = Color.Transparent;
            pictureBox_rCymbal.Parent = pictureBox1;
            pictureBox_rCymbal.BackColor = Color.Transparent;
            pictureBox_Snare.Parent = pictureBox1;
            pictureBox_Snare.BackColor = Color.Transparent;
            pictureBox_cCymbal.Parent = pictureBox1;
            pictureBox_cCymbal.BackColor = Color.Transparent;
            pictureBox_Bass.Parent = pictureBox1;
            pictureBox_Bass.BackColor = Color.Transparent;
            pictureBox_stick.Parent = pictureBox1;
            pictureBox_stick.BackColor = Color.Transparent;
        }

        #region click event

        private void pictureBox_sTom_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\TOMLOW1.wav");
        }

        private void pictureBox_lTom_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\TOMHI1.wav");
        }
        // T
        private void pictureBox_fTom_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\TOMHI3.wav");
        }
        // D
        private void pictureBox_Bass_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\kick_drum.wav");
        }

        // T
        private void pictureBox_rCymbal_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\RIDEEDGE.wav");
        }

        // S
        private void pictureBox_hhCymbal_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\snaredrum.wav");
        }

        //W
        private void pictureBox_cCymbal_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\CRASH1.wav");
        }

        //A
        private void pictureBox_Snare_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\HHOPEN1.wav");
        }
        
        private void pictureBox_stick_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Drum\drumstick.wav");
        }
        #endregion

        #region mouseON event
        private void pictureBox_sTom_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.sTom;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox_sTom_MouseLeave(object sender, EventArgs e)
        {
            Image img = TP_Form.Properties.Resources.drum;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox_lTom_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.lTom;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }



        private void pictureBox_fTom_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.fTom;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void pictureBox_Bass_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.Bass;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void pictureBox_rCymbal_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.rCymbal;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void pictureBox_cCymbal_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.cCymbal;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void pictureBox_hhCymbal_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.hhCymbal;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void pictureBox_Snare_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = TP_Form.Properties.Resources.Snare;
            pictureBox1.BackgroundImage = img;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        #region other btn click event
        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            engine2.StopAllSounds();
            this.Close();
        }

        private void Brouse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Supported Audio (*.wav)| *.wav";
            if (open.ShowDialog() == DialogResult.OK)

            {

                Path.Text = open.FileName;

            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            DialogResult dr = save.ShowDialog();

            if (dr == DialogResult.OK)

            {

                mciSendString(@"save recsound " + save.FileName + ".wav", "", 0, 0);

                mciSendString("close recsound ", "", 0, 0);

            }

            Path.Text = save.FileName + ".wav";

            if (Path.Text == ".wav")
                Path.Text = "NO SAVE";
        }

        private void Recording_Click(object sender, EventArgs e)
        {
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);

            mciSendString("record recsound", "", 0, 0);

        }
        #endregion

        private void Drum_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    e.Handled = true;
                    pictureBox_Snare_Click(this, null);
                    break;
                case Keys.W:
                    e.Handled = true;
                    pictureBox_cCymbal_Click(this, null);
                    break;
                case Keys.S:
                    e.Handled = true;
                    pictureBox_hhCymbal_Click(this, null);
                    break;
                case Keys.E:
                    e.Handled = true;
                    pictureBox_sTom_Click(this, null);
                    break;
                case Keys.D:
                    e.Handled = true;
                    pictureBox_Bass_Click(this, null);
                    break;
                case Keys.R:
                    e.Handled = true;
                    pictureBox_lTom_Click(this, null);
                    break;
                case Keys.F:
                    e.Handled = true;
                    pictureBox_stick_Click(this, null);
                    break;
                case Keys.T:
                    e.Handled = true;
                    pictureBox_rCymbal_Click(this, null);
                    break;
                case Keys.G:
                    e.Handled = true;
                    pictureBox_fTom_Click(this, null);
                    break;
                case Keys.Escape:
                    e.Handled = true;
                    exit_btn_Click(this, null);
                    break;
            }
        }
        public string pathTxt
        {
            get { return this.Path.Text; }
        }

        private void play_Click_1(object sender, EventArgs e)
        {
            engine2.Play2D(Path.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (engine2_b == true)
                engine2_b = false;
            else if (engine2_b == false)
                engine2_b = true;

            engine2.SetAllSoundsPaused(engine2_b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine2.StopAllSounds();
        }
    }
}
