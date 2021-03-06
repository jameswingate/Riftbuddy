﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Riftbuddy
{
    public static class APIHandler
    {
        // Declare global object variables.
        public static string Username;
        public static string Server;
        private static string Key = "RGAPI-e1153305-50bf-4643-9857-bcfff9eec28c";
        public static Summoner summoner;
        public static JavaScriptSerializer js;
        public static LiveGame liveGame;
        public static ChampDataSelf champDataSelf;
        public static ChampDataEnemy champDataEnemy;
        public static Random rnd = new Random();
        public static List<string> champDataEnemyTips = new List<string>();

        // Get URL for summoner data.
        private static string GetSummonerURL()
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + Username + "?api_key=" + Key);
        }
        
        // Get URL for live game data.
        private static string GetCurrentGameURL()
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/spectator/v3/active-games/by-summoner/" + summoner.id + "?api_key=" + Key);
        }

        // Get URL for static champion data.
        private static string GetChampionDataURL(long champId)
        {
            return ("https://" + Server.ToLower() + ".api.riotgames.com/lol/static-data/v3/champions/" + champId + "?locale=en_US&champData=allytips&tags=enemytips&api_key=" + Key);
        }

        // Pull live stats of the user.
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

        // Pull live game stats of the user.
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

                    long champId = -1;
                    foreach (LiveGame.CurrentGameParticipant participant in liveGame.participants)
                    {
                        if (participant.summonerId == summoner.id)
                        {
                            champId = participant.championId;
                        }
                    }

                    GetChampionData(champId);
                }
            }
        }

        // Pull static champion data.
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
            }

            long teamId = -1;
            foreach (LiveGame.CurrentGameParticipant participant in liveGame.participants)
            {
                if (participant.summonerId == summoner.id)
                {
                    teamId = participant.teamID;
                }
            }

            foreach (LiveGame.CurrentGameParticipant participant in liveGame.participants)
            {
                if (participant.teamID != teamId)
                {
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(GetChampionDataURL(participant.championId));

                        string responseBody = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(responseBody);

                        string statusCode = response.StatusCode.ToString();

                        js = new JavaScriptSerializer();
                        champDataEnemy = js.Deserialize<ChampDataEnemy>(responseBody);
                    }

                    foreach(string tip in champDataEnemy.enemytips)
                    {
                        champDataEnemyTips.Add(tip);
                    }
                }
            }

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetChampionDataURL(champId));

                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(responseBody);

                string statusCode = response.StatusCode.ToString();

                js = new JavaScriptSerializer();
                champDataSelf = js.Deserialize<ChampDataSelf>(responseBody);

                SynthesisHandler.Synthesise("You are playing " + champDataSelf.name + ", " + champDataSelf.title);
                SynthesisHandler.Synthesise("Say go whenever you would like some advice, or off to disable Rift Buddy until you say on again.");
                CommandHandler.helpState = 1;
            }
        }
        
        // Synthesise advice for the user's champion.
        public static void GetChampAdviceSelf()
        {
            SynthesisHandler.Synthesise(champDataSelf.allytips[rnd.Next(0, champDataSelf.allytips.Count + 1)]);
        }

        // Synthesise advice for the enemy champions.
        public static void GetChampAdviceEnemy()
        {
            SynthesisHandler.Synthesise(champDataEnemyTips[rnd.Next(0, champDataEnemyTips.Count + 1)]);
        }
    }
}
