using System.Collections;
using System.Collections.Generic;

namespace CodingDojo.StopWatch
{
    public class QueueStack<T> : IEnumerable<T>
    {
        private readonly List<T> items = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public T Dequeue()
        {
            var item = items[0];
            items.Remove(item);
            return item;
        }

        public void Push(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
            items.Insert(0, item);
        }

        public T DequeueAndEnqueue()
        {
            var item = Dequeue();
            Enqueue(item);
            return item;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}