using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Задание: https://github.com/Sakhnyasha/ITEA_Sakhno/blob/Sakhnyasha-2HW6(7)/photo5357514902379539257.jpg

namespace McDonalds
{
    class StringProducer
    {
        public void ServiceProducer(string customer)
        {
            Console.Write("Start service: " + customer + "\n");
            Thread.Sleep(3000);
            Console.WriteLine("End servise:" + customer + " \n");
        }
    }
    class MyThread
    {
        StringProducer strprod;
        string customer;
        Semaphore sem;
        static Random rand = new Random();
        int temp = rand.Next(100);
        public Thread thread;

        public MyThread(StringProducer strprod, string customer, Semaphore sem)
        {
            this.strprod = strprod;
            this.customer = customer;
            this.sem = sem;
            thread = new Thread(Service);
            thread.Start();
        }
        public void Service()
        {
            sem.WaitOne();
            if (temp > 30)
            {
                strprod.ServiceProducer(customer);
            }
            else
            {
                Console.WriteLine("END");
                Console.ReadKey();
                Environment.Exit(0);
            }
            sem.Release();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            StringProducer strpr = new StringProducer();
            Semaphore sem = new Semaphore(1, 1);
            MyThread tr1 = new MyThread(strpr, "Cust 1", sem);
            tr1.thread.Join();
            MyThread tr2 = new MyThread(strpr, "Cust 2", sem);
            tr2.thread.Join();
            MyThread tr3 = new MyThread(strpr, "Cust 3", sem);
            tr3.thread.Join();
            MyThread tr4 = new MyThread(strpr, "Cust 4", sem);
            tr4.thread.Join();
            MyThread tr5 = new MyThread(strpr, "Cust 5", sem);
            tr5.thread.Join();

            Console.WriteLine("END");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
