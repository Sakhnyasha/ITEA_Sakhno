using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод любого ФИО одной строкой
            //Результат: Фамилия И. О.

            Console.WriteLine("Enter: Family Name (SPACEBAR key) Name (SPACEBAR key) Father's Name");
            Console.WriteLine("\nPress ENTER button!\n");

            //только буквы латинского алфавита, ентер и пробел
            bool inputComplete = false;
            StringBuilder sb = new StringBuilder();
            while (!inputComplete)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    inputComplete = true;
                }

                if (key.Key == ConsoleKey.Spacebar)
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());
                }

                if (char.IsLetter(key.KeyChar))
                {
                    //если кирилица
                    if (key.KeyChar >= 'Ё' && key.KeyChar <= 'ё')
                    {
                        Console.WriteLine("Change keyboard layout on ENG!");
                        
                    }
                    //если латиница
                    else
                    {
                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar.ToString());
                    }                    
                }                
            }

            //разбивает на массив по указателю
            String[] arr = sb.ToString().Split(' ');

            Console.Clear();
            Console.WriteLine("Family Name and initials:");
            Console.WriteLine(arr[0].ToString().Substring(0, 1).ToUpper() + arr[0].ToString().Substring(1) + " " + arr[1].ToString().Substring(0, 1).ToUpper() + ". " + arr[2].ToString().Substring(0, 1).ToUpper() + ".");


            Console.WriteLine("\n===========================");
            Console.WriteLine("Press ENTER button to quit!");

            //чтобы консоль не закрывалась
            Console.ReadKey();

            //закрыть консоль
            Environment.Exit(0);

        }
    }
}
