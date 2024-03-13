using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Field
    {
        private bool isMine;
        private bool isVisible;
        private bool isMarked;

        public Field()
        {
            isMine = false;
            isVisible = false;
            isMarked = false;
        }

        public bool IsMine
        {
            get { return isMine; }
            set { isMine = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public bool IsMarked
        {
            get { return isMarked; }
            set { isMarked = value; }
        }
    }
}
