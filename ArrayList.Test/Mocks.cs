using System;

namespace List.Test
{
    class Mocks
    {
        public static string[] GetMock(int numb)
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

                case 7:
                    array = new string[] { "0" };
                    break;

                case 20:
                    array = new string[] { };
                    break;
            }

            return array;
        }

        public static string[] GetMock_Add(int numb)
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
                case 6:
                    array = new string[] { "New value" };
                    break;
                case 7:
                    array = new string[] { "New value", "Second new value" };
                    break;
            }

            return array;
        }

        public static string[] GetMock_AddAt(int numb)
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

            return array;
        }

        public static string[] GetMock_AddList(int numb)
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

            return array;
        }

        public static string[] GetMock_Remove(int numb)
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

            return array;
        }

        public static string[] GetMock_RemoveRange(int numb)
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

            return array;
        }

        public static string[] GetMock_Reverse(int numb)
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

            return array;
        }
    }
}
