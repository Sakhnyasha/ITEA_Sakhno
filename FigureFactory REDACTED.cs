using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureFactory
{
    //Задание
    //Есть фабрика фигур: круг, квадрат, треугольник.
    //У каждой фигуры есть параметры: имя, цвет (выбирается рандомно из массива цветов), периметр и площадь
    //Когда пользователь запускает программу, то он должен выбрать один из 4-х пунктов меню:
    //1-круг, 2-квадрат, 3-треугольник, 0-выход. 
    //"1. Вы выбрали *имя_фигуры*. Введите радиус/сторону/стороны(в зависимоти от метода подсчета периметра и площади треугольника):"
    //Должны вывестись параметры фигуры и меню.
    //Програма предлагает выбрать фигуру пока пользовательне нажмет выход.

    //круг
    class Figure
    {        
        private string[] color_set = { "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Black", "White", "Pink", "Brown" };
        private string color;
        private double perimeter;
        private double square;

        //вывод инфо о фигуре
        public void printInfo()
        {
            Console.WriteLine("\nColor: " + color);
            Console.WriteLine("Perimeter: " + perimeter);
            Console.WriteLine("Square: " + square);
        }

        //расчет периметра, площади. выбор цвета

        //круг
        public void setParametersCircle(int radius)
        {
            //если радиус больше 0
            if (radius > 0)
            {
                Random rnd = new Random();
                color = color_set[rnd.Next(color_set.Length - 1)];
                perimeter = Math.Round((radius * 2 * Math.PI), 2);
                square = Math.Round((Math.Pow(radius, 2) * Math.PI), 2);
                printInfo(); //разобраться с ексепшенами и убрать!
            }
            else
            {
                Console.WriteLine("\nEnter radius greater than 0!"); //тут должен быть ексепшн!
            }
        }

        //квадрат
        public void setParametersSquare(int side)
        {
            if (side > 0)
            {
                Random rnd = new Random();
                color = color_set[rnd.Next(color_set.Length - 1)];
                perimeter = Math.Round(Convert.ToDouble(side * 4), 2);
                square = Math.Round(Convert.ToDouble(Math.Pow(side, 2)), 2);
                printInfo();//разобраться с ексепшенами и убрать!
            }
            else
            {
                Console.WriteLine("\nEnter side greater than 0!"); //тут должен быть ексепшн!
            }
        }

        //треугольник
        public void setParametersTriangle(int side_one, int side_two, int side_three)
        {
            //проверка на существование такой фигуры. Расчет по 3 сторонам
            if ((side_one + side_two > side_three) && (side_one + side_three > side_two) && (side_two + side_three > side_one) && side_one > 0 && side_two > 0 && side_three > 0)
            {
                Random rnd = new Random();
                color = color_set[rnd.Next(color_set.Length - 1)];
                perimeter = Math.Round(Convert.ToDouble(side_one + side_two + side_three), 2);
                square = Math.Round(Convert.ToDouble(Math.Sqrt(perimeter / 2 * (perimeter / 2 - side_one) * (perimeter / 2 - side_two) * (perimeter / 2 - side_three))), 2);
                printInfo();//разобраться с ексепшенами и убрать!
            }
            else
            {
                Console.WriteLine("\nIt is not a Triangle!"); //тут должен быть ексепшн!
            }
        }
    }
    
    class Program
    {
        //проверка на ввод только цифр, пробела и ентера!
        static string ReadFromConsole()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    //проверка на пустую строку
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
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            int button;
            int counter = 1;

            do
            {
                //меню
                Console.WriteLine("\n==========MENU==========" +
                "\nFor Circle press 1." +
                "\nFor Square press 2." +
                "\nFor Triangle press 3." +
                "\nFor EXIT press 0.\n========================");

                button = Convert.ToInt32(ReadFromConsole());
                //counter++;
                Console.Clear();

                //реализация меню
                switch (button)
                {
                    //для круга
                    case 1:
                        Figure circle = new Figure();
                        Console.WriteLine(counter + ". You chosed Circle. \nEnter Radius (ENTER key):");
                        circle.setParametersCircle(Convert.ToInt32(ReadFromConsole().ToString().Trim()));
                        counter++;
                        break;
                    //для квадрата
                    case 2:
                        Figure square = new Figure();
                        Console.WriteLine(counter + ". You chosed Square. \nEnter Side (ENTER key):");
                        square.setParametersSquare(Convert.ToInt32(ReadFromConsole().ToString().Trim()));
                        counter++;
                        break;
                    //для треугольника
                    case 3:
                        Figure triangle = new Figure();
                        Console.WriteLine(counter + ". You chosed Triangle. \nEnter Side_1 (SPACEBAR key) Side_2 (SPACEBAR key) Side_3 (ENTER key):");
                        //парсинг строки
                        String[] arr = ReadFromConsole().ToString().TrimStart().TrimEnd().Split(' ');
                        if (arr.Length == 3)
                        {
                            triangle.setParametersTriangle(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]));
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("Enter 3 sides or remove extra spaces!");
                        }
                        break;
                    //выход из программы
                    case 0:
                        Environment.Exit(0);
                        break;
                    //если другая цифра
                    default:
                        Console.WriteLine("Hmmmm... There's a trouble! Choose 1 or 2 or 3 or 0!");
                        break;
                }
            } while (button != 0);

            //чтобы консоль не закрылась
            Console.ReadKey();
        }
    }
}