using System;
using System.Collections.Generic;

namespace ArrayListHome2
{
    class ArrayListHome2
    {
        static void Main(string[] args)
        {
            List<int> myIntList = new List<int> { 5, 46, 32, 17, 112, 543, 97, 57, 66 };
            int i = 0;
            
            while (i < myIntList.Count)
            {
                if (myIntList[i] % 2 == 0)
                {
                    myIntList.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            foreach (int e in myIntList)
            {
                Console.Write(e + " ");
            }

            Console.ReadKey();
        }
    }
}
