using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Number_Analys
{
    class Program
    {
        static void Main(string[] args)
        {
            //Загадывается рандомное число от 0 до 1000000.
            //Определить:
            //1. Сколько цифр в числе
            //2. Сумму цифр кратных 3
            //3. Количество нечетных цифр
                        
            //создаем рандомное число от 0 до 1000000
            Random rnd = new Random();
            int number_0 = rnd.Next(0, 1000000);
            
            //Константы
            const int MULTIPLE = 3;
            const int ODD = 2;

            //вывод рандомного числа
            Console.WriteLine("The number is: " + number_0);

            //ОПРЕДЕЛЕНИЕ КОЛИЧЕСТВА ЦИФР В ЧИСЛЕ
            //если рандомное число 0: количество цифр: 1      
            int number_1 = number_0; //чтобы не перезаписалось начальное рандомное число
            int num_of_digit = (number_0 == 0) ? 1 : 0; //тернарка - вместо IF (number == 0) {num_of_digit = 1}
            while (number_1 > 0)
            {
                num_of_digit++;
                number_1 = number_1 / 10;
            }
            Console.WriteLine("\nNumber of digits: " + num_of_digit);

            //СУММА ЧИСЕЛ КРАТНЫХ MULTIPLE=3
            //0 кратное 3
            int number_2 = number_0; //чтобы не перезаписалось начальное рандомное число
            int sum_mult3 = 0;
            while (number_2 != 0)
            {
                if (number_2 % 10 % MULTIPLE == 0)
                {
                    sum_mult3 = sum_mult3 + (number_2 % 10);
                }
                number_2 = number_2 / 10;
            }
            Console.WriteLine("Summ of digits wich multiple 3: " + sum_mult3);

            //ОПРЕДЕЛЕНИЕ КОЛИЧЕСТВА НЕЧЕТНЫХ ЦИФР В ЧИСЛЕ
            //0 - четное число
            int number_3 = number_0; //чтобы не перезаписалось начальное рандомное число
            int counter_odd = 0; 
            while (number_3 != 0)
            {
                if (number_3 % 10 % ODD != 0)
                {
                    counter_odd++;
                }
                number_3 = number_3 / 10;
            }
            Console.WriteLine("Number of odd numbers: " + counter_odd);

            Console.WriteLine("\n=============================");
            Console.WriteLine("Press ENTER button to quit!");
            
            //чтобы консоль не закрывалась
            Console.ReadKey();

            //закрыть консоль
            Environment.Exit(0);

        }
    }
}
