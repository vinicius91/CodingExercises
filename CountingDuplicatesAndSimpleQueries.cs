using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// This is the code for the exercises Simple Queries and CountDuplicates
/// </summary>


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
        /// <summary>
        /// Consider an array of n integers, numbers. We define a non-unique value of numbers to be an integer that appears at least twice in the array. For example, if numbers = [1, 1, 2, 2, 2, 3, 4, 3, 9], then there are a total of 3 non-unique values in the array (i.e., 1, 2, and 3).
        ///
        ///Complete the countDuplicates function in the editor below. It has 1 parameter: an array of integers, numbers. It must return an integer denoting the number of non-unique values in the numbers array.
        ///
        ///Input Format Locked stub code in the editor reads the following input from stdin and passes it to the function: The first line contains an integer, n, denoting the size of the numbers array. Each line i of the n subsequent lines (where 0 ≤ i &lt; n) contains an integer describing the value of numbersi.
        ///
        ///Constraints 1 ≤ n ≤ 1000 1 ≤ numbersi ≤ 1000
        ///
        ///Output Format The function must return an integer denoting the number of non-unique values in numbers. This is printed to stdout by locked stub code in the editor.
        /// </summary>
        /// <param name="numbers">The sample that should be provided and analysed for duplicates</param>
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
        /// <summary>
        /// Amy has an array, nums, of n positive integers and another array, maxes, of m positive integers. For each maxesi in maxes, she wants to know the total number of elements in nums which are less than or equal to that maxesi. For example, if nums = [1, 2, 3] and maxes = [2, 4], then there are 2 elements in nums that are ≤ maxes0 (which is 2) and 3 elements in nums that are ≤ maxes1 (which is 4). We can store these respective answers in another array, answer = [2, 3].
        ///
        ///Complete the counts function in the editor below. It has two parameters: An array, nums, of n positive integers. An array, maxes, of m positive integers. The function must return an array of m positive integers in which the integer at each index i (where 0 ≤ i &lt; m) denotes the total number of elements numsj (where 0 ≤ j &lt; n) satisfying numsj ≤ maxesi.
        ///
        ///Input Format Locked stub code in the editor reads the following input from stdin and passes it to the function: The first line contains an integer, n, denoting the number of elements in nums. Each line j of the n subsequent lines (where 0 ≤ j &lt; n) contains an integer describing numsj. The next line contains an integer, m, denoting the number of elements in maxes. Each line i of the m subsequent lines (where 0 ≤ i &lt; m) contains an integer describing maxesi.
        ///
        ///Constraints 2 ≤ n, m ≤ 105 1 ≤ numsj ≤ 109, where 0 ≤ j &lt; n. 1 ≤ maxesi ≤ 109, where 0 ≤ i &lt; m.
        /// </summary>
        /// <param name="numbers">The numbers that should be evaluated</param>
        /// <param name="maxes">The maxes that will evaluate the numbers</param>
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