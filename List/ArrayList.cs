using System;

namespace List
{
    public class ArrayList<T>
    {
        public int Length { get; private set; }

        private T[] _array;
        private const int defoultLenght = 10;
        private const double lenghtCoef = 1.33d;

        public ArrayList()
        {
            Length = 0;
            _array = new T[defoultLenght];
        }

        public ArrayList(T value)
        {
            Length = 1;
            _array = new T[defoultLenght + 1];
            _array[0] = value;
        }

        public ArrayList(T[] values)
        {
            Length = values.Length;
            int realLenght = (int)(Length * lenghtCoef + 1);
            _array = new T[realLenght];
            CopyArrayToList(values, _array);
        }







        private static void CopyArrayToList(T[]from, T[]to)
        {
            for(int i = 0; i < from.Length; ++i)
            {
                to[i] = from[i];
            }
        }
    }
}
