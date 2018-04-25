using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Riftbuddy
{
    public static class APIHandler
    {
        public static string Username;
        public static string Server;
        private static string Key = "RGAPI-e1153305-50bf-4643-9857-bcfff9eec28c";
        public static Summoner summoner;
        public static JavaScriptSerializer js;
        public static LiveGame liveGame;
        public static ChampDataSelf champDataSelf;

        private static string GetSummonerURL()
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + Username + "?api_key=" + Key);
        }

        private static string GetCurrentGameURL()
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/spectator/v3/active-games/by-summoner/" + summoner.id + "?api_key=" + Key);
        }

        private static string GetChampionDataURL(long champId)
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/static-data/v3/champions/" + champId + "?locale=en_US&champData=allytips&tags=enemytips&api_key=" + Key);
        }

        public static async void GetSummoner()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetSummonerURL());

                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(responseBody);

                string statusCode = response.StatusCode.ToString();

                if (statusCode == "NotFound")
                {
                    SynthesisHandler.Synthesise("That Summoner does not exist, try again.");
                }
                else
                {
                    js = new JavaScriptSerializer();
                    summoner = js.Deserialize<Summoner>(responseBody);

                    SynthesisHandler.Synthesise("Welcome " + summoner.name + "to Rift Buddy. Say on while in game to get some help.");
                }
            }
        }

        public static async void GetCurrentGame()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetCurrentGameURL());

                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(responseBody);

                string statusCode = response.StatusCode.ToString();

                if (statusCode == "NotFound")
                {
                    SynthesisHandler.Synthesise("You are not currently in a game. Say on while in game to get some help.");
                }
                else
                {
                    SynthesisHandler.Synthesise("You are in a live game! One second please, pulling data...");

                    js = new JavaScriptSerializer();
                    liveGame = js.Deserialize<LiveGame>(responseBody);
                }
            }

            long champId = -1;
            foreach(LiveGame.CurrentGameParticipant participant in liveGame.participants)
            {
                if (participant.summonerId == summoner.id)
                {
                    champId = participant.championId;
                }
            }

            GetChampionData(champId);
        }

        public static async void GetChampionData(long champId)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetChampionDataURL(champId));

                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(responseBody);

                string statusCode = response.StatusCode.ToString();

                js = new JavaScriptSerializer();
                champDataSelf = js.Deserialize<ChampDataSelf>(responseBody);

                SynthesisHandler.Synthesise("You are playing " + champDataSelf.name + ", " + champDataSelf.title);
                SynthesisHandler.Synthesise("")
            }
        }
    }
}
