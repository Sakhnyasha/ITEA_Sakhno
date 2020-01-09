using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Задание: https://github.com/Sakhnyasha/ITEA_Sakhno/blob/Sakhnyasha-2HW6(7)/photo5357514902379539257.jpg

namespace GoldMine
{
    class GoldMine
    {
        private volatile int gold = 100;
        public int TakeGold()
        {
            lock (this)
            {
                var goldPortion = gold >= 3 ? 3 : gold;
                gold -= goldPortion;
                return goldPortion;
            }
        }
        public bool IsEmpty()
        {
            lock (this)
            {
                return gold <= 0;
            }
        }
    }

    class Worker
    {
        GoldMine goldMine;
        int totalGold;
        string name; 

        public Worker(GoldMine goldMine, string name)
        {
            this.goldMine = goldMine;
            this.name = name;
            new Thread(Method).Start();
        }
        public void Method()
        {
            while (!goldMine.IsEmpty())
            {
                totalGold += goldMine.TakeGold();
                Console.WriteLine(name +  " mined = " + totalGold);
                Thread.Sleep(1000);
            }
            Console.WriteLine(name+ " finished work. Total gold: " + totalGold);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GoldMine goldMine = new GoldMine();
            new Worker(goldMine, "Worker 1");
            new Worker(goldMine, "Worker 2");
            new Worker(goldMine, "Worker 3");
            Thread.Sleep(10000);

            for (int i=4; !goldMine.IsEmpty(); i++)
            {
                new Worker(goldMine, "Worker " + i);
                Thread.Sleep(10000);
            }
            
            Console.ReadKey();
        }
    }
}
