using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class DifficultyMedium : IGameDifficulty
    {
        public int MineCount { get; } = 40;
        public Size[] Size { get; } = new Size[] { new Size(16, 16) };
    };
}
