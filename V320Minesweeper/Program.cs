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

            Fields[0, 0].IsMine = true; // Set the field at A1 as a mine

            DisplayFields(Fields);

            while (true)
            {
                Console.Write("Enter your move (format: A1, B2, etc.): ");
                string move = Console.ReadLine();

                // Convert the move into coordinates
                int row = move[0] - 'A';
                int column = int.Parse(move.Substring(1)) - 1;

                // Check if the selected field is a mine
                if (Fields[row, column].IsMine)
                {
                    Console.WriteLine("Boom! You hit a mine. Game over.");
                    break;
                }

                // Reveal the selected field
                Fields[row, column].IsVisible = true;

                // Check if the game is won (i.e., all non-mine fields are revealed)
                if (IsGameWon(Fields))
                {
                    Console.WriteLine("Congratulations! You've cleared all the mines. You won!");
                    break;
                }

                // Display the updated game board
                DisplayFields(Fields);
            }
        }
        static bool IsGameWon(Field[,] Fields)
        {
            foreach (Field field in Fields)
            {
                if (!field.IsMine && !field.IsVisible)
                {
                    // There's still a non-mine field that's not revealed
                    return false;
                }
            }

            // All non-mine fields are revealed
            return true;
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
                    return '*'; // Is visible and a Mine
                }
                else
                {
                    return ' '; // Is visible but not a mine
                }
            }
            else if (cell.IsMarked)
            {
                return 'X'; // Is invisible but marked
            }
            else
            {
                return '.'; // Is invisible and not marked
            }
        }
    }
}
