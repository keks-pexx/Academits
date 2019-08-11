using System;
using System.Collections.Generic;

namespace ArrayListHome3
{
    class ArrayListHome3
    {
        static void Main(string[] args)
        {
            List<int> myIntList = new List<int> { 5, 46, 32, 17, 112, 5, 66, 543, 97, 112, 57, 66 };
            List<int> myNewIntList = new List<int>(myIntList.Count);

            foreach (int e in myIntList)
            {
                if (!myNewIntList.Contains(e))
                {
                    myNewIntList.Add(e);
                }
            }
           
            foreach (int e in myNewIntList)
            {
                Console.Write(e + " ");
            }

            Console.ReadKey();
        }
    }
}