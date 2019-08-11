using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome1
{
    class ArrayListHome1
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\poem.txt";
            List<string> poem = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        poem.Add(currentLine);
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }

            catch (Exception)
            {
                Console.WriteLine("Ошибка чтения файла");
            }

            foreach (string e in poem)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
