namespace Riftbuddy
{
    public static class CommandHandler
    {
        public static int helpState = 0;

        public static void Process(string prediction)
        {
            if (prediction == "stop")
            {
                SynthesisHandler.Synthesise("Disabling. Say on in your next game to enable Rift Buddy again.");
                helpState = 0;
            }
            else
            if (helpState == 0)
            {
                if (prediction == "__unknown__")
                {
                    SynthesisHandler.Synthesise("Sorry, I didn't quite catch that. Please make your request again.");
                }
                else
                if (prediction == "on")
                {
                    APIHandler.GetCurrentGame();
                }
                else
                if (prediction == "go")
                {
                    SynthesisHandler.Synthesise("The go command is used to get advice after enabling Rift Buddy in game with the on command.");
                }
            }
            else
            if (helpState == 1)
            {
                if (prediction == "go" && helpState == 1)
                {
                    SynthesisHandler.Synthesise("Say yes for advice about your own champion, or no for advice about the enemy champions.");
                    helpState = 2;
                }
            }
            else
            if (helpState == 2)
            {
                if (prediction == "yes")
                {
                    APIHandler.GetChampAdviceSelf();
                }
                else
                if (prediction == "no")
                {
                    APIHandler.GetChampAdviceEnemy();
                }
            }

        }
    }
}
