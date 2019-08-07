using System;
using System.Collections.Generic;

namespace ArrayListHome_3
{
    class ArrayListHome_3
    {
        static void Main(string[] args)
        {
            List<int> myIntList = new List<int> { 5, 46, 32, 17, 112, 5, 66, 543, 97, 112, 57, 66 };
            List<int> myNewIntList = new List<int>();
            for (int i = 0; i < myIntList.Count; i++)
            {
                if (!myNewIntList.Contains(myIntList[i]))
                {
                    myNewIntList.Add(myIntList[i]);
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
