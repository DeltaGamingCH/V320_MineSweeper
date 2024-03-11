namespace Minesweeper.Logic
{
    public class GameModel
    {
        private GameDifficulty difficulty;
        private Board[,] gameBoard;

        public GameModel(int xSize, int ySize)
        {
            this.gameBoard = new Board[xSize, ySize];
        }

        public void DoTurn(string coordinate)
        { 

        }
    } 
}
