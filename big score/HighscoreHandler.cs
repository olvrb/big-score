using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace big_score {
    public class HighscoreHandler {
        private string[] highScores = {"100 sara", "300 oliver", "50 oliver"};

        private Dictionary<string, int> scoreDict {
            get {
                Dictionary<string, int> dict = new Dictionary<string, int>() { };
                foreach (string s in this.highScores) {
                    string[] props = s.Split(" ");
                    string   name  = props[1];
                    int      score;
                    try {
                        score = int.Parse(props[0]);
                    }
                    catch (Exception e) {
                        throw new Exception("Unexpected array format.");
                    }

                    dict.Add(name, score);
                }

                return dict;
            }
        }

        public int[] GetAllScores() {
            List<int> scores = new List<int>();
            foreach (string score in this.highScores) {
                string[] props = score.Split(" ");
                // score
                int s = 0;
                try {
                    s = int.Parse(props[0]);
                }
                catch (Exception e) {
                    throw new Exception("Unexpected array format.");
                }

                scores.Add(s);
            }

            return scores.ToArray();
        }

        public int[] GetScoresOf(string name) {
            List<int> scores = new List<int>();
            foreach (string score in this.highScores) {
                string[] props = score.Split(" ");
                // name
                string n = props[1];
                // score
                int s = 0;
                try {
                    s = int.Parse(props[0]);
                }
                catch (Exception e) {
                    throw new Exception("Unexpected array format.");
                }

                if (n == name) {
                    scores.Add(s);
                }
            }

            return scores.ToArray();
        }

        public HighscoreHandler(string[] highScores) {
            this.highScores = highScores;
        }

        public void PrintHighScores() {
            foreach (string score in highScores) {
                Console.WriteLine(score);
            }
        }

        public string[] GetNames() {
            List<string> newList = new List<string>();
            foreach (string score in this.highScores) {
                try {
                    newList.Add(score.Split(" ")[1]);
                }
                catch (Exception e) {
                    throw new Exception("Unexpected array format.");
                }
            }

            return newList.ToArray();
        }

        public int BestScoreOf(string name) {
            int currentHigh = 0;
            foreach (string score in this.highScores) {
                string[] props = score.Split(" ");
                // name
                string n = props[1];
                // score
                int s = 0;
                try {
                    s = int.Parse(props[0]);
                }
                catch (Exception e) {
                    throw new Exception("Unexpected array format.");
                }

                if (s > currentHigh && n == name) {
                    currentHigh = s;
                }
            }

            return currentHigh;
        }

        public double GetAverageOf(string name) {
            int[] scores = GetScoresOf(name);
            return scores.Average();
        }

        public double GetAverage() {
            return GetAllScores().Average();
        }


        public string[] AddScore(int score, string name) {
            List<string> tempList = this.highScores.ToList();
            tempList.Add($"{score} {name}");
            this.highScores = tempList.ToArray();
            return this.highScores;
        }
    }
}