using NUnit.Framework;
using CodilityTasks.Tasks;

namespace CodilityTasksNUnitTests
{
    public class MyOnlineTestTests
    {
        [Test]
        public void Task1()
        {
            string S = "ABDCA";
            int[] X = new[] { 2, -1, -4, -3, 3 };
            int[] Y = new[] { 2, -2, 4, 1, -3 };
            Assert.AreEqual(3, MyOnlineTest.Task1(S, X, Y));

            // Both points with equal tags have the same distance to the center
            S = "ABB";
            X = new[] { 1, -2, -2 };
            Y = new[] { 1, -2, 2 };
            Assert.AreEqual(1, MyOnlineTest.Task1(S, X, Y));

            // All the points have the same distance to the center
            S = "ABB";
            X = new[] { 1, 2, 2 };
            Y = new[] { 2, -1, 1 };
            Assert.AreEqual(0, MyOnlineTest.Task1(S, X, Y));

            // Both points with equal tags have the same distance to the center
            // the rest are outside of the circle
            S = "CCD";
            X = new[] { 1, -1, 2 };
            Y = new[] { 1, -1, -2 };
            Assert.AreEqual(0, MyOnlineTest.Task1(S, X, Y));
        }

        [Test]
        public void Task2()
        {
            string S = "ABBBCCDDCCC";
            int K = 3;
            Assert.AreEqual(5, MyOnlineTest.Task2(S, K));

            S = "AAAAAAAAAAABXXAAAAAAAAAA";
            K = 3;
            Assert.AreEqual(3, MyOnlineTest.Task2(S, K));

            S = "ABCDDDEFG";
            K = 2;
            Assert.AreEqual(6, MyOnlineTest.Task2(S, K));

            S = "ABCD";
            K = 3;
            Assert.AreEqual(1, MyOnlineTest.Task2(S, K));

            S = "ABC";
            K = 3;
            Assert.AreEqual(0, MyOnlineTest.Task2(S, K));
        }

        [Test]
        public void Task3()
        {
            string S = "babaa";
            Assert.AreEqual(2, MyOnlineTest.Task3(S));

            S = "ababa";
            Assert.AreEqual(4, MyOnlineTest.Task3(S));

            S = "aba";
            Assert.AreEqual(0, MyOnlineTest.Task3(S));

            S = "bbbbb";
            Assert.AreEqual(6, MyOnlineTest.Task3(S));

            S = "bbb";
            Assert.AreEqual(1, MyOnlineTest.Task3(S));
        }
    }
}
