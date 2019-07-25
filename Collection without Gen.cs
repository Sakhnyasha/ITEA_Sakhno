using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class MyCollection : ICollection, IList, IEnumerable
    {
        public int[] arr = new int[4];
        private int _lenght = 0;
        public int capacity = 4;

        public int Count => _lenght;

        //добавление с авторасширением
        public int Add(object value)
        {
            if (_lenght == capacity)
            {
                capacity *= 2;
                int[] temp = new int[capacity];
                Array.Copy(arr, temp, arr.Length);
                arr = temp;
            }

            arr[_lenght] = (int)value;
            _lenght++;
            return _lenght - 1;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 || index < _lenght)
            {
                for (int i = index + 1; i < _lenght; i++)
                {
                    arr[i - 1] = arr[i];
                }
                _lenght--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _lenght; i++)
            {
                yield return arr[i];
            }
        }

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {

            MyCollection c = new MyCollection();
            c.Add(5);
            c.Add(6);
            c.Add(7);
            c.Add(8);
            Console.WriteLine("Array Size:" + c.Count);
            Console.WriteLine("Array Capacity:" + c.capacity);
            Console.Write("Array: ");
            foreach (int element in c)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");


            Console.WriteLine("Adding\n");
            c.Add(5);
            c.Add(6);
            c.Add(7);
            c.Add(8);
            Console.WriteLine("Array Size:"+c.Count);
            Console.WriteLine("Array Capacity:" + c.capacity);
            Console.Write("Array: ");
            foreach (int element in c)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");

            Console.WriteLine("Removing\n");
            c.RemoveAt(6);
            Console.WriteLine("Array Size:" + c.Count);
            Console.WriteLine("Array Capacity:" + c.capacity);
            Console.Write("Array: ");
            foreach (int element in c)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");



            Console.ReadKey();
        }
    }
}
