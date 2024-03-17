using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Field
    {
        private bool isMine { get; set; }
        private bool isVisible { get; set; }
        private bool isMarked { get; set; }

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

        public Memento SaveToMemento()
        {
            // Create a new Memento with a copy of your field's current state.
            return new Memento(isMine, isVisible, isMarked);
        }

        public void RestoreFromMemento(Memento memento)
        {
            // Restore your field's state from the given Memento.
            isMine = memento.IsMine;
            isVisible = memento.IsVisible;
            isMarked = memento.IsMarked;
        }
    }

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
