using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    internal class DifficultyEasy : IGameDifficulty
    {
        public int MineCount { get; } = 10;
        public Size[] Size { get; } = new Size[] { new Size(8,8) };
    };
}
