using System.Collections.Generic;
using System.Linq;

namespace big_score {
    public class Player {
        public int[] Scores { get; set; }
        public string Name { get; set; }
        public int Highscore => Scores.Max();

        public void AddScore(int score) {
            List<int> tempList = this.Scores.ToList();
            tempList.Add(score);
            this.Scores = tempList.ToArray();
        }

        public void RemoveScore(int score) {
            List<int> tempList = this.Scores.ToList();
            tempList.Remove(score);
            this.Scores = tempList.ToArray();
        }
    }
}