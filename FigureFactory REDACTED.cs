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
    class Figure
    {
        public string name;
        private string[] color_set = { "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Black", "White", "Pink", "Brown" };
        private string color;
        private double perimeter;
        private double square;

        virtual public string getName()
        {
            return "";
        }
        public string getColor()
        {
            if (color == null)
            {
                Random rnd = new Random();
                color = color_set[rnd.Next(color_set.Length - 1)];
            }
            return color;
        }
        virtual public double calculatePerimetr()
        {
            return 0;
        }
        virtual public double calculateSquare()
        {
            return 0;
        }
        virtual public void createFigure()
        {
        }
        virtual public void printInfo()
        {
            Console.Clear();
            Console.WriteLine("Name: " + getName() + "\nColor: " + getColor() + "\nPerimeter: " + calculatePerimetr() + "\nSquare: " + calculateSquare());
        }
    }       

    //Круг
    class Circle: Figure
    {
        double radius;
        override public string getName()
        {
            return "Circle";
        }
        override public void createFigure()
        {
            Console.WriteLine("You chosed " + getName() + ". \nEnter Radius (ENTER key):");
            radius = Convert.ToDouble(Program.ReadFromConsole().Trim());
        }
        override public double calculatePerimetr()
        {
            double perimeter = Math.Round((radius * 2 * Math.PI), 2);
            return perimeter;
        }
        override public double calculateSquare()
        {
            double square = Math.Round((Math.Pow(radius, 2) * Math.PI), 2);
            return square;
        }        
    }

    //Квадрат
    class Square: Figure
    {
        double side;
        override public string getName()
        {
            return "Square";
        }
        override public void createFigure()
        {
            Console.WriteLine("You chosed " + getName() + ". \nEnter Side (ENTER key):");
            side = Convert.ToDouble(Program.ReadFromConsole().Trim());
        }
        override public double calculatePerimetr()
        {
            double perimeter = Math.Round(Convert.ToDouble(side * 4), 2);
            return perimeter;
        }
        override public double calculateSquare()
        {
            double square = Math.Round(Convert.ToDouble(Math.Pow(side, 2)), 2);
            return square;
        }
    }

    //Треугольник
    class Triangle: Figure
    {
        double side_one;
        double side_two;
        double side_three;

        override public string getName()
        {
            return "Triangle";
        }
        override public void createFigure()
        {
            Console.WriteLine("You chosed " + getName() + ". \nEnter Side_1 (SPACEBAR key) Side_2 (SPACEBAR key) Side_3 (ENTER key):");
            //парсинг строки
            String[] arr = new String[0];
            arr = Program.ReadFromConsole().TrimStart().TrimEnd().Split(' ');
            while (arr.Length != 3)
            {
                Console.WriteLine("Enter 3 sides or remove extra spaces!");
                arr = Program.ReadFromConsole().TrimStart().TrimEnd().Split(' ');
            }
            side_one = Convert.ToDouble(arr[0]);
            side_two = Convert.ToDouble(arr[1]);
            side_three = Convert.ToDouble(arr[2]);          
        }

        override public void printInfo()
        {
            if ((side_one + side_two > side_three) && (side_one + side_three > side_two) && (side_two + side_three > side_one) && side_one > 0 && side_two > 0 && side_three > 0)
            {
                Console.Clear();
                Console.WriteLine("Name: " + getName() + "\nColor: " + getColor() + "\nPerimeter: " + calculatePerimetr() + "\nSquare: " + calculateSquare());
            }
            else
            {
                Console.WriteLine("\nIt is not a Triangle!");
            }
        }
        override public double calculatePerimetr()
        {
            double perimeter = Math.Round(Convert.ToDouble(side_one + side_two + side_three), 2);
            return perimeter;
        }
        override public double calculateSquare()
        {
            double square = Math.Round(Convert.ToDouble(Math.Sqrt((side_one + side_two + side_three) / 2 * ((side_one + side_two + side_three) / 2 - side_one) * ((side_one + side_two + side_three) / 2 - side_two) * ((side_one + side_two + side_three) / 2 - side_three))), 2);
            return square;
        }
    }

    class Program
    {
        //проверка на ввод только цифр, пробела и ентера!
        static public string ReadFromConsole()
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
            Figure figure = null;

            do
            {
                //обнуление переменной
                figure = null;

                //меню
                Console.WriteLine("\n==========MENU==========" +
                "\nFor Circle press 1." +
                "\nFor Square press 2." +
                "\nFor Triangle press 3." +
                "\nFor EXIT press 0.\n========================");
                
                button = Convert.ToInt32(ReadFromConsole());                 
                Console.Clear();

                //реализация меню
                switch (button)
                {
                    //для круга
                    case 1:
                        figure = new Circle();                       
                        break;
                    //для квадрата
                    case 2:
                        figure = new Square();
                        break;
                    //для треугольника
                    case 3:
                        figure = new Triangle();
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
                
                //вывод результата
                if (figure != null)
                {
                    figure.createFigure();
                    figure.printInfo(); //figure.calculatePerimetr(); figure.calculateSquare();
                }                

            } while (button != 0);
            
            //чтобы консоль не закрылась
            Console.ReadKey();
        }
    }
}
