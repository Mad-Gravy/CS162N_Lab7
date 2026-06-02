using System;
using System.Collections.Generic;
using System.Text;

namespace MexicanTrainDominos
{
    public class Boneyard
    {
        private List<Domino> listOfDominos;

        public int DominosRemaining // Boneyard count
        {
            get
            {
                return listOfDominos.Count;
            }
        }

        public Domino this[int index] // Indexer
        {
            get
            {
                return listOfDominos[index];
            }
            set
            {
                listOfDominos[index] = value;
            }
        }

        public Boneyard(int maxDots)  // Constructor
        {
            listOfDominos = new List<Domino>();

            for (int first = 0; first <= maxDots; first++)
            {
                for (int second = first; second <= maxDots; second++)
                {
                    listOfDominos.Add(new Domino(first, second));
                }
            }
        }

        public Domino Draw() // Draw method, removed the top domino
        {
            if (IsEmpty())
            {
                return null;
            }

            Domino topDomino = listOfDominos[0];

            listOfDominos.RemoveAt(0);

            return topDomino;
        }

        public bool IsEmpty() // Empty boneyard check
        {
            return listOfDominos.Count == 0;
        }

        public void Shuffle()  // Randomizer
        {
            Random generator = new Random();

            for (int i = 0; i < listOfDominos.Count; i++)
            {
                int swapIndex = generator.Next(listOfDominos.Count);

                Domino temp = listOfDominos[i];
                listOfDominos[i] = listOfDominos[swapIndex];
                listOfDominos[swapIndex] = temp;
            }
        }

        public override string ToString() // ToString Method
        {
            string output = "";

            foreach (Domino d in listOfDominos)
            {
                output += d.ToString() + "\n";
            }

            return output;
        }
    }
}