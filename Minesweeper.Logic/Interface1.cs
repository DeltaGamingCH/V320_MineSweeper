using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public interface IGameDifficulty
    {
        int[] Size { get; }
        int mineCount { get; }
    }
   
    internal class EasyDifficulty : IGameDifficulty
    {
        public int[] BoardSize = { 8, 8 };
        public int MineCount = 10;
    }
    internal class MediumDifficulty : IGameDifficulty
    {
        public int[] BoardSize = { 8, 8 };
        public int MineCount = 10;
    }
    internal class HardDifficulty : IGameDifficulty
    {
        public int[] BoardSize = { 8, 8 };
        public int MineCount = 10;
    }
}
