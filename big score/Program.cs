using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace big_score {
    class Program {
        private readonly string[] _highScores = {"100 sara", "300 oliver", "50 oliver"};
        private readonly string[] _options    = {"0. Visa high scores.", "1. Visa unika namn.", "2. Visa en användares bästa poäng.", "3. Visa medelpoäng."};

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


            switch (this.NewMenu()) {
                case 0: {
                    Console.WriteLine(string.Join(Environment.NewLine,
                                                  game.AllScores.Select(x => x.ToString())
                                                 )
                                     );

                    break;
                }
                case 1: {
                    Console.WriteLine(string.Join(Environment.NewLine,
                                                  game.Players.Select(x => x.Name)
                                                 )
                                     );
                    break;
                }
                case 2: {
                    Console.Write("Användarens namn: ");
                    string input = Console.ReadLine();
                    Console.WriteLine(game.GetPlayerByName(input.Trim()).Highscore);
                    break;
                }
                case 3: {
                    Console.WriteLine(game.AverageScore);
                    break;
                }
                default: {
                    break;
                }
            }

            return 0;
        }

        private int NewMenu() {
            string[] options = this._options;

            bool hasSelectedValue = false;
            int  currentIndex     = 0;

            while (!hasSelectedValue) {
                Console.Clear();


                for (int i = 0; i < options.Length; i++) {
                    if (currentIndex == i) {
                        Console.WriteLine(options[i] + "  <-"
                                         );
                    }
                    else {
                        Console.WriteLine(options[i]);
                    }
                }


                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.UpArrow: {
                        currentIndex--;
                        if (currentIndex < 0) {
                            currentIndex = 0;
                        }

                        break;
                    }

                    case ConsoleKey.DownArrow: {
                        currentIndex++;
                        if (currentIndex >= options.Length) {
                            currentIndex = options.Length - 1;
                        }

                        break;
                    }
                    case ConsoleKey.Enter: {
                        hasSelectedValue = true;
                        break;
                    }
                }
            }

            return currentIndex;
        }
    }
}