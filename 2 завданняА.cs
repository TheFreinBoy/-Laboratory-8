using System;
using System.Text;
namespace lab2a
{
    internal class Program    
    {
        static void Main(string[] args)       
        {
            Console.OutputEncoding = Encoding.UTF8;
            int number = GetUserInput();
            int[][] sequences = GenerateSequences(number);
            DisplayAllSequences(number, sequences);    
            Console.WriteLine(GC.GetTotalMemory(false));        
        }

        static int GetUserInput()       
        {
            Console.Write("Enter a natural number n: ");           
            return int.Parse(Console.ReadLine());
        }

        static int[][] GenerateSequences(int n)        
        {
            int[][] sequences = new int[n][];
            for (int i = 0; i < n; i++)
            {                
                int digitSum = CalculateDigitSum(i);
                int count = CalculateDivisibleCount(n, digitSum);
                sequences[i] = new int[count];
                int index = 0;                
                for (int j = 1; j <= n; j++)
                {                    
                    if (digitSum == 0 || j % digitSum == 0)
                    {                        
                        sequences[i][index++] = j;
                    }                
                }
            }
            return sequences;        
        }

        static void DisplayAllSequences(int n, int[][] sequences)
        {
            for (int i = 0; i < n; i++)            
            {
                Console.Write($"Sequence {i}: ");                
                PrintSequence(sequences[i]);
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
            int count = 0;            
            for (int j = 1; j <= n; j++)
            {                
                if (digitSum == 0 || j % digitSum == 0)
                {                    
                    count++;
                }            
            }
            return count;        
        }

        static void PrintSequence(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write($"{sequence[i]} ");
            }
        }
    }
}
