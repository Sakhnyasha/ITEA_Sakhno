using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dota
{
    //Задание: https://github.com/Sakhnyasha/ITEA_Sakhno/blob/Sakhnyasha-2HW2/photo5312134269340068679.jpg
    //Результат: Герой и его копии с полной сводкой
    
    class Item
	{
		protected string name;
		protected float intelligence;
		protected float agility;
		protected float strength;
		protected float strikePower;
		public string getName()
		{
			return name;
		}
		public float getIntelligence()
		{
			return intelligence;
		}
		public float getAgility()
		{
			return agility;
		}
		public float getStrength()
		{
			return strength;
		}
        //у PhaseBoots есть свойство повышать значение удара
        public float getStrikePower()
		{
			return strikePower;
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("- " + getName());
			sb.Append(". Strength: ");
			sb.Append(getStrength());
			sb.Append(", Agility: ");
			sb.Append(getAgility());
			sb.Append(", Intelligence: ");
			sb.Append(getIntelligence());
			sb.Append(", Strike Power: ");
			sb.Append(getStrikePower());
			return sb.ToString();
		}
	}

	class PhaseBoots : Item
	{
		public PhaseBoots()
		{
			name = "Phase Boots";
			intelligence = 0;
			agility = 0;
			strength = 0;
			strikePower = 18;
		}
	}
	class MantaStyle : Item
	{
		public MantaStyle()
		{
			name = "Manta Style";
			intelligence = 10;
			agility = 26;
			strength = 10;
			strikePower = 0;
		}
	}
    
	abstract class Hero
	{
		protected String name;
		protected float intelligence;
		protected float agility;
		protected float strength;
		protected float strikePowerBase; //единственное, что меняется у копий

        //для проверки на оригинал и копию по свойствами предмета
		protected bool isClone;

		//сумка игрока
		public Item[] bag = new Item[2];

		public string getName()
		{
			return name;
		}
		public Hero()
		{
		}

        //чтобы можно было бы установить сумку герою или его копии
		protected Hero(Item[] bag)
		{
			this.bag = bag;
		}

        //флаг на определение клона
		protected void setClone(bool isClone)
		{
			this.isClone = isClone;
		}

        //Считаем количество клонов, которые будут созданы с помощью айтема в сумке
        protected int numberOfClones()
		{
			int numberOfClones = 0;
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] is MantaStyle)
				{
					numberOfClones += 2;
				}
			}
			return numberOfClones;
		}

        //расчет удара
		public abstract float strikePower();

        //проверка на оригинал персонажа
		protected abstract bool isOriginal();

        //вывод копий с учетом стафа в сумке и свойст персонажа
		public abstract ArrayList getUltimate();

		public float getIntelligence()
		{
			return intelligence;
		}
		public float calculateIntelligence()
		{
			float sum = 0;
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] != null)
				{
					sum = sum + bag[i].getIntelligence();
				}
			}
			return sum + intelligence;
		}

		public float getAgility()
		{
			return agility;
		}
		public float calculateAgility()
		{
			float sum = 0;
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] != null)
				{
					sum = sum + bag[i].getAgility();
				}
			}
			return sum + agility;
		}

		public float getStrength()
		{
			return strength;
		}
		public float calculateStrength()
		{
			float sum = 0;
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] != null)
				{
					sum = sum + bag[i].getStrength();
				}
			}
			return sum + strength;
		}

		public float calculateBagStrikePower()
		{
			float sum = 0;
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] != null)
				{
					sum = sum + bag[i].getStrikePower();
				}
			}
			return sum;
		}

		public string heroInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(getName() + ". Copy: " + (isOriginal() ? "(Original)" : "(Clone)"));
			sb.Append("\nStrength: " + getStrength());
			sb.Append("(" + calculateStrength() + ")");
			sb.Append(", Agility: " + getAgility());
			sb.Append("(" + calculateAgility() + ")");
			sb.Append(", Intelligence: " + getIntelligence());
			sb.Append("(" + calculateIntelligence() + ")");
			sb.Append(", StrikePower: ");
			sb.Append(strikePower());
			sb.Append("\nBag: \n");
			for (int i = 0; i < bag.Length; i++)
			{
				if (bag[i] == null)
				{
					sb.Append("- Empty\n");
				}
				else
				{
					sb.Append(bag[i].ToString() + "\n");
				}
			}
			return sb.ToString();
		}
	}

	class PhantomLancer : Hero, ICloneable
	{
		private int isSelfClone;

		public PhantomLancer()
		{
			name = "Phantom Lancer";
			intelligence = 19;
			agility = 29;
			strength = 19;
			Random rnd = new Random();
			strikePowerBase = rnd.Next(22, 44); //базовое значение удара из промежутка
		}

		//чтобы копии так же имели доступ к сумке
		public PhantomLancer(Item[] bag) : this()
		{
			this.bag = bag;
		}

		//создаем клон обьекта. Не забываем о сумке!
		public object Clone()
		{
			return new PhantomLancer(bag);
		}

        //установка значения флага для клона
		private void setSelfClone(int isSelfClone)
		{
			this.isSelfClone = isSelfClone;
		}

        //проверка на оригинал персонажа
		protected override bool isOriginal()
		{
			return !isClone && isSelfClone == 0;
		}

        //вычисление значение удара с учетом свойств персонажа и свойст стафа в сумке
		public override float strikePower()
		{
			float coef;
			if (isClone)
			{
				coef = 0.33f;
			}
			else
			{
				switch (isSelfClone)
				{
					case 0:
						coef = 1f;
						break;
					case 1:
						coef = 0f;
						break;
					case 2:
						coef = 0.2f;
						break;
					default:
						coef = 1f;
						break;
				}
			}

			return coef * (strikePowerBase + base.calculateAgility() + base.calculateBagStrikePower());
		}


		public override ArrayList getUltimate()
		{
			ArrayList copies = new ArrayList();

            //делаем 2 копии (как свойство персонажа) и устанавливаем флаг
			PhantomLancer phantomLancerCopyOne = (PhantomLancer)Clone();
			phantomLancerCopyOne.setSelfClone(1);
			PhantomLancer phantomLancerCopyTwo = (PhantomLancer)Clone();
			phantomLancerCopyTwo.setSelfClone(2);

			copies.Add(this);
			copies.Add(phantomLancerCopyOne);
			copies.Add(phantomLancerCopyTwo);

            //делаем копии (как свойство айтема в сумке) и и устанавливаем флаг
            int number = numberOfClones();
			for (int i = 0; i < number; i++)
			{
				PhantomLancer phantomLancerMantaCopy = (PhantomLancer)Clone();
				phantomLancerMantaCopy.setClone(true);
				copies.Add(phantomLancerMantaCopy);
			}
			return copies;
		}
	}

	class AntiMage : Hero
	{
		//основной конструктор класса
		public AntiMage()
		{
			name = "Anti-Mage";
			intelligence = 12;
			agility = 24;
			strength = 23;
			Random rnd = new Random();
			strikePowerBase = rnd.Next(29, 33);
		}

        //проверка на оригинал персонажа
		protected override bool isOriginal()
		{
			return !isClone;
		}

		public override float strikePower()
		{
            //вычисление значение удара с учетом свойств стафа в сумке
            float coef;
			if (isClone)
			{
				coef = 0.33f;
			}
			else
			{
				coef = 1f;
			}
			return coef * (strikePowerBase + base.calculateAgility() + base.calculateBagStrikePower());
		}

        //чтобы копии так же имели доступ к сумке
        public AntiMage(Item[] bag) : this()
		{
			this.bag = bag;
		}

		public override ArrayList getUltimate()
		{
			ArrayList copies = new ArrayList();

			copies.Add(this);

            //делаем копии (как свойство айтема в сумке) и и устанавливаем флаг
            int number = numberOfClones();
			for (int i = 0; i < number; i++)
			{
				AntiMage AntiMageMantaCopy = new AntiMage(bag);
				AntiMageMantaCopy.setClone(true);
				copies.Add(AntiMageMantaCopy);
			}

			return copies;
		}
	}


	class Program
	{
		static Item generateRandomItem(Random random)
		{
			if (random.Next(2) == 0)
			{
				return new MantaStyle();
			}
			else
			{
				return new PhaseBoots();
			}
		}
		static void Main(string[] args)
		{
            //заполняем сумку и отдаем ее игроку
            Random random = new Random();
			Item[] items1 = { generateRandomItem(random), generateRandomItem(random) };
			Item[] items2 = { generateRandomItem(random), generateRandomItem(random) };
			Hero hero1 = new AntiMage(items1);
			Hero hero2 = new PhantomLancer(items2);

			Console.WriteLine("Hero 1 Ultimate");
            //перебор коллекции
			foreach (Hero element in hero1.getUltimate())
			{
				Console.WriteLine(element.heroInfo());
			}

            Console.WriteLine("============================================================================");

            Console.WriteLine("Hero 2 Ultimate");
            //перебор коллекции
            foreach (Hero element in hero2.getUltimate())
			{
				Console.WriteLine(element.heroInfo());
			}

			Console.ReadKey();
		}

	}
}

