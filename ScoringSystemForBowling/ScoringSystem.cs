using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringSystemForBowling
{
    class ScoringSystem
    {
        List<string> playerNames;
        List<Game> playerScores;

        public ScoringSystem()
        {
            playerNames = new List<string>();
            playerScores = new List<Game>();
            
            gameSetup();
        }

        private void gameSetup()
        {
            string playerName = "";

            do
            {
                Console.Write("Please insert a name for a player, or leave blank to continue: ");
                playerName = Console.ReadLine();
                if (!playerName.Equals(""))
                {
                    playerNames.Add(playerName);
                }
            } while (!playerName.Equals(""));

            foreach (string name in playerNames)
            {
                playerScores.Add(new Game(name));
            }
            iterateThroughRounds();
            Console.WriteLine();
        }

        private void iterateThroughRounds()
        {
            try
            {
                for (int i = 0; i <= 10; i++)
                {
                    foreach (Game game in playerScores)
                    {
                        game.frames[i] = inputScore( i + 1, game);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private Frame inputScore(int frameNumber,Game game)
        {
            Frame frameToReturn = new Frame(frameNumber);
            Console.WriteLine($"insert the amount of pins knocked down for {game.playerName}, or press \"f\" for a foul: ");
            string input = Console.ReadLine();

            int pinsStanding = 10;
            int scoreToAdd = 10;
            string secondTossInput = "";
            if (validateInput(input))
            {
                switch (input)
                {
                    case "F":
                    case "f":
                        break;
                    default:
                        pinsStanding -= int.Parse(input);
                        break;
                }

                if(pinsStanding == 0)
                {
                    frameToReturn.ballOneResult = "[X]";
                    game.playerScore += scoreToAdd;
                }
                else
                {
                    scoreToAdd -= pinsStanding;
                    game.playerScore += scoreToAdd;
                    frameToReturn.ballOneResult = $"[{scoreToAdd}]";
                    Console.WriteLine("Insert the result for the second roll or \"f\" for a foul: ");
                    secondTossInput = Console.ReadLine();
                    if (validateInput(secondTossInput))
                    {
                        switch (input)
                        {
                            case "F":
                            case "f":
                                break;
                            default:
                                pinsStanding -= int.Parse(input);
                                if(pinsStanding == 0)
                                {
                                    frameToReturn.ballTwoResult = "[\\]";
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please insert a proper input!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Please insert a proper input!");
            }
            presentScore();
            return frameToReturn;
        }

        private bool validateInput(string input)
        {
            bool inputIsValid = false;
            if (input.ToLower().Equals("f") )
            {
                inputIsValid = true;
            }
            else
            {
                int inputNumber = int.Parse(input);
                int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                foreach (int number in numbers)
                {
                    if (inputNumber == number)
                    {
                        inputIsValid = true;
                        break;
                    }
                    
                }
            }
            return inputIsValid;
        }

        private void presentScore()
        {
            foreach(Game game in playerScores)
            {
                foreach(Frame frame in game.frames)
                {
                    if(frame.ballOneResult != null)
                    {
                        Console.WriteLine($"{game.playerName}: frame {frame.frameNumber}: {frame.ballOneResult} {frame.ballTwoResult} Score: {game.playerScore}");
                    }
                }
            }
        }
    }
}
