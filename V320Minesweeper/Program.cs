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

            Console.WriteLine(difficulty.MineCount);
            Console.WriteLine(difficulty.Size[0]);

            /* TEMPORARY TESTING MINE PLACEMENT */
            Field[,] Fields = new Field[difficulty.Size[0].Width, difficulty.Size[0].Height];

            InitializeFields(Fields);

            RandomMines(Fields, difficulty.MineCount);

            static void RandomMines(Field[,] Fields, int mineCount)
            {
                Random random = new Random();

                int rows = Fields.GetLength(0);
                int columns = Fields.GetLength(1);

                HashSet<(int, int)> minePositions = new HashSet<(int, int)>();
                while (minePositions.Count < mineCount)
                {
                    int row = random.Next(rows);
                    int column = random.Next(columns);
                    minePositions.Add((row, column));
                }

                foreach (var (row, column) in minePositions)
                {
                    Fields[row, column].IsMine = true;
                }
            }

            static void InitializeFields(Field[,] Fields)
            {
                for (int row = 0; row < Fields.GetLength(0); row++)
                {
                    for (int column = 0; column < Fields.GetLength(1); column++)
                    {
                        Fields[row, column] = new Field();
                    }
                }
            }

            FieldCaretaker caretaker = new FieldCaretaker();

            while (true)
            {
                // Display the updated game board
                DisplayFields(Fields);

                Console.Write("Enter your move (format: A1, B2, etc.) or type 'undo' to undo the last move: ");
                string move = Console.ReadLine();

                // Check if the user wants to undo the last move
                if (move.ToLower() == "undo")
                {
                    for (int i = 0; i < Fields.GetLength(0); i++)
                    {
                        for (int j = 0; j < Fields.GetLength(1); j++)
                        {
                            Memento previousState = caretaker.Pop();
                            if (previousState != null)
                            {
                                Fields[i, j].RestoreFromMemento(previousState);
                            }
                        }
                    }
                    continue; // Skip the rest of the loop and start the next iteration
                }

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
                foreach (var field in Fields)
                {
                    caretaker.PushState(field.SaveToMemento());
                }
            }
        }
        static bool IsGameWon(Field[,] Fields)
        {
            if (Fields == null || Fields.Length == 0)
            {
                return false;
            }

            int rows = Fields.GetLength(0);
            int columns = Fields.GetLength(1);

            if (rows <= 0 || columns <= 0)
            {
                return false;
            }

            foreach (Field field in Fields)
            {
                if (!field.IsMine && !field.IsVisible)
                {
                    // There's still a non-mine field that's not revealed
                    return false;
                }
            }
            return true;
        }

        static void DisplayFields(Field[,] Fields)
        {
            Console.Write("   |");
            for (int column = 0; column < Fields.GetLength(1); column++)
            {
                if (column < 9)
                {
                    Console.Write($" {column + 1} |");
                }
                else
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
