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
    }
}