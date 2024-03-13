using System.Drawing;

namespace Minesweeper.Logic
{
    public class GameModel
    {
        private IGameDifficulty difficulty;
        private Board[,] gameBoard;

        private Field[,] Fields;

        public GameModel() //<== In apprantencies (int xSize, int ySize)
        {
            // this.gameBoard = new Board[xSize, ySize];

            this.difficulty = difficulty;
            this.gameBoard = new Board[difficulty.BoardSize[0], difficulty.BoardSize[1]];

            this.size = Size[] Size { get; } = new Size[] { new Size(30, 16) };
        }

        public void DoTurn(string coordinate)
        {

                    Fields[row, column].IsMine = true;
                }
        }
    }
}
