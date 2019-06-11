using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание: иммитация работы с БД
            //Есть массив string[3][3], который представляет собой БД: "Ann 20 Bucha", "Jack 20 Irpen", "Sofy 19 Bucha"
            //По вводу запроса получить вывод целой строки/строк, где было найдено все совпадения
            
            //первоначальная БД
            string[] arrDB = { "Ann 20 Bucha", "Jack 20 Irpen", "Sofy 19 Bucha" };

            //разбивка на элементы первоначальной БД
            string[] arrReck1 = arrDB[0].Split(' ');
            string[] arrReck2 = arrDB[1].Split(' ');
            string[] arrReck3 = arrDB[2].Split(' ');

            //запрос к пользователю
            Console.WriteLine("Hello! Enter request:");

            //проверка на ввод только латинских букв, пробела и ентера
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (sb.Length < 1)
                    {
                        sb.Append(-1);
                    }
                    Console.WriteLine();
                    break;
                }

                else if (key.Key == ConsoleKey.Spacebar)
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());
                }

                else if (char.IsDigit(key.KeyChar))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());
                }

                else if (char.IsLetter(key.KeyChar))
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

            //парсинг вводимых данных пользователем
            string[] userInputArray = sb.ToString().TrimStart().TrimEnd().Split(' ');                       

            //вывод ответа с БД
            for (int i = 0; i < userInputArray.Length; i++)
            {
                for (int j = 0; j < arrReck1.Length; j++)
                {
                    if (userInputArray[i] == arrReck1[j] || userInputArray[i] == arrReck2[j] || userInputArray[i] == arrReck3[j])
                    {
                        Console.WriteLine("\nResult:");
                        if (userInputArray[i] == arrReck1[j])
                        {
                            Console.WriteLine();
                            for (int k = 0; k < arrReck1.Length; k++)
                            {
                                Console.Write(arrReck1[k] + " ");
                            }
                        }

                        if (userInputArray[i] == arrReck2[j])
                        {
                            Console.WriteLine();
                            for (int k = 0; k < arrReck2.Length; k++)
                            {
                                Console.Write(arrReck2[k] + " ");
                            }
                        }

                        if (userInputArray[i] == arrReck3[j])
                        {
                            Console.WriteLine();
                            for (int k = 0; k < arrReck3.Length;k++)
                            {
                                Console.Write(arrReck3[k] + " ");
                            }
                        } 
                    }
                    else
                    {
                        Console.WriteLine("No matches found");
                        break;
                    }
                }                
            }

            //чтобы консоль не закрывалась
            Console.ReadKey();
        }
    }
}
