using System;
using System.Collections.Generic;

namespace MexicanTrainDominos
{
    public class Hand // Class representing a hand of dominos
    {
        private List<Domino> dominos;

        // Default Constructor
        public Hand()
        {
            dominos = new List<Domino>();
        }

        // Count number of dominos in the hand
        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

        // Indexer for the hand
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

        // Method to add a domino to the hand
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        // Method to remove a domino from the hand
        public void Remove(Domino d)
        {
            dominos.Remove(d);
        }

        // Method to check if a certain domino is in the hand
        public bool Contains(Domino d)
        {
            return dominos.Contains(d);
        }

        // ToString method
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