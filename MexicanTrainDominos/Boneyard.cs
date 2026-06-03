using System;
using System.Collections.Generic;
using System.Text;

namespace MexicanTrainDominos
{
    public class Boneyard // Class representing the boneyard, where the remaining dominos are after players draw their hands
    {
        private List<Domino> listOfDominos;

        // Count of dominos remaining in the boneyard
        public int DominosRemaining
        {
            get
            {
                return listOfDominos.Count;
            }
        }

        // Indexer for the boneyard
        public Domino this[int index]
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

        // Constructor, creates the boneyard with all the dominos up to the max dots specified
        public Boneyard(int maxDots)
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

        // Draw method, removes the top domino from the boneyard and returns it
        public Domino Draw()
        {
            if (IsEmpty())
            {
                return null;
            }

            Domino topDomino = listOfDominos[0];

            listOfDominos.RemoveAt(0);

            return topDomino;
        }

        // Method to check if the boneyard is empty
        public bool IsEmpty()
        {
            return listOfDominos.Count == 0;
        }

        // Shuffle method, randomizes the order of the dominos in the boneyard
        public void Shuffle()
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

        // ToString Method
        public override string ToString()
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