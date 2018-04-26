using System.Speech.Synthesis;

namespace Riftbuddy
{
    public static class SynthesisHandler
    {
        // Declare global static variable.
        private static SpeechSynthesizer synthesizer;

        // Synthesise speech using System.Speech.Synthesis;
        public static void Synthesise(string sentence)
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();

            synthesizer.Speak(sentence);
            synthesizer.Dispose();
        }
    }
}
