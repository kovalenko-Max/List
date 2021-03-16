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

        public void Add(T value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            ++Length;
        }

        public void RemoveLastElement()
        {
            _array[Length-1] = default(T);
            --Length;
            if(Length < _array.Length/2 )
            {
                UpSize();
            }
        }

        public T Get(int index)
        {
            if ((index >= Length) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            
            return _array[index];
        }

        private void UpSize()
        {
            int newRealLenght = (int)(_array.Length * lenghtCoef + 1);

            T[] upSizeArray = new T[newRealLenght];
            CopyArrayToList(_array, upSizeArray);
            _array = upSizeArray;
        }



        private static void CopyArrayToList(T[] from, T[] to)
        {
            for (int i = 0; i < from.Length; ++i)
            {
                to[i] = from[i];
            }
        }
    }
}
