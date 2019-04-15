using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace AudioPlayer
{
    static class AudioServices
    {
       public static  List<AudioSession> GetAllSessions()
        {
            List<AudioSession> sessions = new List<AudioSession>();
            IAudioSessionManager2 manager2 = GetManager();
            IAudioSessionEnumerator audioSession;
            manager2.GetSessionEnumerator(out audioSession);
            int NumberOfSession;
            audioSession.GetCount(out NumberOfSession);
            for (int count =0; count < NumberOfSession;count++)
            {
                IAudioSessionControl2 control;
                audioSession.GetSession(count, out control);
                sessions.Add(new AudioSession(control));
            }
            Marshal.ReleaseComObject(manager2);
            Marshal.ReleaseComObject(audioSession);
            return sessions;
        }

     
        public static IAudioSessionManager2 GetManager()
        {

            IMMDevice speakers = GetSpeakers();

            object AudioSessionManager;
            speakers.Activate(typeof(IAudioSessionManager2).GUID, CLSCTX.CLSCTX_ALL, IntPtr.Zero, out AudioSessionManager);

            return AudioSessionManager as IAudioSessionManager2;
        }



        public static IMMDevice GetSpeakers()
        {
            IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
            IMMDevice speakers;
            deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);
            return speakers;
        }

    }
    [ComImport]
    [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
    class MMDeviceEnumerator
    {
    }


}
