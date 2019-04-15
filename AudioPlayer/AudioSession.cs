using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
namespace AudioPlayer
{
    class AudioSession
    {
        private IAudioSessionControl2 SessionControl2;
        public AudioSession(IAudioSessionControl2 audio)
        {
            SessionControl2 = audio;
        }
        public Process process
        {

            get
            {
                try
                {
                    int id;
                    SessionControl2.GetProcessId(out id);
                    if (id != 0)
                    {
                        return Process.GetProcessById(id);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }


        public void SetApplicationMute(bool IsMute)
        {
            ISimpleAudioVolume simpleAudio = SessionControl2 as ISimpleAudioVolume;
            simpleAudio.SetMute(IsMute, Guid.Empty);
        }
    }
}
