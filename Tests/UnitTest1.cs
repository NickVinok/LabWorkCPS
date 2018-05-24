using System;
using LabWork1.Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlgorithmTest1()
        {
            int[] TestArray = { 0, 1, 2, 3, 4, -10 };
            Algorithms algo = new Algorithms(TestArray);
            algo.Algorithm();
            int expectedNumberOfPositives = 4;
            int expectedNumberOfNegatives = 1;
            int expectedAverage = 0;
            Assert.AreEqual(expectedNumberOfPositives, algo.GetNumberOfPositives());
            Assert.AreEqual(expectedNumberOfNegatives, algo.GetNumberOfNegatives());
            Assert.AreEqual(expectedAverage, algo.GetAverage());
        }

        [TestMethod]
        public void AlgorithmTest2()
        {
            int[] TestArray = { -10, -22, 10, 44, 0, 2, 20, 20 };
            Algorithms algo = new Algorithms(TestArray);
            algo.Algorithm();
            int expectedNumberOfPositives = 5;
            int expectedNumberOfNegatives = 2;
            int expectedAverage = 8;
            Assert.AreEqual(expectedNumberOfPositives, algo.GetNumberOfPositives());
            Assert.AreEqual(expectedNumberOfNegatives, algo.GetNumberOfNegatives());
            Assert.AreEqual(expectedAverage, algo.GetAverage());
        }
    }
}
