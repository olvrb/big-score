using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace big_score {
    public class Game {
        public Player[] Players;

        public int[] AllScores => this.Players.SelectMany(x => x.Scores).ToArray();

        public int Highscore => this.AllScores.Max();

        public double AverageScore => this.AllScores.Average();

        public int GetHighscoreOf(string name) {
            return this.GetPlayerByName(name).Highscore;
        }

        public Player GetPlayerByName(string name) {
            return this.Players.Single(x => x.Name == name);
        }
    }
}