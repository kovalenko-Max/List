using NUnit.Framework;
using System;

namespace List.Test
{
    [TestFixture("ArrayList")]
    [TestFixture("LinkedList")]
    [TestFixture("DLinkedList")]
    public class ListTests
    {
        public IList<string> actual;
        public IList<string> listForAdding;
        public IList<string> expected;

        public string listType = string.Empty;

        public ListTests(string type)
        {
            listType = type;
        }

        public void Setup(string[] inputArray = null, string[] arrayForAdding = null, string[] expectedArray = null)
        {
            switch (listType)
            {
                case "ArrayList":
                    if (!(inputArray is null))
                    {
                        actual = new ArrayList<string>(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new ArrayList<string>(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new ArrayList<string>(expectedArray);
                    }
                    break;

                case "LinkedList":
                    if (!(inputArray is null))
                    {
                        actual = new LinkedList<string>(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new LinkedList<string>(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new LinkedList<string>(expectedArray);
                    }
                    break;

                case "DLinkedList":
                    if (!(inputArray is null))
                    {
                        actual = new DLinkedList<string>(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new DLinkedList<string>(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new DLinkedList<string>(expectedArray);
                    }
                    break;
            }
        }



        //        //[TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        //        //[TestCase(0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0 })]
        //        //[TestCase(4, new int[] { 1, 2 }, new int[] { 1, 2, 4 })]
        //        //public void AddTest(int value, int[] array, int[] expectedArray)
        //        //{
        //        //    Setup(array, expectedArray);
        //        //    actual.Add(value);

        //        //    Assert.AreEqual(expected, actual);
        //        //}

        //[TestCase(0, 1, "0")]
        //[TestCase(4, 1, "3")]
        //[TestCase(8, 1, "7")]
        //[TestCase(12, 1, "8")]
        //[TestCase(0, 7, "0")]
        //public void Get_WhenIndex_ShouldGetElement(int index, int inputMockNumb, string expected)
        //{
        //    Setup(Mocks.GetMock(inputMockNumb));

        //    string actualValue = actual[index];

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestCase(3, "New Value", 1, 5)]
        //[TestCase(3, null, 1, 6)]
        //public void Set_WhenIndex_ShouldSetElement(int index, string value, int inputMockNumb, int expectedinputMockNumb)
        //{
        //    DLinkedList<string> actual = new DLinkedList<string>(Mocks.GetMock(inputMockNumb));
        //    DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock(expectedinputMockNumb));

        //    actual[index] = value;

        //    Assert.AreEqual(expectedDLinkedList, actual);
        //}

        //        [TestCase("New value", 1)]
        //        public void Add_Test(string value, int inputMockNumb)
        //        {
        //            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Add(inputMockNumb));

        //            actualLinkedList.AddAt(0, value);
        //            actualLinkedList.AddAt(5, "Second new value");
        //        }

        [TestCase("7", 1, 2)]
        [TestCase("8", 2, 3)]
        [TestCase("9", 3, 4)]
        [TestCase(null, 3, 5)]
        [TestCase("New value", 0, 6)]
        [TestCase("New value", 20, 6)]
        public void Add_WhenValue_ShouldToEnd(string value, int inputinputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Add(inputinputMockNumb), expectedArray: Mocks.GetMock_Add(expectedinputMockNumb));
            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("New Value", 1, 3)]
        public void AddAtFirst_WhenValue_ShouldAddtoFirst(string value, int inputinputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_AddAt(inputinputMockNumb), expectedArray: Mocks.GetMock_AddAt(expectedinputMockNumb));

            actual.AddAtFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("New Value", 7, 1, 2)]
        [TestCase("New Value", 0, 1, 3)]
        [TestCase("New Value", 2, 1, 4)]
        [TestCase(null, 2, 1, 5)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int inputinputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_AddAt(inputinputMockNumb), expectedArray: Mocks.GetMock_AddAt(expectedinputMockNumb));

            actual.AddAt(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(25, "New Value", 1)]
        [TestCase(-3, "New Value", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int inputinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_AddAt(inputinputMockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddAt(index, value));
        }

        [TestCase(1, 20, 2)]
        public void AddList_WhenDLinkedList_ShouldAddToDLinkedList(int inputinputMockNumb, int numbListForAdding, int expectedinputMockNumb)
        {
            Setup(Mocks.GetMock_AddList(inputinputMockNumb), Mocks.GetMock_AddList(numbListForAdding), Mocks.GetMock_AddList(expectedinputMockNumb));

            actual.AddList(listForAdding);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 20, 3)]
        public void AddListAtFirst_WhenDLinkedList_ShouldAddAtFirst(int inputMockNumb, int numbListForAdding, int expectedinputMockNumb)
        {
            Setup(Mocks.GetMock_AddList(inputMockNumb), Mocks.GetMock_AddList(numbListForAdding), Mocks.GetMock_AddList(expectedinputMockNumb));

            actual.AddListAtFirst(listForAdding);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, 1, 20, 2)]
        [TestCase(0, 1, 20, 3)]
        [TestCase(2, 1, 20, 4)]
        [TestCase(6, 1, 20, 5)]
        [TestCase(3, 1, 6, 7)]
        public void AddListAt_WhenIndexAndDLinkedList_ShouldAddDLinkedListAtIndex(int index, int inputMockNumb, int numbListForAdding, int expectedinputMockNumb)
        {
            Setup(Mocks.GetMock_AddList(inputMockNumb), Mocks.GetMock_AddList(numbListForAdding), Mocks.GetMock_AddList(expectedinputMockNumb));

            actual.AddListAt(index, listForAdding);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(25, 1, 20)]
        [TestCase(-25, 1, 20)]
        public void AddListAt_WhenIndexAndDLinkedList_ShouldThrowIndexOutOfRangeException(int index, int inputMockNumb, int numbListForAdding)
        {
            Setup(inputArray: Mocks.GetMock_AddList(inputMockNumb), arrayForAdding: Mocks.GetMock_AddList(numbListForAdding));

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListAt(index, listForAdding));
        }

        public void RemoveAtLast_WhenLinkedList_ShouldRemoveAtLast(int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Remove(inputMockNumb), expectedArray: Mocks.GetMock_Remove(expectedinputMockNumb));

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 3)]
        public void RemoveAtFirst_WhenArraList_ShouldRemoveAtFirst(int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Remove(inputMockNumb), expectedArray: Mocks.GetMock_Remove(expectedinputMockNumb));

