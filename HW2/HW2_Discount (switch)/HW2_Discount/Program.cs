using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача: "задачку просто закодить, чтобы при запросе цены высвечивало скидку и цену со скидкой через switch"

            //константы
            //размер скидки в %
            const int DISCOUNT_0 = 0;
            const int DISCOUNT_3 = 3;
            const int DISCOUNT_5 = 5;
            const int DISCOUNT_7 = 7;

            //нижняя граница скидки
            const int DISCOUNT_0_BORDER = 0;
            const int DISCOUNT_3_BORDER = 300;
            const int DISCOUNT_5_BORDER = 400;
            const int DISCOUNT_7_BORDER = 500;

            //стоимость некой еденицы товара
            double total;

            //зарос цены товара
            Console.WriteLine("Enter Item Full Price and press ENTER button:");

            //проверка на ввод только цифр и запятой (запятая для некруглой цены)
            //если ввести только ENTER будет ошибка: невозможность привести ентер в дабл. 
            //*stackoverflow наше все*
            bool inputComplete = false;
            StringBuilder sb = new StringBuilder();
            while (!inputComplete)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    inputComplete = true;
                }
                if (char.IsDigit(key.KeyChar))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());
                }
                else if (key.Key == ConsoleKey.OemComma)
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar.ToString());                    
                }
            }

            //очистка консоли (меньше НЕ полезной информации)
            Console.Clear();

            //округление числа до 2 знаков после запятой
            total = Math.Round(Convert.ToDouble(sb.ToString()), 2);

            //вывод полной стоимости товара
            Console.WriteLine("Item Full Price: " + total);

            //определение размера скидки
            int discount = 0;

            switch (total)
            {
                case double total_case when (total_case >= DISCOUNT_7_BORDER):
                    discount = DISCOUNT_7;
                    break;
                case double total_case when (total_case >= DISCOUNT_5_BORDER):
                    discount = DISCOUNT_5;
                    break;
                case double total_case when (total_case >= DISCOUNT_3_BORDER):
                    discount = DISCOUNT_3;
                    break;
                case double total_case when (total_case >= DISCOUNT_0_BORDER):
                    discount = DISCOUNT_0;
                    break;
                default:
                    Console.WriteLine("Hmmmm... There's a trouble! Restart program!");
                    break;
            }

            //расчет цены
            total = total - total * discount / 100;

            //вывод в консоль скидки и цены со скидкой
            Console.WriteLine("\nYour discount: " + discount + "%. " + "Total to pay: " + Math.Round(total, 2));

            Console.WriteLine("\n===========================");
            Console.WriteLine("Press ENTER button to quit!");

            //чтобы консоль не закрывалась
            Console.ReadKey();

            //закрыть консоль
            Environment.Exit(0);
        }
    }
}
