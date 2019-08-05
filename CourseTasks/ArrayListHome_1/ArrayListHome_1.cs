using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome_1
{
    class ArrayListHome_1
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\poem.txt";
            List<string> poem = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                int i = 0;
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    poem.Add(currentLine);
                    i++;
                }
            }

            foreach (string e in poem)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
