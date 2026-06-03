using System;
using System.Collections;
using System.Collections.Generic;

namespace MexicanTrainDominos
{
    public abstract class Train : IEnumerable<Domino>  // Abstract Class - Parent of MexicanTrain and PlayerTrain
    {
        private List<Domino> dominos;
        private int engineValue;

        // Default Constructor
        protected Train()
        {
            dominos = new List<Domino>();
        }

        // Overloaded Constructor
        protected Train(int engValue)
        {
            dominos = new List<Domino>();
            engineValue = engValue;
        }

        // Count number of dominos in the train
        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

        // Getter and Setter for the "engine" value of the train
        public int EngineValue
        {
            get
            {
                return engineValue;
            }

            set
            {
                engineValue = value;
            }
        }

        // Check for an empty train
        public bool IsEmpty
        {
            get
            {
                return dominos.Count == 0;
            }
        }

        // Getter for the last domino played
        public Domino LastDomino
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                return dominos[dominos.Count - 1];
            }
        }

        // Getter for the value the next domino should match
        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                {
                    return EngineValue;
                }
                return LastDomino.Side2;
            }
        }

        // Indexer method
        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        // Adds the domino to the train
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        // Checks if the domino can be played on the train and if it needs to be flipped
        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == PlayableValue)
            {
                mustFlip = false;
                return true;
            }

            if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            }

            mustFlip = false;
            return false;
        }

        // Abstract IsPlayable for child class implementation, chekcs if a hand is legal to be played from
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        // Plays the domino on the train and removes it from the hand
        public void Play(Hand h, Domino d)
        {
            bool mustFlip;

            if (!IsPlayable(h, d, out mustFlip))
            {
                throw new Exception("That domino cannot be played on this train.");
            }

            if (mustFlip)
            {
                d.Flip();
            }

            Add(d);
            h.Remove(d);
        }

        // Enumerator allowing a foreach loop to be used with the train
        public IEnumerator<Domino> GetEnumerator()
        {
            return dominos.GetEnumerator();
        }

        // Non-generic version required by IEnumerable.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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