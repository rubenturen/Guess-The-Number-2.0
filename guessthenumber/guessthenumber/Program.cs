using System;
using System.IO;
using System.Collections.Generic;
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

            var strscore = Convert.ToString(" " + attempts) + Environment.NewLine;

            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
                System.IO.File.AppendAllText(path, strscore);
                string[] Entry = File.ReadAllLines(path);
                var orderedEntries = Entry.OrderBy(x => int.Parse(x.Split(' ')[1]));
                System.IO.File.WriteAllLines(path, orderedEntries);



                Console.WriteLine("Highscores:");
                StreamReader sr = new StreamReader(path);
                var line = sr.ReadLine();
                Console.WriteLine("1st:" + line);
                line = sr.ReadLine();
                Console.WriteLine("2nd:" + line);
                line = sr.ReadLine();
                Console.WriteLine("3rd:" + line);

                return;
            }

            else
            {
                System.IO.File.AppendAllText(path, strscore);
                string[] Entry = File.ReadAllLines(path);
                var orderedEntries = Entry.OrderBy(x => int.Parse(x.Split(' ')[1]));
                System.IO.File.WriteAllLines(path, orderedEntries);

                Console.WriteLine("Highscores:");
                StreamReader sr = new StreamReader(path);
                var line = sr.ReadLine();
                Console.WriteLine("1st:" + line);
                line = sr.ReadLine();
                Console.WriteLine("2nd:" + line);
                line = sr.ReadLine();
                Console.WriteLine("3rd:" + line);

                return;
            }
        }
    }
}
