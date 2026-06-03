using System;

namespace MexicanTrainDominos
{
    public class MexicanTrain : Train // Inheriting child class from the parent class Train
    {
        // Default Constructor
        public MexicanTrain() : base()
        {
        }

        // Overloaded Constructor
        public MexicanTrain(int engValue) : base(engValue)
        {
        }

        // Checks if a certain hand can play a certain domino on the train, and if it needs to be flipped
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return base.IsPlayable(d, out mustFlip);
        }
    }
}