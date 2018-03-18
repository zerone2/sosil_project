using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class Guitar : Form
    {
        //녹음을 위한 import
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string strReturnString, int uReturnLength, int hwndCallback);
        //재생을 위한 import
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        ISoundEngine engine1 = new ISoundEngine();
        bool engine1_b = false;

        public Guitar()
        {
            InitializeComponent();
            Em.Parent = pictureBox1;
            Em.BackColor = Color.Transparent;
            G.Parent = pictureBox1;
            G.BackColor = Color.Transparent;
            C.Parent = pictureBox1;
            C.BackColor = Color.Transparent;
            Am.Parent = pictureBox1;
            Am.BackColor = Color.Transparent;
            F.Parent = pictureBox1;
            F.BackColor = Color.Transparent;
            D.Parent = pictureBox1;
            D.BackColor = Color.Transparent;
            D7.Parent = pictureBox1;
            D7.BackColor = Color.Transparent;
            E.Parent = pictureBox1;
            E.BackColor = Color.Transparent;
            FF.Parent = pictureBox1;
            FF.BackColor = Color.Transparent;
            GG.Parent = pictureBox1;
            GG.BackColor = Color.Transparent;

            line1.Parent = pictureBox1;
            line1.BackColor = Color.Transparent;
            line2.Parent = pictureBox1;
            line2.BackColor = Color.Transparent;
            line3.Parent = pictureBox1;
            line3.BackColor = Color.Transparent;
            line4.Parent = pictureBox1;
            line4.BackColor = Color.Transparent;
            line5.Parent = pictureBox1;
            line5.BackColor = Color.Transparent;
            line6.Parent = pictureBox1;
            line6.BackColor = Color.Transparent;

            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            label9.Parent = pictureBox1;
            label10.Parent = pictureBox1;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Exit_Click(object sender, EventArgs e)
        {
            engine1.StopAllSounds();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Recording_Click(object sender, EventArgs e)
        {

            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);

            mciSendString("record recsound", "", 0, 0);
        }

        private void Brows_Click(object sender, EventArgs e)
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
        }

        private void Play_Click(object sender, EventArgs e)
        {
            engine1.Play2D(Path.Text);
        }

        #region 코드클릭이벤트(음악재생)
        private void G_Click_1(object sender, EventArgs e)
        {
                ISoundEngine engine1 = new ISoundEngine();
                engine1.Play2D(Application.StartupPath + @"\Guitar\G_chord.wav");

                line1.BackColor = System.Drawing.Color.Maroon;
                line5.BackColor = System.Drawing.Color.Maroon;
                line6.BackColor = System.Drawing.Color.Maroon;
                line2.BackColor = System.Drawing.Color.Transparent;
                line3.BackColor = System.Drawing.Color.Transparent;
                line4.BackColor = System.Drawing.Color.Transparent;
                //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void C_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\C_chord.wav");

            line2.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void D_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\D_chord.wav");

            line1.BackColor = System.Drawing.Color.Maroon;
            line2.BackColor = System.Drawing.Color.Maroon;
            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Transparent;
            line5.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void Em_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\Em_chord.wav");

            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void Am_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\Am_chord.wav");

            line2.BackColor = System.Drawing.Color.Maroon;
            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line5.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void F_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\F_chord.wav");

            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void D7_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\D7_chord.wav");

            line1.BackColor = System.Drawing.Color.Maroon;
            line2.BackColor = System.Drawing.Color.Maroon;
            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Transparent;
            line5.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void E_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\E_chord.wav");

            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void FF_Click_1(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\Fsharp_chord.wav");

            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            //Em.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void GG_Click(object sender, EventArgs e)
        {
            ISoundEngine engine1 = new ISoundEngine();
            engine1.Play2D(Application.StartupPath + @"\Guitar\Gsharp_chord.wav");

            line3.BackColor = System.Drawing.Color.Maroon;
            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Maroon;
            line1.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
        }
        #endregion

        #region 기타 줄 클릭 이벤트(색변환)
        private void line6_Click(object sender, EventArgs e)
        {
            line6.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Transparent;
            line4.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line1.BackColor = System.Drawing.Color.Transparent;
        }

        private void line5_Click(object sender, EventArgs e)
        {
            line5.BackColor = System.Drawing.Color.Maroon;
            line6.BackColor = System.Drawing.Color.Transparent;
            line4.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line1.BackColor = System.Drawing.Color.Transparent;
        }

        private void line4_Click(object sender, EventArgs e)
        {
            line4.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line1.BackColor = System.Drawing.Color.Transparent;
        }

        private void line3_Click(object sender, EventArgs e)
        {
            line3.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Transparent;
            line4.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line1.BackColor = System.Drawing.Color.Transparent;
        }

        private void line2_Click(object sender, EventArgs e)
        {
            line2.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Transparent;
            line4.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
            line1.BackColor = System.Drawing.Color.Transparent;
        }

        private void line1_Click(object sender, EventArgs e)
        {
            line1.BackColor = System.Drawing.Color.Maroon;
            line5.BackColor = System.Drawing.Color.Transparent;
            line4.BackColor = System.Drawing.Color.Transparent;
            line3.BackColor = System.Drawing.Color.Transparent;
            line2.BackColor = System.Drawing.Color.Transparent;
            line6.BackColor = System.Drawing.Color.Transparent;
        }
        #endregion
        private void Guitar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    e.Handled = true;
                    G_Click_1(this, null); ;
                    break;
                case Keys.W:
                    e.Handled = true;
                    C_Click_1(this, null);
                    break;
                case Keys.E:
                    e.Handled = true;
                    Em_Click_1(this, null);
                    break;
                case Keys.R:
                    e.Handled = true;
                    Am_Click_1(this, null);
                    break;
                case Keys.T:
                    e.Handled = true;
                    F_Click_1(this, null);
                    break;
                case Keys.A:
                    e.Handled = true;
                    D_Click_1(this, null);
                    break;
                case Keys.S:
                    e.Handled = true;
                    D7_Click_1(this, null);
                    break;
                case Keys.D:
                    e.Handled = true;
                    E_Click_1(this, null);
                    break;
                case Keys.F:
                    e.Handled = true;
                    FF_Click_1(this, null);
                    break;
                case Keys.G:
                    e.Handled = true;
                    GG_Click(this, null);
                    break;
                case Keys.Space:
                    ISoundEngine engine1 = new ISoundEngine();
                    engine1.Play2D(Application.StartupPath + @"\Guitar\fret_noise1.wav");
                    break;
                case Keys.Escape:
                    e.Handled = true;
                    Exit_Click(this, e);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (engine1_b == true)
                engine1_b = false;
            else if (engine1_b == false)
                engine1_b = true;

            engine1.SetAllSoundsPaused(engine1_b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine1.StopAllSounds();
        }
        public string pathTxt
        {
            get { return this.Path.Text; }
        }

        private void scratch_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
