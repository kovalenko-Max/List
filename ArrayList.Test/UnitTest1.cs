using NUnit.Framework;
using List;
using System;

namespace ArrayList.Test
{
    public class ArrayListTests
    {
        [TestCase(0, 1, "0")]
        [TestCase(4, 1, "4")]
        [TestCase(8, 1, "8")]
        public void Get_WhenIndex_ShouldGetElement(int index, int mockNumb, string expected)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock(mockNumb);

            string actual = actualArrayList[index];

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(2, 9999, 1, 3)]
        public void Set_WhenIndex_ShouldSetElement(int index, int value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<int> expectedArrayList = ArrayListMock.GetIntArrayListMock(numb: expectedMockNumb);
            ArrayList<int> actual = ArrayListMock.GetIntArrayListMock(mockNumb);

            actual[index] = value;

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase("7", 1, 2)]
        [TestCase("8", 2, 3)]
        [TestCase("9", 3, 4)]
        public void Add_WhenValue_ShouldToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_Add(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_Add(expectedMockNumb);

            actualArrayList.Add(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 1, 3)]
        public void AddAtFirst_WhenValue_ShouldAddtoFirst(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddAt(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_AddAt(expectedMockNumb);

            actualArrayList.AddAtFirst(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 7, 1, 2)]
        [TestCase("New Value", 0, 1, 3)]
        [TestCase("New Value", 2, 1, 4)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddAt(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_AddAt(expectedMockNumb);

            actualArrayList.AddAt(index, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, "New Value", 1)]
        [TestCase(-3, "New Value", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int mockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddAt(mockNumb);

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddAt(index, value));
        }

        [TestCase(1, 20, 2)]
        public void AddList_WhenArrayList_ShouldAddToArrayList(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddList(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetMock_AddList(numbListForAdding);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_AddList(expectedMockNumb);

            actualArrayList.AddList(listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 20, 3)]
        public void AddListAtFirst_WhenArrayList_ShouldAddAtFirst(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddList(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetMock_AddList(numbListForAdding);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_AddList(expectedMockNumb);

            actualArrayList.AddListAtFirst(listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(7, 1, 20, 2)]
        [TestCase(0, 1, 20, 3)]
        [TestCase(2, 1, 20, 4)]
        [TestCase(6, 1, 20, 5)]
        public void AddListAt_WhenIndexAndArrayList_ShouldAddArrayListAtIndex(int index, int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddList(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetMock_AddList(numbListForAdding);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_AddList(expectedMockNumb);

            actualArrayList.AddListAt(index, listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, 1, 20)]
        [TestCase(-25, 1, 20)]
        public void AddListAt_WhenIndexAndArrayList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb, int numbListForAdding)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddAt(mockNumb);
            ArrayList<string> listForAdding = ArrayListMock.GetMock_AddList(numbListForAdding);

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddListAt(index, listForAdding));
        }

        [TestCase(1, 2)]
        public void RemoveAtLast_WhenArrayList_ShouldRemoveAtLast(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_Remove(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_Remove(expectedMockNumb);

            actualArrayList.Remove();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 3)]
        public void RemoveAtFirst_WhenArraList_ShouldRemoveAtFirst(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_Remove(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_Remove(expectedMockNumb);

            actualArrayList.RemoveAtFirst();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(8, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(2, 1, 4)]
        public void RemoveAt_WhenArraList_ShouldRemoveAtFirst(int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_Remove(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_Remove(expectedMockNumb);

            actualArrayList.RemoveAt(index);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, 1)]
        [TestCase(-25, 1)]
        public void RemoveAt_WhenIndexAndArrayList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_AddAt(mockNumb);

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.RemoveAt(index));
        }

        [TestCase(2, 1, 2)]
        [TestCase(7, 1, 5)]
        [TestCase(20, 1, 20)]
        [TestCase(9, 1, 20)]
        public void RemoveRange_WhenCount_ShoudlRemoveRange(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_RemoveRange(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_RemoveRange(expectedMockNumb);

            actualArrayList.RemoveRange(count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(2, 1, 3)]
        [TestCase(100, 1, 20)]
        public void RemoveRangeAtFirst_WhenCount_ShouldRemoveRangeFromFirst(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_RemoveRange(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_RemoveRange(expectedMockNumb);

            actualArrayList.RemoveRangeAtFirst(count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(7, 2, 1, 2)]
        [TestCase(7, 20, 1, 2)]
        [TestCase(0, 2, 1, 3)]
        [TestCase(0, 20, 1, 20)]
        [TestCase(3, 2, 1, 4)]
        public void RemoveRangeAt_WhenIndexAndRange_ShoudlRemoveRange(int index, int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = ArrayListMock.GetMock_RemoveRange(mockNumb);
            ArrayList<string> expectedArrayList = ArrayListMock.GetMock_RemoveRange(expectedMockNumb);

            actualArrayList.RemoveRangeAt(index, count);

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

            public static ArrayList<string> GetMock(int numb)
            {
                string[] array;

                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                        break;
                }

                return new ArrayList<string>(array);
            }

            public static ArrayList<string> GetMock_Add(int numb)
            {
                string[] array;
                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", };
                        break;

                    case 2:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7" };
                        break;

                    case 3:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        break;
                }

                return new ArrayList<string>(array);
            }

            public static ArrayList<string> GetMock_AddAt(int numb)
            {
                string[] array;
                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", };
                        break;

                    case 2:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "New Value" };
                        break;

                    case 3:
                        array = new string[] { "New Value", "0", "1", "2", "3", "4", "5", "6" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "New Value", "2", "3", "4", "5", "6" };
                        break;
                }

                return new ArrayList<string>(array);
            }

            public static ArrayList<string> GetMock_AddList(int numb)
            {
                string[] array;
                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6" };
                        break;

                    case 2:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "n0", "n1", "n2", "n3", "n4", "n5", "n6" };
                        break;

                    case 3:
                        array = new string[] { "n0", "n1", "n2", "n3", "n4", "n5", "n6", "0", "1", "2", "3", "4", "5", "6" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "n0", "n1", "n2", "n3", "n4", "n5", "n6", "2", "3", "4", "5", "6" };
                        break;
                    case 5:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "n0", "n1", "n2", "n3", "n4", "n5", "n6", "6" };
                        break;

                    case 20:
                        array = new string[] { "n0", "n1", "n2", "n3", "n4", "n5", "n6" };
                        break;

                }

                return new ArrayList<string>(array);
            }

            public static ArrayList<string> GetMock_Remove(int numb)
            {
                string[] array;
                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                        break;

                    case 2:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7" };
                        break;

                    case 3:
                        array = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "3", "4", "5", "6", "7", "8" };
                        break;
                }

                return new ArrayList<string>(array);
            }

            public static ArrayList<string> GetMock_RemoveRange(int numb)
            {
                string[] array;
                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", };
                        break;

                    case 2:
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", };
                        break;

                    case 3:
                        array = new string[] { "2", "3", "4", "5", "6", "7", "8", };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "2", "5", "6", "7", "8", };
                        break;

                    case 5:
                        array = new string[] { "0", "1" };
                        break;

                    case 20:
                        array = new string[] { };
                        break;
                }

                return new ArrayList<string>(array);
            }
        }
    }


}