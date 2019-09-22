using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        public int Capacity
        {
            get
            {
                return contents.Length;
            }

            set
            {
                if (Capacity != value)
                {
                    if (value < Count)
                    {
                        throw new ArgumentOutOfRangeException("значение меньше размера списка");
                    }
                   
                    Array.Resize(ref contents, value);
                    Capacity = value;                    
                }
            }
        }

        private int modCount;
        private T[] contents;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                return contents[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                contents[index] = value;
            }
        }

        public int Count { get; private set; }

        public МyArrayList()
        {
            Count = 0;
            modCount = 0;
            contents = new T[DefaultCapacity];
            Capacity = DefaultCapacity;
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T data)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;              
            }

            contents[Count] = data;
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Count = 0;
            Capacity = DefaultCapacity;
            modCount++;
        }

        public bool Contains(T data)
        {
            return IndexOf(data) >= 0;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("массив null");
            }

            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException("индекс должен быть в пределах массива");
            }

            if (contents.Length > array.Length - index)
            {
                throw new ArgumentOutOfRangeException("массив недостаточного размера");
            }

            Array.Copy(contents, 0, array, index, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = this.modCount;

            for (int i = 0; i < Count; i++)
            {
                if (modCount != this.modCount)
                {
                    throw new InvalidOperationException("Список был изменен");
                }

                yield return contents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T data)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(data, contents[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T data)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            if (Count == Capacity)
            {
                Capacity *= 2;                
            }

            if (Count == index)
            {
                contents[index] = data;
                Count++;
                modCount++;
                return;
            }

            Array.Copy(contents, index, contents, index + 1, Count - index);
            contents[index] = data;
            Count++;
            modCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            if (index + 1 < Count)
            {
                Array.Copy(contents, index + 1, contents, index, Count - index - 1);
            }

            Count--;
            modCount++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (contents.Length == 0)
            {
                sb.Append("{ }");
                return sb.ToString();
            }

            sb.Append("{ ");

            for (int i = 0; i < Count; i++)
            {
                sb.Append(contents[i]);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}