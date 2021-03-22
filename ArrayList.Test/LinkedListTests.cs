using NUnit.Framework;
using System;

namespace List.Test
{
    class LinkedListTests
    {

        [TestCase(0, 1, "0")]
        [TestCase(4, 1, "3")]
        [TestCase(8, 1, "7")]
        public void Get_WhenIndex_ShouldGetElement(int index, int mockNumb, string expected)
        {
            LinkedList<string> actualArrayList = LinkedListMock.GetMock(mockNumb);

            string actual = actualArrayList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "New Value", 1, 5)]
        [TestCase(3, null, 1, 6)]
        public void Set_WhenIndex_ShouldSetElement(int index, string value, int mockNumb, int expectedMockNumb)
        {
            LinkedList<string> expectedArrayList = LinkedListMock.GetMock(expectedMockNumb);
            LinkedList<string> actual = LinkedListMock.GetMock(mockNumb);

            actual[index] = value;

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase("7", 1, 2)]
        [TestCase("8", 2, 3)]
        [TestCase("9", 3, 4)]
        [TestCase(null, 3, 5)]
        public void Add_WhenValue_ShouldToEnd(string value, int mockNumb, int expectedMockNumb)
        {
            LinkedList<string> actualArrayList = LinkedListMock.GetMock_Add(mockNumb);
            LinkedList<string> expectedArrayList = LinkedListMock.GetMock_Add(expectedMockNumb);

            actualArrayList.Add(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 1, 3)]
        public void AddAtFirst_WhenValue_ShouldAddtoFirst(string value, int mockNumb, int expectedMockNumb)
        {
            LinkedList<string> actualArrayList = LinkedListMock.GetMock_AddAt(mockNumb);
            LinkedList<string> expectedArrayList = LinkedListMock.GetMock_AddAt(expectedMockNumb);

            actualArrayList.AddAtFirst(value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase("New Value", 7, 1, 2)]
        [TestCase("New Value", 0, 1, 3)]
        [TestCase("New Value", 2, 1, 4)]
        [TestCase(null, 2, 1, 5)]
        public void AddAt_WhenIndexAndStringValue_ShouldAddElementByIndex(string value, int index, int mockNumb, int expectedMockNumb)
        {
            LinkedList<string> actualArrayList = LinkedListMock.GetMock_AddAt(mockNumb);
            LinkedList<string> expectedArrayList = LinkedListMock.GetMock_AddAt(expectedMockNumb);

            actualArrayList.AddAt(index, value);

            Assert.AreEqual(expectedArrayList, actualArrayList);
        }

        [TestCase(25, "New Value", 1)]
        [TestCase(-3, "New Value", 1)]
        public void AddAt_WhenIndexAndStringValue_ShouldThrowIndexOutOfRangeException(int index, string value, int mockNumb)
        {
            LinkedList<string> actualArrayList = LinkedListMock.GetMock_AddAt(mockNumb);

            Assert.Throws<IndexOutOfRangeException>(() => actualArrayList.AddAt(index, value));
        }






        private static class LinkedListMock
        {
            public static LinkedList<string> GetMock(int numb)
            {
                string[] array;

                switch (numb)
                {
                    default:
                        array = new string[] { };
                        break;

                    case 1:
                        array = new string[] { "0", "1", "2", "3", "3", "4", "5", "6", "7", "8", "8", "8", "8" };
                        break;

                    case 2:
                        array = new string[] { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
                        break;


                    case 3:
                        array = new string[] { "2", "5", "8", "0", "8", "1", "8", "3", "3", "4", "6", "7", "8" };
                        break;

                    case 4:
                        array = new string[] { "8", "8", "8", "8", "7", "6", "5", "4", "3", "3", "2", "1", "0" };
                        break;

                    case 5:
                        array = new string[] { "0", "1", "2", "New Value", "3", "4", "5", "6", "7", "8", "8", "8", "8" };
                        break;

                    case 6:
                        array = new string[] { "0", "1", "2", null, "3", "4", "5", "6", "7", "8", "8", "8", "8" };
                        break;

                    case 20:
                        array = new string[] { };
                        break;
                }

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_Add(int numb)
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

                    case 5:
                        array = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", null };
                        break;
                }

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_AddAt(int numb)
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
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6", "New Value" };
                        break;

                    case 3:
                        array = new string[] { "New Value", "0", "1", "2", "3", "4", "5", "6" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "New Value", "2", "3", "4", "5", "6" };
                        break;

                    case 5:
                        array = new string[] { "0", "1", null, "2", "3", "4", "5", "6" };
                        break;
                }

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_AddList(int numb)
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

                    case 6:
                        array = new string[] { null, null, null };
                        break;

                    case 7:
                        array = new string[] { "0", "1", "2", null, null, null, "3", "4", "5", "6" };
                        break;
                    case 20:
                        array = new string[] { "n0", "n1", "n2", "n3", "n4", "n5", "n6" };
                        break;

                }

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_Remove(int numb)
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

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_RemoveRange(int numb)
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
                        array = new string[] { "0", "1", "2", "3", "4", "5", "6" };
                        break;

                    case 3:
                        array = new string[] { "2", "3", "4", "5", "6", "7", "8" };
                        break;

                    case 4:
                        array = new string[] { "0", "1", "2", "5", "6", "7", "8" };
                        break;

                    case 5:
                        array = new string[] { "0", "1" };
                        break;

                    case 20:
                        array = new string[] { };
                        break;
                }

                return new LinkedList<string>(array);
            }

            public static LinkedList<string> GetMock_Reverse(int numb)
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
                        array = new string[] { "8", "7", "6", "5", "4", "3", "2", "1", "0" };
                        break;

                    case 20:
                        array = new string[] { };
                        break;
                }

                return new LinkedList<string>(array);
            }
        }
    }
}
