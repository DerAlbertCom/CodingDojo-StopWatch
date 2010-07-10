using System.Collections;
using System.Collections.Generic;

namespace CodingDojo.StopWatch
{
    public class SimpleArray<T> : IEnumerable<T> where T : class , new()
    {
        private readonly List<T> array;

        public SimpleArray(int capacity)
        {
            array = new List<T>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                array.Add(null);
            }
        }

        public T this[int index]
        {
            get { return array[index]; }
            internal set { array[index] = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}