using System;

namespace MexicanTrainDominos
{
    public class Domino : IComparable<Domino> // Class representing a single domino
    {
        private int side1;
        private int side2;

        // Default Constructor
        public Domino()  
        {
            side1 = 0;
            side2 = 0;
        }

        // Overloaded Constructor
        public Domino(int side1, int side2)
        {
            Side1 = side1;
            Side2 = side2;
        }


        // Getters and Setters for the two sides of the domino
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

        // Method to return the total number of pips on the domino
        public int Score
        {
            get
            {
                return side1 + side2;
            }
        }

        // CompareTo method, compares two dominos based on their score
        public int CompareTo(Domino other)
        {
            return Score.CompareTo(other.Score);
        }

        // Equals method, checks if two dominos have identical side values
        public override bool Equals(object obj)
        {
            if (obj is Domino other)
            {
                return side1 == other.side1 &&
                       side2 == other.side2;
            }

            return false;
        }

        // Method to flip the domino
        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        // ToString Method
        public override string ToString()  
        {
            return $"[{side1}|{side2}]";
        }

        // GetHashCode method
        public override int GetHashCode()
        {
            return HashCode.Combine(side1, side2);
        }
    }
}