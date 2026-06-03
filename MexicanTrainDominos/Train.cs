using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace MexicanTrainDominos
{
    public abstract class Train
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

        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

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

        public bool IsEmpty
        {
            get
            {
                return dominos.Count == 0;
            }
        }

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

        // Indexer
        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

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

        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

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