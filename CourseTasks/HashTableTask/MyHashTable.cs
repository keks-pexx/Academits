using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    class MyHashTable<T> : ICollection<T>
    {
        private readonly List<T>[] contents;
        private int modCount;   
        public int Count { get; private set; }

        public MyHashTable(params T[] data)
        {
            Count = 0;

            foreach (var e in data)
            {
                Add(e);
            }
        }

        public MyHashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("размер не может быть меньше 1");
            }

            contents = new List<T>[capacity];
            Count = 0;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            var index = GetIndex(item);

            if (ReferenceEquals(contents[index], null))
            {
                contents[index] = new List<T>();
            }

            contents[index].Add(item);

            Count++;
            modCount++;
        }

        public void Clear()
        {
            foreach (List<T> t in contents)
            {
                if (ReferenceEquals(t, null))
                {
                    continue;
                }

                t.Clear();
            }

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            var index = GetIndex(item);

            if (ReferenceEquals(contents[index], null))
            {
                return false;
            }

            return contents[index].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException("cсылка на null");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("индекс меньше 0");
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("недостаточно места для копируемого массива");
            }

            var i = arrayIndex;

            foreach (var e in this)
            {
                array[i] = e;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = this.modCount;
            foreach (var item in contents)
            {
                if (ReferenceEquals(item, null))
                {
                    continue;
                }

                foreach (var e in item)
                {
                    if (modCount != this.modCount)
                    {
                        throw new InvalidOperationException("Список был изменен");
                    }

                    yield return e;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            var index = GetIndex(item);

            if (ReferenceEquals(contents[index], null))
            {
                return false;
            }

            if (contents[index].Remove(item))
            {
                Count--;
                modCount++;

                return true;
            }

            return false;
        }

        private int GetIndex(T item)
        {
            return ReferenceEquals(item, null) ? 0 : Math.Abs(item.GetHashCode() % contents.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var hashTable = this;

            sb.Append("{ ");

            foreach (var e in hashTable)
            {                
                if (e == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(e);
                }

                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}