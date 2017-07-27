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
        private int capacity = 8;
        private int count;

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
            array = new T[0];
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
                Array.Resize(ref array, capacity);
            }
            array[count++] = item;
        }

        /// <summary>
        /// remove element from queue
        /// </summary>
        /// <returns>removed element</returns>
        /// <exception cref="InvalidOperationException">throws when queue is empty</exception>
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

        /// <summary>
        /// returns element at the beginning without removing them
        /// </summary>
        /// <returns>element at the beginning</returns>
        /// <exception cref="InvalidOperationException">throws when queue is empty</exception>
        public T Peek()
        {
            if (count == 0) throw new InvalidOperationException("queue is empty");
            return array[0];
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
            for (int i = 0; i < count; i++)
            {
                if (ReferenceEquals(array[i], item)) return true;
                if (equialityComparer.Equals(array[i], item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// remove all elements from queue
        /// </summary>
        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
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
            for (int i = 0; i < count; i++)
            {
                if (arrayIndex + i >= array.Length) break;
                array[arrayIndex + i] = this.array[i];
            }
        }

        /// <summary>
        /// copy elements to a new array
        /// </summary>
        /// <returns>new array containing copied elements</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[count];
            Array.Copy(array, newArray, count);
            return newArray;
        }

        #endregion

        /// <summary>
        /// returns enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<T> GetEnumerator() => new QueueEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region enumerator

        private struct QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private int index;

            public QueueEnumerator(Queue<T> collection) : this()
            {
                queue = collection;
                index = -1;
            }

            /// <summary>
            /// moves enumerator to the next element
            /// </summary>
            /// <returns>true if it's possible, otherwise false</returns>
            public bool MoveNext() => ++index < queue.Count;

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

            void IEnumerator.Reset() => index = -1;

            void IDisposable.Dispose()
            {
            }
        }

        #endregion
    }
}
