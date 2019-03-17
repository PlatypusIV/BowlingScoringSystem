using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringSystemForBowling
{
    public class Game
    {
        public string playerName;
        public int playerScore = 0;

        public List<Frame> frames = new List<Frame>();

        public Game(string name)
        {
            playerName = name;
            for (int i = 0; i < 10; i++)
            {
                frames.Add(new Frame(i + 1));
            }
        }
    }

}
