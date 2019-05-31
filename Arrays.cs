using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //есть 3 массива: byte, short, int размерностью 10 эл. 
            //нужно положить рандомное число в 1 из этих массивов. число в диапазоне от 0 до int.MaxValue
            //нужно заполнить все 3 массива и вывести к-ство итераций

            int counter = 0;
            int length = 10;
            int count_i = 0;
            int count_s = 0;
            int count_b = 0;

            //масивы
            byte[] b_array = new byte[length];
            short[] s_array = new short[length];
            int[] i_array = new int[length];


            //обьявление рандома
            Random rnd = new Random ();
            
            //заполнение массивов
            do
            {                
                int number = rnd.Next(int.MaxValue);
                counter++;

                if(number < byte.MaxValue && count_b < length)
                {
                    b_array [count_b] = Convert.ToByte(number);
                    count_b++;
                }
                else if (number < short.MaxValue && count_s < length)
                {
                    s_array[count_s] = Convert.ToInt16(number);
                    count_s++;
                }
                else if (number < int.MaxValue && count_i < length)
                {
                    i_array[count_i] = Convert.ToInt32(number);
                    count_i++;
                }
            }            
            while (count_b != length || count_s != length || count_i != length);

            //вывод количества итераций
            Console.WriteLine("Number of iterations: " + counter);
            Console.ReadKey();
        }
    }
}
