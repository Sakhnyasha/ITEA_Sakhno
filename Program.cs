using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача: "задачку просто закодить, что бы при запросе цены высвечивало скидку и цену со скидкой"

            //стоимость некой еденицы товара
            double total; 

            //размер скидки в %
            const float discount_0 = 0;
            const float discount_3 = 3;
            const float discount_5 = 5;
            const float discount_7 = 7;

            //нижняя граница скидки
            const int discount_0_border = 0;
            const int discount_3_border = 300;
            const int discount_5_border = 400;
            const int discount_7_border = 500;

            //зарос цены товара
            Console.WriteLine("Enter Item Full Price:");
            total = Math.Round((Convert.ToDouble(Console.ReadLine())), 2);
            
            //расчет итоговой суммы с учетом скидки
            //7%
            if (total >= discount_7_border)
            {
                total = total - total * discount_7 / 100;
                Console.WriteLine("\nYour discount: " + discount_7 + "%. " + "Total to pay: " + Math.Round(total, 2));
            }
            //5%
            else if (total >= discount_5_border)
            {
                total = total - total * discount_5 / 100;
                Console.WriteLine("\nYour discount: " + discount_5 + "%. " + "Total to pay: " + Math.Round(total, 2));
            }
            //3%
            else if (total >= discount_3_border)
            {
                total = total - total * discount_3 / 100;
                Console.WriteLine("\nYour discount: " + discount_3 + "%. " + "Total to pay: " + Math.Round(total, 2));
            }
            //0%
            else if (total >= discount_0_border)
            {
                total = total - total * discount_0 / 100;
                Console.WriteLine("\nYour discount: " + discount_0 + "%. " + "Total to pay: " + Math.Round(total, 2));
            }
            //если кто-то "упал мордой в салат"
            else
            {
                Console.WriteLine("Hm... There's a trouble. Try again!");
            }
            
            //чтобы консоль не закрывалась
            Console.ReadKey();            
        }
    }
}
