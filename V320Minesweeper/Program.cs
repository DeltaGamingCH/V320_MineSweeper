using Minesweeper.Logic;
using System.Xml.Schema;

namespace V320Minesweeper
{
    class Program
    {
        static void Main(string[] args) {
        
            var model = new GameModel(16, 16);
            while (true)
            {
                Console.Clear();
                //Write Model to console

                Console.WriteLine("Enter a coordinate.");

                var coordinate = Console.ReadLine();

                model.DoTurn(coordinate);
            }
        }
    }
}
