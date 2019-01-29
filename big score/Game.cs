using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace big_score {
    public class Game {
        public Player[] Players;

        public int[] AllScores => this.Players.SelectMany(x => x.Scores).ToArray();

        public string[] AllNames => this.Players.Select(x => x.Name).ToArray();

        public int Highscore => this.AllScores.Max();

        public double AverageScore => this.AllScores.Average();

        public int GetHighscoreOf(string name) {
            return this.GetPlayerByName(name).Highscore;
        }

        public Player GetPlayerByName(string name) {
            return this.Players.Single(x => x.Name == name);
        }

        public static Player[] ParseScoreArray(string[] scores) {
            List<Player> players = new List<Player>();
            foreach (string score in scores) {
                string[] properties = score.Split(" ");
                string   name       = properties[1];
                int      s          = int.Parse(properties[0]);

                // If player already exists, add the score to it.
                var oldPlayer = players.SingleOrDefault(x => x.Name == name);
                if (oldPlayer != null) {
                    oldPlayer.AddScore(s);
                }
                else {
                    players.Add(new Player {
                        Name   = properties[1],
                        Scores = new[] {int.Parse(properties[0])}
                    });
                }
            }

            return players.ToArray();
        }
    }
}