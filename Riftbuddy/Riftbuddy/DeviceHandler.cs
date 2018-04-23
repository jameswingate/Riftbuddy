using NAudio.Wave;

namespace Riftbuddy
{
    public static class DeviceHandler
    {
        public static IWaveIn waveIn;

        public static string[] GetDevices()
        {
            int deviceTotal = WaveIn.DeviceCount;
            string[] devices = new string[deviceTotal];

            for (int deviceCount = 0; deviceCount < deviceTotal; deviceCount++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(deviceCount);
                devices[deviceCount] = deviceCount + ": " + deviceInfo.ProductName;
            }

            return devices;
        }

        public static void StartRecording()
        {
            waveIn = new WaveIn(WaveCallbackInfo.FunctionCallback());

        }

    }
}
