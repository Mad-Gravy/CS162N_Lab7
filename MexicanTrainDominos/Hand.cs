using System;
using System.Collections.Generic;

namespace MexicanTrainDominos
{
    public class Hand
    {
        private List<Domino> dominos;

        public Hand()
        {
            dominos = new List<Domino>();
        }

        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
            set
            {
                dominos[index] = value;
            }
        }

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public void Remove(Domino d)
        {
            dominos.Remove(d);
        }

        public bool Contains(Domino d)
        {
            return dominos.Contains(d);
        }

        public override string ToString()
        {
            string output = "";

            foreach (Domino d in dominos)
            {
                output += d.ToString() + " ";
            }

            return output;
        }
    }
}