using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    //迭代器抽象
    public interface Iterator
    {
        bool MoveNext();
        object GetCurrent();
        void Next();
        void Reset();

    }
    //抽象聚合类
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    //具体聚合类

    public class ConcreteList : IListCollection
    {
        int[] collection;

        public ConcreteList()
        {
            collection = new int[] { 2, 4, 6, 8 };
        }
        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Lenght
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }
    }

    //具体迭代器类
    public class ConcreteIterator : Iterator
    {
        //迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;
        private int _index;
        public ConcreteIterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }
        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public bool MoveNext()
        {
            if (_index < _list.Lenght)
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (_index < _list.Lenght)
            {
                _index++;
            }
        }

        public void Reset()
        {
            _index = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }

            Console.ReadLine();
        }
    }
}
