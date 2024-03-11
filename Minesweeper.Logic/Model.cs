namespace Minesweeper.Logic
{
    public class Model
    {
        private Board[,] gameBoard;

        public Model(int xSize, int ySize)
        {
            this.gameBoard = new Board[xSize, ySize];
        }

        public void DoTurn(string coordinate)
        { 

        }
    } 
}
