using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothes_Factory.Abstract_products;
using Clothes_Factory.Factories;

namespace Clothes_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Client entrepreneur = new Client(new ElegantClothesFactory());
            entrepreneur.DescribeYourClothes();
            Console.WriteLine($"Entrepreneur: {entrepreneur.DescribeYourClothes()} \n");

            Client student = new Client(new CasualClothesFactory());
            Console.WriteLine($"Student: {student.DescribeYourClothes()}");

            Console.ReadKey();
        }
    }
}



//namespace TrainConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Stack st = new Stack();
//            st.Push("Hello");
//            st.Push(3.1);
//            st.Push(5);
//            st.Push('b');
//            st.Push(true);

//            List<int> numbers = new List<int>();
//            numbers.Add(19);
//            numbers.Add(21);
//            numbers.Add(13);
//            numbers.Add(9);
//            numbers.Add(32);

//            for (int i = 0; i < numbers.Count(); i++)
//            {
//                if (numbers[i] > 20)
//                {
//                    numbers.RemoveAt(i);
//                    i--;
//                }


//            }
//            numbers.Insert(2, 1);
//            numbers.Sort();
//            foreach (int i in numbers)
//                Console.Write(i);



//            Console.ReadKey();
//            //Console.WriteLine("Hello World!");
//        }
//    }
//}
