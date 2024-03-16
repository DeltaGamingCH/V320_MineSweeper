using System.Drawing;

namespace Minesweeper.Logic
{
    public class GameModel
    {
        private IGameDifficulty difficulty;

        private Field[,] Fields;

        private Size[] size;

        internal static IGameDifficulty CreateDifficultyEasy()
        {
            return new DifficultyEasy();
        }

        public GameModel(IGameDifficulty difficulty) //<== In apprantencies (int xSize, int ySize)
        {
            // this.gameBoard = new Board[xSize, ySize];

            this.difficulty = difficulty;
            this.Fields = new Field[difficulty.Size[0].Width, difficulty.Size[0].Height];
            this.size = difficulty.Size;
        }

        /*public void DoTurn(string coordinate)
        {
            Fields[row, column].IsMine = true;
        }*/

    }
}
