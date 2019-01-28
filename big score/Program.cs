using System;
using System.Linq;

namespace big_score {
    class Program {
        private string[] highScores = {"100 sara", "300 oliver", "50 oliver"};

        static void Main(string[] args) => new Program().Init();

        int Init() {
            HighscoreHandler handler = new HighscoreHandler(this.highScores);

            Console.WriteLine(handler.BestScoreOf("sara"));
            Console.WriteLine(handler.GetAverage());
            Console.WriteLine(handler.AddScore(100, "eric").Last());
            Console.WriteLine(handler.GetAverage());
            return 0;
        }
        
    }
}