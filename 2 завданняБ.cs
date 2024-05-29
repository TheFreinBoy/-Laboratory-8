using System;
using System.Text;

namespace Lab2b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int number = GetUserInput();
            if (number <= 0)
            {
                Console.WriteLine("Please enter a natural number n.");
                return;
            }
            int[][] sequences = GenerateSequences(number);
            DisplayAllSequences(number, sequences);
            Console.WriteLine(GC.GetTotalMemory(false));   
        }
        static int GetUserInput()
        {
            Console.Write("Enter a natural number n: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number) && number > 0)
            {
                return number;
            }
            else
            {
                return -1; 
            }
        }
        static int[][] GenerateSequences(int n)
        {
            int maxDigitSum = CalculateMaxDigitSum(n);
            int[][] sequences = new int[maxDigitSum + 1][];
            int[] sequenceLengths = new int[maxDigitSum + 1];

            for (int i = 0; i < n; i++)
            {
                int digitSum = CalculateDigitSum(i);
                if (sequences[digitSum] == null)
                {
                    sequenceLengths[digitSum] = CalculateDivisibleCount(n, digitSum);
                    if (digitSum != 0) 
                    {
                        sequences[digitSum] = new int[sequenceLengths[digitSum]];
                        int index = 0;
                        for (int j = 1; j <= n; j++)
                        {
                            if (j % digitSum == 0)
                            {
                                sequences[digitSum][index++] = j;
                            }
                        }
                    }
                }
            }
            return sequences;
        }
        static void DisplayAllSequences(int n, int[][] sequences)
        {
            for (int i = 0; i < n; i++)
            {
                int digitSum = CalculateDigitSum(i);
                Console.Write($"Sequence number {i}: ");
                PrintSequence(sequences[digitSum]);
                Console.WriteLine();
            }
        }
        static int CalculateDigitSum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        static int CalculateDivisibleCount(int n, int digitSum)
        {
            if (digitSum == 0)
                return 0; 

            int count = 0;
            for (int j = 1; j <= n; j++)
            {
                if (digitSum != 0 && j % digitSum == 0) 
                {
                    count++;
                }
            }
            return count;
        }
        static int CalculateMaxDigitSum(int n)
        {
            int maxSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int sum = CalculateDigitSum(i);
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            return maxSum;
        }
        static void PrintSequence(int[] sequence)
        {
            if (sequence == null)
            {
                return;
            }
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write($"{sequence[i]} ");
            }
        }
    }
}
