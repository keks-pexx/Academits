using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        public int Count { get; private set; }

        public T GetFirstValue()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Список пуст");
            }

            return Head.Data;
        }

        private ListItem<T> IterateToIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            int n = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    return p;
                }

                n++;
            }

            return null;
        }

        public T GetValue(int index)
        {
            return IterateToIndex(index).Data;
        }

        public T Change(int index, T data)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            int n = 0;

            T oldValue = Head.Data;
            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    oldValue = p.Data;
                    p.Data = data;
                }

                n++;
            }

            return oldValue;
        }

        public T Delete(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            T oldValue = Head.Data;

            if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                ListItem<T> p = IterateToIndex(index - 1);
                oldValue = p.Next.Data;
                p.Next = p.Next.Next;
            }

            Count--;
            return oldValue;
        }

        public void AddToBegin(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data, Head);

            Head = listItem;
            Count++;
        }

        public void AddByIndex(int index, T data)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            ListItem<T> listItem = new ListItem<T>(data);
            int n = 0;

            if (index == 0)
            {
                listItem.Next = Head;
                Head = listItem;
            }
            else if (index == Count)
            {
                ListItem<T> prev = IterateToIndex(index - 1);
                prev.Next = listItem;
                Count++;
            }
            else
            {
                ListItem<T> prev = IterateToIndex(index - 1);
                listItem.Next = prev.Next;
                prev.Next = listItem;
                Count++;
            }
        }

        public bool DeleteValue(T data)
        {
            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (Equals(data, p.Data))
                {
                    if (prev != null)
                    {
                        prev.Next = p.Next;
                    }
                    else
                    {
                        Head = Head.Next;
                    }

                    Count--;
                    return true;
                }
            }

            return false;
        }

        public T DeleteHead()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Список пуст");
            }

            T oldValue = Head.Data;
            Head = Head.Next;
            Count--;

            return oldValue;
        }

        public void Reverse()
        {
            ListItem<T> prev = null;
            ListItem<T> current = Head;

            while (current != null)
            {
                ListItem<T> next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>();

            if (Count == 0)
            {
                return listCopy;
            }
            else
            {
                listCopy.Head = new ListItem<T>(Head.Data);
                listCopy.Count = Count;
                ListItem<T> prev = listCopy.Head;
                ListItem<T> current = Head.Next;

                while (current != null)
                {
                    ListItem<T> listItem = new ListItem<T>(current.Data);
                    prev.Next = listItem;
                    prev = listItem;
                    current = current.Next;
                }
                               
                return listCopy;
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                sb.Append(p.Data);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");
            return sb.ToString();
        }
    }
}