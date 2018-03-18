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

using IrrKlang;
using System.Speech;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace TP_Form
{
    public partial class Piano : Form
    {
        //녹음을 위한 import
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string strReturnString, int uReturnLength, int hwndCallback);
        //재생을 위한 import
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        int octa = 4;
        ISoundEngine engine1 = new ISoundEngine();
        bool engine1_b = false;

        public Piano()
        {
            InitializeComponent();
        }


        private void C_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\C" + octa + ".wav");

            //색 조정
            C.BackColor = System.Drawing.Color.SkyBlue;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void D_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\D" + octa + ".wav");

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.SkyBlue;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void E_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\E" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.SkyBlue;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void F_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\F" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.SkyBlue;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void G_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\G" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.SkyBlue;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void H_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\A" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;


            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.SkyBlue;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;

        }

        private void I_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\B" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.SkyBlue;
        }



        private void CC_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\CC" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.SkyBlue;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void DD_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\DD" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.SkyBlue;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void FF_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\FF" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.SkyBlue;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void GG_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\GG" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.SkyBlue;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.Black;
            I.BackColor = System.Drawing.Color.White;
        }

        private void HH_Click(object sender, EventArgs e)
        {
            ISoundEngine engine = new ISoundEngine();
            engine.Play2D(Application.StartupPath + @"\Piano\AA" + octa + ".wav");

            C.BackColor = System.Drawing.Color.SkyBlue;

            //색 조정
            C.BackColor = System.Drawing.Color.White;
            CC.BackColor = System.Drawing.Color.Black;
            D.BackColor = System.Drawing.Color.White;
            DD.BackColor = System.Drawing.Color.Black;
            E.BackColor = System.Drawing.Color.White;
            F.BackColor = System.Drawing.Color.White;
            FF.BackColor = System.Drawing.Color.Black;
            G.BackColor = System.Drawing.Color.White;
            GG.BackColor = System.Drawing.Color.Black;
            H.BackColor = System.Drawing.Color.White;
            HH.BackColor = System.Drawing.Color.SkyBlue;
            I.BackColor = System.Drawing.Color.White;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    e.Handled = true;
                    C.PerformClick();
                    break;
                case Keys.W:
                    e.Handled = true;
                    CC.PerformClick();
                    break;
                case Keys.S:
                    e.Handled = true;
                    D.PerformClick();
                    break;
                case Keys.E:
                    e.Handled = true;
                    DD.PerformClick();
                    break;
                case Keys.D:
                    e.Handled = true;
                    E.PerformClick();
                    break;
                case Keys.F:
                    e.Handled = true;
                    F.PerformClick();
                    break;
                case Keys.T:
                    e.Handled = true;
                    FF.PerformClick();
                    break;
                case Keys.G:
                    e.Handled = true;
                    G.PerformClick();
                    break;
                case Keys.Y:
                    e.Handled = true;
                    GG.PerformClick();
                    break;
                case Keys.H:
                    e.Handled = true;
                    H.PerformClick();
                    break;
                case Keys.U:
                    e.Handled = true;
                    HH.PerformClick();
                    break;
                case Keys.J:
                    e.Handled = true;
                    I.PerformClick();
                    break;
                case Keys.PageUp:
                    button1_Click(this, e);
                    break;
                case Keys.PageDown:
                    dOctaBtn_Click(this, e);
                    break;
                case Keys.Escape:
                    Exit_Click(this, e);
                    break;
            }
        }

        private void Recording_Click(object sender, EventArgs e)
        {
            now.Visible = true;
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);

            mciSendString("record recsound", "", 0, 0);
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
            now.Visible = false;

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

        private void Play_Click(object sender, EventArgs e)
        {
            engine1.Play2D(Path.Text);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            engine1.StopAllSounds();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (engine1_b == true)
                engine1_b = false;
            else if (engine1_b == false)
                engine1_b = true;

            engine1.SetAllSoundsPaused(engine1_b);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
             engine1.StopAllSounds();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (octa < 6)
                octa++;
            octave.Text = "Octave " + octa;
        }

        private void dOctaBtn_Click(object sender, EventArgs e)
        {
            if (octa > 1)
                octa--;
            octave.Text = "Octave " + octa;
        }

        public string pathTxt
        {
            get { return this.Path.Text; }
        }
    }
}
