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

        	//для определения последнего элимента корзины
		int currentElement = -1;
		public Product getLastProduct()
		{
			if (currentElement - 1 < 0)
			{
				return null;
			}
			else
			{
				return products[currentElement];
			}
		}
        	//добавление следующего элемента в корзину
		public void putProduct(Product product)
		{
			if (currentElement+1 >= products.Length)
			{
				Console.WriteLine("Your cart is FULL!\n");
			}
			else
			{
				currentElement++;
				products[currentElement] = product;
			}
		}
        	//удаление последнего элемента из корзины
		public void delProduct()
		{
			if (currentElement < 0)
			{
				Console.WriteLine("Your cart is EMPTY!\n");
			}
			else
			{
				products[currentElement] = null;
				currentElement--;
			}
		}
        	//вывод состояния корзины
		public void printInfo()
		{
			StringBuilder sb = new StringBuilder("Status:\n");

            		if (currentElement < 0)
            		{
                		Console.WriteLine("Your cart is EMPTY!\n");
            		}
			    else if(currentElement > products.Length)
			    {
				Console.WriteLine("Your cart is FULL!\n");
			    }

			    else
			    {
				for (int i = 0; i <= currentElement; i++)
				{
				    Product product = products[i];
				    sb.Append("Name: ");
				    sb.Append(product.getName());
				    sb.Append(", price: ");
				    sb.Append(product.getPrice());
				    sb.Append("\n");
				}
				Console.WriteLine(sb.ToString());
			    }
			}
		}
	interface ICart
	{
		void printInfo();
		void putProduct(Product product);
		void delProduct();
		Product getLastProduct();
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
			Apple apple = new Apple();
			Cookies cookies = new Cookies();
			Chocolate chocolate = new Chocolate();

			Console.WriteLine("======Stack Cart======\n");

            		//add 5 products. get cart info
            		cart.putProduct(apple);
			cart.putProduct(cookies);
			cart.putProduct(chocolate);
			cart.putProduct(cookies);
			cart.putProduct(apple);
            		cart.printInfo();

		    	//add 6-th product. get error. get cart info
		    	cart.putProduct(chocolate);
		    	cart.printInfo();

		    	//для особо настырных. добавим еще раз
		    	cart.putProduct(chocolate);
		    	cart.printInfo();

		    	//dell 5-th product. get cart info
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//dell 4-th product. get cart info
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//dell 3-rd product. get cart info
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//dell 2-nd product. get cart info
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//dell 1-st product. get error. get cart info
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//для особо настырных. удалим еще раз
		    	cart.getLastProduct();
		    	cart.delProduct();
		    	cart.printInfo();

		    	//чтобы консолька не закрылась
		    	Console.ReadKey();
		}
	}
}
