using NUnit.Framework;
using System;

namespace List.Test
{
    class DLListTests
    {
        [TestCase(0, 1, "0")]
        [TestCase(4, 1, "3")]
        [TestCase(8, 1, "7")]
        [TestCase(12, 1, "8")]
        [TestCase(0, 7, "0")]
        public void Get_WhenIndex_ShouldGetElement(int index, int mockNumb, string expected)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));

            string actual = actualDLinkedList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "New Value", 1, 5)]
        [TestCase(3, null, 1, 6)]
        public void Set_WhenIndex_ShouldSetElement(int index, string value, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actual = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock(expectedMockNumb));

            actual[index] = value;

            Assert.AreEqual(expectedDLinkedList, actual);
        }

        [TestCase("New value", 1)]
        public void Add_Test(string value, int mockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Add(mockNumb));

            actualLinkedList.AddAt(0, value);
            actualLinkedList.AddAt(5, "Second new value");
        }

        [TestCase("7", 1, 2)]
        [TestCase("8", 2, 3)]
        [TestCase("9", 3, 4)]
        [TestCase(null, 3, 5)]
        [TestCase("New value", 0, 6)]
        [TestCase("New value", 20, 6)]
        public void Add_WhenValue_ShouldToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_Add(mockNumb));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_Add(expectedMockNumb));

            actualDLinkedList.Add(value);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase("New Value", 1, 3)]
        public void AddAtFirst_WhenValue_ShouldAddtoFirst(string value, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddAt(mockNumb));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddAt(expectedMockNumb));

            actualDLinkedList.AddAtFirst(value);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase("New Value", 7, 1, 2)]
        [TestCase("New Value", 0, 1, 3)]
        [TestCase("New Value", 2, 1, 4)]
        [TestCase(null, 2, 1, 5)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddAt(mockNumb));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddAt(expectedMockNumb));

            actualDLinkedList.AddAt(index, value);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase(25, "New Value", 1)]
        [TestCase(-3, "New Value", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int mockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddAt(mockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actualDLinkedList.AddAt(index, value));
        }

        [TestCase(1, 20, 2)]
        public void AddList_WhenDLinkedList_ShouldAddToDLinkedList(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(mockNumb));
            DLinkedList<string> listForAdding = new DLinkedList<string>(Mocks.GetMock_AddList(numbListForAdding));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualDLinkedList.AddList(listForAdding);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase(1, 20, 3)]
        public void AddListAtFirst_WhenDLinkedList_ShouldAddAtFirst(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(mockNumb));
            DLinkedList<string> listForAdding = new DLinkedList<string>(Mocks.GetMock_AddList(numbListForAdding));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualDLinkedList.AddListAtFirst(listForAdding);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase(7, 1, 20, 2)]
        [TestCase(0, 1, 20, 3)]
        [TestCase(2, 1, 20, 4)]
        [TestCase(6, 1, 20, 5)]
        [TestCase(3, 1, 6, 7)]
        public void AddListAt_WhenIndexAndDLinkedList_ShouldAddDLinkedListAtIndex(int index, int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(mockNumb));
            DLinkedList<string> listForAdding = new DLinkedList<string>(Mocks.GetMock_AddList(numbListForAdding));
            DLinkedList<string> expectedDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualDLinkedList.AddListAt(index, listForAdding);

            Assert.AreEqual(expectedDLinkedList, actualDLinkedList);
        }

        [TestCase(25, 1, 20)]
        [TestCase(-25, 1, 20)]
        public void AddListAt_WhenIndexAndDLinkedList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb, int numbListForAdding)
        {
            DLinkedList<string> actualDLinkedList = new DLinkedList<string>(Mocks.GetMock_AddList(mockNumb));
            DLinkedList<string> listForAdding = new DLinkedList<string>(Mocks.GetMock_AddList(numbListForAdding));

            Assert.Throws<IndexOutOfRangeException>(() => actualDLinkedList.AddListAt(index, listForAdding));
        }

        public void RemoveAtLast_WhenLinkedList_ShouldRemoveAtLast(int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualLinkedList.Remove();

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase(1, 3)]
        public void RemoveAtFirst_WhenArraList_ShouldRemoveAtFirst(int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualLinkedList.RemoveAtFirst();

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase(8, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(2, 1, 4)]
        public void RemoveAt_WhenArraList_ShouldRemoveAtFirst(int index, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualLinkedList.RemoveAt(index);

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase(25, 1)]
        [TestCase(-25, 1)]
        public void RemoveAt_WhenIndexAndLinkedList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(mockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actualLinkedList.RemoveAt(index));
        }

        [TestCase(2, 1, 2)]
        [TestCase(7, 1, 5)]
        [TestCase(20, 1, 20)]
        [TestCase(9, 1, 20)]
        public void RemoveRange_WhenCount_ShoudlRemoveRange(int count, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

            actualLinkedList.RemoveRange(count);

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase(2, 1, 3)]
        [TestCase(100, 1, 20)]
        public void RemoveRangeAtFirst_WhenCount_ShouldRemoveRangeFromFirst(int count, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

            actualLinkedList.RemoveRangeAtFirst(count);

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase(7, 2, 1, 2)]
        [TestCase(7, 20, 1, 2)]
        [TestCase(0, 2, 1, 3)]
        [TestCase(0, 20, 1, 20)]
        [TestCase(3, 2, 1, 4)]
        public void RemoveRangeAt_WhenIndexAndRange_ShoudlRemoveRange(int index, int count, int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

            actualLinkedList.RemoveRangeAt(index, count);

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase("3", 1, 3)]
        [TestCase("8", 1, 8)]
        [TestCase("non-existent Value", 1, -1)]
        public void RemoveByValue_WhenValue_ShouldRemove(string value, int mockNumb, int expected)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Remove(mockNumb));

            int actual = actualLinkedList.RemoveByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("3", 1, 2)]
        [TestCase("8", 1, 4)]
        [TestCase("8", 2, 12)]
        [TestCase("non-existent Value", 1, 0)]
        [TestCase("0", 7, 1)]
        public void RemoveAllByValue_WhenAllValues_ShoulRemoved(string value, int mockNumb, int expected)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));

            int actual = actualLinkedList.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2)]
        [TestCase(20, 20)]
        public void Reverse_WhenArray_ShouldRevers(int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock_Reverse(mockNumb));
            //LinkedListMock.GetMock_Reverse(mockNumb);
            DLinkedList<string> expectedLinkedList = new DLinkedList<string>(Mocks.GetMock_Reverse(expectedMockNumb));

            actualLinkedList.Reverse();

            Assert.AreEqual(expectedLinkedList, actualLinkedList);
        }

        [TestCase("0", 1, 0)]
        [TestCase("5", 1, 6)]
        [TestCase("8", 1, 9)]
        [TestCase("non-existent Value", 1, -1)]
        public void GetIndexByValue(string value, int mockNumb, int expectedIndex)
        {
            DLinkedList<string> actualLinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            int actualIndex = actualLinkedList.GetIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(1, 9)]
        [TestCase(5, 3)]
        public void GetIndexOfMax_WhenLinkedList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            DLinkedList<string> LinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            int actual = LinkedList.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0)]
        [TestCase(6, 3)]
        public void GetIndexOfMin_WhenLinkedList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            DLinkedList<string> LinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            int actual = LinkedList.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "8")]
        [TestCase(5, "New Value")]
        public void GetMax_WhenLinkedList_ShouldReturnMaxElement(int mockNumb, string expected)
        {
            DLinkedList<string> LinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            string actual = LinkedList.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "0")]
        [TestCase(3, "0")]
        public void GetMin_WhenLinkedList_ShouldReturnMinElement(int mockNumb, string expected)
        {
            DLinkedList<string> LinkedList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            string actual = LinkedList.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 1)]
        [TestCase(2, 2)]
        [TestCase(20, 20)]
        public void SortAscending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualArrayList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            DLinkedList<string> expectedArrayList = new DLinkedList<string>(Mocks.GetMock(expectedMockNumb));
            actualArrayList.SortAscending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(3, 4)]
        [TestCase(2, 2)]
        [TestCase(20, 20)]
        public void SortDescending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            DLinkedList<string> actualArrayList = new DLinkedList<string>(Mocks.GetMock(mockNumb));
            DLinkedList<string> expectedArrayList = new DLinkedList<string>(Mocks.GetMock(expectedMockNumb));
            actualArrayList.SortDescending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }
    }
}
