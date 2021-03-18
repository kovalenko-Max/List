using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    public class ArrayList<T>
    {
        public int Length { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index < Length)
                {
                    return _array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index < Length)
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

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
            if (Length >= _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            ++Length;
        }

        public void AddAtFirst(T value)
        {
            this.AddAt(0, value);
        }

        public void AddAt(int index, T value)
        {
            ++Length;
            if (Length >= _array.Length)
            {
                this.UpSize();
            }
            this.Shift(index, 1);
            _array[index] = value;
        }

        public void RemoveAtLast()
        {
            RemoveAt(Length - 1);
        }

        public void RemoveAt(int index)
        {
            _array[index] = default(T);
            --Length;
            if (Length < _array.Length / 2)
            {
                this.UpSize();
            }
            this.Shift(index, -1);
        }

        public void RemoveRange(int index, int count)
        {
            int range = index + count;
            for (int i = index; i < range; ++i)
            {
                _array[i] = default(T);
            }
            Length -= count;
            this.Shift(index, -count);

            if (Length < _array.Length / 2)
            {
                this.UpSize();
            }

        }

        public void RemoveRangeAtFirst(int count)
        {
            this.RemoveRange(0, count);
        }

        public void RemoveRangeAtEnd(int cont)
        {
            this.RemoveRange(Length - cont, cont);
        }

        public int RemoveByValue(T value)
        {
            int indexForRemove = GetIndexByValue(value);
            RemoveAt(indexForRemove);

            return indexForRemove;
        }

        public int GetIndexByValue(T value)
        {
            int result = -1;
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < Length; ++i)
            {
                if (comparer.Compare(_array[i], value) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public int GetIndexOfMax()
        {
            int result = 0;
            T maxElement = _array[0];
            Comparer<T> comparer = Comparer<T>.Default;

            for (int i = 0; i < Length; ++i)
            {
                if ((comparer.Compare(_array[i], maxElement) > 0))
                {
                    maxElement = _array[i];
                    result = i;
                }
            }

            return result;
        }

        public int GetIndexOfMin()
        {
            int result = 0;
            T minElement = _array[0];
            Comparer<T> comparer = Comparer<T>.Default;

            for (int i = 0; i < Length; ++i)
            {
                if ((comparer.Compare(_array[i], minElement) < 1))
                {
                    minElement = _array[i];
                    result = i;
                }
            }

            return result;
        }

        public T GetMax()
        {
            return _array[GetIndexOfMax()];
        }

        public T GetMin()
        {
            return _array[GetIndexOfMin()];
        }

        public void SortAscending()
        {
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < Length - 1; ++i)
            {
                int min = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if ((comparer.Compare(_array[j], _array[min]) < 0))
                    {
                        min = j;
                    }
                }
                Swap(ref _array[min], ref _array[i]);
            }
        }

        public void SortDescending()
        {
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < Length - 1; ++i)
            {
                int max = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if ((comparer.Compare(_array[j], _array[max]) > 0))
                    {
                        max = j;
                    }
                }
                Swap(ref _array[max], ref _array[i]);
            }
        }

        public void Reverse()
        {
            int halfLenght = Length / 2;

            for (int i = 0; i < halfLenght; ++i)
            {
                int rotateIndex = Length - 1 - i;
                Swap(ref _array[i], ref _array[rotateIndex]);
            }
        }

        public override bool Equals(object obj)
        {
            ArrayList<T> compareAray = (ArrayList<T>)obj;
            bool result = true;

            if (this.Length == compareAray.Length)
            {
                Comparer<T> comparer = Comparer<T>.Default;
                for (int i = 0; i < this.Length; ++i)
                {
                    if (comparer.Compare(this._array[i], compareAray._array[i]) != 0)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override string ToString()
        {
            string toString = string.Empty;
            for (int i = 0; i < Length; ++i)
            {
                toString += _array[i] + " ";
            }
            return toString;
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


        /// <summary>
        /// Shifts array elements from index to shiftCount. If the number is negative, it shifts the beginning.
        /// </summary>
        /// <param name="indexFrom"></param>
        /// <param name="shiftCount"></param>
        private void Shift(int indexFrom, int shiftCount)
        {
            if (shiftCount > 0)
            {
                for (int i = Length - 1; i > indexFrom; --i)
                {
                    _array[i] = _array[i - shiftCount];
                }
            }
            else
            {
                for (int i = indexFrom; i < Length; ++i)
                {
                    _array[i] = _array[i - shiftCount];
                }
            }
        }

        private void Swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}


//public bool Equals(ArrayList<T> arrayList)
//{
//    bool result = true;

//    if (this.Length == arrayList.Length)
//    {
//        for (int i = 0; i < this.Length; ++i)
//        {
//            bool b = Enumerable.SequenceEqual(this, arrayList);
//        }
//    }
//    else
//    {
//        result = false;
//    }

//    return result;
//}