using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        #region fields&property

        private T[] array;
        private int capacity = 8;
        private int count;

        public int Count => count;

        #endregion

        #region ctors

        public Queue()
        {
            array = new T[0];
        }

        public Queue(int capacity)
        {
            if (capacity < 0) throw new ArgumentException($"{nameof(capacity)} can't less then zero");
            array = new T[capacity];
            this.capacity = capacity;
        }

        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException($"{nameof(collection)} is null");
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        #endregion

        public void Enqueue(T item)
        {
            if (count == capacity)
            {
                capacity *= 2;
                Array.Resize(ref array, capacity);
            }
            array[count++] = item;
        }

        public T Dequeue()
        {
            if (count == 0) throw new InvalidOperationException("queue is empty");
            T item = array[0];
            for (int i = 1; i < count; i++)
            {
                array[i - 1] = array[i];
            }
            array[count--] = default(T);
            return item;
        }

        public T Peek()
        {
            if (count == 0) throw new InvalidOperationException("queue is empty");
            return array[0];
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> equialityComparer = EqualityComparer<T>.Default;
            for (int i = 0; i < count; i++)
            {
                if (ReferenceEquals(array[i], item)) return true;
                if (equialityComparer.Equals(array[i], item))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
        }

        public void СоруТо(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null");
            if (arrayIndex < 0) throw new ArgumentException("arrayIndex can't be less than 0");
            for (int i = 0; i < count; i++)
            {
                if (arrayIndex + i >= array.Length) break;
                array[arrayIndex + i] = this.array[count - i - 1];
            }
        }

        public T[] ToArray()
        {
            T[] newArray = new T[count];
            Array.Copy(array, newArray, count);
            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
