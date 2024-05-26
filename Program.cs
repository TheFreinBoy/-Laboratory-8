using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int a = 1; // мінімальна кількість стовпців
        int b = 5; // максимальна кількість стовпців
        int rowCount = 4; // кількість рядків у матриці C

        int[][] C = CreateRandomMatrix(rand, a, b, rowCount);
        PrintMatrix("Матриця C:", C);

        Queue<int> F = CopyElementsToQueue(C);
        F = SortQueue(F);

        int[,] Q = CreateSquareMatrix(F);
        PrintMatrix("Квадратна матриця Q:", Q);
    }

    static int[][] CreateRandomMatrix(Random rand, int a, int b, int rowCount)
    {
        int[][] C = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            int colCount = rand.Next(a, b + 1);
            C[i] = new int[colCount];
            for (int j = 0; j < colCount; j++)
            {
                C[i][j] = rand.Next(100); // випадкові числа від 0 до 99
            }
        }
        return C;
    }

    static void PrintMatrix(string title, int[][] matrix)
    {
        Console.WriteLine(title);
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

    static void PrintMatrix(string title, int[,] matrix)
    {
        Console.WriteLine(title);
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static Queue<int> CopyElementsToQueue(int[][] matrix)
    {
        Queue<int> queue = new Queue<int>();
        foreach (var row in matrix)
        {
            foreach (var elem in row)
            {
                queue.Enqueue(elem);
            }
        }
        return queue;
    }

    static Queue<int> SortQueue(Queue<int> queue)
    {
        int[] sortedArray = queue.ToArray();
        Array.Sort(sortedArray);
        return new Queue<int>(sortedArray);
    }

    static int[,] CreateSquareMatrix(Queue<int> queue)
    {
        int totalElements = queue.Count;
        int n = (int)Math.Floor(Math.Sqrt(totalElements));

        int[,] matrix = new int[n, n];
        for (int i = 0; i < n * n; i++)
        {
            matrix[i / n, i % n] = queue.Dequeue();
        }
        return matrix;
    }
}
