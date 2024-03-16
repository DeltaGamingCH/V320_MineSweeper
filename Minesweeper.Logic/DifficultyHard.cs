using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class DifficultyHard : IGameDifficulty
    {
        public int MineCount { get; } = 99;
        public Size[] Size { get; } = new Size[] { new Size(30, 16) };
    };
}
