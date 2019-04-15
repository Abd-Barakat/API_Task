using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace AudioPlayer
{
    [Flags]
    enum CLSCTX
    {
        CLSCTX_INPROC_SERVER = 0x1,
        CLSCTX_INPROC_HANDLER = 0x2,
        CLSCTX_LOCAL_SERVER = 0x4,
        CLSCTX_REMOTE_SERVER = 0x10,
        CLSCTX_ALL = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER
    }
     enum STGM
    {
        STGM_READ = 0x00000000,
    }
    [Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
     interface IPropertyStore
    {
        [PreserveSig]
        int GetCount(out int cProps);

        [PreserveSig]
        int GetAt(int iProp, out PROPERTYKEY pkey);

        [PreserveSig]
        int GetValue(ref PROPERTYKEY key, ref PROPVARIANT pv);

        [PreserveSig]
        int SetValue(ref PROPERTYKEY key, ref PROPVARIANT propvar);

        [PreserveSig]
        int Commit();
    }
    [Flags]
     enum VARTYPE : short
    {
        VT_I4 = 3,
        VT_BOOL = 11,
        VT_UI4 = 19,
        VT_LPWSTR = 31,
        VT_BLOB = 65,
        VT_CLSID = 72,
    }
    [StructLayout(LayoutKind.Explicit)]
     struct PROPVARIANTunion
    {
        [FieldOffset(0)]
        public int lVal;
        [FieldOffset(0)]
        public ulong uhVal;
        [FieldOffset(0)]
        public short boolVal;
        [FieldOffset(0)]
        public IntPtr pwszVal;
        [FieldOffset(0)]
        public IntPtr puuid;
    }
    [StructLayout(LayoutKind.Sequential)]
     struct PROPVARIANT
    {
        public VARTYPE vt;
        public ushort wReserved1;
        public ushort wReserved2;
        public ushort wReserved3;
        public PROPVARIANTunion union;

        public object GetValue()
        {
            switch (vt)
            {
                case VARTYPE.VT_BOOL:
                    return union.boolVal != 0;

                case VARTYPE.VT_LPWSTR:
                    return Marshal.PtrToStringUni(union.pwszVal);

                case VARTYPE.VT_UI4:
                    return union.lVal;

                case VARTYPE.VT_CLSID:
                    return (Guid)Marshal.PtrToStructure(union.puuid, typeof(Guid));

                default:
                    return vt.ToString() + ":?";
            }
        }
    }

    [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IMMDevice
    {
        [PreserveSig]
        int Activate([MarshalAs(UnmanagedType.LPStruct)] Guid riid, CLSCTX dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
        [PreserveSig]
        int OpenPropertyStore(STGM stgmAccess, out IPropertyStore ppProperties);

        [PreserveSig]
        int GetId([MarshalAs(UnmanagedType.LPWStr)] out string ppstrId);

        [PreserveSig]
        int GetState(out DEVICE_STATE pdwState);
    }
}
