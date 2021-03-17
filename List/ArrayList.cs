using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    public class ArrayList<T> : IEnumerable<T>
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
            _array = new T[defoultLenght];
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
            _array[Length - 1] = default(T);
            --Length;
            if (Length < _array.Length / 2)
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

        //public bool Equals(ArrayList<T> arrayList)
        //{
        //    bool result = true;

        //    if (this.Length == arrayList.Length)
        //    {
        //        Comparer<T> comparer = Comparer<T>.Default;
        //        for (int i = 0; i < this.Length; ++i)
        //        {
        //            if (comparer.Compare(this.Get(i), arrayList.Get(i)) != 0)
        //            {
        //                result = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        result = false;
        //    }

        //    return result;
        //}

        public bool Equals(ArrayList<T> arrayList)
        {
            bool result = true;

            if (this.Length == arrayList.Length)
            {
                for (int i = 0; i < this.Length; ++i)
                {
                    bool b = Enumerable.SequenceEqual(this, arrayList);
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void UpSize()
        {
            int newRealLenght = (int)(Length * lenghtCoef + 1);

            T[] upSizeArray = new T[newRealLenght];
            CopyArrayToList(_array, upSizeArray);
            _array = upSizeArray;
        }

        private static void CopyArrayToList(T[] from, T[] to)
        {
            int copyLenght = from.Length < to.Length ? from.Length : to.Length;
            for (int i = 0; i < copyLenght; ++i)
            {
                to[i] = from[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}
