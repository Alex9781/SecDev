using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LR1DebugProtector
{
    internal class Program
    {
        static void Main()
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool DebugActiveProcess(uint dwProcessId);

            [DllImport("kernel32.dll", EntryPoint = "WaitForDebugEvent")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool WaitForDebugEvent(ref DEBUG_EVENT lpDebugEvent, uint dwMilliseconds);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, ContinueStatus dwContinueStatus);

            Process process = new()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "./LR1.exe"
                }
            };

            if (process.Start())
            {
                Console.WriteLine(process.Id.ToString());
                DebugActiveProcess((uint)process.Id);

                WaitForExit(process);

                while (true)
                {
                    DEBUG_EVENT de;
                    WaitForDebugEvent(ref de, 0xFFFFFFFF);
                    ContinueDebugEvent(de.dwProcessId, de.dwThreadId, ContinueStatus.DBG_CONTINUE);
                }
            }
        }

        private enum ContinueStatus : uint
        {
            DBG_CONTINUE = 0x00010002,
            DBG_EXCEPTION_NOT_HANDLED = 0x80010001,
            DBG_REPLY_LATER = 0x40010001
        }

        private struct DEBUG_EVENT
        {
            public uint dwDebugEventCode;
            public int dwProcessId;
            public int dwThreadId;
        }

        private static async void WaitForExit(Process process)
        {
            while (true)
            {
                await Task.Delay(1000);
                if (process.HasExited) Environment.Exit(0);
            }
        }
    }
}