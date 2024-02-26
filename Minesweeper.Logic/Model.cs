namespace Minesweeper.Logic
{
    public class Model
    {
        private Field[,] gameBoard;

        public Model(int xSize, int ySize)
        {
            this.gameBoard = new Field[xSize, ySize];
        }

        public void DoTurn(string coordinate)
        { 

        }
    } 
}
