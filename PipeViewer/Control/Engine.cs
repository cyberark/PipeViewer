using System;
using System.Linq;
using System.Runtime.InteropServices;
using NtApiDotNet;
namespace PipeViewer.Control
{
    static class Engine
    {
        public enum NamedPipeFunctionEndType
        {
            Server,
            Client
        }

        public static NtNamedPipeFileBase GetNamedPipeObject(string i_NamedPipe, NamedPipeFunctionEndType e_EndType)
        {
            NtNamedPipeFileBase namedPipeFileObject = null;

            i_NamedPipe = i_NamedPipe.Replace(@"\\.\pipe\", @"\Device\NamedPipe\");
            //FileShareMode ShareMode = FileShareMode.Read | FileShareMode.Write;
            //FileOpenOptions Options = FileOpenOptions.SynchronousIoNonAlert;
            //FileAccessRights Access = FileAccessRights.GenericRead | FileAccessRights.GenericWrite | FileAccessRights.Synchronize;

            FileShareMode ShareMode = FileShareMode.None;
            FileOpenOptions Options = FileOpenOptions.None;
            FileAccessRights Access = FileAccessRights.MaximumAllowed;
            

            if (e_EndType == NamedPipeFunctionEndType.Client)
            {
                namedPipeFileObject = GetNamedPipeClientObject(i_NamedPipe, ShareMode, Options, Access);
            } else {
                namedPipeFileObject = GetNamedPipeServerObject(i_NamedPipe, ShareMode, Options, Access);
            }

            return namedPipeFileObject;
        }

 
        // https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/blob/c02ed8ba04324e54a0a188ab9877ee6aa372dfac/NtObjectManager/Cmdlets/Object/GetNtNamedPipeFileCmdlet.cs
        public static NtNamedPipeFileBase GetNamedPipeClientObject(string i_NamedPipe, FileShareMode i_ShareMode, FileOpenOptions i_Options, FileAccessRights i_Access)
        {
            NtNamedPipeFileBase namedPipeFileObject = null;

            //i_NamedPipe = @"\Device\NamedPipe\Winsock2\CatalogChangeListener-5c0-0";
            //i_NamedPipe = @"\Device\NamedPipe\WiFiNetworkManagerTask";
            //i_NamedPipe = @"\Device\NamedPipe\initShutdown";

            using (ObjectAttributes obj_attributes = new ObjectAttributes(i_NamedPipe))
            {
                try
                {
                    // https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/issues/65
                    // https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/blob/c02ed8ba04324e54a0a188ab9877ee6aa372dfac/NtObjectManager/Cmdlets/Object/GetNtNamedPipeFileCmdlet.cs
                    // https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/blob/c02ed8ba04324e54a0a188ab9877ee6aa372dfac/NtObjectManager/Cmdlets/Object/GetNtFileCmdlet.cs
                    namedPipeFileObject = (NtNamedPipeFileBase)NtFile.Open(obj_attributes, i_Access, i_ShareMode, i_Options);
                }
                catch (Exception e)
                {
                    // In the future we can write to log
                }

            };

            return namedPipeFileObject;
        }

        public static NtNamedPipeFileBase GetNamedPipeServerObject(string i_NamedPipe, FileShareMode i_ShareMode, FileOpenOptions i_Options, FileAccessRights i_Access)
        {
            NtNamedPipeFileBase namedPipeFileObject = null;

            using (ObjectAttributes obj_attributes = new ObjectAttributes(i_NamedPipe))
            {
                try
                {
                    namedPipeFileObject = NtFile.CreateNamedPipe(obj_attributes, i_Access, i_ShareMode, i_Options, FileDisposition.Open, NamedPipeType.Bytestream,
                                            NamedPipeReadMode.ByteStream, NamedPipeCompletionMode.CompleteOperation, 0, 0, 0, NtWaitTimeout.FromMilliseconds(0));

                }
                catch (Exception)
                {
                    // In the future we can write to log
                }
            };

            return namedPipeFileObject;
        }


        /* 
         * These permissions are based on tests we did on files
         * https://learn.microsoft.com/en-us/windows/win32/secauthz/standard-access-rights
         * https://blog.cjwdev.co.uk/2011/06/28/permissions-not-included-in-net-accessrule-filesystemrights-enum/
         * https://www.installsetupconfig.com/win32programming/accesscontrollistacl2_1.html
         * https://superuser.com/questions/1752766/what-are-the-access-rules-of-standard-access-rights-and-object-specific-acces
         * 
            Read:                          00000000 00010010 00000000 10001001 : 00120089
            Read & Execute:                00000000 00010010 00000000 10101001 : 001200A9					       
            Write:                         00000000 00010000 00000001 00010110 : 00100116					       
            Read & Write                   00000000 00010010 00000001 10011111 : 0012019F					       
            Read & Write & Execute         00000000 00010010 00000001 10111111 : 001201BF					       
            Modify                         00000000 00010011 00000001 10111111 : 001301BF
            Full                           00000000 00011111 00000001 11111111 : 001F01FF

            Read ("Traverse folder / execute", "List folder / Read data", 
                  "Read Attribute", "Read Extended Attributes", "Read permissions")
  
            All advanced permissions separated: 
            List folder / Read data        00000000 00010000 00000000 00000001 : 00100001 -> R (accesschk.exe)
            Read Attribute                 00000000 00010000 00000000 10000000 : 00100080 -> no R (accesschk.exe)
            Read Extended Attributes       00000000 00010000 00000000 00001000 : 00100008 -> no R (accesschk.exe)
            Read permissions               00000000 00010010 00000000 00000000 : 00120000 -> no R (accesschk.exe)
            Traverse folder / execute      00000000 00010000 00000000 00100000 : 00100020 -> R (accesschk.exe)
            Create files / write data      00000000 00010000 00000000 00000010 : 00100002 -> W (accesschk.exe)
            Create folders / append data   00000000 00010000 00000000 00000100 : 00100004 -> W (accesschk.exe)
            Write attributes               00000000 00010000 00000001 00000000 : 00100100 -> no W (accesschk.exe)
            Write Extended eattributes     00000000 00010000 00000000 00010000 : 00100010 -> no W (accesschk.exe)
            Delete                         00000000 00010001 00000000 00000000 : 00110000 -> W (accesschk.exe)
            Change permissions             00000000 00010100 00000000 00000000 : 00140000 -> RW (accesschk.exe)
            Change ownership               00000000 00011000 00000000 00000000 : 00180000 -> RW (accesschk.exe)

                                                                                                 
            R ("List folder / Read data", "Traverse folder / execute")                -> 00000000 00010000 00000000 00100001 : 0x100021   (bits 0, 5, and 20) 
            W ("Create files / write data", "Create folders / append data", "Delete") -> 00000000 00010001 00000000 00000110 : 0x110006   (bits 1, 2, 16, and 20)
            RW ("Change permissions", "Change ownership")                             -> 00000000 00011100 00000000 00000000 : 0x1c0000   (bits 18, 19, and 20)

         * */
        enum PermissionsAccessMask
        {
            Read = 0x00120089,
            ReadAndExecute = 0x001200A9,
            Write = 0x00100116,
            ReadWrite = 0x0012019F,
            ReadWriteExecute = 0x001201BF,
            Modify = 0x001301BF, 
            Full = 0x001F01FF,
            ListFolderReadData = 0x00100001,
            ReadAttribute = 0x00100080,
            ReadExtendedAttributes = 0x00100008,
            ReadPermissions = 0x00120000,
            TraverseFolderExecute = 0x00100020,
            CreateFilesWriteData = 0x00100002,
            CreateFoldersAppendData = 0x00100004,
            WriteAttributes = 0x00100100,
            WriteExtendedAttributes = 0x00100010,
            Delete = 0x00110000,
            ChangePermissions = 0x00140000,
            ChangeOwnership = 0x00180000
        }


        public static string ConvertAccessMaskToSimplePermissions(uint i_AccessMask)
        {
            // Eviatar: Should we consider bit number 20 ? On files it always set to 1 but on named pipe it's not.
            // We currently left it 0.
            string permissions = "";


            if ((i_AccessMask & (uint)PermissionsAccessMask.Full) == (uint)PermissionsAccessMask.Full)
            {
                permissions = "Full";
            } else if ((i_AccessMask & (uint)PermissionsAccessMask.Modify) == (uint)PermissionsAccessMask.Modify)
            {
                permissions = "RWX";
            } else if ((i_AccessMask & (uint)PermissionsAccessMask.ReadWriteExecute) == (uint)PermissionsAccessMask.ReadWriteExecute)
            {
                permissions = "RWX";
            } else if ((i_AccessMask & (uint)PermissionsAccessMask.ReadWrite) == (uint)PermissionsAccessMask.ReadWrite)
            {
                permissions = "RW";
            } else if((i_AccessMask & (uint)PermissionsAccessMask.Write) == (uint)PermissionsAccessMask.Write)
            {
                permissions = "W";
            } else if((i_AccessMask & (uint)PermissionsAccessMask.ReadAndExecute) == (uint)PermissionsAccessMask.ReadAndExecute)
            {
                permissions = "RX";
            } else if ((i_AccessMask & (uint)PermissionsAccessMask.Read) == (uint)PermissionsAccessMask.Read)
            {
                permissions = "R";
            } else
            {
                permissions = "(special)";
            }

/*
             * 
             * 
             *     if (i_AccessMask == 1180059) // 00010010 00000001 10011011
                    {
                        int a = 2; 

                    }
             * *
             * When using the binary check, it gave RW for pipes that according to the standard security properties have R permissions.
             * We change it to check based on hardcoded values for the permissions.
*/


            //byte[] byteArray = BitConverter.GetBytes(i_AccessMask);
            //byte[] binaryArray = Convert.ToString(i_AccessMask, 2)
            //                    .PadLeft(32, '0')
            //                    .Select(c => byte.Parse(c.ToString()))
            //                    .Reverse()
            //                    .ToArray();

            
            //if ((binaryArray[0] == 1 || binaryArray[5] == 1))// && binaryArray[20] == 1)
            //{
            //    permissions += "R";
            //}

            //if ((binaryArray[1] == 1 || binaryArray[2] == 1 || binaryArray[16] == 1))// && binaryArray[20] == 1)
            //{
            //    permissions += "W";
            //}
            
            //if ((binaryArray[18] == 1 || binaryArray[19] == 1) )//&& binaryArray[20] == 1)
            //{
            //    permissions = "RW";
            //}

            //uint readPermissions = ((uint)PermissionsAccessMask.ListFolderReadData | (uint)PermissionsAccessMask.TraverseFolderExecute) & i_AccessMask;

            return permissions;
        }

        //public static NtFile CreateNamedPipe(string name, NtObject root, FileAccessRights desired_access,
        //    FileShareMode share_access, FileOpenOptions open_options, FileDisposition disposition, NamedPipeType pipe_type,
        //    NamedPipeReadMode read_mode, NamedPipeCompletionMode completion_mode, int maximum_instances, int input_quota,
        //    int output_quota, NtWaitTimeout default_timeout)
        //{
        //    using (ObjectAttributes obj_attributes = new ObjectAttributes(name, AttributeFlags.CaseInsensitive, root))
        //    {
        //        return NtFile.CreateNamedPipe(obj_attributes, desired_access, share_access, open_options, disposition, pipe_type,
        //            read_mode, completion_mode, maximum_instances, input_quota, output_quota, default_timeout);
        //    }
        //}

    }
}
