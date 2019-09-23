using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    class Lambda
    {
        public static IEnumerable<double> GetSqrt()
        {
            int i = 1;
            while (true)
            {
                yield return Math.Sqrt(i);
                i++;
            }
        }

        static void Main(string[] args)
        {
            Person person1 = new Person { Name = "Иван", Age = 33 };
            Person person2 = new Person { Name = "Пётр", Age = 47 };
            Person person3 = new Person { Name = "Александр", Age = 10 };
            Person person4 = new Person { Name = "Сергей", Age = 25 };
            Person person5 = new Person { Name = "Дарья", Age = 6 };
            Person person6 = new Person { Name = "Олег", Age = 27 };
            Person person7 = new Person { Name = "Пётр", Age = 60 };
            Person person8 = new Person { Name = "Арина", Age = 3 };
            Person person9 = new Person { Name = "Иван", Age = 15 };

            List<Person> list = new List<Person>() { person1, person2, person3, person4, person5, person6, person7, person8, person9 };

            List<string> uniqueNames = list
                .Select(x => x.Name)
                .Distinct()
                .ToList();

            Console.Write("Уникальные имена: ");
            foreach (string name in uniqueNames)
            {
                Console.Write(name + " ");
            }


            Console.WriteLine();

            IEnumerable<Person> ageUnder18 = list
                .Where(x => x.Age < 18);

            Console.Write("Люди младше 18 лет: ");
            foreach (Person p in ageUnder18)
            {
                Console.Write(p.Name + " ");
            }

            Console.WriteLine();

            double ageUnder18Average = ageUnder18
                .Average(x => x.Age);

            Console.WriteLine("Средний возраст людей младше 18 лет: " + ageUnder18Average);

            Console.WriteLine();

            Dictionary<string, double> personsByAgeAverage = list
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Average(x => x.Age));

            Console.WriteLine("Map по среднему возрасту:");
            foreach (var p in personsByAgeAverage)
            {
                Console.WriteLine(p);
            }

             IOrderedEnumerable<Person> personsBetwen20To45 = list
                .Where(x => x.Age >= 20 && x.Age <= 45)
                .OrderByDescending(x => x.Age);

            Console.WriteLine();
            Console.Write("Люди, возраст которых между 20 и 45: ");
            foreach (Person p in personsBetwen20To45)
            {
                Console.Write(p.Name+ " ");
            }

            //Бесконечный поток корней чисел

            Console.WriteLine();
            Console.WriteLine("Задача Бесконечный поток корней чисел");
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());

            foreach (double e in GetSqrt().Take(number))
            {
                Console.WriteLine(e);
            }
            
            Console.ReadKey();
        }
    }
}