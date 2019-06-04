using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Нарисовать рамочку, а внутри крест. Должно быть "масштабируемым"

            //задаем размер
            Console.WriteLine("Enter size (odd number):");
            
            //проверка на ввод только цифр
            //если ввести только ENTER будет ошибка: неверный формат
            bool inputComplete = false;
            StringBuilder sb = new StringBuilder();
            while (!inputComplete)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (char.IsDigit(key.KeyChar))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    inputComplete = true;
                }
            }

            int size = Int32.Parse(sb.ToString());

            //задаем массив массивов
            char[][] arr = new char[size][];

            //заполнение * и " "
            for (int i = 0; i < arr.Length; i++)
            {
                char[] temp = new char[size]; // чтобы можно было написать что-то типа char[][] arr = new char[size][size], но синтаксис не позволяет это написаить во вторые скобки
                for (int j = 0; j < temp.Length; j++)
                {
                    if (i == 0 || i == arr.Length - 1 || j == 0 || j == temp.Length - 1 || (i == (arr.Length / 2) && j > 1 && j < temp.Length - 2) || (j == (temp.Length / 2) && i > 1 && i < arr.Length - 2))
                    {
                        temp[j] = '*';
                    }
                    else
                    {
                        temp[j] = ' ';
                    }
                }
                arr[i] = temp;
            }

            Console.WriteLine();
            //вывод массива массивов
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j]);
                }
                Console.WriteLine();
            }

            //чтобы консоль не закрывалась
            Console.ReadKey();
        }
    }
}
