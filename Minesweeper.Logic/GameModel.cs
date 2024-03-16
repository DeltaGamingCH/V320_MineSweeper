using System.Drawing;

namespace Minesweeper.Logic
{
    public class GameModel
    {
        private IGameDifficulties difficulty;
        private IGameDifficulties easyDifficulty;
        private IGameDifficulties mediumDifficulty;
        private IGameDifficulties hardDifficulty;

        private Board[,] gameBoard;

        private Field[,] Fields;

        public GameModel() //<== In apprantencies (int xSize, int ySize)
        {
            // this.gameBoard = new Board[xSize, ySize];

            this.difficulty = difficulty;
            this.gameBoard = new Board[difficulty.BoardSize[0], difficulty.BoardSize[1]];

            this.size = Size[] Size { get; } = new Size[] { new Size(30, 16) };
        }

        public IGameDifficulties GetDifficulty()
        {
            return difficulty;
        }

        public IGameDifficulties EasyDifficulty()
        {
            return easyDifficulty;
        }

        public IGameDifficulties MediumDifficulty()
        {
            return mediumDifficulty;
        }

        public IGameDifficulties HardDifficulty()
        {
            return hardDifficulty;
        }

        public IGameDifficulties GetCurrentDifficulty()
        {
            return difficulty;
        }

        public void DoTurn(string coordinate)
        {
            Fields[row, column].IsMine = true;
        }

    }
}
