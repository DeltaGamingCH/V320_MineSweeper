using Minesweeper.Logic;
using System.Xml.Schema;

namespace V320Minesweeper
{
    class Program
    {
        static void Main(string[] args) {

            // var model = new GameModel(16, 16);

            Console.WriteLine("Welcome to MineSweeper!");
            Console.WriteLine("Please select a difficulty: ");
            Console.WriteLine(" - 'easy'");
            Console.WriteLine(" - 'medium'");
            Console.WriteLine(" - 'hard'");

            string selectDifficulty;
            while (true)
            {
                Console.Write("Your selected difficulty: ")
                selectDifficulty = Console.ReadLine().ToLower;
                if (selectDifficulty == "easy" || selectDifficulty == "medium" || selectDifficulty == "hard")
                {
                    break;
                } else
                    Console.WriteLine("Invalid Input. Please select one of the difficulties above.");
            }

            Logic.IGameDifficulties difficulty;
            switch (selectDifficulty)
            {
                case "easy":
                    difficulty = new Logic.EasyDifficulty();
                    break;
                case "medium": 
                    difficulty = new Logic.MediumDifficulty();
                    break;
                case "hard": 
                    difficulty = new Logic.HardDifficulty();
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Defaulting to Easy Difficulty.");
                    difficulty = new Logic.EasyDifficulty();
                    break;
            }

            Logic.GameModel gameModel = new Logic.GameModel(difficulty);
            /*
            while (true)
            {


                

                /*
                Console.Clear();
                //Write Model to console

                Console.WriteLine("Enter a coordinate.");

                var coordinate = Console.ReadLine();

                model.DoTurn(coordinate);*/
            /*}*/
        }
    }
}
