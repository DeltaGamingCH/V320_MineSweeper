using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class FieldCaretaker
    {
        private List<Memento> states = new List<Memento>();

        public void PushState(Memento state)
        {
            states.Add(state);
        }

        public Memento Pop()
        {
            if (states.Count == 0) return null;

            var lastIndex = states.Count - 1;
            var lastState = states[lastIndex];
            states.RemoveAt(lastIndex);

            return lastState;
        }
    }
}