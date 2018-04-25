namespace Riftbuddy
{
    public static class CommandHandler
    {
        public static int helpState = 0;

        public static void Process(string prediction)
        {
            if (prediction == "__unknown__")
            {
                SynthesisHandler.Synthesise("Sorry, I didn't quite catch that. Please make your request again.");
            }
            else
            if (prediction == "on" && helpState == 0)
            {
                APIHandler.GetCurrentGame();
            }
            else
            
        }
    }
}
