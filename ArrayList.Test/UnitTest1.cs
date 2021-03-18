using NUnit.Framework;
using List;
using System;

namespace ArrayList.Test
{
    public class ArrayListTests
    {
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

        [TestCase(25, 1, 2)]
        public void Add_WhenIntValue_ShouldToEnd(int value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> actualArrayList = ArrayListMock.GetIntArrayListMock(mockNumb);
            actualArrayList.Add(value);
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(expectedMockNumb, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("Alex", 1, 2)]
        [TestCase("Value", 20, 21)]
        public void Add_WhenStringValue_ShouldAddToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            actualArrayList.Add(value);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New value by index", 3, 3, 4)]
        [TestCase("Value", 0, 0, 21)]
        [TestCase("New value by index", 0, 21, 22)]
        [TestCase("New value by index", 2, 22, 23)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.AddAt(index, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, "smth", 1)]
        [TestCase(-3, "smth", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int mockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddAt(index, value));
        }

        [TestCase(1, 7, 13)]
        public void AddList_WhenArrayList_ShouldAddToArrayList(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetStringArrayListMock(numbListForAdding);

            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);

            actualArrayList.AddList(listForAdding);
            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 7, 15)]
        public void AddListAtFirst_WhenArrayList_ShouldAddAtFirst(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetStringArrayListMock(numbListForAdding);

            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);

            actualArrayList.AddListAtFirst(listForAdding);
            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(4, 1, 7, 14)]
        [TestCase(2, 7, 16, 17)]
        [TestCase(8, 18, 16, 19)]
        [TestCase(8, 1, 7, 13)]
        public void AddListAt_WhenIndexAndArrayList_ShouldAddArrayListAtIndex(int index, int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetStringArrayListMock(numbListForAdding);

            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);

            actualArrayList.AddListAt(index, listForAdding);
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

        [TestCase("", 1, 10)]
        public void RemoveByValue_WhenArray_ShouldRevers(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetStringArrayListMock(expectedMockNumb);
            actualArrayList.RemoveByValue(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("25", 11, 4)]
        public void RemoveAllByValue_WhenAllValues_ShoulRemoved(string value, int mockNumb, int expected)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetStringArrayListMock(mockNumb);
            int actual = actualArrayList.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
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
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f", "Alex" };
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

                    case 11:
                        a = new string[] { "Cat", "dog", "25", " то-то", "25", "что-то", "25", "@@??", "25", "a, b, c, d, e, f" };
                        break;

                    case 12:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "a, b, c, d, e, f" };
                        break;

                    case 13:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f", "Cat", "dog", " то-то", "что-то", "@@??" };
                        break;

                    case 14:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "Cat", "dog", " то-то", "что-то", "@@??", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 15:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 16:
                        a = new string[] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
                        break;

                    case 17:
                        a = new string[] { "Cat", "dog", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", " то-то", "что-то", "@@??" };
                        break;
                    case 18:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f" };
                        break;
                    case 19:
                        a = new string[] { "Cat", "dog", " то-то", "что-то", "@@??", "", "25", "a, b, c, d, e, f", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
                        break;

                    case 20:
                        a = new string[] { };
                        break;
                    case 21:
                        a = new string[] { "Value" };
                        break;
                    case 22:
                        a = new string[] { "New value by index", "Value" };
                        break;
                    case 23:
                        a = new string[] { "New value by index", "Value", "New value by index" };
                        break;

                }

                return new ArrayList<string>(a);
            }


        }
    }


}