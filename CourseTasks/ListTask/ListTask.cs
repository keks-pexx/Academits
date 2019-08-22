using System;

namespace ListTask
{
    class ListTask
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> myList = new SinglyLinkedList<string>();

            myList.AddToBegin("Значение 6");
            myList.AddToBegin("Значение 5");
            myList.AddToBegin("Значение 4");
            myList.AddToBegin("Значение 3");
            myList.AddToBegin("Значение 2");
            myList.AddToBegin("Значение 1");

            Console.WriteLine("В списке {0} элемент(ов)", myList.Count);
            Console.WriteLine("Первый элемент: {0}", myList.GetFirstValue());
            Console.WriteLine("Пятый элемент: {0}", myList.Change(4, "Значение 5 новое"));
            Console.WriteLine("Замена пятого элемента на: {0}", myList.Delete(4));
            Console.WriteLine("Удалили пятый элемент и получили такой список: {0}", myList);
            myList.AddByIndex(4, "Значение 5");
            Console.WriteLine("Вернули пятый элемент обратно: {0}", myList);

            string myValue = "Значение 3";
            if (myList.DeleteValue(myValue))
            {
                Console.WriteLine("Успешно удалили \"{0}\", и получили список: {1}", myValue, myList);
            }
            else
            {
                Console.WriteLine("Элемента \"{0}\" в списке нет");
            }

            Console.WriteLine("Удалим первый элемент \"{0}\" и получим список: {1}", myList.DeleteHead(), myList);
            myList.Reverse();
            Console.WriteLine("Развернутый список: {0}", myList);

            SinglyLinkedList<string> myNewList = myList.Copy();
            Console.WriteLine("Копия списка: {0}", myNewList);

            Console.ReadKey();
        }
    }
}