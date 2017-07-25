using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sample1 = new List<int>() { 1, 3, 1, 4, 5, 6, 3, 2 };
            List<int> sample2 = new List<int>() { 1, 1, 2, 2, 2, 3 };
            CountingDuplicates(sample1);
            CountingDuplicates(sample2);
            List<int> sample3number = new List<int>() { 1, 4, 2, 4 };
            List<int> sample3maxes = new List<int>() { 3, 5 };
            CountTheMaxes(sample3number, sample3maxes);
            List<int> sample4number = new List<int>() { 2, 10, 5, 4, 8 };
            List<int> sample4maxes = new List<int>() { 3, 1, 7, 8 };
            CountTheMaxes(sample4number, sample4maxes);
            Console.ReadKey();

        }

        static void CountingDuplicates(List<int> numbers)
        {
            if (numbers.Count <= 1 || numbers.Count >= 1000)
            {
                Console.WriteLine("The set of numbers does not fit the contrains");
                return;
            }
            if (numbers.Exists(x => x < 1) || numbers.Exists(x => x > 1000))
            {
                Console.WriteLine("A number in the set does not fit the contrains");
                return;
            }

            List<int> unique = new List<int>();
            List<int> duplicate = new List<int>();
            foreach (int number in numbers)
            {
                if (unique.Contains(number))
                {
                    if (!duplicate.Contains(number))
                    {
                        duplicate.Add(number);
                    }
                }
                else
                {
                    unique.Add(number);
                }

            }

            Console.WriteLine("The duplicated numbers are: ");
            foreach (int number in duplicate)
            {
                Console.WriteLine(number + ";");
            }

            Console.WriteLine("Were found {0} duplicates in the sample", duplicate.Count);
            Console.WriteLine(" ");

        }

        static void CountTheMaxes(List<int> numbers, List<int> maxes)
        {
            numbers.Sort();
            maxes.Sort();
            List<Maxesi> maxesis = new List<Maxesi>();

            foreach (int max in maxes)
            {
                foreach (int number in numbers)
                {

                    if (maxesis.Any(x => x.max == max))
                    {
                        if (number <= max)
                        {
                            maxesis.FirstOrDefault(x => x.max == max).number++;
                        }
                    }
                    else
                    {
                        if (number <= max)
                        {
                            maxesis.Add(new Maxesi() { max = max, number = 1 });
                        }
                        else
                        {
                            maxesis.Add(new Maxesi() { max = max, number = 0 });
                        }

                    }

                }
            }
            Console.WriteLine("In this sample we have:");
            foreach (var maxesi in maxesis)
            {
                Console.WriteLine("The number {0} with {1} less or equal numbers", maxesi.max, maxesi.number);
            }
            Console.WriteLine(" ");
        }

    }

    public class Maxesi
    {
        public int max { get; set; }
        public int number { get; set; }
    }
}