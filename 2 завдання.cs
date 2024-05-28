using System;
using System.Collections.Generic;
using System.Text;

public class Class2
{
    static void Main()
    {
        //2 блок
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть число n:");
        int n = int.Parse(Console.ReadLine());    
        Solution(n);
        Console.WriteLine(GC.GetTotalMemory(false));
        GC.Collect(); 
        Console.WriteLine(GC.GetTotalMemory(false));         
    }
    static void Solution(int n)
    {
        var jaggedArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = MakeArray(i, n);
        }
        PrintNumbers(jaggedArray);
    }   
    static int[] MakeArray(int i, int n)
    {
        Queue<int> numbers = new Queue<int>();
        if (i >0)
        {
            int sum = SumOfDigits(i);
            for (int j = 1; j <= n; j++)
            {                    
                if (j% sum ==0)
                {
                 numbers.Enqueue(j);
                }
            } 
        }                  
        return numbers.ToArray();
    }
    
    static int SumOfDigits(int number)
    {      
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }
    static void PrintNumbers(int[][] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers[i].Length; j++)
            {
                Console.Write(numbers[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
