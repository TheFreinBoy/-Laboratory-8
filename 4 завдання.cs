﻿using System;
using System.Text;

class Program
{
    static void Main()
    {       
        Console.OutputEncoding = Encoding.UTF8;
        int a = 1;
        int b = 5;
        Console.Write("Введіть кількість рядків:");      
        int rowCount = int.Parse(Console.ReadLine());
        Console.Write("\n");
        int[][] C = CreateRandomMatrix(a, b, rowCount);
        PrintMatrixC("Матриця C:", C);
        Console.Write("\n");
        int[] F = CopyElementsToArray(C);
        Array.Sort(F);
        int[,] Q = CreateSquareMatrix(F);
        PrintMatrixQ("Квадратна матриця Q:", Q);
    }

    static int[][] CreateRandomMatrix(int a, int b, int rowCount)
    {
        Random rand = new Random();
        int[][] C = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            int colCount = rand.Next(a, b + 1);
            C[i] = new int[colCount];
            for (int j = 0; j < colCount; j++)
            {
                C[i][j] = rand.Next(100);
            }
        }
        return C;
    }

    static void PrintMatrixC(string title, int[][] matrix)
    {
        Console.WriteLine(title);
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void PrintMatrixQ(string title, int[,] matrix)
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

    static int[] CopyElementsToArray(int[][] matrix)
    {
        int totalElements = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            totalElements += matrix[i].Length;
        }

        int[] array = new int[totalElements];
        int index = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                array[index++] = matrix[i][j];
            }
        }
        return array;
    }

    static int[,] CreateSquareMatrix(int[] array)
    {
        int totalElements = array.Length;
        int n = (int)Math.Floor(Math.Sqrt(totalElements));

        int[,] matrix = new int[n, n];
        for (int i = 0; i < n * n; i++)
        {
            matrix[i / n, i % n] = array[i];
        }
        return matrix;
    }
}
