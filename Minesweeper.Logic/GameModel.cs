namespace Minesweeper.Logic
{
        public class GameModel
        {
            public Field[,] Fields;

            public GameModel(int rows, int columns, int mineCount)
            {
                Fields = new Field[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Fields[i, j] = new Field();
                    }
                }

                FillFieldsWithMines(mineCount);
            }

            public void FillFieldsWithMines(int mineCount)
            {
                Random random = new Random();
                for (int i = 0; i < mineCount; i++)
                {
                    int row, column;
                    do
                    {
                        row = random.Next(Fields.GetLength(0));
                        column = random.Next(Fields.GetLength(1));
                    } while (Fields[row, column].IsMine);

                    Fields[row, column].IsMine = true;
                }
            }
        }
    }
