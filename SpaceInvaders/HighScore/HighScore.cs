using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class HighScore
    {
        public HighScore()
        {
            this.CreateHighScoreFileIfNotExists();
            this.score = GetHighScoreFromFile(); 
        }

        public int GetScore()
        {
            return this.score;
        }

        public void CreateHighScoreFileIfNotExists()
        {
            if (!System.IO.File.Exists(path))
            {
                System.IO.FileStream f = System.IO.File.Create(path);
                f.Close();
            }
        }

        public void WriteHighScoreToFile(int score)
        {
            if (score > this.score)
            {
                Debug.Assert(System.IO.File.Exists(path));
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
                {
                    writer.WriteLine(score.ToString());
                }
            }
        }

        public int GetHighScoreFromFile()
        {
            int score = 0;
            Debug.Assert(System.IO.File.Exists(path));
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    score = Convert.ToInt32(line);
                    line = reader.ReadLine();
                }

            }
            return score;
        }

        private int score;
        private string path = "high_score.txt";
    }

}
