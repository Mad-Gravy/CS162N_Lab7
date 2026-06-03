using System;

namespace MexicanTrainDominos
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMexicanTrain();
            Console.WriteLine();

            TestPlayerTrain();

            Console.ReadLine();
        }

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
    }
}