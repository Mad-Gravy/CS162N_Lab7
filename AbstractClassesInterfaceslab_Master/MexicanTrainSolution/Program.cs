using System;
using System.Collections.Generic;

namespace MexicanTrainDominos
{
    class Program
    {
        // Time to test!!!
        static void Main(string[] args)
        {
            TestMexicanTrain();
            Console.WriteLine();

            TestPlayerTrain();
            Console.WriteLine();

            TestDominoSort();
            Console.WriteLine();

            TestTrainForEach();

            Console.ReadLine();
        }

        // Tests the Mexican Train. Creates a hand with one domino and plays it on the Mexican Train. The train should accept the domino and the hand should be empty after.
        static void TestMexicanTrain()
        {
            Hand h = new Hand();
            Domino d = new Domino(12, 6);

            h.Add(d);

            MexicanTrain mt = new MexicanTrain(12);
            mt.Play(h, d);

            Console.WriteLine("Testing MexicanTrain");
            Console.WriteLine("Train should contain [12|6]: " + mt);
            Console.WriteLine("Hand should be empty: " + h);
        }

        // Tests the PlayerTrain class. Creates 2 hands: 2 dominoes and 1 domino, and a PlayerTrain. Tests Play, Open, Close, and IsOpen.
        static void TestPlayerTrain()
        {
            Hand h1 = new Hand();
            Hand h2 = new Hand();

            Domino d1 = new Domino(12, 5);
            Domino d2 = new Domino(5, 8);
            Domino d3 = new Domino(3, 4);

            h1.Add(d1);
            h1.Add(d2);
            h2.Add(d3);

            PlayerTrain pt = new PlayerTrain(h1, 12);

            Console.WriteLine("Testing PlayerTrain");
            Console.WriteLine("IsOpen should be false: " + pt.IsOpen);

            pt.Open();
            Console.WriteLine("IsOpen should be true: " + pt.IsOpen);

            pt.Close();
            Console.WriteLine("IsOpen should be false: " + pt.IsOpen);

            pt.Play(h1, d1);

            Console.WriteLine("Train should contain [12|5]: " + pt);
            Console.WriteLine("Hand 1 should contain [5|8]: " + h1);
        }

        // Tests IComparable<Domino>.
        // Dominoes should sort from lowest Score to highest Score.
        static void TestDominoSort()
        {
            List<Domino> dominos = new List<Domino>();

            dominos.Add(new Domino(6, 6)); // Score 12
            dominos.Add(new Domino(1, 2)); // Score 3
            dominos.Add(new Domino(4, 5)); // Score 9

            dominos.Sort();

            Console.WriteLine("Testing Domino Sort");
            Console.WriteLine("Expected order: [1|2], [4|5], [6|6]");

            foreach (Domino d in dominos)
            {
                Console.WriteLine(d + " Score: " + d.Score);
            }
        }

        // Tests IEnumerable<Domino>.
        // This confirms that a Train can be used in a foreach loop.
        static void TestTrainForEach()
        {
            Hand h = new Hand();

            Domino d1 = new Domino(12, 5);
            Domino d2 = new Domino(5, 8);

            h.Add(d1);
            h.Add(d2);

            MexicanTrain mt = new MexicanTrain(12);

            mt.Play(h, d1);
            mt.Play(h, d2);

            Console.WriteLine("Testing foreach with Train");
            Console.WriteLine("Expected output: [12|5] and [5|8]");

            foreach (Domino d in mt)
            {
                Console.WriteLine(d);
            }
        }
    }
}