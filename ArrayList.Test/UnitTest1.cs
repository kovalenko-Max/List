using NUnit.Framework;
using List;

namespace ArrayList.Test
{
    public class ArrayListTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [TestCase(new int[] {5, 10, 15, 20 })]
        [TestCase(new char[] {'g', 's', 'a', '5'})]
        public void ArrayList_WhenValue_ShouldRturnNewArrayList(int[] array)
        {
            ArrayList<int> arrayList = new ArrayList<int>(array);

        }
    }
}