using System;
using System.Collections.Generic;

namespace MexicanTrainDominos
{
    class Program
    {
        // Time to test!!!
        static void Main(string[] args)
        {
            TestTrain();
            Console.WriteLine();

            TestMexicanTrain();
            Console.WriteLine();

            TestPlayerTrain();
            Console.WriteLine();

            TestDominoSort();
            Console.WriteLine();

            TestTrainForEach();

            Console.ReadLine();
        }

        // Tests the abstract parent class Train: Constructor, Count, EngineValue, IsEmpty, LastDomino, PlayableValue, Indexer, Play, and ToString methods.
        static void TestTrain()
        {
            Hand h = new Hand();

            Domino d1 = new Domino(12, 5);
            Domino d2 = new Domino(5, 8);

            h.Add(d1);
            h.Add(d2);

            MexicanTrain train = new MexicanTrain(12);

            Console.WriteLine("Testing Train Class");
            Console.WriteLine("Count should be 0: " + train.Count);
            Console.WriteLine("EngineValue should be 12: " + train.EngineValue);
            Console.WriteLine("IsEmpty should be True: " + train.IsEmpty);
            Console.WriteLine("PlayableValue should be 12: " + train.PlayableValue);

            train.Play(h, d1);

            Console.WriteLine();
            Console.WriteLine("After first play:");

            Console.WriteLine("Count should be 1: " + train.Count);
            Console.WriteLine("IsEmpty should be False: " + train.IsEmpty);
            Console.WriteLine("LastDomino should be [12|5]: " + train.LastDomino);
            Console.WriteLine("PlayableValue should be 5: " + train.PlayableValue);
            Console.WriteLine("Indexer [0] should be [12|5]: " + train[0]);

            train.Play(h, d2);

            Console.WriteLine();
            Console.WriteLine("After second play:");

            Console.WriteLine("Count should be 2: " + train.Count);
            Console.WriteLine("LastDomino should be [5|8]: " + train.LastDomino);
            Console.WriteLine("PlayableValue should be 8: " + train.PlayableValue);
            Console.WriteLine("Train contents: " + train);
        }

        // Tests the derived class MexicanTrain: Constructor, Add, IsPlayable
        static void TestMexicanTrain()
        {
            Hand h = new Hand();
            Domino d = new Domino(12, 6);

            h.Add(d);

            MexicanTrain mt = new MexicanTrain(12);

            bool mustFlip;

            Console.WriteLine("Testing MexicanTrain IsPlayable");
            Console.WriteLine("Domino [12|6] should be playable: " + mt.IsPlayable(h, d, out mustFlip));
            Console.WriteLine("mustFlip should be false: " + mustFlip);

            mt.Play(h, d);

            Console.WriteLine("Testing MexicanTrain");
            Console.WriteLine("Train should contain [12|6]: " + mt);
            Console.WriteLine("Hand should be empty: " + h);
        }

        // Tests the derived class PlayerTrain: Constructor, Add, IsPlayable, IsOpen, Open, Close, Play
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

            bool mustFlip;

            Console.WriteLine("Testing PlayerTrain IsPlayable");
            Console.WriteLine("Owner hand should be able to play [12|5]: " + pt.IsPlayable(h1, d1, out mustFlip));
            Console.WriteLine("mustFlip should be false: " + mustFlip);

            Console.WriteLine("Other hand should NOT be able to play [3|4] while train is closed: " + pt.IsPlayable(h2, d3, out mustFlip));
            Console.WriteLine("mustFlip should be false: " + mustFlip);

            pt.Open();
            Console.WriteLine("Other hand still should NOT be able to play [3|4] because it does not match 12: " + pt.IsPlayable(h2, d3, out mustFlip));

            Domino d4 = new Domino(7, 12);
            h2.Add(d4);

            Console.WriteLine("Other hand should be able to play [7|12] while train is open: " + pt.IsPlayable(h2, d4, out mustFlip));
            Console.WriteLine("mustFlip should be true: " + mustFlip);

            pt.Close();

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