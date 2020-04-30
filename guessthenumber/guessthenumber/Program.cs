using System;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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
            string path2 = @"C:\\GAN\\Highscore2nd.txt";
            string path3 = @"C:\\GAN\\Highscore3rd.txt";
            RandomCode(random, guess, attempts, path, path2, path3, folder);
        }
        private static void RandomCode(Random random, int guess, int attempts, string path, string path2, string path3, string folder)
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
                return;
            }

            else
            {

                System.IO.File.AppendAllText(path, score);
                return;
            }
        }
    }
}
