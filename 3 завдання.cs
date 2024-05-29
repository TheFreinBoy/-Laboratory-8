using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int rowCount = RowCount();
        int[][] jaggedArray = InputJaggedArray(rowCount);
        int[][] resultArray = RemoveRows(jaggedArray);
        PrintJaggedArray(resultArray);
    }
    static int RowCount()
    {
        Console.Write("Введіть кількість рядків: ");
        return int.Parse(Console.ReadLine());
    }
    static int[][] InputJaggedArray(int rowCount)
    {
        int[][] jaggedArray = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            Console.Write($"Введіть елементи для рядка {i + 1}, розділені пробілами: ");
            string[] input = Console.ReadLine().Split(' ');
            jaggedArray[i] = Array.ConvertAll(input, int.Parse);
        }
        return jaggedArray;
    }
    static int[][] RemoveRows(int[][] array)
    {
        int count = CountRows(array);
        int[][] result = new int[count][];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                result[index++] = array[i];
            }
        }
        return result;
    }

    static int CountRows(int[][] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }

    static void PrintJaggedArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
