using System;

namespace FractionHW4
{
    public class Fraction
    {
        private int a;
        private int b;

        public int A => a;
        public int B => b;

        public Fraction()
        {
            this.a = 0;
            this.b = 0;
        }

        public Fraction(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Fraction operator -(Fraction drib1)
        {
            return new Fraction(-drib1.a, drib1.b);
        }

        public static Fraction operator -(Fraction drib1, Fraction drib2)
        {
            return drib1 + (-drib2);
        }

        public static Fraction operator +(Fraction drib1, Fraction drib2)
        {
            return new Fraction(drib1.a * drib2.b + drib1.b * drib2.a, drib1.b * drib2.b);
        }
        
        public static Fraction operator *(Fraction drib1, Fraction drib2)
        {
            return new Fraction(drib1.a * drib2.a, drib1.b * drib2.b);
        }

        public static Fraction operator /(Fraction drib1, Fraction drib2)
        {
            if (drib2.a == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(drib2.a));
            }
            return new Fraction(drib1.a * drib2.b, drib1.b * drib2.a);
        }

        public void Input()
        {
            Console.Write("a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("b: ");
            b = int.Parse(Console.ReadLine());
        }

        public static int GCD(int a, int b)
        {
            int remainder;

            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);
            if (b > a)
            {
                remainder = a;
                a = b;
                b = remainder;
            }

            do
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            while (remainder != 0);
            return a;
        }

        public static void Transform(Fraction drib)
        {
            if(drib.a != 0)
            {
                int res = GCD(drib.a, drib.b);

                if(res != 1)
                {
                    drib.a /= res;
                    drib.b /= res;
                }
            }

        }

        public static Fraction Average(Fraction[] arr)
        {
            Fraction res = Sum(arr);
            Fraction chyslo = new Fraction(arr.Length, 1);
            res /= chyslo;
            Transform(res);
            return res;
        }

        public static Fraction Sum(Fraction[] arr)
        {
            Fraction res = new Fraction(0, 1);
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i];
            }
            Transform(res);
            return res;
        }

        public static Fraction Substruction(Fraction[] arr)
        {
            Fraction res = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                res -= arr[i];
            }
            Transform(res);
            return res;
        }

        public static Fraction Multiplication(Fraction[] arr)
        {
            Fraction res = new Fraction(1, 1);
            for (int i = 0; i < arr.Length; i++)
            {
                res *= arr[i];
            }
            Transform(res);
            return res;
        }

        public override string ToString() => $" {a}/{b}";

        static void Main(string[] args)
        {
            int n = 5;
            Fraction[] mas = new Fraction[n];
            for (int i = 1; i < n + 1; i++) 
            {
                mas[i - 1] = new Fraction(i + 1, i + 2);
                Console.Write(mas[i - 1]);
            }

            Fraction res = Average(mas);
            Console.Write("\nAverage:" + res);
            res = Sum(mas);
            Console.Write("\nSum:" + res);
            res = Multiplication(mas);
            Console.Write("\nMult:" + res);
            res = Substruction(mas);
            Console.Write("\nSubstr:" + res);

            Console.Read();
        }
    }
}