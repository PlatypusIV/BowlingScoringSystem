using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoringSystem.Classes
{
    class GameLogic
    {
        List<string> listOfPlayers;
        List<Game> listOfGames;



        public GameLogic()
        {
            gameSetup();
        }

        private void gameSetup()
        {
            int numOfPlayers;
            

            Console.Write("Please insert the number of players: ");

            numOfPlayers = int.Parse(Console.ReadLine());

            listOfPlayers = generatePlayers(numOfPlayers);

            listOfGames = playGames();

            printOutFrames();

        }

        private void printOutFrames()
        {
            try
            {
                foreach(Game game in listOfGames)
                {
                    foreach(Frame frame in game.frames)
                    {
                        Console.Write($"{game.player}: Frame({frame.frameNumber+1}){frame.rollOneResult}\n");
                    }

                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private List<string> generatePlayers(int numOfPlayers)
        {
            List<string> players = new List<string>();
            for(int i = 0; i < numOfPlayers; i++)
            {
                string player = $"Player {i + 1}";
                players.Add(player);
            }

            return players;
        }

        private List<Game> playGames()
        {
            List<Game> gameResults = new List<Game>();
            try
            {
                foreach (string name in listOfPlayers)
                {
                    gameResults.Add(new Game(name));
                }

                for (int frameNumber = 1; frameNumber <= 10; frameNumber++)
                {
                    foreach (Game game in gameResults)
                    {                        
                        game.frames.Add(rollBall(new Frame(frameNumber)));
                    }
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return gameResults;
        }

        private Frame rollBall(Frame frame)
        {
            var currentFrame = frame;
            try
            {

                int rollResult = GetRandomNumber(0, 10);
                int remainingPins = 10 - rollResult;
                if (remainingPins > 0)
                {
                    switch (rollResult)
                    {
                        case 7:
                        case 8:
                            currentFrame.rollOneResult = "[O]";
                            break;
                        case 0:
                            currentFrame.rollOneResult = $"[{generateMisplay()}]";
                            break;
                        default:
                            currentFrame.rollOneResult = $"[{rollResult.ToString()}]";
                            break;
                    }
                }
                else
                {
                    currentFrame.rollOneResult = "[X]";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return currentFrame;
        }

        private char generateMisplay()
        {
            char misplayType = ' ';
            int number = GetRandomNumber(0, 20);

            if (number>8)
            {
                misplayType = '-';
            }
            else
            {
                misplayType = 'F';
            }
            return misplayType;
        }

        private static readonly Random randomNumber = new Random();

        private static int GetRandomNumber(int min,int max)
        {
            lock (randomNumber)
            {
                return randomNumber.Next(min, max);
            }
        }
    }

    public class Frame
    {
        public int frameNumber;

        public string rollOneResult = null;
        public string rollTwoResult = null;
        public string rollThreeResult = null;

        public Frame(int frameNum)
        {
            frameNumber = frameNum;
        }
    }
}
