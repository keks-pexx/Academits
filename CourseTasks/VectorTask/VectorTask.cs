using System;

namespace VectorTask
{
    class VectorTask
    {
        static void Main(string[] args)
        {
            double[] array1 = { 4, 25, 18, 17, 32 };
            double[] array2 = { 5, 67, 21, 12, 32 };

            Vector vector1 = new Vector(4, array1);
            Vector vector2 = new Vector(6, array2);
            Vector vector3 = new Vector(vector1);

            Console.WriteLine("Вектор1: " + vector1);
            Console.WriteLine("Вектор1 размер: {0}, длина: {1}", vector1.GetSize(), vector1.GetVectorLength());
            Console.WriteLine("Вектор2: " + vector2);
            Console.WriteLine("Вектор2 размер: {0}, длина: {1}", vector2.GetSize(), vector2.GetVectorLength());
            Console.WriteLine("Вектор3: " + vector3);
            Console.WriteLine("Вектор3 размер: {0}, длина: {1}", vector3.GetSize(), vector3.GetVectorLength());

            Console.WriteLine("Хэшкод вектора 1: " + vector1.GetHashCode());
            Console.WriteLine("Равенство векторов 1 и 3: " + vector1.Equals(vector3));

            Console.WriteLine("Добавляем вектор 2 к 1: " + vector1.AddVector(vector2));
            Console.WriteLine("Вычитаем вектор 2 из 3: " + vector3.SubtractVector(vector2));

            Vector vector4 = Vector.GetVectorSum(vector2, vector3);
            Console.WriteLine("Сумма вектора 2 и 3 (Вектор4): " + vector4);

            Vector vector5 = Vector.GetVectorSum(vector4, vector3);
            Console.WriteLine("Разность векторов 4 из 3 (Вектор5): " + vector5);
            Console.WriteLine("Произведение векторов 2 из 5: " + Vector.GetScalarMultiplication(vector2, vector5));

            Console.ReadKey();
        }
    }
}