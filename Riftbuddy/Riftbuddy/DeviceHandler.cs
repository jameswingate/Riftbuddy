using System;
using System.IO;
using NAudio.Wave;

namespace Riftbuddy
{
    public static class DeviceHandler
    {
        public static IWaveIn waveIn;
        public static WaveFileWriter waveWriter;
        public static int waveLength;
        public static int deviceTotal;

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
            waveIn = new WaveIn(WaveCallbackInfo.FunctionCallback());

            deviceTotal = WaveIn.DeviceCount;
            for (int c = 0; c < deviceTotal; ++c)
            {
                WaveInCapabilities info = WaveIn.GetCapabilities(c);
            }

            waveIn.WaveFormat = new WaveFormat(16000, 1);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            FileInfo waveDirectory = new FileInfo(@"C:\\RiftbuddyTemp\\temp.wav");
            waveDirectory.Directory.Create();

            waveWriter = new WaveFileWriter(@"C:\\RiftbuddyTemp\\temp.wav", waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        public static void StopRecording()
        {
            waveIn.StopRecording();
        }

        public static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter != null)
            {
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();

                int seconds = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);

                if (seconds > 0)
                {
                    waveIn.StopRecording();
                }
            }



        }

        public static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }

            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }

        }
    }
}
