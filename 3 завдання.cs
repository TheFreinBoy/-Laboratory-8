using System;

class Program
{
    static void Main()
    {
        int[][] jaggedArray = InputJaggedArray();
        int[][] resultArray = RemoveEvenIndexedElements(jaggedArray);
        PrintJaggedArray(resultArray);
    }

    static int[][] InputJaggedArray()
    {
        Console.Write("Введіть кількість рядків: ");
        int rowCount = int.Parse(Console.ReadLine());
        int[][] jaggedArray = new int[rowCount][];
        Console.WriteLine("Введіть масив по-елементно:");
        for (int i = 0; i < rowCount; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            jaggedArray[i] = Array.ConvertAll(input, int.Parse);
        }
        return jaggedArray;
    }

    static int[][] RemoveEvenIndexedElements(int[][] array)
    {
        int[][] result = new int[array.Length][];
        for (int i = 0; i < array.Length; i++)
        {
            int newSize = array[i].Length / 2;
            result[i] = new int[newSize];
            int newIndex = 0;
            for (int j = 1; j < array[i].Length; j += 2)
            {
                result[i][newIndex++] = array[i][j];
            }
        }

        return result;
    }

     static void PrintJaggedArray( int[][] matrix)
    {
        Console.WriteLine(" ");
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
