using System;

namespace HashTableTask
{
    class HashTableTask
    {
        static void Main(string[] args)
        {
            var hashTable = new MyHashTable<string>(20);

            hashTable.Add("Значение1");
            hashTable.Add("Значение3");
            hashTable.Add("Значение 123");
            hashTable.Add("200");
            hashTable.Add("345");
            hashTable.Add(null);
            hashTable.Add("Nubmer2");           

            Console.WriteLine(hashTable);
            Console.WriteLine(hashTable.Contains("345"));            
            Console.WriteLine();

            hashTable.Remove("Значение3");
            hashTable.Remove(null);
            Console.WriteLine(hashTable);

            Console.ReadKey();
        }             
    }
}
