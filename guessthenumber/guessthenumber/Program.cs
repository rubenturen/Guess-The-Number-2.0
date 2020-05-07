using System;
using System.IO;
using System.Linq;

namespace guessthenumber
{
    class Program
    {
        public static void Main(string[] args)
        {

            Random random = new Random();
            int guess = 0;
            int attempts = 1;
            string folder = @"C:\\GAN";
            string path = @"C:\\GAN\\Highscore.txt";
            RandomCode(random, guess, attempts, path, folder);
        }
        private static void RandomCode(Random random, int guess, int attempts, string path, string folder)
        {
            int num = random.Next(1, 100);

        outer: 

            Console.WriteLine("choose a number between 1 and 100");

            guess = Convert.ToInt32(Console.ReadLine());

            while (guess != num)
            {
                if (guess > num)
                {
                    Console.WriteLine("the number was to large");
                    attempts = attempts + 1;
                    goto outer;
                }
                else
                {
                    Console.WriteLine("the number was to small");
                    attempts = attempts + 1;
                    goto outer;
                }

            }
            Console.WriteLine("you guessed the number it took you " + attempts + " attempts");

            var score = Convert.ToString(attempts) + Environment.NewLine;

            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
                System.IO.File.AppendAllText(path, score);
                string[] sortedtext = File.ReadAllLines(path);
                var orderedEntries = sortedtext.OrderBy(x => int.Parse(x.Split(' ')[1]));

                foreach (var score1 in orderedEntries)
                {
                    Console.WriteLine(sortedtext);
                }
                return;
            }

            else
            {

                System.IO.File.AppendAllText(path, score);
                string[] Entry = File.ReadAllLines(path);
                var orderedEntries = Entry.OrderByDescending(x => int.Parse(x.Split(' ')[1]));

                foreach (var score1 in orderedEntries)
                {
                    Console.WriteLine(Entry);
                }

            }
        }
    }
}
