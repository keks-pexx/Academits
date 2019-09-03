using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            МyArrayList<string> myArrayList = new МyArrayList<string>();
            myArrayList.Add("Значение0");
            myArrayList.Add("Значение1");
            myArrayList.Add("Значение2");
            myArrayList.Add("Значение3");
            myArrayList.Add("Значение5");
            myArrayList.Add("Значение6");
            myArrayList.Add("Значение7");
            myArrayList.Add("Значение8");
            myArrayList.Add("Значение9");

            Console.WriteLine("Список:\n{0}\n", myArrayList);

            myArrayList.Insert(4, "Значение4");
            Console.WriteLine("Вставка значения по индексу 4 \n{0}\n", myArrayList);
            myArrayList.Insert(10, "Значение10");
            Console.WriteLine("Вставка значения по индексу 10 \n{0}\n", myArrayList);

            myArrayList.TrimExcess();
            Console.WriteLine("Урезание списка \n{0}\n", myArrayList);

            myArrayList.Insert(0, "Значение0новое");
            Console.WriteLine("Вставка значения по индексу 0 \n{0}\n", myArrayList);

            string forDelete = "Значение8";
            if (myArrayList.Remove(forDelete))
            {
                Console.WriteLine("Удаление {0} \n{1}\n", forDelete, myArrayList);
            }
            else
            {
                Console.WriteLine("{0} нет в списке", forDelete);
            }

            myArrayList.RemoveAt(2);
            Console.WriteLine("Удаление значения по индексу 2: \n{0}\n", myArrayList);

            string forCheck = "Значение6";
            if (myArrayList.Contains(forCheck))
            {
                Console.WriteLine("{0} входит в список\n", forCheck);
            }
            else
            {
                Console.WriteLine("{0} не входит в список\n", forCheck);
            }

            myArrayList.Clear();
            Console.WriteLine("Очиска списка: {0}", myArrayList);

            Console.ReadKey();
        }
    }
}