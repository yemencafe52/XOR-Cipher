using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XorEnoUI1
{
    internal class Xor
    {
        [DllImport("XorEnoLib1", EntryPoint = "XorFun", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr XorFun(IntPtr data,int dataLen,IntPtr password,int passwordLen);

        [DllImport("XorEnoLib1", EntryPoint = "ClearMEM", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ClearMemory(IntPtr ptr);

        internal static byte[] XorM(byte[] data,byte[] password)
        {
            byte[] res = null;

            unsafe
            {
                fixed(byte*p = &data[0])
                {
                    fixed(byte*p2 = &password[0])
                    {
                        IntPtr ptr = XorFun(new IntPtr(p), data.Length, new IntPtr(p2), password.Length);
                        res = PtrToByteArray(ptr,data.Length);
                        ClearMemory(ptr);
                        Marshal.Release(ptr);
                    }
                }
            }

            return res;
        }

        private static byte[] PtrToByteArray(IntPtr ptr,int dataLen)
        {
            byte[] res = new byte[dataLen];

            unsafe
            {
                byte* p;
                p = (byte*)ptr.ToPointer();
                {
                    for(int i=0;i<dataLen;i++)
                    {
                        res[i] = *(byte*)(p + i);
                    }
                }
            }
            return res;
        }

    }
}
