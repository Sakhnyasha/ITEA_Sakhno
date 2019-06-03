using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Month
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача: Придумать алгоритм для вывода количества дней каждого месяца в году
            
            //массив на 12 элементов
            int[] month = new int[12];
            int i;

            //ввод года
            Console.WriteLine("Enter year:");
            int year = Int32.Parse(Console.ReadLine());
            Console.Clear();

            //опредиление к-ства дней в месяце
            for (i=0; i<month.Length; i++)
            {
                //до августа  (i=7)
                if (i <= 6 && i % 2 == 0)                  
                    month[i] = 31;
                else if(i <= 6 && i % 2 != 0)
                {
                    if (i == 1)
                    {
                        //проверка на высокосность года
                        if (year % 4 == 0)
                            month[i] = 29;
                        else
                            month[i] = 28;
                    }
                    else
                        month[i] = 30;
                }
                //после августа  (i=7)
                else if (i > 6 && i % 2 != 0)
                    month[i] = 31;
                else if (i > 6 && i % 2 == 0)
                    month[i] = 30;      
            }

            //вывод ответа
            Console.WriteLine("Year:\n" + year);
            Console.Write("------------------\n");

            for (i = 0; i < month.Length; i++)
            {
                Console.WriteLine("Month #" + (((i + 1)<10)?"0"+(i+1):""+(i+1)) + ": " + month[i] + " days");
            }

            //чтобы консоль не закрывалась
            Console.ReadKey();
        }
    }
}
