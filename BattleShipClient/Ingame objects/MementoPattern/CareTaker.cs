using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.MementoPattern
{
    public class CareTaker
    {
        private List<Memento> history;
        private int currentState = -1;

        public CareTaker()
        {
            this.history = new List<Memento>();
        }

        public void addMemento(Memento m)
        {
            this.history.Add(m);
            currentState = this.history.Count() - 1;
        }

        public Memento getMemento(int index)
        {
            return history[index];
        }

        public Memento undo()
        {
            Console.WriteLine("Undoing state...");
            if (currentState <= 0)
            {
                currentState = 0;
                return getMemento(0);
            }

            currentState--;
            return getMemento(currentState);
        }

        public Memento redo()
        {
            Console.WriteLine("Redoing state...");

            if (currentState >= history.Count - 1)
            {
                currentState = history.Count - 1;

                return getMemento(currentState);
            }

            currentState++;
            return getMemento(currentState);
        }

        public int currSize()
        {
            return this.history.Count;
        }
    }
}
