using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using exzamen;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a, b = 0;
            Console.WriteLine("Введите первое число:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Сумма равна:{0}", a + b);
            Console.ReadKey();
        }
    }
}
