using System;

namespace MexicanTrainDominos
{
    public class MexicanTrain : Train
    {
        public MexicanTrain() : base()
        {
        }

        public MexicanTrain(int engValue) : base(engValue)
        {
        }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return IsPlayable(d, out mustFlip);
        }
    }
}