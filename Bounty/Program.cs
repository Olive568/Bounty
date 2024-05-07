using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bounty
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int[] array = new int[rnd.Next(20, 200)];
         
            int num = 0;    
            while(true)
            {
                Console.WriteLine("input a number between -100 to 100");
                num = int.Parse(Console.ReadLine());
                if(num < -100 || num > 100)
                {
                    Console.WriteLine("Invalid number");
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("the array has " + array.Length + " numbers");
            Console.ReadKey();
           for(int i =0; i < array.Length - 1; i++) 
            {
                array[i] = rnd.Next(-100,101);
            }
            var timer = new Stopwatch();
            timer.Start();
            var solutions = Finder(array, num);
            timer.Stop();
            TimeSpan timetaken = timer.Elapsed;
            string foo = "Time taken: " + timetaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            // Print out the solutions
            if (solutions.Length > 0)
            {
                int breaker = 0;
                Console.WriteLine("Three solutions");
                foreach (var solution in solutions)
                {
                    if(breaker == 3)
                    {
                        break;
                    }
                    breaker++;
                    Console.WriteLine($"{solution.Item1}, {solution.Item2}, {solution.Item3}");
                }
            }
            else
            {
                Console.WriteLine("No solutions found.");
            }

            Console.ReadKey();
        }

        static Tuple<int, int, int>[] Finder(int[] array, int target)
        {
            Array.Sort(array);
            int length = array.Length;
            var solutions = new System.Collections.Generic.List<Tuple<int, int, int>>();

            for (int i = 0; i < length - 2; i++)
            {
                int left = i + 1;
                int right = length - 1;

                while (left < right)
                {
                    int currentSum = array[i] + array[left] + array[right];
                    if (currentSum == target)
                    {
                        solutions.Add(new Tuple<int, int, int>(array[i], array[left], array[right]));
                        left++;
                        right--;
                    }
                    else if (currentSum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return solutions.ToArray();        }
    }
}