            actual.RemoveAtFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(8, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(2, 1, 4)]
        public void RemoveAt_WhenArraList_ShouldRemoveAtFirst(int index, int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Remove(inputMockNumb), expectedArray: Mocks.GetMock_Remove(expectedinputMockNumb));

            actual.RemoveAt(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(25, 1)]
        [TestCase(-25, 1)]
        public void RemoveAt_WhenIndexAndLinkedList_ShouldThrowIndexOutOfRangeException(int index, int inputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Remove(inputMockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveAt(index));
        }

        [TestCase(2, 1, 2)]
        [TestCase(7, 1, 5)]
        [TestCase(20, 1, 20)]
        [TestCase(9, 1, 20)]
        public void RemoveRange_WhenCount_ShoudlRemoveRange(int count, int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_RemoveRange(inputMockNumb), expectedArray: Mocks.GetMock_RemoveRange(expectedinputMockNumb));

            actual.RemoveRange(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1, 3)]
        [TestCase(100, 1, 20)]
        public void RemoveRangeAtFirst_WhenCount_ShouldRemoveRangeFromFirst(int count, int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_RemoveRange(inputMockNumb), expectedArray: Mocks.GetMock_RemoveRange(expectedinputMockNumb));

            actual.RemoveRangeAtFirst(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, 2, 1, 2)]
        [TestCase(7, 20, 1, 2)]
        [TestCase(0, 2, 1, 3)]
        [TestCase(0, 20, 1, 20)]
        [TestCase(3, 2, 1, 4)]
        public void RemoveRangeAt_WhenIndexAndRange_ShoudlRemoveRange(int index, int count, int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_RemoveRange(inputMockNumb), expectedArray: Mocks.GetMock_RemoveRange(expectedinputMockNumb));

            actual.RemoveRangeAt(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("3", 1, 3)]
        [TestCase("8", 1, 8)]
        [TestCase("non-existent Value", 1, -1)]
        public void RemoveByValue_WhenValue_ShouldRemove(string value, int inputMockNumb, int expectedIndex)
        {
            Setup(inputArray: Mocks.GetMock_Remove(inputMockNumb));

            int actualIndex = actual.RemoveByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase("3", 1, 2)]
        [TestCase("8", 1, 4)]
        [TestCase("8", 2, 12)]
        [TestCase("non-existent Value", 1, 0)]
        [TestCase("0", 7, 1)]
        public void RemoveAllByValue_WhenAllValues_ShoulRemoved(string value, int inputMockNumb, int expectedCount)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            int actualCount = actual.RemoveAllByValue(value);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1, 2)]
        [TestCase(20, 20)]
        public void Reverse_WhenArray_ShouldRevers(int inputMockNumb, int expectedinputMockNumb)
        {
            Setup(inputArray: Mocks.GetMock_Reverse(inputMockNumb), expectedArray: Mocks.GetMock_Reverse(expectedinputMockNumb));

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", 1, 0)]
        [TestCase("5", 1, 6)]
        [TestCase("8", 1, 9)]
        [TestCase("non-existent Value", 1, -1)]
        public void GetIndexByValue(string value, int inputMockNumb, int expectedIndex)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            int actualIndex = actual.GetIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(1, 9)]
        [TestCase(5, 3)]
        public void GetIndexOfMax_WhenLinkedList_ShouldReturnIndexOfMax(int inputMockNumb, int expectedIndex)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            int actualindex = actual.GetIndexOfMax();

            Assert.AreEqual(expectedIndex, actualindex);
        }

        [TestCase(1, 0)]
        [TestCase(6, 3)]
        public void GetIndexOfMin_WhenLinkedList_ShouldReturnIndexOfMax(int inputMockNumb, int expectedIndex)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            int actualindex = actual.GetIndexOfMin();

            Assert.AreEqual(expectedIndex, actualindex);
        }

        [TestCase(1, "8")]
        [TestCase(5, "New Value")]
        public void GetMax_WhenLinkedList_ShouldReturnMaxElement(int inputMockNumb, string expectedValue)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            string actualValue = actual.GetMax();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(1, "0")]
        [TestCase(3, "0")]
        public void GetMin_WhenLinkedList_ShouldReturnMinElement(int inputMockNumb, string expectedValue)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb));

            string actualValue = actual.GetMin();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(3, true, 1)]
        [TestCase(2, true, 2)]
        [TestCase(20, true, 20)]
        [TestCase(3, false, 4)]
        [TestCase(2, false, 2)]
        [TestCase(20, false, 20)]
        public void Sort_WhenBoolIsAscending_ShouldSortAscendingOrDescending(int inputMockNumb, bool isAscending, int expectedMockNumb)
        {
            Setup(inputArray: Mocks.GetMock(inputMockNumb), expectedArray: Mocks.GetMock(expectedMockNumb));

            actual.Sort(isAscending);

            Assert.AreEqual(expected, actual);
        }
    }
}
