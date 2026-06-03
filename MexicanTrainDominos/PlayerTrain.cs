using System;

namespace MexicanTrainDominos
{
    public class PlayerTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        public PlayerTrain(Hand h) : base()
        {
            hand = h;
            isOpen = false;
        }

        public PlayerTrain(Hand h, int engValue) : base(engValue)
        {
            hand = h;
            isOpen = false;
        }

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (h == hand || IsOpen)
            {
                return base.IsPlayable(d, out mustFlip); // When running a validation pass on my code, it was suggested I add "base." to IsPlayable()
            }

            mustFlip = false;
            return false;
        }
    }
}