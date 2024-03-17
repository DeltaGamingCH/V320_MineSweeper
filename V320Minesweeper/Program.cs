using Minesweeper.Logic;
using System;
using System.Xml.Schema;
using Logic = Minesweeper.Logic;

namespace V320Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
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
                }
                else
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

            /* TEMPORARY TESTING MINE PLACEMENT */
            Field[,] Fields = new Field[difficulty.Size[0].Width, difficulty.Size[0].Height];

            InitializeFields(Fields);

            DisplayFields(Fields);

            Console.ReadLine();
        }

        static void InitializeFields(Field[,] Fields)
        {
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = new Field();
                }
            }

            // Temporary testing mine placement
            Fields[1, 1].IsMine = true;
            Fields[3, 5].IsMine = true;
        }

        static void DisplayFields(Field[,] Fields)
        {
            Console.Write("   |");
            for (int column = 0; column < Fields.GetLength(1); column++)
            {
                if (column < 9)
                {
                    Console.Write($" {column + 1} |");
                } else
                {
                    Console.Write($" {column + 1}|");
                }
            }
            Console.WriteLine();

            Console.Write("----");

            for (int column = 0; column < Fields.GetLength(1); column++)
            {
                Console.Write("----");
            }

            Console.WriteLine();

            for (int row = 0; row < Fields.GetLength(0); row++)
            {
                Console.Write($" {(char)('A' + row)} |");
                for (int column = 0; column < Fields.GetLength(1); column++)
                {
                    char displayChar = GetDisplayChar(Fields[row, column]);
                    Console.Write($" {displayChar} |");
                }
                Console.WriteLine();

                Console.Write("----");

                for (int column = 0; column < Fields.GetLength(1); column++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }


            /* EXISTING FIELD DISPLAY LOGIC
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Console.Write(GetDisplayChar(Fields[i, j]) + " ");
                }
                Console.WriteLine();
            }*/
        }

        static char GetDisplayChar(Field cell)
        {
            if (cell.IsVisible)
            {
                if (cell.IsMine)
                {
                    return '*';
                }
                else
                {
                    return ' ';
                }
            }
            else if (cell.IsMarked)
            {
                return 'X';
            }
            else
            {
                return '.';
            }
        }
    }
}
