using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyArrayList<T> : IList<T>
    {
        public int Capacity { get; set; }
        private int ModCount;
        private T[] Contents;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                return Contents[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                Contents[index] = value;
            }
        }

        public int Count { get; private set; }

        public МyArrayList()
        {
            Count = 0;
            Capacity = 10;
            ModCount = 0;
            Contents = new T[Capacity];
        }

        public void TrimExcess()
        {
            Array.Resize(ref Contents, Count);
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
            if (Count > Contents.Length)
            {
                Capacity *= 2;
                Array.Resize(ref Contents, Capacity);
            }

            Contents[Count] = data;
            Count++;
            ModCount++;
        }

        public void Clear()
        {
            Count = 0;
            TrimExcess();
            ModCount++;
        }

        public bool Contains(T data)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(Contents[i], data))
                {
                    return true;
                }
            }

            return false;
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

            if (Contents.Length > array.Length - index)
            {
                throw new ArgumentOutOfRangeException("массив недостаточного размера");
            }

            Array.Copy(Contents, 0, array, index, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = ModCount;

            for (int i = 0; i < Contents.Length; ++i)
            {
                if (modCount != ModCount)
                {
                    throw new InvalidOperationException("Список был изменен!");
                }

                yield return Contents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T data)
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                if (Equals(data, Contents[i]))
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

            Count++;
            ModCount++;

            if (Count > Contents.Length)
            {
                Capacity *= 2;
                Array.Resize(ref Contents, Capacity);
            }

            if (Count == index - 1)
            {
                Contents[index] = data;
                return;
            }

            T[] contentsTemp = new T[Capacity];

            Array.Copy(Contents, 0, contentsTemp, 0, index);
            contentsTemp[index] = data;
            Array.Copy(Contents, index, contentsTemp, index + 1, Count - index - 1);
            Contents = contentsTemp;
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
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
                Array.Copy(Contents, index + 1, Contents, index, Count - index + 1);
            }

            Count--;
            ModCount++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Contents.Length == 0)
            {
                sb.Append("{ }");
                // для отладки
                sb.Append("\nCount:" + Count);
                sb.Append(" Capacity:" + Capacity);
                return sb.ToString();
            }

            sb.Append("{ ");

            for (int i = 0; i < Count; i++)
            {
                sb.Append(Contents[i]);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");
            // для отладки
            sb.Append("\nCount:" + Count);
            sb.Append(" Capacity:" + Capacity);

            return sb.ToString();
        }
    }
}