using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "Москва", "Санкт-Петербург", "Воронеж" };
            int[] a = { 7, 17, 1, 9, 1, 17, 56, 56, 23 }, b = { 56, 17, 17, 1, 23, 34, 23, 1, 8, 1 };
            Console.WriteLine("Task 1\n" + PrintCities(cities));
            Console.WriteLine("Task 2\n27 => " + Round(27) + ", " + "27.8 => " + Round(27.8) + ", " + "41.7 => " + Round(41.7));
            Console.WriteLine("Task 3\n" + Declension(25) + ", " + Declension(41) + ", " + Declension(1048));
            Console.WriteLine("Task 4\n1: " + IsPrime(1) + ", 4: " + IsPrime(4) + ", 7: " + IsPrime(7) + ", 102: " + IsPrime(102) + ", 67: " + IsPrime(67));
            Console.WriteLine("Task 5\n");
            foreach (int i in Coincidences(a, b))
                Console.Write(i + " ");

        }
        static string PrintCities(string[] array) //5 минут
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i] + ", ";
            return result.Remove(result.Length - 2, 2) + ".";
        }
        static int Round(double value) //5 минут
        {
            if (value % 5 < 2.5)
                return (int)(value / 5) * 5;
            else
                return (int)(value / 5 + 1) * 5;
        }
        static string Declension(int value) //5 минут
        {
            string word = "компьютер";
            if (value % 100 > 10 && value % 100 < 20)
                return value + " " + word + "ов";
            else if (value % 10 == 1)
                return value + " " + word;
            else if (value % 10 > 1 && value % 10 < 5)
                return value + " " + word + "а";
            else return value + " " + word + "ов";
        }
        static bool IsPrime(int value) //5 минут
        {
            bool result = true;
            if (value > 1)
                for (int i = 2; i < value; i++)
                {
                    if (value % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            else result = false;
            return result;
        }
        static List<int> Coincidences(int[] array1, int[] array2) //20 минут
        {
            List<int> result = new List<int>();
            Dictionary<int, int> array_unique_1= new Dictionary<int, int>();
            Dictionary<int, int> array_unique_2 = new Dictionary<int, int>();
            int temp = -1;
            Array.Sort(array1);
            Array.Sort(array2);

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != temp)
                    array_unique_1.Add(array1[i], 1);
                else array_unique_1[array1[i]]++;
                
                temp = array1[i];
            }

            temp = -1;
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i] != temp)
                    array_unique_2.Add(array2[i], 1);
                else array_unique_2[array2[i]]++;

                temp = array2[i];
            }

            foreach (KeyValuePair<int, int> keyValue_1 in array_unique_1)
                foreach (KeyValuePair<int, int> keyValue_2 in array_unique_2)
                    if (keyValue_1.Key == keyValue_2.Key && keyValue_1.Value >= 2 && keyValue_2.Value >= 2)
                        result.Add(keyValue_2.Key);
            return result;
        }
    }
}
