using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        public int Count { get; set; }

        public T GetFirstValue()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Список пуст");
            }

            return Head.Data;
        }

        private ListItem<T> Iterate(int index)
        {
            if (index > Count || index < 0)
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
            return Iterate(index).Data; ;
        }

        public T Change(int index, T data)
        {
            T oldValue = default(T);
            int n = 0;

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
            T oldValue = default(T);
            int n = 0;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (n == index)
                {
                    oldValue = p.Data;
                    prev.Next = p.Next;
                    Count--;
                }

                n++;
            }

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
            if (index > Count - 1 && index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            ListItem<T> listItem = new ListItem<T>(data);
            int n = 0;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (n == index)
                {
                    prev.Next = listItem;
                    listItem.Next = p;
                    Count++;
                    break;
                }

                n++;
            }
        }

        public bool DeleteValue(T data)
        {
            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (p.Data != null && data != null && p.Data.Equals(data) || p.Data == null && data == null)
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
            ListItem<T> current = Head;
            ListItem<T> prev = null;
            listCopy.Head = Head;

            while (current != null)
            {
                ListItem<T> listItem = new ListItem<T>(current.Data, prev);
                listCopy.Count++;
                prev = current;
                current = current.Next;
            }
            
            return listCopy;
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