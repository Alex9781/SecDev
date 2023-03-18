using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace LR1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsCodeHashValid())
            {
                MessageBox.Show("Code is valid");
            }
            else
            {
                MessageBox.Show("Code is invalid");
                return;
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                MessageBox.Show("Debugger is attached");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AuthForm authForm = new();
            Application.Run(authForm);
        }

        static bool IsCodeHashValid()
        {
            byte[] fileBytes = File.ReadAllBytes(Application.ExecutablePath);
            MemoryStream peStream = new(fileBytes);
            using var peReader = new PEReader(peStream);

            if (peReader.PEHeaders.PEHeader != null)
            {
                PEHeader header = peReader.PEHeaders.PEHeader;
                int size = header.SizeOfCode;
                byte[] data = new byte[size];
                fileBytes.ToList().CopyTo(0x400, data, 0, size);              
                string currentHash = Convert.ToHexString(SHA256.HashData(data));
                Debug.WriteLine(currentHash);
                const string referenceHash = "4F89CC86F8C9DF008B9CEEB91D2D5FC05E2415B75632CEA360571EEE40E24E33";
                return currentHash == referenceHash;
            }
            return false;
        }     
    }
}