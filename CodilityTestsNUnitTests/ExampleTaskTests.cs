using NUnit.Framework;
using CodilityTasks.Tasks;

namespace CodilityTasksNUnitTests
{
    public class ExampleTaskTests
    {
        [Test]
        public void Example1()
        {
            int[] arr = new[] { 5, 5, 7, 5, 5, 6, 4, 5, 2, 5, 1, 5, 4, 5 };
            int x = 5;
            Assert.AreEqual(6, ExampleTasks.Example1(arr, x));
            
            arr = new[] { 5, 5, 7, 5, 5, 6, 4, 6, 2, 5, 1, 5, 4, 5 };
            Assert.AreEqual(7, ExampleTasks.Example1(arr, x));

            ////Corner cases
            //If no X, array's length should be returned
            arr = new[] { 1, 4, 8, 3, 9, 0, 2, 7 };
            x = 6;
            Assert.AreEqual(8, ExampleTasks.Example1(arr, x));

            //if all values are X, 0 is returned
            arr = new[] { 4, 4, 4, 4, 4, 4 };
            x = 4;
            Assert.AreEqual(0, ExampleTasks.Example1(arr, x));
        }

        [Test]
        public void Example2()
        {
            Assert.AreEqual(4, ExampleTasks.LeastNumOfKnightSteps(0, 0, 5, 5));
            Assert.AreEqual(4, ExampleTasks.LeastNumOfKnightSteps(0, 0, 3, 7));
            Assert.AreEqual(5, ExampleTasks.LeastNumOfKnightSteps(0, 0, 6, 7));
            Assert.AreEqual(2, ExampleTasks.LeastNumOfKnightSteps(0, 0, 1, 1));
            Assert.AreEqual(1, ExampleTasks.LeastNumOfKnightSteps(0, 0, 1, 2));
            Assert.AreEqual(4, ExampleTasks.LeastNumOfKnightSteps(0, 0, 2, 2));
            Assert.AreEqual(0, ExampleTasks.LeastNumOfKnightSteps(0, 0, 0, 0));
            Assert.AreEqual(3, ExampleTasks.LeastNumOfKnightSteps(0, 0, 1, 0));
            Assert.AreEqual(2, ExampleTasks.LeastNumOfKnightSteps(0, 0, 2, 0));
            Assert.AreEqual(3, ExampleTasks.LeastNumOfKnightSteps(0, 0, 3, 0));
            Assert.AreEqual(2, ExampleTasks.LeastNumOfKnightSteps(0, 0, 4, 0));
            Assert.AreEqual(3, ExampleTasks.LeastNumOfKnightSteps(0, 0, 5, 0));
            Assert.AreEqual(4, ExampleTasks.LeastNumOfKnightSteps(0, 0, 6, 0));
        }
    }
}