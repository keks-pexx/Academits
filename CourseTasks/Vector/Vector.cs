using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class Vector
    {
        private double[] Values { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("размерность должна быть > 0", nameof(n));
            }

            Values = new double[n];
        }

        public Vector(Vector vector)
        {
            if (vector.Values.Length == 0)
            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Values.Length));
            }

            Values = new double[vector.Values.Length];
            Array.Copy(vector.Values, Values, vector.Values.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Values = new double[array.Length];
            Array.Copy(array, Values, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            Values = new double[n];
            Array.Copy(array, Values, array.Length);
        }

        public int GetSize()
        {
            return Values.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Values.Length; i++)
            {
                sb.Append(Values[i]).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        private static bool ArrayEquals(double[] a1, double[] a2)
        {
            if (a1.Length != a2.Length)
            {
                return false;
            }
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Vector p = (Vector)obj;
            return GetSize() == p.GetSize() && ArrayEquals(Values, p.Values);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + GetSize();
            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + Values[i].GetHashCode();
            }
         
            return hash;
        }

        public Vector AddVector(Vector vector)
        {
            if (vector.Values.Length == 0)
            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Values.Length));
            }

            return vector;
        }
    }
}
