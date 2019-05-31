using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача: сделать Bubble Sort

            int i, j, temp; //переменные циклов и временная переменная для значения массива
            Boolean sort; //чтобы не пробегать еще раз отсортированный массив

            //ввод размера массива для сортировки
            Console.WriteLine("Enter Array Length: ");
            int lenth = Int32.Parse(Console.ReadLine());
            //ввод размера рандома
            Console.WriteLine("\nEnter Random Size: ");
            int rnd_lenth = Int32.Parse(Console.ReadLine());
            Console.Clear();

            //создание массива
            int[] array = new int[lenth];
            //создание рандома
            Random rnd = new Random();

            //заполнение массива рандомными числами            
            for (i = 0; i < array.Length; i++)
            {
                int rand = rnd.Next(rnd_lenth);
                array[i] = rand;
            }

            //вывод згенерированного массива
            Console.WriteLine("Random Unsorted Array:");
            for (i = 0; i < array.Length; i++)
            {                
                Console.Write(array[i] + " ");
            }

            //сортировка
            for (i = 0; i < array.Length; i++)
            {
                sort = false;
                for (j = 0; j < array.Length - i - 1 ; j++)
                {
                    if (array[j] >= array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        sort = true;
                    }
                }
                if (sort == false)
                {
                    break;
                }
            }

            //встроенная сортировка массива
            //Array.Sort(array);

            //вывод отсортированного массива
            Console.WriteLine("\n\nSorted Array:");
            for (i = 0; i < array.Length; i++)
            {                
                Console.Write(array[i] + " ");
            }
                        
            //чтобы консоль не закрылась
            Console.ReadKey();
        }
    }
}
