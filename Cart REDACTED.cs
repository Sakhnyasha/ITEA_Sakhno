using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання
//Зробити корзину з товарами, де корзина реалізує інтерфейс, а товари наслідуються від абстрактних класів.
//В корзину можна класти та прибирати з неї товари, переглядати вміст. Розмір корзини 5 товарів.
//Товар має поля: назва та ціна. В корзині масив товарів також виступає полем.

namespace Cart
{
    //корзинка
    class Cart : ICart
    {
        public Product[] products = new Product[5];

        //добавление следующего элемента в корзину
        public int putProduct(Product product)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = product;
                    return i;
                }
            }
            Console.WriteLine("\nYour cart is FULL!");
            return -1;
        }

        //получение продукта
        public Product getProduct(int i)
        {
            if (i >= 0 || i < products.Length)
            {
                return products[i];
            }
            else
            {
                return null;
            }
        }

        //проверка не пустая ли корзина
        public Boolean isEmpty()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        //удаление последнего элемента из корзины
        public void delProduct(int i)
        {
            if (i >= 0 || i < products.Length)
            {
                products[i] = null;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        //вывод состояния корзины
        public void printInfo()
        {
            if (!isEmpty())
            {
                Console.WriteLine("\nStatus:");
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i] != null)
                    {
                        Console.WriteLine(products[i].productDescription());
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYour cart is EMPTY!");
            }            
        }    
    }
    interface ICart
    {
        void printInfo();
        int putProduct(Product product);
        void delProduct(int i);
    }
    abstract class Product
    {
        protected string name;
        protected string price;
        public string getName()
        {
            return name;
        }
        public string getPrice()
        {
            return price;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setPrice(string price)
        {
            this.price = price;
        }
        public string productDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(getName());
            sb.Append(", price: ");
            sb.Append(getPrice());
            return sb.ToString();
        }
    }
    class Apple : Product
    {        
        public Apple()
        {
            name = "Apple";
            price = "10";
        }
    }
    class Cookies : Product
    {
        public Cookies()
        {
            name = "Cookies";
            price = "12";
        }
    }
    class Chocolate : Product
    {
        public Chocolate()
        {
            name = "Chocolate";
            price = "9";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICart cart = new Cart();
            Product apple = new Apple();
            Product cookies = new Cookies();
            Product chocolate = new Chocolate();

            Console.WriteLine("======Stack Cart======");

            //add 5 products. get cart info
            cart.putProduct(apple);
            cart.putProduct(cookies);
            cart.putProduct(chocolate);
            cart.putProduct(apple);
            cart.putProduct(cookies);
            //changing Apple name and price
            apple.setName("Apple Gold");
            apple.setPrice("20");
            cart.printInfo();

            //add 6-th product. get error. get cart info
            cart.putProduct(chocolate);
            cart.printInfo();

            //dell 5-th product. get cart info
            cart.delProduct(4);
            cart.printInfo();

            //dell 4-th product. get cart info
            cart.delProduct(3);
            cart.printInfo();

            //dell 3-rd product. get cart info
            cart.delProduct(2);
            cart.printInfo();

            //dell 2-nd product. get cart info
            cart.delProduct(1);
            cart.printInfo();

            //dell 1-st product. get error. get cart info
            cart.delProduct(0);
            cart.printInfo();

            //чтобы консолька не закрылась
            Console.ReadKey();
        }
    }
}