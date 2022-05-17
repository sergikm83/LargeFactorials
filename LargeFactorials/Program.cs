using System;
using System.Collections.Generic;
using System.Text;

namespace LargeFactorials
{
    // https://www.codewars.com/kata/557f6437bf8dcdd135000010/train/csharp

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 150; i++)
                Console.WriteLine($"{i:00}! = {Factorial(i)}");
        }
        // функция вычисления факторила
        public static string Factorial(int n)
        {
            // искомое значение будет здесь
            List<int> desiredValue = new List<int>();
            // добавляем 1
            desiredValue.Add(1);
            int idx = 1;
            
            // цикл от 2-х до n
            for (int i = 2; i <= n; i++)
            {
                // получаем значение индекса и выполняем
                // порязрядное умножение на i-ое число
                idx = BitwiseMultiplication(i, desiredValue, idx);
            }

            // сюда запишем результат, который надо вернуть
            StringBuilder result = new StringBuilder();
            // обратный цикл по всем элементам list'а
            // и запись в result
            for (int i = idx - 1; i >= 0; i--)
                result.Append(desiredValue[i]);
            return result.ToString();
        }
        // поразрядное умножение и возврат индекса
        static int BitwiseMultiplication(int multiplier, List<int> desiredValue, int idx)
        {
            int seniorRank = 0; // старший разряд

            for (int i = 0; i < idx; i++)
            {
                // промежуточное вычисление (поразрядно от младшего к старшему)
                int staging = desiredValue[i] * multiplier + seniorRank;
                // записываем в i-ый разряд остаток от деления на 10
                desiredValue[i] = staging % 10;
                // результат вычисления (целая часть), который пойдет в старший разряд
                seniorRank = staging / 10;
            }
            // если в старший разряд есть что писать
            while (seniorRank != 0)
            {
                // добавляем новый элемент (старший разряд)
                // и добавляем в него значение
                desiredValue.Add(seniorRank % 10);
                // уменьшаем целую часть на 10
                seniorRank = seniorRank / 10;
                // увеличиваем индекс
                idx++;
            }
            return idx;
        }
    }

}
