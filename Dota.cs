using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dota
{
    class Hero
    {
        public double health = 200;
        //сумка игрока
        public Item[] bag = new Item[2];
        virtual public string getName()
        {
            return "";
        }
        //return сумму значений характеристик айтемов сумки
        virtual public float getIntelligence ()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == null)
                {                   
                }
                else
                {
                    sum = sum + bag[i].getIntelligence();
                }
            }
            return sum;
        }
        virtual public float getAgility()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == null)
                {
                }
                else
                {
                    sum = sum + bag[i].getAgility();
                }
            }
            return sum;
        }
        virtual public float getStrength()
        {
            float sum = 0;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == null)
                {
                }
                else
                {
                    sum = sum + bag[i].getStrength();
                }
            }
            return sum;
        }
        virtual public float getStrikePower()
        {
            return 0;
        }
        public string getInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(getName() + "   Heath: ");
            sb.Append(health);
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
                if(bag[i] == null)
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
        //у всех нащадках тоже есть такая функция
        virtual public void Hit(Hero opponent)
        {
        }     
    }

    class Pudge: Hero
    {
        override public string getName()
        {
            return "Pudge         ";
        }
        override public float getIntelligence()
        {
            return 2 + base.getIntelligence();
        }
        override public float getAgility()
        {
            return 4 + base.getAgility();
        }
        override public float getStrength()
        {
            return 10 + base.getStrength();
        }
        override public float getStrikePower()
        {
            return 10 + base.getStrikePower();
        }
        override public void Hit(Hero opponent)
        {
            opponent.health = Math.Round((Convert.ToDouble(opponent.health - (getStrikePower() + getStrength() / 2 + getAgility() / 4 + getIntelligence() / 4))), 0);
        }
    }

    class MonkeyKing: Hero
    {
        override public string getName()
        {
            return "Monkey King   ";
        }
        override public float getIntelligence()
        {
            return 6 + base.getIntelligence();
        }
        override public float getAgility()
        {
            return 10 + base.getAgility();
        }
        override public float getStrength()
        {
            return 5 + base.getStrength();
        }
        override public float getStrikePower()
        {
            return 6 + base.getStrikePower();
        }
        override public void Hit(Hero opponent)
        {
            opponent.health = Math.Round((Convert.ToDouble(opponent.health - (getStrikePower() + getStrength() / 4 + getAgility() / 2 + getIntelligence() / 4))), 0);
        }
    }

    class DrowRanger: Hero
    {
        override public string getName()
        {
            return "Drow Ranger   ";
        }
        override public float getIntelligence()
        {
            return 6 + base.getIntelligence();
        }
        override public float getAgility()
        {
            return 7 + base.getAgility();
        }
        override public float getStrength()
        {
            return 4 + base.getStrength();
        }
        override public float getStrikePower()
        {
            return 5 + base.getStrikePower();
        }
        override public void Hit(Hero opponent)
        {
            opponent.health = Math.Round((Convert.ToDouble(opponent.health - (getStrikePower() + getStrength() / 4 + getAgility() / 2 + getIntelligence() / 4))), 0);
        }
    }

    class Warlock: Hero
    {
        override public string getName()
        {
            return "Warlock       ";
        }
        override public float getIntelligence()
        {
            return 10 + base.getIntelligence();
        }
        override public float getAgility()
        {
            return 7 + base.getAgility();
        }
        override public float getStrength()
        {
            return 8 + base.getStrength();
        }
        override public float getStrikePower()
        {
            return 9 + base.getStrikePower();
        }
        override public void Hit(Hero opponent)
        {
            opponent.health = Math.Round((Convert.ToDouble(opponent.health - (getStrikePower() + getStrength() / 4 + getAgility() / 4 + getIntelligence() / 2))), 0);
        }
    }

    class CrystalMaiden: Hero
    {
        override public string getName()
        {
            return "Crystal Maiden";
        }
        override public float getIntelligence()
        {
            return 10 + base.getIntelligence();
        }
        override public float getAgility()
        {
            return 8 + base.getAgility();
        }
        override public float getStrength()
        {
            return 9 + base.getStrength();
        }
        override public float getStrikePower()
        {
            return 9 + base.getStrikePower();
        }
        override public void Hit(Hero opponent)
        {
            opponent.health = Math.Round((Convert.ToDouble(opponent.health - (getStrikePower() + getStrength() / 4 + getAgility() / 4 + getIntelligence() / 2))), 0);
        }
    }


    class Item
    {
        virtual public string getName()
        {
            return "";
        }
        virtual public float getIntelligence()
        {
            return 0;
        }
        virtual public float getAgility()
        {
            return 0;
        }
        virtual public float getStrength()
        {
            return 0;
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
        override public string getName()
        {
            return "Bow";
        }
        override public float getIntelligence()
        {
            return 3;
        }
        override public float getAgility()
        {
            return 8;
        }
        override public float getStrength()
        {
            return 7;
        }
    }

    class Truncheon : Item
    {
        override public string getName()
        {
            return "Truncheon";
        }
        override public float getIntelligence()
        {
            return 2;
        }
        override public float getAgility()
        {
            return 2;
        }
        override public float getStrength()
        {
            return 9;
        }
    }

    class Wand : Item
    {
        override public string getName()
        {
            return "Wand";
        }
        override public float getIntelligence()
        {
            return 10;
        }
        override public float getAgility()
        {
            return 5;
        }
        override public float getStrength()
        {
            return 7;
        }
    }
        
    class Program
    {
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
                        Pudge pudge = new Pudge();
                        heroes[i] = pudge;
                        break;
                    case 1:
                        MonkeyKing monkeyKing = new MonkeyKing();
                        heroes[i] = monkeyKing;
                        break;
                    case 2:
                        DrowRanger drowRanger = new DrowRanger();
                        heroes[i] = drowRanger;
                        break;
                    case 3:
                        Warlock warlock = new Warlock();
                        heroes[i] = warlock;
                        break;
                    case 4:
                        CrystalMaiden crystalMaiden = new CrystalMaiden();
                        heroes[i] = crystalMaiden;
                        break;
                }

                //заполняем сумку героя
                for(int j = 0; j < 2; j++)
                {
                    int item_index = random.Next(4);
                    switch(item_index)
                    {
                        case 0:
                            Bow bow = new Bow();
                            heroes[i].bag[j] = bow;
                            break;
                        case 1:
                            Truncheon truncheon = new Truncheon();
                            heroes[i].bag[j] = truncheon;
                            break;
                        case 2:
                            Wand wand = new Wand();
                            heroes[i].bag[j] = wand;
                            break;
                        case 3:
                            heroes[i].bag[j] = null;
                            break;
                    }
                }
            }

            //вывод изначальных параметров игроков
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Hero" + (i + 1) + "\n" + heroes[i].getInfo() + "\n");
            }
            Thread.Sleep(1000);
            Console.WriteLine("=======================");

            //пошла игра
            int current_move = 0;
            while (heroes[0].health > 0 && heroes[1].health > 0)
            {
                //определение игрока и его противника
                Hero player = heroes[current_move];
                Hero opponent = heroes[(current_move==0)?1:0];

                //удар
                player.Hit(opponent);
                //смена хода
                current_move = (current_move == 0) ? 1 : 0;

                //вывод лога и результата
                Console.Clear();
                if (heroes[0].health <= 0)
                {
                    Console.WriteLine("WINNER: " + heroes[1].getName());
                    break;
                }
                else if (heroes[1].health <= 0)
                {
                    Console.WriteLine("WINNER: " + heroes[0].getName());
                    break;
                }
                else
                {
                    //вывод инфо о состоянии героев
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("Hero" + (i + 1) + "\n" + heroes[i].getInfo() + "\n");
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine("=======================");
                }                
            }
            
            Console.WriteLine("\n===========================");
            Console.WriteLine("Press any key to quit!");
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