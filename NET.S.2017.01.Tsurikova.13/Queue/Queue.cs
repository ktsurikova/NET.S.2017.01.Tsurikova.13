using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    /// <summary>
    /// queue collection
    /// </summary>
    /// <typeparam name="T">define type of elements in queue</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region fields&property

        private T[] array;
        private int head;
        private int tail;
        private int capacity = 8;
        private int count;
        private int version;

        /// <summary>
        /// number of elements in queue
        /// </summary>
        public int Count => count;

        #endregion

        #region ctors

        /// <summary>
        /// initializes a new instance of class with the default initial capacity
        /// </summary>
        public Queue()
        {
            array = new T[capacity];
        }

        /// <summary>
        /// initializes a new instance of class with the specified initial capacity
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        /// <exception cref="ArgumentException">throws when capacity is invalid</exception>
        public Queue(int capacity)
        {
            if (capacity < 0) throw new ArgumentException($"{nameof(capacity)} can't less then zero");
            array = new T[capacity];
            this.capacity = capacity;
        }

        /// <summary>
        /// initializes a new instance of class with elements from collection
        /// </summary>
        /// <param name="collection">collection whose elements are copied</param>
        /// <exception cref="ArgumentNullException">throws when collection is null</exception>
        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException($"{nameof(collection)} is null");
            array = new T[collection.Count()];
            capacity = array.Length;
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        #endregion

        #region enqueue, dequeue, peek

        /// <summary>
        /// add element to queue
        /// </summary>
        /// <param name="item">element to be added</param>
        public void Enqueue(T item)
        {
            if (count == capacity)
            {
                capacity *= 2;
                Resize(capacity);
            }
            array[tail] = item;
            tail = (tail + 1) % capacity;
            count++;
            version++;
        }

        private void Resize(int capacity)
        {
            T[] newArray = new T[capacity];

            if (count > 0)
            {
                if (head < tail)
                    Array.Copy(array, head, newArray, 0, count);
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            head = 0;
            tail = count == capacity ? 0 : count;
            version++;
        }

        /// <summary>
        /// remove element from queue
        /// </summary>
        /// <returns>removed element</returns>
        /// <exception cref="InvalidOperationException">throws when queue is empty</exception>
        public T Dequeue()
        {
            if (count == 0) throw new InvalidOperationException("queue is empty");

            T item = array[head];
            array[head] = default(T);
            head = (head + 1) % capacity;
            count--;
            version++;
            return item;
        }

        /// <summary>
        /// returns element at the beginning without removing them
        /// </summary>
        /// <returns>element at the beginning</returns>
        /// <exception cref="InvalidOperationException">throws when queue is empty</exception>
        public T Peek()
        {
            if (count == 0) throw new InvalidOperationException("queue is empty");
            return array[head];
        }

        #endregion

        #region other methods

        /// <summary>
        /// determine whether queue contains element
        /// </summary>
        /// <param name="item">item to be checked</param>
        /// <returns>true if contains, otherwise false</returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> equialityComparer = EqualityComparer<T>.Default;
            int index = head;

            for (int counter = count; counter > 0; counter--)
            {
                if (ReferenceEquals(array[index], item)) return true;
                if (equialityComparer.Equals(array[index], item))
                    return true;
                index = (index + 1) % capacity;
            }

            return false;
        }

        /// <summary>
        /// remove all elements from queue
        /// </summary>
        public void Clear()
        {
            if (head < tail)
                Array.Clear(array, 0, count);
            else
            {
                Array.Clear(array, head, capacity - head);
                Array.Clear(array, 0, tail);
            }

            head = 0;
            tail = 0;
            count = 0;
            version++;
        }

        /// <summary>
        /// copy elements of queue to array
        /// </summary>
        /// <param name="array">array into which elements of the queue will be copied</param>
        /// <param name="arrayIndex">index at which copying begins</param>
        /// <exception cref="ArgumentNullException">throws when array id null</exception>
        /// <exception cref="ArgumentException">throws when arrayIndex is invalid</exception>
        public void СоруТо(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null");
            if (arrayIndex < 0) throw new ArgumentException($"{nameof(arrayIndex)} can't be less than 0");

            int numOfElem = array.Length - arrayIndex < count ? array.Length - arrayIndex : count;
            if (numOfElem == 0) return;

            int fromHead = capacity - head < numOfElem ? capacity - head : numOfElem;
            Array.Copy(this.array, head, array, arrayIndex, fromHead);

            int fromStart = numOfElem - fromHead;
            if (fromStart <= 0) return;
            Array.Copy(this.array, 0, array, arrayIndex + capacity - head, fromStart);
        }

        /// <summary>
        /// copy elements to a new array
        /// </summary>
        /// <returns>new array containing copied elements</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[count];

            if (head < tail)
                Array.Copy(array, head, newArray, 0, count);
            else
            {
                Array.Copy(array, head, newArray, 0, capacity - head);
                Array.Copy(array, 0, newArray, capacity - head, tail);
            }

            return newArray;
        }

        #endregion

        /// <summary>
        /// returns enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public QueueEnumerator GetEnumerator() => new QueueEnumerator(this);

        #region enumerator

        public struct QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private int index;
            private int version;

            public QueueEnumerator(Queue<T> collection) : this()
            {
                queue = collection;
                index = -1;
                version = queue.version;
            }

            /// <summary>
            /// moves enumerator to the next element
            /// </summary>
            /// <returns>true if it's possible, otherwise false</returns>
            public bool MoveNext()
            {
                if (version != queue.version)
                    throw new InvalidOperationException("queue was modified");
                return ++index < queue.Count;
            }

            /// <summary>
            /// returns element in current position
            /// </summary>
            public T Current
            {
                get
                {
                    if (index <= -1 || index >= queue.Count)
                        throw new InvalidOperationException();
                    return queue.array[index];
                }
            }

            object IEnumerator.Current => Current;

            void IEnumerator.Reset()
            {
                if (version != queue.version)
                    throw new InvalidOperationException("queue was modified");
                index = -1;
            }

            void IDisposable.Dispose()
            {
            }
        }

        #endregion
    }
}
