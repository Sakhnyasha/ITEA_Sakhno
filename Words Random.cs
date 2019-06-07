using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_Random
{
    class Program
    {
        static void Main(string[] args)
        {
            //Массив string[]. 
            // а. В массиве количество слов rnd[5,10]. В каждом слове к-ство букв rnd[3,8]. 
            // б. Посчитать общее количество согласных букв во всем массиве

            //к-ство слов [5,10] и размер слова [3, 8] букв
            Random rnd = new Random();
            int words = rnd.Next(5, 10);
            int letters = rnd.Next(3, 8);

            //итоговый массив
            string[] result = new string[words];

            //согласные буквы
            string consonants = "bcdfghjklmnpqrstvwxyz";
            //счетчик для согласных букв
            int counter_letter = 0;
            

            //генерация
            for (int i = 0; i < words; i++)
            {
                for (int j = 0; j < letters; j++)
                {
                    //делаем буковку
                    char char_letter = (char)rnd.Next(97, 122);
                    //проверка на согласные
                    for (int k = 0; k < consonants.Length; k++)
                    {
                        if (char_letter == consonants[k])
                        {
                            counter_letter++;
                        }                            
                    }
                    result[i] = result[i] + char_letter.ToString();
                }
            }

            //вывод результата
            Console.WriteLine("Your Array:");
            for (int i = 0; i < words; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine("\nAmount of consonants:" + counter_letter);

            //чтобы консоль не закрылась
            Console.ReadKey();

        }
    }
}
