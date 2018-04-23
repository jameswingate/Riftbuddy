using System;
using System.IO;
using System.Diagnostics;

namespace Riftbuddy
{
    public static class ModelHandler
    {
        public static void ProcessSpeech()
        {
            ProcessStartInfo pyth = new ProcessStartInfo();
            pyth.FileName = @"pythonw";
            pyth.Arguments = @"C:\RiftbuddyTemp\label.py --graph=C:\RiftbuddyTemp\model.pb --labels=C:\RiftbuddyTemp\labels.txt --wav=C:\RiftbuddyTemp\input.wav";
            pyth.UseShellExecute = false;
            pyth.RedirectStandardOutput = true;

            using (Process process = Process.Start(pyth))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Debug.WriteLine(result);
                }
            }
        }
    }
}
