using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Random_Gess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача:        Компютер загадывает рандомное число от 0 до 100.
            //               У пользователя есть 5 попыток, чтобы угадать это число.
            //Формат вывода: Try #1: Enter your number
            //               Answer #1: Wrong! My number is smaller! / is bigger!
            //Результат:     You won! / You lose!


            //создаем рандомное число от 0 до 100
            Random rnd = new Random();
            int gess_num = rnd.Next(101); 

            Console.WriteLine("Hello! I guess a number! Try to guess!");

            //число пользователя
            int user_num;

            //Console.WriteLine(gess_num);

            //крутите барабан! всего 5 попыток
            for (int i=0; i <=4; i++)
            {
                Console.WriteLine("\nTry #" + (i+1) + ": Enter your number!\n");
                user_num = Convert.ToInt32(Console.ReadLine());
                
                //если угадали число
                if (user_num == gess_num)
                {
                    Console.Clear();
                    Console.WriteLine("Hooray! You won! It's " + gess_num.ToString());                   
                    break;
                }

                else if (user_num > gess_num)
                {
                    Console.WriteLine("\nAnswer #" + (i + 1) + ": Wrong! My number is smaller!");
                    Console.WriteLine("\n=====================================================");
                }

                else if (user_num < gess_num)
                {
                    Console.WriteLine("\nAnswer #" + (i + 1) + ": Wrong! My number is bigger!");
                    Console.WriteLine("\n=====================================================");
                }
                
                //если не угадали за 5 попыток вывод сообщения о провале
                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry! You lose! It was " + gess_num.ToString());
                }
            }

            Console.WriteLine("\n===========================");
            Console.WriteLine("Press ENTER button to quit!");

            //чтобы консоль не закрывалась
            Console.ReadKey();

            //закрыть консоль
            Environment.Exit(0);

        }
    }
}
