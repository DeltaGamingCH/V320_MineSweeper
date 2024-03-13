using Minesweeper.Logic;
using System.Xml.Schema;

namespace V320Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 10;
            int columns = 10;
            int mineCount = 20;

            GameModel game = new GameModel(rows, columns, mineCount);

            for (int i = 0; i < game.Fields.GetLength(0); i++)
            {
                for (int j = 0; j < game.Fields.GetLength(1); j++)
                {
                    Console.Write(game.Fields[i, j].IsMine ? "M " : ". ");
                }
                Console.WriteLine();
            }
        }
    }
}
