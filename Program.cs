using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace Dota_Dictionary
{
    //Задание:
    //Формирование 2 зеркальных команд.
    //Каждая команда состоит из 5 героев.
    //Герой имеет сумку с 6-ю предметами. Предметы сетяться рандомно.
    //Первая команда создается, вторая является клоном первой. Клонирование deep
    //Команда - Dictionary<Hero, List<Item>>
    abstract class Item: ICloneable
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
        abstract public object Clone();
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
        public PhaseBoots(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new PhaseBoots(Name, Intelligence, Agility, Strength, StrikePower);
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
        public MantaStyle(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new MantaStyle(Name, Intelligence, Agility, Strength, StrikePower);
        }
    }
    class Buckler : Item
    {
        public Buckler()
        {
            Name = "Buckler";
            Intelligence = 2;
            Agility = 2;
            Strength = 2;
            StrikePower = 0;
        }
        public Buckler(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new Buckler(Name, Intelligence, Agility, Strength, StrikePower);
        }
    }
    class Circlet : Item
    {
        public Circlet()
        {
            Name = "Circlet";
            Intelligence = 2;
            Agility = 2;
            Strength = 2;
            StrikePower = 0;
        }
        public Circlet(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new Circlet(Name, Intelligence, Agility, Strength, StrikePower);
        }
    }
    class RingOfBasilius : Item
    {
        public RingOfBasilius()
        {
            Name = "Ring Of Basilius";
            Intelligence = 0;
            Agility = 0;
            Strength = 0;
            StrikePower = 8;
        }
        public RingOfBasilius(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new RingOfBasilius(Name, Intelligence, Agility, Strength, StrikePower);
        }
    }
    class Quarterstaff : Item
    {
        public Quarterstaff()
        {
            Name = "Quarterstaff";
            Intelligence = 0;
            Agility = 0;
            Strength = 0;
            StrikePower = 10;
        }
        public Quarterstaff(string name, float intelligence, float agility, float strength, float strikePower)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePower = strikePower;
        }
        public override object Clone()
        {
            return new Quarterstaff(Name, Intelligence, Agility, Strength, StrikePower);
        }
    }

    abstract class Hero : ICloneable
    {
        public string Name;
        public float Intelligence;
        public float Agility;
        public float Strength;
        public float StrikePowerBase;
        
        public Hero()
        {
        }

        public Hero(string Name, float Intelligence, float Agility, float Strength, float StrikePowerBase)
        {
            this.Name = Name;
            this.Intelligence = Intelligence;
            this.Agility = Agility;
            this.Strength = Strength;
            this.StrikePowerBase = StrikePowerBase;
        }

        private string GetName()
        {
            return Name;
        }

        //расчет удара            
        private float GetIntelligence(IList<Item> bag)
        {
            return Intelligence;
        }
        private float CalculateIntelligence(IList<Item> bag)
        {
            float sum = 0;
            foreach (var item in bag)
            {
                if (item != null)
                {
                    sum += item.GetIntelligence();
                }
            }

            return sum + Intelligence;
        }

        private float GetAgility(IList<Item> bag)
        {
            return Agility;
        }
        protected float CalculateAgility(IList<Item> bag)
        {
            float sum = 0;
            foreach (var item in bag)
            {
                if (item != null)
                {
                    sum += item.GetAgility();
                }
            }

            return sum + Agility;
        }

        private float GetStrength(IList<Item> bag)
        {
            return Strength;
        }
        private float CalculateStrength(IList<Item> bag)
        {
            float sum = 0;
            foreach (var item in bag)
            {
                if (item != null)
                {
                    sum += item.GetStrength();
                }
            }

            return sum + Strength;
        }

        protected abstract float StrikePower(IList<Item> bag);
        protected float CalculateBagStrikePower(IList<Item> bag)
        {
            float sum = 0;
            foreach (var item in bag)
            {
                if (item != null)
                {
                    sum += item.GetStrikePower();
                }
            }

            return sum;
        }

        public string HeroInfo(IList<Item> bag)
        {
            var sb = new StringBuilder();
            sb.Append("\n"+GetName());
            sb.Append("\nStrength: " + GetStrength(bag));
            sb.Append("(" + CalculateStrength(bag) + ")");
            sb.Append(", Agility: " + GetAgility(bag));
            sb.Append("(" + CalculateAgility(bag) + ")");
            sb.Append(", Intelligence: " + GetIntelligence(bag));
            sb.Append("(" + CalculateIntelligence(bag) + ")");
            sb.Append(", StrikePower: ");
            sb.Append(StrikePower(bag));
            sb.Append("\nBag:\n");
            foreach (var item in bag)
            {
                sb.Append(item == null ? "- Empty\n" : item + "\n");
            }
            return sb.ToString();
        }
        //для клонирования
        abstract public object Clone();
    }

    class PhantomLancer : Hero
    {
        public PhantomLancer()
        {
            Name = "Phantom Lancer";
            Intelligence = 19;
            Agility = 29;
            Strength = 19;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(22, 44); //базовое значение удара из промежутка
        }
        //для клонирования
        public PhantomLancer(string name, float intelligence, float agility, float strength, float strikePowerBase)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePowerBase = strikePowerBase;
        }
        //вычисление значение удара
        protected override float StrikePower(IList<Item> bag)
        {
            return (StrikePowerBase + CalculateAgility(bag) + CalculateBagStrikePower(bag));
        }
        public override object Clone()
        {
            return new PhantomLancer(Name, Intelligence, Agility, Strength, StrikePowerBase);
        }
    }

    class AntiMage : Hero
    {
        public AntiMage()
        {
            Name = "Anti-Mage";
            Intelligence = 12;
            Agility = 24;
            Strength = 23;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(29, 33);
        }
        //для клонирования
        public AntiMage(string name, float intelligence, float agility, float strength, float strikePowerBase)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePowerBase = strikePowerBase;
        }
        //вычисление значение удара
        protected override float StrikePower(IList<Item> bag)
        {
            return (StrikePowerBase + CalculateAgility(bag) + CalculateBagStrikePower(bag));
        }
        public override object Clone()
        {
            return new AntiMage(Name, Intelligence, Agility, Strength, StrikePowerBase);
        }
    }
        
    class Mirana : Hero
    {
        public Mirana()
        {
            Name = "Mirana";
            Intelligence = 22;
            Agility = 18;
            Strength = 18;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(25, 30);
        }
        //для клонирования
        public Mirana(string name, float intelligence, float agility, float strength, float strikePowerBase)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePowerBase = strikePowerBase;
        }
        protected override float StrikePower(IList<Item> bag)
        {
            return (StrikePowerBase + CalculateAgility(bag) + CalculateBagStrikePower(bag));
        }
        public override object Clone()
        {
            return new Mirana(Name, Intelligence, Agility, Strength, StrikePowerBase);
        }
    }

    class Ursa : Hero
    {
        public Ursa()
        {
            Name = "Ursa";
            Intelligence = 16;
            Agility = 18;
            Strength = 24;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(24, 28);
        }
        //для клонирования
        public Ursa(string name, float intelligence, float agility, float strength, float strikePowerBase)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePowerBase = strikePowerBase;
        }
        protected override float StrikePower(IList<Item> bag)
        {
            return (StrikePowerBase + CalculateAgility(bag) + CalculateBagStrikePower(bag));
        }
        public override object Clone()
        {
            return new Ursa(Name, Intelligence, Agility, Strength, StrikePowerBase);
        }
    }

    class DrowRanger : Hero
    {
        public DrowRanger()
        {
            Name = "Drow Ranger";
            Intelligence = 15;
            Agility = 30;
            Strength = 18;
            var rnd = new Random();
            StrikePowerBase = rnd.Next(19, 30);
        }
        //для клонирования
        public DrowRanger(string name, float intelligence, float agility, float strength, float strikePowerBase)
        {
            Name = name;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            StrikePowerBase = strikePowerBase;
        }
        protected override float StrikePower(IList<Item> bag)
        {
            return (StrikePowerBase + CalculateAgility(bag) + CalculateBagStrikePower(bag));
        }
        public override object Clone()
        {
            return new DrowRanger(Name, Intelligence, Agility, Strength, StrikePowerBase);
        }
    }


    class Program
    {
        //вывод инфо
        private static void PrintDictionary(Dictionary<Hero, IList<Item>> dictionary)
        {
            foreach (var keyValue in dictionary)
            {
                Console.WriteLine(keyValue.Key.HeroInfo(keyValue.Value));
            }
        }

        static void Main(string[] args)
        {
            //команда из 5 игроков
            //сумка из 6 предметов
            int team_capacity = 5;
            int list_capacity = 6;

            //создаем команду
            Dictionary<Hero, IList<Item>> team1 = new Dictionary<Hero, IList<Item>>(team_capacity);        
            
            Random random = new Random();
            for (int i = 0; i < team_capacity; i++)
            {
                List<Item> items1 = new List<Item>(list_capacity);
                //заполняем игрока
                int hero_imdex = random.Next(5);
                switch (hero_imdex)
                {
                    case 0:
                        team1.Add(new PhantomLancer(), items1);
                        break;
                    case 1:
                        team1.Add(new AntiMage(), items1);
                        break;
                    case 2:
                        team1.Add(new Mirana(), items1);
                        break;
                    case 3:
                        team1.Add(new Ursa(), items1);
                        break;
                    case 4:
                        team1.Add(new DrowRanger(), items1);
                        break;
                }

                //заполняем сумку героя
                for (int j = 0; j < list_capacity; j++)
                {
                    int item_imdex = random.Next(6);
                    switch (item_imdex)
                    {
                        case 0:
                            items1.Add(new Quarterstaff());
                            break;
                        case 1:
                            items1.Add(new MantaStyle());
                            break;
                        case 2:
                            items1.Add(new PhaseBoots());
                            break;
                        case 3:
                            items1.Add(new RingOfBasilius());
                            break;
                        case 4:
                            items1.Add(new Circlet());
                            break;
                        case 5:
                            items1.Add(new Buckler());
                            break;
                    }
                }
            }
            //вывод инфо команды 1
            Console.WriteLine("==========TEAM 1========");
            PrintDictionary(team1);

            //команда 2            
            Dictionary<Hero, IList<Item>> team2 = new Dictionary<Hero, IList<Item>>(team_capacity);
            //клонирование!
            foreach (KeyValuePair<Hero, IList<Item>> keyValue in team1)
            {
                List<Item> items2 = new List<Item>(list_capacity);
                team2.Add((Hero)keyValue.Key.Clone(), items2);
                foreach (Item item in keyValue.Value)
                {
                    items2.Add((Item)item.Clone());
                }
            }
            //вывод инфо команды 2
            Console.WriteLine("\n==========TEAM 2========");
            PrintDictionary(team2);

            //чтобы консоль не закрывалась
            Console.ReadKey();
        }
    }
}
