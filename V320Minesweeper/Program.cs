using Minesweeper.Logic;
using System;
using System.Data;
using System.Data.Common;
using System.Xml.Schema;
using Logic = Minesweeper.Logic;

namespace V320Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MineSweeper!");
            Console.WriteLine("Select your difficulty: ");
            Console.WriteLine($"- \x1b[32mEasy\x1b[0m");
            Console.WriteLine($"- \x1b[33mMedium\x1b[0m");
            Console.WriteLine($"- \x1b[31mHard\x1b[0m");

            string selectDifficulty;
            while (true)
            {
                Console.Write("Your selected difficulty: ");
                selectDifficulty = Console.ReadLine().ToLower();
                if (selectDifficulty == "easy" || selectDifficulty == "medium" || selectDifficulty == "hard")
                {
                    break;
                }
                else
                    Console.WriteLine("Invalid Input. Please select one of the difficulties above.");
            }

            Logic.IGameDifficulty difficulty;
            switch (selectDifficulty)
            {
                case "easy":
                    difficulty = new Logic.DifficultyEasy();
                    Console.WriteLine($"You are playing on \x1b[32mEasy\x1b[0m difficulty.");
                    break;
                case "medium":
                    difficulty = new Logic.DifficultyMedium();
                    Console.WriteLine($"You are playing on \x1b[33mMedium\x1b[0m difficulty.");
                    break;
                case "hard":
                    difficulty = new Logic.DifficultyHard();
                    Console.WriteLine($"You are playing on \x1b[31mHard\x1b[0m difficulty.");
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Defaulting to Easy Difficulty.");
                    difficulty = new Logic.DifficultyEasy();
                    break;
            }

            Logic.GameModel gameModel = new Logic.GameModel(difficulty);

            Console.WriteLine();

            gameModel.InitializeFields();

            gameModel.DoTurn();
        }
    }
}
