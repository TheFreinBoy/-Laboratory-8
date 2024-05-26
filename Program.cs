using System;
using System.Text;
class Program
{
    static void Main()
    {
        /*Знищити T елементів, починаючи з номеру К(якщо, починаючи з номера К, елементи є, але менше, чим
        T штук — знищити, скільки є; однак, якщо К від'ємне, не робити нічого).*/
        Console.OutputEncoding = Encoding.UTF8;
        int[] array = EnteringArray();
        Console.Write("Введіть елемент К:");
        int K = int.Parse(Console.ReadLine());
        Console.Write("Введіть елемент Т:");
        int T = int.Parse(Console.ReadLine());
       
        RemoveElements(ref array, K, T);

        PrintArray(array);
    }
    static int[] EnteringArray()
    {
        Console.Write("Введіть елементи масиву через пробіл:");
        string input = Console.ReadLine();
        int[] array = Array.ConvertAll(input.Split(), int.Parse);
        return array;
    }
    static void PrintArray(int[] array)
    {
        Console.Write("Відповідь:");
        for (int i = 0;i <array.Length;i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.ReadKey();
    }
    static void RemoveElements(ref int[] array, int K, int T)
    {
        if (K < 0)
        {
            return;
        }
        if (K >= array.Length)
        {
            return;
        }
        int elementsToRemove = Math.Min(T, array.Length - K);
        for (int i = K; i < array.Length - elementsToRemove; i++)
        {
            array[i] = array[i + elementsToRemove];
        }
        Array.Resize(ref array, array.Length - elementsToRemove);
    }
}
