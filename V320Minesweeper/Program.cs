using Minesweeper.Logic;
using System.Xml.Schema;

namespace V320Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var model = new Model(16, 16);
            while (true)
            {
                Console.Clear();
                //Write Model to console

                Difficulty difficulty = new Difficulty();

                Console.WriteLine("Enter a coordinate.");

                var coordinate = Console.ReadLine();

                model.DoTurn(coordinate);
            }

        }

        
    }
}
