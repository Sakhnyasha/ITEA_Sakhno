using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog_Run_10_on_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //инструкция пользователю
            //бомбочка и аптечка не на первом элементе, не на последнем, не один на другом
            Console.WriteLine("====Move DOG!====" + "\nDOG walks on 10x10 field." + "\nFor RIGHT move press D. " +
                "For LEFT move press A." + "\nFor UP move press W. " + "For DOWN move press S." + "\nDOG has 100 XP." + "\nEach move -5XP. Hitting the bomb -40XP. " +
                "Hitting First Aid Kit +40XP." + "\nGame over when DOG reaches the end of field (X) OR DOG XP=0." +
                "\n\nPress ANY BUTTON to start!");
            Console.ReadKey();
            Console.Clear();

            int i;
            int j;
            int size = 10; //РАЗМЕРНОСТЬ МАССИВА! потом сделать масштабируемым с возможностью ввода размера с клавы

            //начальное здоровье собачки
            int xp = 100;
            
            //создаем массив
            char[,] dog = new char[size, size];
                       
            //определение количества строк и столбцов (если вбили вруную значения массива)
            int rows = dog.GetUpperBound(0) + 1; //с помощью выражения mas.GetUpperBound(0) + 1 можно получить количество строк таблицы, представленной двухмерным массивом
            int columns = dog.Length / rows; //через mas.Length / rows можно получить количество элементов в каждой строке

            //заполнение массива
            //dog[0, 0] = '@'; dog[9, 9] = 'X'; остальное '_';
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    dog[i, j] = '_';
                    dog[0, 0] = '@';
                    dog[rows - 1, columns - 1] = 'X';
                }
            }
            
            //выбор рандомных мест для бомбы и аптечки
            Random rnd = new Random();
            
            //рандомно заполняем бомбочками и аптечками
            for (i = 0; i < rows; i++)
            {
                j = rnd.Next(1, columns - 1); 
                while (dog[i, j] != '_')
                {
                    j = rnd.Next(1, columns - 1);
                }
                dog[i, j] = '*';

                while (dog[i, j] != '_')
                {
                    j = rnd.Next(1, columns - 1);
                }
                dog[i, j] = '+';
            }
                        
            //вывод начального поля
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    //Console.Write($"{dog[i, j]} \t");
                    Console.Write(dog[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\nXP:" + xp);


            //вечный цикл            
            for (; ; )
            {
                //для считывания символов с клавыатуры
                ConsoleKeyInfo key = Console.ReadKey(true);

                Boolean keepLoop = true; //чтобы наконец-то вышло из цикла!
                
                for (i = 0; i < rows && keepLoop; i++)
                {
                    for (j = 0; j < columns && keepLoop; j++)
                    {                        
                        if (dog[i, j] == '@')
                        {
                            //движение вправо на Д
                            //уменьшение здоровья                            
                            if (key.Key == ConsoleKey.D)
                            {
                                //если не конец строки
                                if (j != columns - 1)
                                {
                                    xp = xp - 5;
                                    if (dog[i, j + 1] == '*')
                                        xp = xp - 40;
                                    if (dog[i, j + 1] == '+')
                                    {
                                        xp = xp + 40;
                                        if (xp > 100)
                                            xp = 100;
                                    }
                                    dog[i, j] = '_';
                                    dog[i, j + 1] = '@';
                                }
                                //если конец строки перекинуть на начало
                                else
                                {
                                    xp = xp - 5;
                                    dog[i, 0] = '@';
                                    dog[i, j] = '_';
                                    
                                }
                                keepLoop = false;
                            }

                            //движение влево на А
                            //уменьшение здоровья
                            else if (key.Key == ConsoleKey.A)
                            {
                                //если не начало строки
                                if (j != 0)
                                {
                                    xp = xp - 5;
                                    if (dog[i, j - 1] == '*')
                                        xp = xp - 40;
                                    if (dog[i, j - 1] == '+')
                                    {
                                        xp = xp + 40;
                                        if (xp > 100)
                                            xp = 100;
                                    }
                                    dog[i, j] = '_';
                                    dog[i, j - 1] = '@';                                    
                                }
                                //если начало строки перекинуть на конец
                                else
                                {
                                    xp = xp - 5;
                                    dog[i, columns - 1] = '@';
                                    dog[i, j] = '_';                                    
                                }
                                keepLoop = false;
                            }

                            //движение вверх на W
                            //уменьшение здоровья
                            else if (key.Key == ConsoleKey.W)
                            {
                                //если не начало столбца
                                if (i != 0)
                                {
                                    xp = xp - 5;
                                    if (dog[i - 1, j] == '*')
                                        xp = xp - 40;
                                    if (dog[i - 1, j] == '+')
                                    {
                                        xp = xp + 40;
                                        if (xp > 100)
                                            xp = 100;
                                    }
                                    dog[i, j] = '_';
                                    dog[i - 1, j] = '@';                                    
                                }
                                //если начало столбца перекинуть на конец
                                else
                                {
                                    xp = xp - 5;
                                    dog[rows - 1, j] = '@';
                                    dog[i, j] = '_';                                    
                                }
                                keepLoop = false;
                            }

                            //движение вниз на S
                            //уменьшение здоровья
                            else if (key.Key == ConsoleKey.S)
                            {                                
                                //если не конец столбца
                                if (i != rows - 1)
                                {
                                    xp = xp - 5;
                                    if (dog[i + 1, j] == '*')
                                        xp = xp - 40;
                                    if (dog[i + 1, j] == '+')
                                    {
                                        xp = xp + 40;
                                        if (xp > 100)
                                            xp = 100;
                                    }
                                    dog[i, j] = '_';
                                    dog[i + 1, j] = '@';                                    
                                }
                                //если конец столбца перекинуть на начало
                                else
                                {
                                    xp = xp - 5;
                                    dog[0, j] = '@';
                                    dog[i, j] = '_';                                    
                                }
                                keepLoop = false;
                            }
                        }
                    }
                }

                Console.Clear();

                //если достигли конца массива или здоровье=0 + выход из вечного цикла
                if (dog[rows-1, columns-1] == '@' || xp <= 0)
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                //перерисовка консоли. отображение движения собачки
                else
                {
                    for (i = 0; i < rows; i++)
                    {
                        for (j = 0; j < columns; j++)
                        {
                            //Console.Write($"{dog[i, j]} \t");
                            Console.Write(dog[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n\nXP:" + xp);
                }
            }

            Console.WriteLine("\nPress ENTER button to quit!");

            //чтобы консоль не закрывалась
            Console.ReadKey();

            //закрыть консоль
            Environment.Exit(0);
        }
    }
}
