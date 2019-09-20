using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    class MyHashTable<T> : ICollection<T>
    {
        private int length;
        private List<T>[] itemsList = new List<T>[10];
        //TODO
        public int Count { get; }

        public void Add(T item)
        {

        }

        public void Clear()
        {

        }

        public bool Contains(T item)
        {
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        public bool Remove(T item)
        {
            return true;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
