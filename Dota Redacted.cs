using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dota
{
    abstract class Hero
    {
        private double health = 400;

        protected String Name;
        protected float Intelligence;
        protected float Agility;
        protected float Strength;
        protected float StrikePower;

        //сумка игрока
        public Item[] bag = new Item[2];

        public string getName()
        {
            return Name;
        }

        public double getHealth()
        {
            return health;
        }

        public void setHealth(double health)
        {
            this.health = health;
        }

        //return сумму значений характеристик айтемов сумки и персонажа
        public float getIntelligence()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] != null)
                {
                    sum = sum + bag[i].getIntelligence();
                }
            }
            return sum + Intelligence;
        }
        public float getAgility()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] != null)
                {
                    sum = sum + bag[i].getAgility();
                }
            }
            return sum + Agility;
        }
        public float getStrength()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] != null)
                {
                    sum = sum + bag[i].getStrength();
                }
            }
            return sum + Strength;
        }
        public float getStrikePower()
        {
            return StrikePower;
        }
        public string getInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(getName() + "\tHeath: ");
            sb.Append(getHealth());
            sb.Append("\nStrength: ");
            sb.Append(getStrength());
            sb.Append(", Agility: ");
            sb.Append(getAgility());
            sb.Append(", Intelligence: ");
            sb.Append(getIntelligence());
            sb.Append(", StrikePower: ");
            sb.Append(getStrikePower());
            sb.Append("\nBag: \n");
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == null)
                {
                    sb.Append("- Empty\n");
                }
                else
                {
                    sb.Append(bag[i].getInfo() + "\n");
                }
            }
            return sb.ToString();
        }
        //у всех наследниках тоже есть такая функция
        abstract public void Hit(Hero opponent);
    }

    class Pudge : Hero
    {
        public Pudge()
        {
            Name = "Pudge         ";
            Intelligence = 2 ;
            Agility = 4;
            Strength = 10;
            StrikePower = 10;
        }
        override public void Hit(Hero opponent)
        {
            setHealth(Math.Round(Convert.ToDouble(opponent.getHealth() - (getStrikePower() + getStrength() / 2 + getAgility() / 4 + getIntelligence() / 4)), 0));
        }
    }

    class MonkeyKing : Hero
    {
        public MonkeyKing()
        {
            Name = "Monkey King   ";
            Intelligence = 6;
            Agility = 10;
            Strength = 5;
            StrikePower = 6;
        }
        override public void Hit(Hero opponent)
        {
            setHealth(Math.Round(Convert.ToDouble(opponent.getHealth() - (getStrikePower() + getStrength() / 4 + getAgility() / 2 + getIntelligence() / 4)), 0));
        }
    }

    class DrowRanger : Hero
    {
        public DrowRanger()
        {
            Name = "Drow Ranger   ";
            Intelligence = 6;
            Agility = 7;
            Strength = 4;
            StrikePower = 5;
        }
        override public void Hit(Hero opponent)
        {
            setHealth(Math.Round(Convert.ToDouble(opponent.getHealth() - (getStrikePower() + getStrength() / 4 + getAgility() / 2 + getIntelligence() / 4)), 0));
        }
    }

    class Warlock : Hero
    {
        public Warlock()
        {
            Name = "Warlock       ";
            Intelligence = 10;
            Agility = 7;
            Strength = 8;
            StrikePower = 9;
        }
        override public void Hit(Hero opponent)
        {
            setHealth(Math.Round(Convert.ToDouble(opponent.getHealth() - (getStrikePower() + getStrength() / 4 + getAgility() / 4 + getIntelligence() / 2)), 0));
        }
    }

    class CrystalMaiden : Hero
    {
        public CrystalMaiden()
        {
            Name = "Crystal Maiden";
            Intelligence = 10;
            Agility = 8;
            Strength = 9;
            StrikePower = 9;
        }
        override public void Hit(Hero opponent)
        {
            setHealth(Math.Round(Convert.ToDouble(opponent.getHealth() - (getStrikePower() + getStrength() / 4 + getAgility() / 4 + getIntelligence() / 2)), 0));
        }
    }

    class Item
    {
        protected string Name;
        protected float Intelligence;
        protected float Agility;
        protected float Strength;

        public string getName()
        {
            return Name;
        }
        public float getIntelligence()
        {
            return Intelligence;
        }
        public float getAgility()
        {
            return Agility;
        }
        public float getStrength()
        {
            return Strength;
        }

        public string getInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("- " + getName());
            sb.Append(". Strength: ");
            sb.Append(getStrength());
            sb.Append(", Agility: ");
            sb.Append(getAgility());
            sb.Append(", Intelligence: ");
            sb.Append(getIntelligence());
            return sb.ToString();
        }
    }

    class Bow : Item
    {
        public Bow()
        {
            Name = "Bow";
            Intelligence = 3;
            Agility = 8;
            Strength = 7;
        }
    }

    class Truncheon : Item
    {
        public Truncheon()
        {
            Name = "Truncheon";
            Intelligence = 2;
            Agility = 2;
            Strength = 9;
        }
    }

    class Wand : Item
    {
        public Wand()
        {
            Name = "Wand";
            Intelligence = 10;
            Agility = 5;
            Strength = 7;
        }
    }

    class Program
    {
        //вывод инфо
        private static void PrintHerosStatus(Hero[] heroes)
        {
            for (int i = 0; i < heroes.Length; i++)
            {
                Console.WriteLine("Hero" + (i + 1) + "\n" + heroes[i].getInfo() + "\n");
            }
            Thread.Sleep(1000);
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("█▀▀▀▄░░█▀▀▀▀█░▀▀▀█▀▀▀▒█▀▀▀▀█▒▒█ █" +
                "\n█░░░░█░█░░░▒█░░░░█░░▒▒█▒▒▒▒█▒▒█ █" +
                "\n█░░░░█░█░░░▒█░░░░█░░▒▒█▄▄▄▄█▒▒█ █" +
                "\n█░░░░█░█░░░▒█░░░░█░░▒▒█▒▒▒▒█▒▒█ █" +
                "\n█▄▄▄▀░░█▄▄▄▄█░░░░█░░▒▒█▒▒▒▒█▒▒█ █" +
                "\n========AUTOMATIC  FIGHTS========" +
                "\n\n====PRESS ANY KEY TO CONTINUE====");
            Console.ReadKey();
            Console.Clear();

            //массив для будущих игроков
            Hero[] heroes = new Hero[2];

            //выбор рандомных персонажей, стафа и запись в массив heroes
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int hero_imdex = random.Next(5);
                switch (hero_imdex)
                {
                    case 0:
                        heroes[i] = new Pudge();
                        break;
                    case 1:
                        heroes[i] = new MonkeyKing();
                        break;
                    case 2:
                        heroes[i] = new DrowRanger();
                        break;
                    case 3:
                        heroes[i] = new Warlock();
                        break;
                    case 4:
                        heroes[i] = new CrystalMaiden();
                        break;
                }

                //заполняем сумку героя
                for (int j = 0; j < 2; j++)
                {
                    int item_index = random.Next(4);
                    switch (item_index)
                    {
                        case 0:
                            heroes[i].bag[j] = new Bow();
                            break;
                        case 1:
                            heroes[i].bag[j] = new Truncheon();
                            break;
                        case 2:
                            heroes[i].bag[j] = new Wand();
                            break;
                        case 3:
                            heroes[i].bag[j] = null;
                            break;
                    }
                }
            }

            //вывод изначальных параметров игроков
            PrintHerosStatus(heroes);

            //пошла игра
            int current_move = 0;
            do
            {
                //определение игрока и его противника
                Hero player = heroes[current_move];
                Hero opponent = heroes[(current_move == 0) ? 1 : 0];

                //удар
                player.Hit(opponent);
                //смена хода
                current_move = (current_move == 0) ? 1 : 0;

                //если здоровье <0, то здоровье=0
                if (heroes[0].getHealth() < 0)
                {
                    heroes[0].setHealth(0);
                }
                else if (heroes[1].getHealth() < 0)
                {
                    heroes[1].setHealth(0);
                }
                //вывод инфо о состоянии героев
                PrintHerosStatus(heroes);
            }
            while (heroes[0].getHealth() > 0 && heroes[1].getHealth() > 0);
            Console.Clear();

            //вывод результата
            Hero winner = heroes[0].getHealth() == 0 ? heroes[1] : heroes[0];
            Console.WriteLine("WINNER: " + winner.getName() + "\n===========================" + "\nPress any key to quit!");

            //чтобы консоль не закрывалась
            //очистка буфера ввода
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Console.ReadKey();
            //закрыть консоль
            Environment.Exit(0);
        }
    }
}
