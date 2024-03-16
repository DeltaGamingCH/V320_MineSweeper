using Minesweeper.Logic;
using System.Xml.Schema;
using Logic = Minesweeper.Logic;

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
                Console.Write("Your selected difficulty: ");
                selectDifficulty = Console.ReadLine();
                if (selectDifficulty == "easy" || selectDifficulty == "medium" || selectDifficulty == "hard")
                {
                    break;
                } else
                    Console.WriteLine("Invalid Input. Please select one of the difficulties above.");
            }

            Logic.IGameDifficulty difficulty;
            switch (selectDifficulty)
            {
                case "easy":
                    difficulty = new Logic.DifficultyEasy();
                    break;
                case "medium": 
                    difficulty = new Logic.DifficultyMedium();
                    break;
                case "hard": 
                    difficulty = new Logic.DifficultyHard();
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Defaulting to Easy Difficulty.");
                    difficulty = new Logic.DifficultyEasy();
                    break;
            }

            Logic.GameModel gameModel = new Logic.GameModel(difficulty);

            Console.WriteLine(difficulty.MineCount);
            Console.WriteLine(difficulty.Size[0]);
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
