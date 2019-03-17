using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringSystemForBowling
{
    public class Frame
    {
        public int frameNumber;

        public string ballOneResult;
        public string ballTwoResult;
        public string ballThreeResult;

        public Frame(int frameNum)
        {
            frameNumber = frameNum;
        }
    }
}
