using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Memento
    {
        public bool IsMine { get; private set; }
        public bool IsVisible { get; private set; }
        public bool IsMarked { get; private set; }

        public Memento(bool isMine, bool isVisible, bool isMarked)
        {
            IsMine = isMine;
            IsVisible = isVisible;
            IsMarked = isMarked;
        }
    }
}
