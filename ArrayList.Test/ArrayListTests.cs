using NUnit.Framework;
using System;

namespace List.Test
{
    public class ArrayListTests
    {
        [TestCase(0, 1, "0")]
        [TestCase(4, 1, "3")]
        [TestCase(8, 1, "7")]
        public void Get_WhenIndex_ShouldGetElement(int index, int mockNumb, string expected)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));

            string actual = actualArrayList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "New Value", 1, 5)]
        [TestCase(3, null, 1, 6)]
        public void Set_WhenIndex_ShouldSetElement(int index, string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actual = new ArrayList<string>(Mocks.GetMock(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock(expectedMockNumb));

            actual[index] = value;

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase("7", 1, 2)]
        [TestCase("8", 2, 3)]
        [TestCase("9", 3, 4)]
        [TestCase(null, 3, 5)]
        public void Add_WhenValue_ShouldToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Add(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_Add(expectedMockNumb));

            actualArrayList.Add(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 1, 3)]
        public void AddAtFirst_WhenValue_ShouldAddtoFirst(string value, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddAt(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_AddAt(expectedMockNumb));

            actualArrayList.AddAtFirst(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 7, 1, 2)]
        [TestCase("New Value", 0, 1, 3)]
        [TestCase("New Value", 2, 1, 4)]
        [TestCase(null, 2, 1, 5)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddAt(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_AddAt(expectedMockNumb));

            actualArrayList.AddAt(index, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, "New Value", 1)]
        [TestCase(-3, "New Value", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int mockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddAt(mockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddAt(index, value));
        }

        [TestCase(1, 20, 2)]
        public void AddList_WhenArrayList_ShouldAddToArrayList(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {

            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddList(mockNumb));
            ArrayList<string> listForAdding = new ArrayList<string>(Mocks.GetMock_AddList(numbListForAdding));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualArrayList.AddList(listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 20, 3)]
        public void AddListAtFirst_WhenArrayList_ShouldAddAtFirst(int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddList(mockNumb));
            ArrayList<string> listForAdding = new ArrayList<string>(Mocks.GetMock_AddList(numbListForAdding));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualArrayList.AddListAtFirst(listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(7, 1, 20, 2)]
        [TestCase(0, 1, 20, 3)]
        [TestCase(2, 1, 20, 4)]
        [TestCase(6, 1, 20, 5)]
        [TestCase(3, 1, 6, 7)]
        public void AddListAt_WhenIndexAndArrayList_ShouldAddArrayListAtIndex(int index, int mockNumb, int numbListForAdding, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddList(mockNumb));
            ArrayList<string> listForAdding = new ArrayList<string>(Mocks.GetMock_AddList(numbListForAdding));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_AddList(expectedMockNumb));

            actualArrayList.AddListAt(index, listForAdding);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, 1, 20)]
        [TestCase(-25, 1, 20)]
        public void AddListAt_WhenIndexAndArrayList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb, int numbListForAdding)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_AddList(mockNumb));
            ArrayList<string> listForAdding = new ArrayList<string>(Mocks.GetMock_AddList(numbListForAdding));

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddListAt(index, listForAdding));
        }

        [TestCase(1, 2)]
        public void RemoveAtLast_WhenArrayList_ShouldRemoveAtLast(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Remove(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualArrayList.Remove();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(1, 3)]
        public void RemoveAtFirst_WhenArraList_ShouldRemoveAtFirst(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Remove(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualArrayList.RemoveAtFirst();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(8, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(2, 1, 4)]
        public void RemoveAt_WhenArraList_ShouldRemoveAtFirst(int index, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Remove(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_Remove(expectedMockNumb));

            actualArrayList.RemoveAt(index);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, 1)]
        [TestCase(-25, 1)]
        public void RemoveAt_WhenIndexAndArrayList_ShouldThrowIndexOutOfRangeException(int index, int mockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Remove(mockNumb));

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.RemoveAt(index));
        }

        [TestCase(2, 1, 2)]
        [TestCase(7, 1, 5)]
        [TestCase(20, 1, 20)]
        [TestCase(9, 1, 20)]
        public void RemoveRange_WhenCount_ShoudlRemoveRange(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

            actualArrayList.RemoveRange(count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(2, 1, 3)]
        [TestCase(100, 1, 20)]
        public void RemoveRangeAtFirst_WhenCount_ShouldRemoveRangeFromFirst(int count, int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

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
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_RemoveRange(expectedMockNumb));

            actualArrayList.RemoveRangeAt(index, count);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("3", 1, 3)]
        [TestCase("8", 1, 9)]
        [TestCase("non-existent Value", 1, -1)]
        public void RemoveByValue_WhenArray_ShouldRevers(string value, int mockNumb, int expected)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));

            int actual = actualArrayList.RemoveByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("3", 1, 2)]
        [TestCase("8", 1, 4)]
        [TestCase("8", 2, 12)]
        [TestCase("non-existent Value", 1, 0)]
        public void RemoveAllByValue_WhenAllValues_ShoulRemoved(string value, int mockNumb, int expected)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));

            int actual = actualArrayList.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2)]
        [TestCase(20, 20)]
        public void Reverse_WhenArray_ShouldRevers(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock_Reverse(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock_Reverse(expectedMockNumb));

            actualArrayList.Reverse();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("0", 1, 0)]
        [TestCase("5", 1, 6)]
        [TestCase("8", 1, 9)]
        [TestCase("non-existent Value", 1, -1)]
        public void GetIndexByValue(string value, int mockNumb, int expectedIndex)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            int actualIndex = actualArrayList.GetIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(1, 9)]
        [TestCase(20, 0)]
        public void GetIndexOfMax_WhenArrayList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            ArrayList<string> arrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            int actual = arrayList.GetIndexOfMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0)]
        [TestCase(20, 0)]
        public void GetIndexOfMin_WhenArrayList_ShouldReturnIndexOfMax(int mockNumb, int expected)
        {
            ArrayList<string> arrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            int actual = arrayList.GetIndexOfMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "8")]
        [TestCase(20, default(string))]
        public void GetMax_WhenArrayList_ShouldReturnMaxElement(int mockNumb, string expected)
        {
            ArrayList<string> arrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            string actual = arrayList.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "0")]
        [TestCase(20, default(string))]
        public void GetMin_WhenArrayList_ShouldReturnMinElement(int mockNumb, string expected)
        {
            ArrayList<string> arrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            string actual = arrayList.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 1)]
        [TestCase(2, 2)]
        [TestCase(20, 20)]
        public void SortAscending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock(expectedMockNumb));
            actualArrayList.SortAscending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(3, 4)]
        [TestCase(2, 2)]
        [TestCase(20, 20)]
        public void SortDescending_WhenStringArrayList_ShouldBeSorted(int mockNumb, int expectedMockNumb)
        {
            ArrayList<string> actualArrayList = new ArrayList<string>(Mocks.GetMock(mockNumb));
            ArrayList<string> expectedArrayList = new ArrayList<string>(Mocks.GetMock(expectedMockNumb));
            actualArrayList.SortDescending();

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }
    }
}