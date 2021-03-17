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
        public void ArrayList_WhenValue_ShouldRturnNewArrayList(char[] array)
        {
            ArrayList<char> arrayList = new ArrayList<char>(array);
        }
        
        [TestCase(new int[] { 5, 10, 15, 20 }, 299)]
        public void Add_WhenValue_ShouldAddNewValueToEnd(int[] array ,int value)
        {
            ArrayList<int> arrayList = new ArrayList<int>(array);

            arrayList.Add(value);
            arrayList.Add(99);
            arrayList.Add(40);
            arrayList.Add(13);
            arrayList.Add(125);
            arrayList.Get(4);
            arrayList.Get(5);

            ArrayList<string> stringArrayList = new ArrayList<string>();

            stringArrayList.Add("Cat");
            stringArrayList.Add("Thms");
            stringArrayList.Add("Dog");
            stringArrayList.Add("Car");
            stringArrayList.Add("adasdasdasd");
            stringArrayList.Add("Nat");

            ArrayList<string> ar = new ArrayList<string>();
            ar.Add("Cat");
            ar.Add("Thms");
            ar.Add("Dog");
            ar.Add("Car");
            ar.Add("adasdasdasd");

            bool compare = stringArrayList.Equals(ar);
            
            ar.Add("Nat");

            compare = stringArrayList.Equals(ar);

        }
    }
}