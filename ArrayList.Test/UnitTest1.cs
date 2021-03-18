using NUnit.Framework;
using List;
using System;

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
        public void Set_WhenIndex_ShouldGetElement(int index, int value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(numb: expectedMockNumb);
            ArrayList<int> actual = ArrayListMock.GetIntArrayListMock(mockNumb);
            actual[index] = value;
            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase("New value by index", 3, 3, 4)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.AddAt(index, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(3, 3, 1, 5)]
        public void RemoveRange_WhenIndexAndRange_ShoudlRemoveRange(int index, int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.RemoveRange(index, count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }
        [TestCase(3, 1, 6)]
        public void RemoveRangeAtFirst_WhenCount_ShouldRemoveRangeFromFirst(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.RemoveRangeAtFirst(count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }
        [TestCase(3, 1, 7)]
        public void RemoveRangeAtEnd_WhenCoutn_ShouldRemoveRangeFromEnd(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);

            actualArrayList.RemoveRangeAtEnd(count);
            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("@@??", 1, 4)]
        [TestCase("0000", 1, -1)]
        public void GetIndexByValue(string value, int mockNumb, int expectedIndex)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            int actualIndex = actualArrayList.GetIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(1, 3)]
        public void GetIndexOfMax_WhenArrayList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            ArrayList<string> arrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            int actual = arrayList.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 5)]
        public void GetIndexOfMin_WhenArrayList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            ArrayList<string> arrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            int actual = arrayList.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "что-то")]
        public void GetMax_WhenArrayList_ShouldReturnMaxElement(int mockNumb, string expected)
        {
            ArrayList<string> arrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            string actual = arrayList.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "")]
        public void GetMin_WhenArrayList_ShouldReturnMinElement(int mockNumb, string expected)
        {
            ArrayList<string> arrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            string actual = arrayList.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 4)]
        public void Sort_WhenIntArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> actualArrayList = ArrayListMock.GetIntArrayListMock(mockNumb);
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(expectedMockNumb);

            actualArrayList.SortAscending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 8)]
        public void SortAscending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.SortAscending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 9)]
        public void SortDescending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.SortDescending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(8, 9)]
        public void Reverse_WhenArray_ShouldRevers(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.Reverse();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        //[TestCase("@@??", 1, 10)]
        [TestCase("", 1, 10)]
        public void RemoveByValue_WhenArray_ShouldRevers(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.RemoveByValue(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
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

                    case 4:
                        a = new int[] { 1, 1, 2, 5, 25, 38, 87, 99, 325, 922, };
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
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 2:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f", value };
                        break;

                    case 3:
                        a = new string[] { "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 4:
                        a = new string[] { "dog", " то-то", "что-то", "New value by index", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;

                    case 5:
                        a = new string[] { "Cat", "dog", " то-то", "25", "a, b, c, d, e, f" };
                        break;

                    case 6:
                        a = new string[] { "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 7:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??" };
                        break;
                    case 8:
                        a = new string[] { "", "@@??", "25", "a, b, c, d, e, f", "Cat", "dog", " то-то", "что-то" };
                        break;
                    case 9:
                        a = new string[] { "что-то", " то-то", "dog", "Cat", "a, b, c, d, e, f", "25", "@@??", "" };
                        break;
                    case 10:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "25", "a, b, c, d, e, f" };
                        break;
                }

                return new ArrayList<string>(a);
            }
        }
    }


}