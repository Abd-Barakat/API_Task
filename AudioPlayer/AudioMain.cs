using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace AudioPlayer
{

    public partial class MainForm : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);
        private string[] Files;
        private List<string> Songs;
        private string Path;
        private bool IsPlayImage;
        private bool IsMuteImg;
        private bool IsfullImg;
        private bool IshalfImg;
        private bool IsQuartImg;
        private bool IsPlaying;
        private bool IsPaused;
        private TimeSpan MusicLength;
        private Image prev_speaker_image;
        private int index;
        private bool IsStoped;
        private bool IsSelected;
        private bool IsMouseDown;
        private const int MM_MCINOTIFY = 953;
        private Thread Listener;

        public MainForm()
        {
            InitializeComponent();
            Songs = new List<string>();
            Path = System.IO.Directory.GetParent(@"..\..\").FullName;
            Path += @"\Songs";
            Files = System.IO.Directory.GetFiles(Path);
            for (int Num_Songs = 0; Num_Songs < Files.Length; Num_Songs++)
            {
                Songs.Add(System.IO.Path.GetFileName(Files[Num_Songs]));
                PlayList.Items.Add(Songs[Num_Songs]);
            }
            IsPlayImage = true;
            IshalfImg = true;
            IsMuteImg = false;
            IsQuartImg = false;
            IsfullImg = false;
            IsPlaying = false;
            IsStoped = false;
            IsPaused = false;
            IsSelected = true;
            index = 0;
            IsSelected = false;
            PlayList.SelectedIndex = index;
            IsSelected = true;
            Listener = new Thread(Listen);
            Listener.IsBackground = true;
            Listener.Start();
           
        }


        private void Listen()
        {
            
            do
            {
                if (IsPlaying) /*&& IsOn*/
                {
                    TurnOff(true);
                }
                else if (!IsPlaying)/*&& !IsOn*/
                {
                    TurnOff(false);
                }
                Thread.Sleep(500);
            } while (true);
        }


        private void TurnOff(bool IsMute)
        {
            foreach (AudioSession session in AudioServices.GetAllSessions())
            {
                if (session.Process!=null)
                {
                    if(session.Process.ProcessName == "VideoPlayer")
                    {
                        session.SetApplicationMute(IsMute);
                    }
                }
            }
        }


        private void Open(int index)
        {
            //TurnOff(true);
            string command = @"open " + Files[index] + " type mpegvideo alias MP3_Device";
            var Opened = mciSendString(command, null, 0, IntPtr.Zero);
            if (Opened == 0)
            {
                mciSendString("play MP3_Device notify ", null, 0, this.Handle);
                musicTimer.Start();
                SongBar.Value = 0;
                StartLabel.Text = "00:00";
                mciSendString("setaudio MP3_Device volume to " + VolumeBar.Value * 10, null, 0, IntPtr.Zero);
                mciSendString("set MediaFile time format milliseconds", null, 0, IntPtr.Zero);
                StringBuilder builder = new StringBuilder(512);
                mciSendString("status MP3_Device length", builder, builder.Capacity, IntPtr.Zero).ToString();
                MusicLength = new TimeSpan();
                SongBar.Maximum = Convert.ToInt32(builder.ToString());
                MusicLength = TimeSpan.FromMinutes(Convert.ToDouble(builder.ToString()) / 1000);
                EndLabel.Text = (MusicLength.ToString("hh':'mm"));
                IsPlaying = true;
            }
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY && m.WParam.ToInt32() == 1)//success finished playing
            {
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
                musicTimer.Stop();
                TurnOff(false);
                IsPlaying = false;
                backgroundWorker1.RunWorkerAsync();
            }
            base.WndProc(ref m);
        }


        private void Play()
        {
            mciSendString("play MP3_Device", null, 0, IntPtr.Zero);
            musicTimer.Start();
            IsPaused = false;
            IsPlaying = true;
        }


        private void PlayPauseImage_Click(object sender, EventArgs e)
        {
            switch (IsPlayImage)
            {
                case true:
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Pause;
                    if (!IsPaused || IsStoped)//check IsPaused if not then open a song , check  isstoped if true then re open the song
                    {
                        Open(index);
                        IsStoped = false;
                    }
                    else//if paused and want to replay 
                    {
                        Play();
                        
                    }
                    IsPlayImage = false;
                    break;
                case false://to pause the song 
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Play;
                    musicTimer.Stop();
                    IsPlaying = false;
                    IsPaused = true;
                    mciSendString("pause MP3_Device", null, 0, IntPtr.Zero);
                    IsPlayImage = true;
                    break;
            }
        }


        private void SpeakerImage_Click(object sender, EventArgs e)
        {
            switch (IsMuteImg)
            {
                case true:
                    SpeakerImage.Image = prev_speaker_image;
                    mciSendString("setaudio MP3_Device volume to " + VolumeBar.Value * 10, null, 0, IntPtr.Zero);
                    IsMuteImg = false;
                    break;
                case false:
                    prev_speaker_image = SpeakerImage.Image;
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_mute;
                    mciSendString("setaudio MP3_Device volume to 0 ", null, 0, IntPtr.Zero);
                    IsMuteImg = true;
                    break;
            }
        }


        private void Change_Speaker_Image(int VoulumValue)
        {

            if (VolumeBar.Value > 0 && VolumeBar.Value <= 35)
            {
                if (!IsQuartImg)//to prevent change image within same range !!
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_quarter;
                    IsQuartImg = true;
                    IsfullImg = IshalfImg = IsMuteImg = false;
                }
            }
            else if (VolumeBar.Value > 35 && VolumeBar.Value <= 70)
            {
                if (!IshalfImg)//to prevent change image within same range !!
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_half;
                    IshalfImg = true;
                    IsfullImg = IsQuartImg = IsMuteImg = false;
                }
            }
            else if (VolumeBar.Value > 70)
            {
                if (!IsfullImg)//to prevent change image within same range !!
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_full;
                    IsfullImg = true;
                    IshalfImg = IsQuartImg = IsMuteImg = false;
                }
            }
            else
            {
                SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_mute;
                IsMuteImg = true;
                IshalfImg = IsQuartImg = IsfullImg = false;
            }
        }


        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            Change_Speaker_Image(VolumeBar.Value);
            if (IsPlaying)
            {
                mciSendString("setaudio MP3_Device volume to " + VolumeBar.Value * 10, null, 0, IntPtr.Zero);
            }
        }


        private void StopImage_Click(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                SongBar.Value = 0;
                StartLabel.Text = EndLabel.Text = "00:00";
                IsStoped = true;
                IsPlaying = false;
                musicTimer.Stop();
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
                PlayPauseImage_Click(null, null);
            }
        }


        private void PreviousImage_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                index = Files.Length - 1;
            }
            else
            {
                index--;
            }
            IsSelected = false;
            PlayList.SelectedIndex = index;
            IsSelected = true;
            mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
            musicTimer.Stop();
            IsPlayImage = true;
            IsPaused = false;
            PlayPauseImage_Click(null, null);
        }


        private void musicTimer_Tick(object sender, EventArgs e)
        {
            if (SongBar.Value < SongBar.Maximum)
            {
                StringBuilder builder = new StringBuilder(512);
                mciSendString("status MP3_Device position", builder, builder.Capacity, IntPtr.Zero);
                SongBar.Value = Convert.ToInt32(builder.ToString());
                TimeSpan span = new TimeSpan();
                span = TimeSpan.FromSeconds((double)SongBar.Value / 1000);
                StartLabel.Text = span.ToString("mm':'ss");
            }
            else
            {
                musicTimer.Stop();
            }
        }


        private void SongBar_Scroll(object sender, EventArgs e)
        {
            if (IsPlaying && !IsMouseDown)
            {
                string command = "play MP3_Device  from " + SongBar.Value + " notify";
                mciSendString(command, null, 0, this.Handle);
            }
        }


        private void NextImage_Click(object sender, EventArgs e)
        {
            index++;
            if (index == Files.Length)
            {
                index = 0;
            }
            IsSelected = false;
            PlayList.SelectedIndex = index;
            IsSelected = true;
            mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
            musicTimer.Stop();
            IsPlayImage = true;
            IsPaused = false;
            PlayPauseImage_Click(null, null);
        }


        private void PlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
                index = PlayList.SelectedIndex;
                IsPlayImage = true;
                PlayPauseImage_Click(null, null);
            }
        }


        private void SongBar_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            musicTimer.Stop();
            TimeSpan span = new TimeSpan();
            span = TimeSpan.FromSeconds(SongBar.Value);
            StartLabel.Text = span.ToString("mm':'ss");
        }


        private void SongBar_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            musicTimer.Start();
        }

        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TurnOff(false);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
        }


       
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            index++;
            if (index == Files.Length)
            {
                index = 0;
            }
            IsSelected = false;
            PlayList.SelectedIndex = index;
            IsSelected = true;
            Open(index);
        }
    }
}
