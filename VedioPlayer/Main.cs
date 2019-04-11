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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
namespace AudioPlayer
{


    public partial class Main : Form
    {


        private string [] Videos;//
        private WMPLib.IWMPPlaylist PlayList;
      
        public Main()
        {
            InitializeComponent();
            VideoPlayer.settings.playCount = int.MaxValue;
            VideoPlayer.settings.autoStart = true;
            PlayList = VideoPlayer.playlistCollection.newPlaylist("VideosList");
        }


        private void Main_Load(object sender, EventArgs e)
        {
            string currentDirectory = System.IO.Directory.GetParent(@"..\..\").FullName;
            Videos = System.IO.Directory.GetFiles(currentDirectory + @"\Video");
            for (int  Num_Videos =0; Num_Videos<Videos.Length; Num_Videos++)
            {
                var media = VideoPlayer.newMedia(Videos[Num_Videos]);
                PlayList.appendItem(media);
            }
            VideoPlayer.currentPlaylist = PlayList;
        }
        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            if (e.newState == 10) // Ready State 
            {
                VideoPlayer.Ctlcontrols.play();
            }

        }

    }
}
