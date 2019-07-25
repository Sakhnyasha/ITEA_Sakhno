using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dota
{
    //Задание: https://github.com/Sakhnyasha/ITEA_Sakhno/blob/Sakhnyasha-2HW2/photo5312134269340068679.jpg + 
    //+пусть будет ваша коллекция параметризируемая, куда можно будет добавлять айтемы. делать все операции с айтемами
    //Результат: Герой и его копии с полной сводкой

    class MyCollection<T> : IList<T>
    {
        private T[] _arr;
        private int _lenght;
        public int Сapacity { get; private set; }

        public MyCollection(int сapacity)
        {
            Сapacity = сapacity;
            _arr = new T[сapacity];
        }

        //конструктор. Вызывает дефолтный конструктор и передает ему размер коллекции, которую принимает и заполняет ее соответственно.
        public MyCollection(ICollection<T> collection) : this(collection.Count)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public int Count => _lenght;

        //добавление с авторасширением
        public void Add(T value)
        {
            if (_lenght == Сapacity)
            {
                Сapacity *= 2;
                var temp = new T[Сapacity];
                Array.Copy(_arr, temp, _arr.Length);
                _arr = temp;
            }

            _arr[_lenght] = value;
            _lenght++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 && index >= _lenght) return;
            for (var i = index + 1; i < _lenght; i++)
            {
                _arr[i - 1] = _arr[i];
            }
            _lenght--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _lenght; i++)
            {
                yield return _arr[i];
            }
        }

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    class Item
    {
        protected string Name;
        protected float Intelligence;
        protected float Agility;
        protected float Strength;
        protected float StrikePower;

        public Item()
        {
        }

        public Item(Item item)
        {
            Name = item.GetName();
            Intelligence = item.GetIntelligence();
            Agility = item.GetAgility();
            Strength = item.GetStrength();
            StrikePower = item.GetStrikePower();
        }

        public string GetName()
        {
            return Name;
        }

        public float GetIntelligence()
        {
            return Intelligence;
        }

        public float GetAgility()
        {
            return Agility;
        }

        public float GetStrength()
        {
            return Strength;
        }

        //у PhaseBoots есть свойство повышать значение удара
        public float GetStrikePower()
        {
            return StrikePower;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("- " + GetName());
            sb.Append(". Strength: ");
            sb.Append(GetStrength());
            sb.Append(", Agility: ");
            sb.Append(GetAgility());
            sb.Append(", Intelligence: ");
            sb.Append(GetIntelligence());
            sb.Append(", Strike Power: ");
            sb.Append(GetStrikePower());
            return sb.ToString();
        }
    }

    class PhaseBoots : Item
    {
        public PhaseBoots()
        {
            Name = "Phase Boots";
            Intelligence = 0;
            Agility = 0;
            Strength = 0;
            StrikePower = 18;
        }

        public PhaseBoots(PhaseBoots item)
        {
            Name = item.GetName();
            Intelligence = item.GetIntelligence();
            Agility = item.GetAgility();
            Strength = item.GetStrength();
            StrikePower = item.GetStrikePower();
        }
    }

    class MantaStyle : Item
    {
        public MantaStyle()
        {
            Name = "Manta Style";
            Intelligence = 10;
            Agility = 26;
            Strength = 10;
            StrikePower = 0;
        }

        public MantaStyle(MantaStyle item)
        {
            Name = item.GetName();
            Intelligence = item.GetIntelligence();
            Agility = item.GetAgility();
            Strength = item.GetStrength();
            StrikePower = item.GetStrikePower();
        }
    }

    abstract class Hero
    {
        protected string Name;
        protected float Intelligence;
        protected float Agility;
        protected float Strength;
        protected float StrikePowerBase; //единственное, что меняется у копий

        //для проверки на оригинал и копию по свойствами предмета
        protected bool IsClone;

        //сумка игрока
        protected MyCollection<Item> Bag = new MyCollection<Item>(2);

        private string GetName()
        {
            return Name;
        }

        protected Hero()
        {
        }

        //чтобы можно было бы установить сумку герою или его копии
        protected Hero(ICollection<Item> bag)
        {
            Bag = new MyCollection<Item>(bag.Count);
            foreach (var item in bag)
            {
                if (item is MantaStyle)
                {
                    Bag.Add(new MantaStyle((MantaStyle)item));
                }
                else if (item is PhaseBoots)
                {
                    Bag.Add(new PhaseBoots((PhaseBoots)item));
                }
                else
                {
                    Bag.Add(new Item(item));
                }
            }
        }

        //флаг на определение клона
        protected void SetClone(bool isClone)
        {
            IsClone = isClone;
        }

        //Считаем количество клонов, которые будут созданы с помощью айтема в сумке
        protected int NumberOfClones()
        {
            var numberOfClones = 0;
            foreach (var item in Bag)
            {
                if (item is MantaStyle)
                {
                    numberOfClones += 2;
                }
            }

            return numberOfClones;
        }

        //расчет удара
        protected abstract float StrikePower();

        //проверка на оригинал персонажа
        protected abstract bool IsOriginal();

        //вывод копий с учетом стафа в сумке и свойст персонажа
        public abstract ArrayList GetUltimate();

        private float GetIntelligence()
        {
            return Intelligence;
        }

        private float CalculateIntelligence()
        {
            float sum = 0;
            foreach (var item in Bag)
            {
                if (item != null)
                {
                    sum += item.GetIntelligence();
                }
            }

            return sum + Intelligence;
        }

        private float GetAgility()
        {
            return Agility;
        }

        protected float CalculateAgility()
        {
            float sum = 0;
            foreach (var item in Bag)
            {
                if (item != null)
                {
                    sum += item.GetAgility();
                }
            }

            return sum + Agility;
        }

        private float GetStrength()
        {
            return Strength;
        }

        private float CalculateStrength()
        {
            float sum = 0;
            foreach (var item in Bag)
            {
                if (item != null)
                {
                    sum += item.GetStrength();
                }
            }

            return sum + Strength;
        }

        protected float CalculateBagStrikePower()
        {
            float sum = 0;
            foreach (var item in Bag)
            {
                if (item != null)
                {
                    sum += item.GetStrikePower();
                }
            }

            return sum;
        }

        public string HeroInfo()
        {
            var sb = new StringBuilder();
            sb.Append(GetName() + ". Copy: " + (IsOriginal() ? "(Original)" : "(Clone)"));
            sb.Append("\nStrength: " + GetStrength());
            sb.Append("(" + CalculateStrength() + ")");
            sb.Append(", Agility: " + GetAgility());
            sb.Append("(" + CalculateAgility() + ")");
            sb.Append(", Intelligence: " + GetIntelligence());
            sb.Append("(" + CalculateIntelligence() + ")");
            sb.Append(", StrikePower: ");
            sb.Append(StrikePower());
            sb.Append("\nBag: \n");
            foreach (var item in Bag)
            {
                sb.Append(item == null ? "- Empty\n" : item + "\n");
            }
            return sb.ToString();
        }
    }

    class PhantomLancer : Hero, ICloneable
    {
        private int _isSelfClone;

        //чтобы копии так же имели доступ к сумке
        public PhantomLancer(ICollection<Item> bag) : base(bag)
        {
            Name = "Phantom Lancer";
            Intelligence = 19;
            Agility = 29;
            Strength = 19;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(22, 44); //базовое значение удара из промежутка
        }

        //создаем клон обьекта. Не забываем о сумке!
        public object Clone()
        {
            return new PhantomLancer(Bag);
        }

        //установка значения флага для клона
        private void SetSelfClone(int isSelfClone)
        {
            _isSelfClone = isSelfClone;
        }

        //проверка на оригинал персонажа
        protected override bool IsOriginal()
        {
            return !IsClone && _isSelfClone == 0;
        }

        //вычисление значение удара с учетом свойств персонажа и свойст стафа в сумке
        protected override float StrikePower()
        {
            float coef;
            if (IsClone)
            {
                coef = 0.33f;
            }
            else
            {
                switch (_isSelfClone)
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

            return coef * (StrikePowerBase + CalculateAgility() + CalculateBagStrikePower());
        }


        public override ArrayList GetUltimate()
        {
            var copies = new ArrayList();

            //делаем 2 копии (как свойство персонажа) и устанавливаем флаг
            var phantomLancerCopyOne = (PhantomLancer)Clone();
            phantomLancerCopyOne.SetSelfClone(1);
            var phantomLancerCopyTwo = (PhantomLancer)Clone();
            phantomLancerCopyTwo.SetSelfClone(2);

            copies.Add(this);
            copies.Add(phantomLancerCopyOne);
            copies.Add(phantomLancerCopyTwo);

            //делаем копии (как свойство айтема в сумке) и и устанавливаем флаг
            var number = NumberOfClones();
            for (var i = 0; i < number; i++)
            {
                var phantomLancerMantaCopy = (PhantomLancer)Clone();
                phantomLancerMantaCopy.SetClone(true);
                copies.Add(phantomLancerMantaCopy);
            }

            return copies;
        }
    }

    class AntiMage : Hero
    {
        //основной конструктор класса
        //чтобы копии так же имели доступ к сумке
        public AntiMage(ICollection<Item> bag) : base(bag)
        {
            Name = "Anti-Mage";
            Intelligence = 12;
            Agility = 24;
            Strength = 23;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(29, 33);
        }

        //проверка на оригинал персонажа
        protected override bool IsOriginal()
        {
            return !IsClone;
        }

        protected override float StrikePower()
        {
            //вычисление значение удара с учетом свойств стафа в сумке
            var coef = IsClone ? 0.33f : 1f;
            return coef * (StrikePowerBase + CalculateAgility() + CalculateBagStrikePower());
        }

        public override ArrayList GetUltimate()
        {
            var copies = new ArrayList { this };


            //делаем копии (как свойство айтема в сумке) и и устанавливаем флаг
            var number = NumberOfClones();
            for (var i = 0; i < number; i++)
            {
                var antiMageMantaCopy = new AntiMage(Bag);
                antiMageMantaCopy.SetClone(true);
                copies.Add(antiMageMantaCopy);
            }

            return copies;
        }
    }

    class Program
    {
        private static Item GenerateRandomItem(Random random)
        {
            if (random.Next(2) == 0)
            {
                return new MantaStyle();
            }

            return new PhaseBoots();
        }

        static void Main(string[] args)
        {
            //заполняем сумку и отдаем ее игроку
            var random = new Random();
            Item[] items1 = { GenerateRandomItem(random), GenerateRandomItem(random) };
            Item[] items2 = { GenerateRandomItem(random), GenerateRandomItem(random) };
            Hero hero1 = new AntiMage(items1);
            Hero hero2 = new PhantomLancer(items2);

            Console.WriteLine("Hero 1 Ultimate");
            //перебор коллекции
            foreach (Hero element in hero1.GetUltimate())
            {
                Console.WriteLine(element.HeroInfo());
            }

            Console.WriteLine("============================================================================");

            Console.WriteLine("Hero 2 Ultimate");
            //перебор коллекции
            foreach (Hero element in hero2.GetUltimate())
            {
                Console.WriteLine(element.HeroInfo());
            }

            Console.ReadKey();
        }
    }
}