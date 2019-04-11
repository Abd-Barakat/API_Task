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
        private static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);
        private string[] Files;
        private List<string> Songs;
        private string Path;
        private bool IsPlayImg;
        private bool IsMuteImg;
        private bool IsfullImg;
        private bool IshalfImg;
        private bool IsQuartImg;
        private bool IsPlaying;
        private bool IsPrev;
        private bool IsNext;
        private bool IsStop;
        private Image prev_speaker_image;
        private int index;
        private string buffer="";
        public const int MM_MCINOTIFY = 953;
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
            }
            IsPlayImg = true;
            IshalfImg = true;
            IsMuteImg = false;
            IsQuartImg = false;
            IsfullImg = false;
            IsPlaying = false;
            index = 0;
            IsStop = false;
            IsPrev = false;
            IsNext = false;
        }

        private void Play(int index)
        {
            string command = @"open " + Files[index] + " type mpegvideo alias MP3_Device";
            var Opened = mciSendString(command, null, 0, IntPtr.Zero);
            if (Opened == 0)
            {
                mciSendString("play MP3_Device notify ", null, 0, this.Handle);
                mciSendString("setaudio MP3_Device volume to " + VolumeBar.Value * 10, null, 0, IntPtr.Zero);
                mciSendString("set MediaFile time format milliseconds", null, 0, IntPtr.Zero);
                mciSendString("set MediaFile seek exactly on", null, 0, IntPtr.Zero);
                StringBuilder builder = new StringBuilder(512);
                mciSendString("status MP3_Device length", builder, builder.Capacity, IntPtr.Zero).ToString();
                TimeSpan time = new TimeSpan();
                time = TimeSpan.FromMinutes(Convert.ToDouble(builder.ToString()) / 1000);
                EndLabel.Text = (time.ToString("hh':'mm"));
                IsPlaying = true;
            }
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY && !IsStop &&!IsNext&&IsPrev)
            {
                MessageBox.Show("End");
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
                IsPlaying = false;
                index++;
                if (index == Files.Length)
                {
                    index = 0;
                }
                Play(index);
            }
            if (IsStop)
            {
                IsStop = false;
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
            }
            if (IsNext)
            {
                IsStop = false;
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
            }
            if (IsPrev)
            {
                IsStop = false;
                mciSendString("close MP3_Device", null, 0, IntPtr.Zero);
            }

            base.WndProc(ref m);
        }
        private void PlayPauseImage_Click(object sender, EventArgs e)
        {
            switch (IsPlayImg)
            {
                case true:
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Pause;
                    Play(index);
                    IsPlayImg = false;
                    break;
                case false:
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Play;
                    IsPlayImg = true;
                    break;
            }
        }
        private void SpeakerImage_Click(object sender, EventArgs e)
        {
            switch (IsMuteImg)
            {
                case true:
                    SpeakerImage.Image = prev_speaker_image;
                    IsMuteImg = false;
                    break;
                case false:
                    prev_speaker_image = SpeakerImage.Image;
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_mute;
                    IsMuteImg = true;
                    break;
            }
        }
        private void Change_Speaker_Image(int VoulumValue)
        {

            if (VolumeBar.Value > 0 && VolumeBar.Value <= 35)
            {
                if (!IsQuartImg)
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_quarter;
                    IsQuartImg = true;
                    IsfullImg = IshalfImg = IsMuteImg = false;
                }
            }
            else if (VolumeBar.Value > 35 && VolumeBar.Value <= 70)
            {
                if (!IshalfImg)
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_half;
                    IshalfImg = true;
                    IsfullImg = IsQuartImg = IsMuteImg = false;
                }
            }
            else if (VolumeBar.Value > 71)
            {
                if (!IsfullImg)
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
                mciSendString("stop MP3_Device", null, 0,IntPtr.Zero);
                IsStop = true;
                PlayPauseImage_Click(null, null);
            }

        }

        private void PreviousImage_Click(object sender, EventArgs e)
        {
            if (index ==0)
            {
                index = Files.Length - 1;
            }
            else
            {
                index--;
            }
            Play(index);
        }
    }
}
