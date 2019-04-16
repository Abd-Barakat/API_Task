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
        private Process process;

        public AudioSession(IAudioSessionControl2 audio)
        {
            SessionControl2 = audio;
        }

        public Process Process
        {

            get
            {
                try
                {
                    int id;
                    SessionControl2.GetProcessId(out id);
                    if (id != 0 && process == null)
                    {
                        process = Process.GetProcessById(id);
                    }
                }
                catch (Exception)//windows 7 sometime return invalid id for process so no process found for this id
                {
                    // do nothing 

                }
                return process;
            }
        }


        public void SetApplicationMute(bool IsMute)
        {
            ISimpleAudioVolume simpleAudio = SessionControl2 as ISimpleAudioVolume;
            simpleAudio.SetMute(IsMute, Guid.Empty);
        }
    }
}
