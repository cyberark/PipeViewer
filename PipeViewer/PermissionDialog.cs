using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace NamePipeViewer
{

    // TODO: not used yet, it might help to create the properties windows to view the security of the pipes
    // and other details in a nice way.
    // https://stackoverflow.com/questions/28035464/how-does-one-invoke-the-windows-permissions-dialog-programmatically
    public static class PermissionDialog
    {
        public static bool Show(IntPtr hwndParent, string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            SafePidlHandle folderPidl;
            int hr;
            var a = Path.GetDirectoryName(path);
            hr = SHILCreateFromPath(Path.GetDirectoryName(path), out folderPidl, IntPtr.Zero);
            if (hr != 0)
                throw new Win32Exception(hr);

            SafePidlHandle filePidl;
            hr = SHILCreateFromPath(path, out filePidl, IntPtr.Zero);
            if (hr != 0)
                throw new Win32Exception(hr);

            IntPtr file = ILFindLastID(filePidl);

            System.Runtime.InteropServices.ComTypes.IDataObject ido;
            hr = SHCreateDataObject(folderPidl, 1, new IntPtr[] { file }, null, typeof(System.Runtime.InteropServices.ComTypes.IDataObject).GUID, out ido);
            if (hr != 0)
                throw new Win32Exception(hr);

            // if you get a 'no such interface' error here, make sure the running thread is STA
            IShellExtInit sei = (IShellExtInit)new SecPropSheetExt();
            sei.Initialize(IntPtr.Zero, ido, IntPtr.Zero);

            IShellPropSheetExt spse = (IShellPropSheetExt)sei;
            IntPtr securityPage = IntPtr.Zero;
            spse.AddPages((p, lp) =>
            {
                securityPage = p;
                return true;
            }, IntPtr.Zero);

            PROPSHEETHEADER psh = new PROPSHEETHEADER();
            psh.dwSize = Marshal.SizeOf(psh);
            psh.hwndParent = hwndParent;
            psh.nPages = 1;
            psh.phpage = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(psh.phpage, securityPage);

            // TODO: adjust title & icon here, also check out the available flags
            psh.pszCaption = "Permissions for '" + path + "'";

            IntPtr res;
            try
            {
                res = PropertySheet(ref psh);
            }
            finally
            {
                Marshal.FreeHGlobal(psh.phpage);
            }
            return res == IntPtr.Zero;
        }

        private class SafePidlHandle : SafeHandle
        {
            public SafePidlHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                if (IsInvalid)
                    return false;

                Marshal.FreeCoTaskMem(handle);
                return true;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PROPSHEETHEADER
        {
            public int dwSize;
            public int dwFlags;
            public IntPtr hwndParent;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public string pszCaption;
            public int nPages;
            public IntPtr nStartPage;
            public IntPtr phpage;
            public IntPtr pfnCallback;
        }

        [DllImport("shell32.dll")]
        private static extern IntPtr ILFindLastID(SafePidlHandle pidl);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHILCreateFromPath(string pszPath, out SafePidlHandle ppidl, IntPtr rgflnOut);

        [DllImport("shell32.dll")]
        private static extern int SHCreateDataObject(SafePidlHandle pidlFolder, int cidl, IntPtr[] apidl, System.Runtime.InteropServices.ComTypes.IDataObject pdtInner, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out System.Runtime.InteropServices.ComTypes.IDataObject ppv);

        [DllImport("comctl32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr PropertySheet(ref PROPSHEETHEADER lppsph);

        private delegate bool AddPropSheetPage(IntPtr page, IntPtr lParam);

        [ComImport]
        [Guid("1f2e5c40-9550-11ce-99d2-00aa006e086c")] // this GUID points to the property sheet handler for permissions
        private class SecPropSheetExt
        {
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214E8-0000-0000-C000-000000000046")]
        private interface IShellExtInit
        {
            void Initialize(IntPtr pidlFolder, System.Runtime.InteropServices.ComTypes.IDataObject pdtobj, IntPtr hkeyProgID);
        }

        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214E9-0000-0000-C000-000000000046")]
        private interface IShellPropSheetExt
        {
            void AddPages([MarshalAs(UnmanagedType.FunctionPtr)] AddPropSheetPage pfnAddPage, IntPtr lParam);
            void ReplacePage(); // not fully defined, we don't use it 
        }
    }
}
