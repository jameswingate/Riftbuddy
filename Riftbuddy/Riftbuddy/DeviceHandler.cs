using System;
using System.IO;
using NAudio.Wave;

namespace Riftbuddy
{
    public static class DeviceHandler
    {
        private static WaveIn waveIn = null;
        private static WaveFileWriter waveWriter = null;
        private static int deviceTotal;

        public static string[] GetDevices()
        {
            deviceTotal = WaveIn.DeviceCount;
            string[] devices = new string[deviceTotal];

            for (int deviceCount = 0; deviceCount < deviceTotal; deviceCount++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(deviceCount);
                devices[deviceCount] = deviceCount + ": " + deviceInfo.ProductName + " - " + deviceInfo.Channels + " Channels";
            }

            return devices;
        }

        public static void StartRecording()
        {
            waveIn = new WaveIn();

            deviceTotal = WaveIn.DeviceCount;
            for (int c = 0; c < deviceTotal; ++c)
            {
                WaveInCapabilities info = WaveIn.GetCapabilities(c);
            }

            waveIn.WaveFormat = new WaveFormat(16000, 1);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            FileInfo waveDirectory = new FileInfo(@"C:\\RiftbuddyTemp\\input.wav");
            waveDirectory.Directory.Create();

            waveWriter = new WaveFileWriter(@"C:\\RiftbuddyTemp\\input.wav", waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        private static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter != null)
            {
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();

                int seconds = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);
                System.Diagnostics.Debug.WriteLine("Recording: {0}", seconds);

                if (seconds > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Stopped recording");
                    waveIn.StopRecording();
                }
            }
            else
            {
                return;
            }
        }

        private static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;
            System.Diagnostics.Debug.WriteLine("Cleaned recording");

            waveWriter.Dispose();
            waveWriter = null;
            System.Diagnostics.Debug.WriteLine("Cleaned writer");

        }
    }
}
