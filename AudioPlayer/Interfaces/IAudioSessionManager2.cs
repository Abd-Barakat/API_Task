using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace AudioPlayer
{
    [Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IAudioSessionManager2
    {
        [PreserveSig]
        int GetAudioSessionControl([MarshalAs(UnmanagedType.LPStruct)] Guid AudioSessionGuid, int StreamFlags, out IAudioSessionControl2 SessionControl);

        [PreserveSig]
        int GetSimpleAudioVolume([MarshalAs(UnmanagedType.LPStruct)] Guid AudioSessionGuid, int StreamFlags, ISimpleAudioVolume AudioVolume);

        [PreserveSig]
        int GetSessionEnumerator(out IAudioSessionEnumerator SessionEnum);

        [PreserveSig]
        int RegisterSessionNotification(IAudioSessionNotification SessionNotification);

        [PreserveSig]
        int UnregisterSessionNotification(IAudioSessionNotification SessionNotification);

        int RegisterDuckNotificationNotImpl();
        int UnregisterDuckNotificationNotImpl();
    }
    [Guid("641DD20B-4D41-49CC-ABA3-174B9477BB08")]
     interface IAudioSessionNotification
    {
        void OnSessionCreated(IAudioSessionControl2 NewSession);
    }
   
}
