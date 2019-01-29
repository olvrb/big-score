using System;
using System.Linq;

namespace big_score {
    class Program {
        private readonly string[] _highScores = {"100 sara", "300 oliver", "50 oliver"};

        private static void Main(string[] args) => new Program().Init();

        int Init() {
            // Game game = new Game {
            //     Players = new[] {
            //         new Player {
            //             Name   = "oliver",
            //             Scores = new[] {300, 50}
            //         },
            //         new Player {
            //             Name   = "sara",
            //             Scores = new[] {100}
            //         }
            //     }
            // };

            Game game = new Game {Players = Game.ParseScoreArray(_highScores)};

            Console.WriteLine(game.Highscore);
            Console.WriteLine(game.AverageScore);

            Console.WriteLine(game.GetHighscoreOf("oliver"));

            game.GetPlayerByName("oliver").AddScore(500);
            Console.WriteLine(game.GetHighscoreOf("oliver"));


            Console.ReadLine();
            return 0;
        }
    }
}