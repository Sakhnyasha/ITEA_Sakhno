using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class MyCollection<T> : IList
    {
        private T[] _arr;
        private int _lenght;

        public int Сapacity { get; private set; }

        public MyCollection(int сapacity)
        {
            Сapacity = сapacity;
            _arr = new T[сapacity];
        }

        //количество элиментов в массиве
        public int Count => _lenght;

        //добавление с авторасширением
        public int Add(object value)
        {
            if (_lenght == Сapacity)
            {
                Сapacity *= 2;
                T[] temp = new T[Сapacity];
                Array.Copy(_arr, temp, _arr.Length);
                _arr = temp;
            }

            _arr[_lenght] = (T)value;
            _lenght++;
            return _lenght - 1;
        }

        //удаление по ссылке на элимент
        public void RemoveAt(int index)
        {
            if (index >= 0 || index < _lenght)
            {
                for (int i = index + 1; i < _lenght; i++)
                {
                    _arr[i - 1] = _arr[i];
                }
                _lenght--;
            }
        }

        //для возможности передобра foreach, например
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _lenght; i++)
            {
                yield return _arr[i];
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
            MyCollection<int> collection = new MyCollection<int>(4);
            //добавление элиментов
            collection.Add(5);
            collection.Add(6);
            collection.Add(7);
            collection.Add(8);
            Console.WriteLine("Array Size:" + collection.Count);
            Console.WriteLine("Array Capacity:" + collection.Сapacity);
            //вывод массива
            Console.Write("Array: ");
            foreach (int element in collection)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");

            //добавление элиментов с расширением массива
            Console.WriteLine("Adding\n");
            collection.Add(5);
            collection.Add(6);
            collection.Add(7);
            collection.Add(8);
            Console.WriteLine("Array Size:"+ collection.Count);
            Console.WriteLine("Array Capacity:" + collection.Сapacity);
            Console.Write("Array: ");
            foreach (int element in collection)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");

            //удаление элимента
            Console.WriteLine("Removing\n");
            collection.RemoveAt(6);
            Console.WriteLine("Array Size:" + collection.Count);
            Console.WriteLine("Array Capacity:" + collection.Сapacity);
            Console.Write("Array: ");
            foreach (int element in collection)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("\n========");



            Console.ReadKey();
        }
    }
}
