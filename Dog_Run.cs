using System;

namespace Dog_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            //начальные условия
            char[] dog = { '@', '_', '_', '_', '_', '_', '_', '_', '_', '_'};

            int i;
            //char temp;
            int xp = 100;

            //инструкция пользователю
            Console.WriteLine("====Move DOG!===="+ "\nDOG walks on the line." + "\nFor RIGHT move press D. " +
                "For LEFT move press A." + "\nDOG has 100 XP." + "\nEach move -5XP. Hitting the bomb -40XP. " +
                "Hitting First Aid Kit +40XP" +"\nGame over when DOG reaches the end of the line OR DOG XP=0." +
                "\n\nPress ANY BUTTON to start!");
            Console.ReadKey();
            Console.Clear();

           //выбор рандомных мест для бомбы и аптечки
            Random rnd = new Random();
            int rnd1 = rnd.Next(1, dog.Length-1);
            int rnd2 = rnd.Next(1, dog.Length-1);

            while(dog[rnd1] != '_')
            {
                rnd1 = rnd.Next(dog.Length - 1);
            }
            dog[rnd1] = '*';

            while (dog[rnd2] != '_')
            {
                rnd2 = rnd.Next(dog.Length - 1);
            }
            dog[rnd2] = '+';
            
            //вывод начального массива
            for (i = 0; i < dog.Length; i++)
                Console.Write(dog[i]);
            Console.WriteLine("\n\nXP:" + xp);

            //вечный цикл            
            for (; ; )
            {
                //для считывания символов с клавыатуры
                ConsoleKeyInfo key = Console.ReadKey(true);

                //движение вправо на Д
                //уменьшение здоровья
                if (key.Key == ConsoleKey.D)
                {
                    xp = xp - 5;
                    for (i = 0; i < dog.Length - 1; i++)
                    {                        
                        if (dog[i] == '@')
                        {
                            if (dog[i+1] == '*')
                                xp = xp - 40;
                            if (dog[i+1] == '+')
                            {
                                xp = xp + 40;
                                if (xp > 100)
                                    xp = 100;
                            }  
                            //если без бомбочек и аптечки
                            //temp = dog[i];
                            //dog[i] = dog[i + 1];
                            //dog[i + 1] = temp;
                            dog[i] = '_';
                            dog[i + 1] = '@';
                            break;
                        }
                    }
                }
                //движение влево на А
                //уменьшение здоровья
                else if (key.Key == ConsoleKey.A && dog[0] != '@')
                {                    
                    xp = xp - 5;
                    for (i = 0; i < dog.Length - 1; i++)
                    {
                        if (dog[i + 1] == '@')
                        {
                            if (dog[i] == '*')
                                xp = xp - 40;
                            if (dog[i] == '+')
                            {
                                xp = xp + 40;
                                if (xp > 100)
                                    xp = 100;
                            }
                            //если без бомбочек и аптечки
                            //temp = dog[i + 1];
                            //dog[i + 1] = dog[i];
                            //dog[i] = temp;
                            dog[i + 1] = '_';
                            dog[i] = '@';
                            break;
                        }                       
                    }
                }

                Console.Clear();
                
                //если достигли конца массива или здоровье=0 + выход из вечного цикла
                if (dog[dog.Length - 1] == '@' || xp == 0)
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                //перерисовка консоли. отображение движения собачки
                else
                {
                    for (i = 0; i < dog.Length; i++)
                        Console.Write(dog[i]);

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
