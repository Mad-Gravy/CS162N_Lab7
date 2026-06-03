using System;

namespace MexicanTrainDominos
{
    public class PlayerTrain : Train // Inheriting child class from the parent class Train
    {
        private Hand hand;
        private bool isOpen;

        // Default Constructor
        public PlayerTrain(Hand h) : base()
        {
            hand = h;
            isOpen = false;
        }

        // Overloaded Constructor
        public PlayerTrain(Hand h, int engValue) : base(engValue)
        {
            hand = h;
            isOpen = false;
        }

        // Checks if train can be played on by any player
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        // Swicth method, marks train as open
        public void Open()
        {
            isOpen = true;
        }

        // Switch method, marks train as closed
        public void Close()
        {
            isOpen = false;
        }

        // Checks if a certain hand can play a certain domino on the train, and if it needs to be flipped
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (h == hand || IsOpen)
            {
                return base.IsPlayable(d, out mustFlip);
            }

            mustFlip = false;
            return false;
        }
    }
}