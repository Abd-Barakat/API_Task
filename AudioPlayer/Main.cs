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
namespace AudioPlayer
{

    public partial class Main : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        private string[] Files;
        private List<string> Songs;
        private string Path;
        private bool isPlay;
        private bool isMute;
        private bool isfull;
        private bool ishalf;
        private bool isQuart;
        private Image prev_speaker_image;
        public Main()
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
            isPlay = true;
            ishalf = true;
            isMute = false;
            isQuart = false;
            isfull = false;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            foreach (string file in Files)
            {
                string command = @"open " + file + " type mpegvideo alias MP3_Device";
                var Opened = mciSendString(command, null, 0, 0);
                if (Opened == 0)
                {
                    mciSendString("play MP3_Device wait", null, 0, 0);
                    mciSendString("close MP3_Device", null, 0, 0);
                }
            }
        }

        private void PlayPauseImage_Click(object sender, EventArgs e)
        {
            switch (isPlay)
            {
                case true:
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Pause;
                    isPlay = false;
                    break;
                case false:
                    PlayPauseImage.Image = AudioPlayer.Properties.Resources.Play;
                    isPlay = true;
                    break;
            }

        }


     

        private void SpeakerImage_Click(object sender, EventArgs e)
        {
            switch(isMute)
            {
                case true:
                    SpeakerImage.Image = prev_speaker_image;
                    isMute = false;
                    break;
                case false:
                    prev_speaker_image = SpeakerImage.Image;
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_mute;
                    isMute = true;
                    break;
            }
        }
        private void Change_Speaker_Image(int VoulumValue)
        {

            if (VolumeBar.Value > 0 && VolumeBar.Value <= 35)
            {
                if (!isQuart)
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_quarter;
                    isQuart = true;
                    isfull = ishalf = isMute = false;
                }
            }
            else if (VolumeBar.Value > 35 && VolumeBar.Value <= 70)
            {
                if (!ishalf)
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_half;
                    ishalf = true;
                    isfull = isQuart = isMute = false;
                }
            }
            else if(VolumeBar.Value >71)
            {
                if (!isfull)
                {
                    SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_full;
                    isfull = true;
                    ishalf = isQuart = isMute = false;
                }
            }
            else
            {
                SpeakerImage.Image = AudioPlayer.Properties.Resources.speaker_mute;
                isMute = true;
                ishalf = isQuart = isfull = false;
            }
        }
        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            Change_Speaker_Image(VolumeBar.Value);
        }
    }
}
