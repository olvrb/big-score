using System;
using System.Linq;

namespace big_score {
    class Program {
        private string[] highScores = {"100 sara", "300 oliver", "50 oliver"};

        private static void Main(string[] args) => new Program().Init();

        int Init() {
            // HighscoreHandler handler = new HighscoreHandler(this.highScores);

            // Console.WriteLine(handler.BestScoreOf("sara"));
            // Console.WriteLine(handler.GetAverage());
            // Console.WriteLine(handler.AddScore(100, "eric").Last());
            // Console.WriteLine(handler.GetAverage());

            Game game = new Game() {
                Players = new[] {
                    new Player {
                        Name   = "oliver",
                        Scores = new[] {300, 50}
                    },
                    new Player {
                        Name   = "sara",
                        Scores = new[] {100}
                    }
                }
            };

            Console.WriteLine(game.Highscore);
            Console.WriteLine(game.AverageScore);

            Console.WriteLine(game.GetHighscoreOf("oliver"));

            game.GetPlayerByName("oliver").AddScore(500);
            Console.WriteLine(game.GetHighscoreOf("oliver"));

            return 0;
        }
    }
}