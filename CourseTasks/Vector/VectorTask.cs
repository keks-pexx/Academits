using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class VectorTask
    {
        static void Main(string[] args)
        {
            double[] array = { 4, 25, 18, 17, 32 };
            Vector vector1 = new Vector(6, array);
            Vector vector2 = new Vector(vector1);

            Console.WriteLine(vector1.GetSize());
            Console.WriteLine(vector2);
            Console.WriteLine(vector1.GetHashCode());
            Console.WriteLine(vector1.Equals(vector2));
            Console.ReadKey();
        }
    }
}
