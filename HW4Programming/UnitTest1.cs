using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionHW4;

namespace UnitTestFractionHW4
{
    [TestClass]

    public class UnitTestFractionHW4
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get => testContext;
            set => testContext = value;
        }

        public Fraction[] CreateArray()
        {
            int n = 5;
            Fraction[] mas = new Fraction[n];
            for (int i = 1; i < n + 1; i++)
            {
                mas[i - 1] = new Fraction(i + 1, i + 2);
                Console.Write(mas[i - 1]);
            }
            return mas;
        }

        [TestMethod]

        public void TestAdd()
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(2, 5);
            Fraction c = a + b;
            Fraction.Transform(c);

            Assert.IsTrue(c.A == 1 && c.B == 1);
        }

        [TestMethod]

        public void TestTransform()
        {
            Fraction a = new Fraction(305, 700);
            Fraction.Transform(a);
            Assert.IsTrue(a.A == 61 && a.B == 140);
        }

        [TestMethod]

        public void TestGCD()
        {
            int res = Fraction.GCD(305, 610);
            Assert.AreEqual(res, 305);
        }

        [TestMethod]

        public void TestAverage()
        {
            Fraction[] arr = CreateArray();
            Fraction average = Fraction.Average(arr);
            Fraction a = new Fraction(547, 700);
           
            Assert.IsTrue(a.A == average.A && a.B == average.B);
        }

        [TestMethod]

        public void TestMultiplication()
        {
            Fraction[] arr = CreateArray();
            Fraction res = Fraction.Multiplication(arr);
            Fraction a = new Fraction(2, 7);

            Assert.IsTrue(a.A == res.A && a.B == res.B);
        }

        [TestMethod]

        public void TestSum()
        {
            Fraction[] arr = CreateArray();
            Fraction res = Fraction.Sum(arr);
            Fraction a = new Fraction(547, 140);

            Assert.IsTrue(a.A == res.A && a.B == res.B);
        }

        [TestMethod]

        public void TestSubstruction()
        {
            Fraction[] arr = CreateArray();
            Fraction sub = Fraction.Substruction(arr);
            Fraction a = new Fraction(-1081, 420);

            Assert.IsTrue(a.A == sub.A && a.B == sub.B);
        }

       
    }
}
