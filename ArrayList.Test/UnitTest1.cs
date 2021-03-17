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

        [TestCase(25, 1, 2)]
        public void Add_WhenIntValue_ShouldToEnd(int value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> actualArrayList = ArrayListMock.GetIntArrayListMock(mockNumb);
            actualArrayList.Add(value);
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(expectedMockNumb, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("Alex", 1, 2)]
        public void Add_WhenStringValue_ShouldAddToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            actualArrayList.Add(value);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }
        
        [TestCase(4, 87)]
        [TestCase(0, 1)]
        [TestCase(9, 38)]
        public void Get_WhenIndex_ShouldGetElement(int index, int expected)
        {
            ArrayList<int> arrayList = ArrayListMock.GetIntArrayListMock(numb: 1);
            int actual = arrayList[index];
            Assert.AreEqual(expected, actual);
        }
        [TestCase(2, 9999, 1, 3)]
        public void Set_WhenIndex_ShouldGetElement(int index, int value,int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(numb: expectedMockNumb);
            ArrayList<int> actual = ArrayListMock.GetIntArrayListMock(mockNumb);
            actual[index] = value;
            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase()]
        public void AddAt_WhenIndexAndValue_ShouldAddElementByIndex()
        {
            ArrayList<string> arrayList = ArrayListMock.GetStringArrayListMock(1);

            arrayList.AddAt(0, "Абра-кадабра");
            arrayList.Add("255");
            arrayList.Add("Car");
            arrayList.AddAt(6, "Новое значение");
            arrayList.AddAtFirst("Новое значение в начало списка");
            arrayList.RemoveAt(3);
            arrayList.RemoveAtLast();
            
            arrayList.RemoveRange(3, 5);

        }

        public static class ArrayListMock
        {
            public static ArrayList<int> GetIntArrayListMock(int numb, int value = 0)
            {
                int[] a;
                switch (numb)
                {
                    default:
                        a = new int[0];
                        break;
                    case 1:
                        a = new int[] { 1, 325, 5, 25, 87, 922, 2, 1, 99, 38 };
                        break;
                    case 2:
                        a = new int[] { 1, 325, 5, 25, 87, 922, 2, 1, 99, 38, value };
                        break;
                    case 3:
                        a = new int[] { 1, 325, 9999, 25, 87, 922, 2, 1, 99, 38 };
                        break;
                }

                return new ArrayList<int>(a);
            }

            public static ArrayList<string> GetStringArrayListMock(int numb, string value = "")
            {
                string[] a;
                switch (numb)
                {
                    default:
                        a = new string[0];
                        break;
                    case 1:
                        a = new string[] { "Cat", "dog", "Кто-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 2:
                        a = new string[] { "Cat", "dog", "Кто-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f", value };
                        break;

                    case 3:
                        a = new string[] { "dog", "Кто-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                }

                return new ArrayList<string>(a);
            }
        }
    }


}