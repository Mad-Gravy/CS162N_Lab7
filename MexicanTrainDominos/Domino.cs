using System;

namespace MexicanTrainDominos
{
    public class Domino
    {
        private int side1;
        private int side2;

        public Domino()  // Default Constructor
        {
            side1 = 0;
            side2 = 0;
        }

        public Domino(int side1, int side2)  // Full Constructor
        {
            Side1 = side1;
            Side2 = side2;
        }


        // Getters and Setters
        public int Side1
        {
            get { return side1; }
            set { side1 = value; }
        }

        public int Side2
        {
            get { return side2; }
            set { side2 = value; }
        }

        public override string ToString()  // ToString Method
        {
            return $"[{side1}|{side2}]";
        }

        public override bool Equals(object obj)  // Comparison
        {
            if (obj is Domino other)
            {
                return side1 == other.side1 &&
                       side2 == other.side2;
            }

            return false;
        }

        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        public override int GetHashCode()  // GetHash method
        {
            return HashCode.Combine(side1, side2);
        }
    }
}