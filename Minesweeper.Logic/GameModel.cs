using System.ComponentModel;
using System.Drawing;

namespace Minesweeper.Logic
{
    public class GameModel
    {
        private Field[,] _fields;
        private IGameDifficulty _difficulty;
        private FieldCaretaker _caretaker;


        public GameModel(IGameDifficulty difficulty)
        {
            _difficulty = difficulty;
            _fields = new Field[difficulty.Size[0].Width, difficulty.Size[0].Height];
            _caretaker = new FieldCaretaker();
        }

        public void InitializeFields()
        {
            for (int row = 0; row < _fields.GetLength(0); row++)
            {
                for (int column = 0; column < _fields.GetLength(1); column++)
                {
                    _fields[row, column] = new Field();
                }
            }

            RandomMines(_difficulty.MineCount);
        }

        private void RandomMines(int mineCount)
        {
            Random random = new Random();

            int rows = _fields.GetLength(0);
            int columns = _fields.GetLength(1);

            HashSet<(int, int)> minePositions = new HashSet<(int, int)>();
            while (minePositions.Count < mineCount)
            {
                int row = random.Next(rows);
                int column = random.Next(columns);
                minePositions.Add((row, column));
            }

            foreach (var (row, column) in minePositions)
            {
                _fields[row, column].IsMine = true;
            }
        }

        public void DoTurn()
        {
            while (true)
            {
                // Display the updated game board
                DisplayFields(_fields);

                Console.Write("Enter your move (format: A1, B2, etc.) or type 'undo' to undo the last move: ");
                string move = Console.ReadLine().ToLower();

                // Check if the user wants to undo the last move
                if (move.ToLower() == "undo")
                {
                    for (int i = _fields.Length - 1; i >= 0; i--)
                    {
                        Memento previousState = _caretaker.Pop();
                        if (previousState != null)
                        {
                            _fields[i / _fields.GetLength(0), i % _fields.GetLength(1)].RestoreFromMemento(previousState);
                        }
                    }
                    continue; // Skip the rest of the loop and start the next iteration
                }

                // Save the current state before making a move
                for (int i = 0; i < _fields.Length; i++)
                {
                    _caretaker.PushState(_fields[i / _fields.GetLength(0), i % _fields.GetLength(1)].SaveToMemento());
                }

                // Convert the move into coordinates

                if (move.Length < 2 || !char.IsLetter(move[0]) || !int.TryParse(move.Substring(1), out int column))
                {
                    Console.WriteLine("Invalid move. Please enter a valid coordinate.");
                    continue;
                }

                int row = move[0] - 'a';
                column = int.Parse(move.Substring(1)) - 1;

                if (row < 0 || row >= _fields.GetLength(0) || column < 0 || column >= _fields.GetLength(1))
                {
                    Console.WriteLine("Invalid move. Please enter valid coordinates.");
                    continue;
                }

                // Check if the selected field is a mine
                if (_fields[row, column].IsMine)
                {
                    Console.WriteLine("Boom! You hit a mine. Game over.");
                    foreach (Field field in _fields)
                    {
                        field.IsVisible = true;
                    }
                    DisplayFields(_fields);
                    break;
                }

                // Reveal the selected field
                _fields[row, column].IsVisible = true;

                // Check if the game is won (i.e., all non-mine fields are revealed)
                if (IsGameWon(_fields))
                {
                    Console.WriteLine("Congratulations! You've cleared all the mines. You won!");
                    break;
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
                    char displayChar = GetDisplayChar(Fields, row, column);
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

        static char GetDisplayChar(Field[,] Fields, int row, int column)
        {
            Field cell = Fields[row, column];
            if (cell.IsVisible)
            {
                if (cell.IsMine)
                {
                    return '*'; // Is visible and a Mine
                }
                else
                {
                    int adjacentMines = AdjacentMines(Fields, row, column); //Calculate adjacent mines
                    if (adjacentMines > 0)
                    {
                        return char.Parse(adjacentMines.ToString());
                    }
                    else
                    {
                        return ' '; // Is visible but not a mine
                    }
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

        static int AdjacentMines(Field[,] Fields, int row, int column)
        {
            int count = 0;
            int rows = Fields.GetLength(0);
            int columns = Fields.GetLength(1);

            int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < rowOffsets.Length; i++)
            {
                int newRow = row + rowOffsets[i];
                int newColumn = column + colOffsets[i];

                if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns)
                {
                    if (Fields[newRow, newColumn].IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}