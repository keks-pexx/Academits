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
            /*
            myArrayList.Remove("Значение8");
            Console.WriteLine("Удаление Значение8: \n{0}\n", myArrayList);
            myArrayList.RemoveAt(2);
            Console.WriteLine("Удалим элемент по индексу 2 получим: \n{0}\n", myArrayList);
            Console.WriteLine("Проверка на вхождение Значение6: \n{0}", myArrayList.Contains("Значение6"));
            Console.WriteLine("Проверка на вхождение null: \n{0}", myArrayList.Contains(null));
            myArrayList.Clear();
            Console.WriteLine("Очиска списка: {0}", myArrayList);
            */
            Console.ReadKey();
        }
    }
}