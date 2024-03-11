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
        int MineCount { get; }
        Size[] Size { get; }

        public class DifficultyEasy : IGameDifficulty
        {
            public int MineCount { get; } = 10;
            public Size[] Size { get; } = new Size[] { new Size(8, 8) };
        };
        public class DifficultyMedium : IGameDifficulty
        {
            public int MineCount { get; } = 40;
            public Size[] Size { get; } = new Size[] { new Size(16, 16) };
        };
        public class DifficultyHard : IGameDifficulty
        {
            public int MineCount { get; } = 99;
            public Size[] Size { get; } = new Size[] { new Size(30, 16) };
        };
    }
}
