using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    /// <summary>
    /// set collection
    /// </summary>
    /// <typeparam name="T">define type of elements in set</typeparam>
    public class Set<T> : ISet<T> where T : class, IEquatable<T>
    {
        #region fields&properties

        private T[] array;
        private int capacity = 8;
        private int count;

        /// <summary>
        /// number of elements in queue
        /// </summary>
        public int Count => count;

        /// <summary>
        /// gets value indicating whether the set is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        private bool IsFull() => count == capacity;

        #endregion

        #region Ctors

        /// <summary>
        /// initializes a new instance of class with the default initial capacity
        /// </summary>
        public Set()
        {
            array = new T[capacity];
        }

        /// <summary>
        /// initializes a new instance of class with the specified initial capacity
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        /// <exception cref="ArgumentException">throws when capacity is invalid</exception>
        public Set(int capacity)
        {
            if (capacity < 0) throw new ArgumentException($"{nameof(capacity)} can't be less than zero");
            this.capacity = capacity;
            array = new T[capacity];
        }

        /// <summary>
        /// initializes a new instance of class with elements from collection
        /// </summary>
        /// <param name="collection">collection whose elements are copied</param>
        /// <exception cref="ArgumentNullException">throws when collection is null</exception>
        public Set(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException($"{nameof(collection)} is null");
            array = new T[collection.Count()];
            capacity = array.Length;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        #endregion

        #region iset implementation

        /// <summary>
        /// add item to set
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <returns>rue if successfully added, otherwise false</returns>
        /// <exception cref="ArgumentNullException">throws when item is null</exception>
        public bool Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException($"{nameof(item)} is null");
            if (!Contains(item))
            {
                if (IsFull())
                {
                    capacity *= 2;
                    Array.Resize(ref array, capacity);
                }

                array[count++] = item;
                return true;
            }
            return false;
        }

        /// <summary>
        /// determine whether queue contains element
        /// </summary>
        /// <param name="item">item to be checked</param>
        /// <returns>true if contains, otherwise false</returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }

        #region enumerator

        /// <summary>
        /// returns enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        /// <summary>
        /// modifies the current set so that it contains all elements that are present in
        /// either the current set or the specified collection.
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            foreach (var item in other)
            {
                Add(item);
            }
        }

        /// <summary>
        /// modifies the current set so that it contains only elements that are also in a
        /// specified collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            for (int i = 0; i < count; i++)
            {
                if (!other.Contains(array[i], EqualityComparer<T>.Default))
                {
                    Remove(array[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// removes all elements in the specified collection from the current set
        /// </summary>
        /// <param name="other">collection of items to remove from the set</param>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            foreach (var item in other)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// modifies the current set so that it contains only elements that are present either
        /// in the current set or in the specified collection, but not both
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            List<T> toAddList = new List<T>();
            foreach (var item in other)
            {
                if (!Contains(item))
                    toAddList.Add(item);
            }
            ExceptWith(other);
            foreach (var item in toAddList)
            {
                Add(item);
            }
        }


        #region InclusionRelations

        /// <summary>
        /// determines whether a set is a subset of a specified collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set is a subset of other; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            if (count > other.Count()) return false;
            for (int i = 0; i < count; i++)
            {
                if (!other.Contains(array[i], EqualityComparer<T>.Default)) return false;
            }
            return true;
        }

        /// <summary>
        /// determines whether the current set is a superset of a specified collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set is a superset of other; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            if (count < other.Count()) return false;
            foreach (var item in other)
            {
                if (!Contains(item)) return false;
            }
            return true;
        }

        /// <summary>
        /// determines whether the current set is a proper (strict) superset of a specified
        ///  collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set is a proper superset of other; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            if (count <= other.Count()) return false;
            return IsSupersetOf(other);
        }

        /// <summary>
        /// determines whether the current set is a proper (strict) subset of a specified
        /// collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set is a proper subset of other; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            if (count >= other.Count()) return false;
            return IsSubsetOf(other);
        }

        /// <summary>
        /// determines whether the current set overlaps with the specified collection
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set and other share at least one common element; otherwise,
        ///     false</returns>
        /// <exception cref="ArgumentNullException">throws when other is null</exception>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            foreach (var item in other)
            {
                if (Contains(item)) return true;
            }
            return false;
        }

        #endregion

        #region equals set

        /// <summary>
        /// determines whether the current set and the specified collection contain the same
        /// elements
        /// </summary>
        /// <param name="other">collection to compare to the current set</param>
        /// <returns>true if the current set is equal to other; otherwise, false</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException($"{nameof(other)} is null");
            if (ReferenceEquals(other, this)) return true;

            if (other.Count() != count) return false;
            return IsEqualsSet(this, other) && IsEqualsSet(other, this);
        }

        private static bool IsEqualsSet(IEnumerable<T> a, IEnumerable<T> b)
        {
            foreach (var item in a)
            {
                if (!b.Contains(item, EqualityComparer<T>.Default)) return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// add item to set
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <returns>rue if successfully added, otherwise false</returns>
        /// <exception cref="ArgumentNullException">throws when item is null</exception>
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// remove all elements from set
        /// </summary>
        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
        }

        /// <summary>
        /// copy elements of set to array
        /// </summary>
        /// <param name="otherArray">array into which elements of the set will be copied</param>
        /// <param name="arrayIndex">index at which copying begins</param>
        /// <exception cref="ArgumentNullException">throws when array id null</exception>
        /// <exception cref="ArgumentException">throws when arrayIndex is invalid</exception>
        public void CopyTo(T[] otherArray, int arrayIndex)
        {
            if (ReferenceEquals(otherArray, null)) throw new ArgumentNullException($"{nameof(array)} is null");
            if (arrayIndex < 0) throw new ArgumentException($"{nameof(arrayIndex)} can't be less than 0");

            for (int i = 0; i < count; i++)
            {
                if (arrayIndex + i >= otherArray.Length) break;
                otherArray[arrayIndex + i] = array[i];
            }
        }

        /// <summary>
        /// remove item for set
        /// </summary>
        /// <param name="item">element to be removed</param>
        /// <returns>true if item successfully removed, otherwise false</returns>
        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            var i = Array.IndexOf(array, item);
            array[i] = array[count - 1];
            array[count - 1] = default(T);
            count--;
            return true;
        }

        #endregion

    }
}

