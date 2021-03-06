﻿using System;
using System.IO;
using NAudio.Wave;

namespace Riftbuddy
{
    public static class DeviceHandler
    {
        // Declare global static variables.
        private static WaveIn waveIn = null;
        private static WaveFileWriter waveWriter = null;
        private static int deviceTotal;

        // Obtain all current recording devices.
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

        // Start recording.
        public static void StartRecording()
        {
            waveIn = new WaveIn();

            deviceTotal = WaveIn.DeviceCount;
            for (int c = 0; c < deviceTotal; ++c)
            {
                WaveInCapabilities info = WaveIn.GetCapabilities(c);
            }

            waveIn.WaveFormat = new WaveFormat(22050, 1);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            FileInfo waveDirectory = new FileInfo(@"C:\RiftbuddyTemp\input.wav");
            waveDirectory.Directory.Create();

            waveWriter = new WaveFileWriter(@"C:\RiftbuddyTemp\input.wav", waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        // Microphone event handler.
        private static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
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
            else
            {
                return;
            }
        }

        // Microphone event handler.
        private static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;

            waveWriter.Dispose();
            waveWriter = null;

            ModelHandler.ProcessSpeech();
        }
    }
}
