using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace AudioPlayer
{
    [Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d"),
  InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IAudioSessionControl2
    {
        [PreserveSig]
        int GetState(out AudioSessionState state);
        [PreserveSig]
        int GetDisplayName(out IntPtr name);
        [PreserveSig]
        int SetDisplayName(string value, Guid EventContext);
        [PreserveSig]
        int GetIconPath(out IntPtr Path);
        [PreserveSig]
        int SetIconPath(string Value, Guid EventContext);
        [PreserveSig]
        int GetGroupingParam(out Guid GroupingParam);
        [PreserveSig]
        int SetGroupingParam(Guid Override, Guid Eventcontext);
        [PreserveSig]
        int RegisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
        [PreserveSig]
        int UnregisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
        [PreserveSig]
        int GetSessionIdentifier(out IntPtr retVal);
        [PreserveSig]
        int GetSessionInstanceIdentifier(out IntPtr retVal);
        [PreserveSig]
        int GetProcessId(out Int32 retvVal);
        [PreserveSig]
        int IsSystemSoundsSession();
        [PreserveSig]
        int SetDuckingPreference(bool optOut);

    }
    enum AudioSessionState
    {
        AudioSessionStateInactive,
        AudioSessionStateActive,
        AudioSessionStateExpired
    }
    internal interface IAudioSessionEvents
    {
        void OnDisplayNameChanged([MarshalAs(UnmanagedType.LPWStr)] string NewDisplayName, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);
        void OnIconPathChanged([MarshalAs(UnmanagedType.LPWStr)] string NewIconPath, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);
        void OnSimpleVolumeChanged(float NewVolume, bool NewMute, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);
        void OnChannelVolumeChanged(int ChannelCount, IntPtr NewChannelVolumeArray, int ChangedChannel, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);
        void OnGroupingParamChanged([MarshalAs(UnmanagedType.LPStruct)] Guid NewGroupingParam, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);
        void OnStateChanged(AudioSessionState NewState);
        void OnSessionDisconnected(AudioSessionDisconnectReason DisconnectReason);
    }
    enum AudioSessionDisconnectReason
    {
        DisconnectReasonDeviceRemoval = 0,
        DisconnectReasonServerShutdown = (DisconnectReasonDeviceRemoval + 1),
        DisconnectReasonFormatChanged = (DisconnectReasonServerShutdown + 1),
        DisconnectReasonSessionLogoff = (DisconnectReasonFormatChanged + 1),
        DisconnectReasonSessionDisconnected = (DisconnectReasonSessionLogoff + 1),
        DisconnectReasonExclusiveModeOverride = (DisconnectReasonSessionDisconnected + 1)
    }


}
