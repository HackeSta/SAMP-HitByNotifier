using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SAMP_HitByNotifier
{
    class Game
    {
        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UInt32 nSize, ref UInt32 lpNumberOfBytesRead);

        private static Process process;
        private static Process[] _process;
        private static IntPtr processHandle;

        public static bool Init()   //Tries to attatch to the game
        {
            try
            {
                _process = Process.GetProcessesByName("gta_sa");
                if (_process.Length == 0)
                {
                    return false;
                }
                else
                {
                    process = _process[0];
                    processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool ReadMemory<T>(IntPtr address, out T obj)         //Source: shadowAPI2
        {
            obj = default(T);
            var size = 1;
            if (typeof(T) != typeof(byte))
                size = Marshal.SizeOf(typeof(T));
            var buffer = new byte[size];
            uint readed = 0;

            if (ReadProcessMemory(processHandle, address, buffer, (uint)size, ref readed))
            {
                if (size == readed)
                {
                    if (obj.GetType() == typeof(Int16))
                        obj = (T)Convert.ChangeType(BitConverter.ToInt16(buffer, 0), typeof(T));
                    else if (obj.GetType() == typeof(Int32))
                        obj = (T)Convert.ChangeType(BitConverter.ToInt32(buffer, 0), typeof(T));
                    else if (obj.GetType() == typeof(float))
                        obj = (T)Convert.ChangeType(BitConverter.ToSingle(buffer, 0), typeof(T));
                    else if (obj.GetType() == typeof(IntPtr))
                        obj = (T)Convert.ChangeType(new IntPtr(BitConverter.ToInt32(buffer, 0)), typeof(T));
                    else if (obj.GetType() == typeof(byte))
                        obj = (T)Convert.ChangeType(buffer[0], typeof(T));

                    return true;
                }
            }

            return false;
        }
        private static IntPtr GetPlayerPointer()        //Source: shadowAPI2
        {
            IntPtr pointer = IntPtr.Zero;
            IntPtr CPed = (IntPtr)0xB6F5F0;
            ReadMemory<IntPtr>(CPed, out pointer);
            return pointer;
        }

        public static int getWeaponID()   //Returns the weapon ID of the last weapon you were hit by
        {
            if (Init())
            {
                int id = 0;
                ReadMemory<int>(GetPlayerPointer() + 0x760, out id);
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
