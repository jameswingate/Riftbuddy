using System.Speech.Synthesis;

namespace Riftbuddy
{
    public static class SynthesisHandler
    {
        private static SpeechSynthesizer synthesizer;

        public static void Synthesise(string sentence)
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();

            synthesizer.Speak(sentence);
            synthesizer.Dispose();
        }
    }
}
