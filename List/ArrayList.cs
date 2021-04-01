using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ArrayList<T> : IList<T> where T : IComparable
    {
        private const int defoultLenght = 10;
        private const double lenghtCoef = 1.33d;

        private T[] _array;

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if ((index < Length) && (index >= 0))
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
                if ((index < Length) && (index >= 0))
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

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
                Resize();
            }

            _array[Length] = value;
            ++Length;
        }

        public void AddAtFirst(T value)
        {
            AddAt(0, value);
        }

        public void AddAt(int index, T value)
        {
            if ((index >= 0) && (index <= Length))
            {
                ++Length;
                if (Length >= _array.Length)
                {
                    Resize();
                }

                Shift(index, Length, 1);
                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public void AddList(IList<T> arrayList)
        {
            AddListAt(Length, arrayList);
        }

        public void AddListAtFirst(IList<T> arrayList)
        {
            AddListAt(0, arrayList);
        }

        public void AddListAt(int index, IList<T> listForAdding)
        {
            ArrayList<T> ArrayListForAdding;

            if (listForAdding is ArrayList<T>)
            {
                ArrayListForAdding = (ArrayList<T>)listForAdding;
            }
            else
            {
                ArrayListForAdding = new ArrayList<T>(listForAdding.ToArray());
            }

            if ((index <= Length) && (index >= 0))
            {
                Length += ArrayListForAdding.Length;
                if (Length >= _array.Length)
                {
                    Resize();
                }

                Shift(index, Length - 1, ArrayListForAdding.Length);

                for (int i = 0; i < ArrayListForAdding.Length; ++i)
                {
                    _array[index] = ArrayListForAdding[i];
                    ++index;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                int index = Length - 1;
                RemoveAt(index);
            }
        }

        public void RemoveAtFirst()
        {
            if (Length > 0)
            {
                int index = 0;
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if ((index < Length) && (index >= 0))
            {
                --Length;

                if (Length < _array.Length / 2)
                {
                    Resize();
                }

                Shift(index, Length, -1);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRange(int count)
        {
            int index = (Length - count) > 0 ? (Length - count) : 0;

            RemoveRangeAt(index, count);
        }

        public void RemoveRangeAtFirst(int count)
        {
            RemoveRangeAt(0, count);
        }

        public void RemoveRangeAt(int index, int count)
        {
            if ((index >= 0) && (index <= Length))
            {
                if (count > Length)
                {
                    Length = index;
                }
                else
                {
                    Length -= count;
                    Shift(index, Length, -count);
                }

                if (Length < _array.Length / 2)
                {
                    Resize();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int RemoveByValue(T value)
        {
            int indexForRemove = GetIndexByValue(value);
            if (indexForRemove != -1)
            {
                RemoveAt(indexForRemove);
            }

            return indexForRemove;
        }

        public int RemoveAllByValue(T value)
        {
            int count = 0;

            int indexForRemove = GetIndexByValue(value);
            while (indexForRemove != -1)
            {
                RemoveAt(indexForRemove);
                indexForRemove = GetIndexByValue(value);
                ++count;
            }

            return count;
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

        public void Sort(bool isAscending = true)
        {
            if (isAscending)
            {
                SortAscending();
            }
            else
            {
                SortDescending();
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Length; ++i)
            {
                yield return _array[i];
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Length];

            for (int i = 0; i < Length; ++i)
            {
                array[i] = _array[i];
            }

            return array;
        }

        public override bool Equals(object obj)
        {
            ArrayList<T> compareAray = (ArrayList<T>)obj;
            bool result = true;

            if (Length == compareAray.Length)
            {
                Comparer<T> comparer = Comparer<T>.Default;
                for (int i = 0; i < Length; ++i)
                {
                    if (comparer.Compare(_array[i], compareAray._array[i]) != 0)
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
            StringBuilder result = new StringBuilder(string.Empty);
            for (int i = 0; i < Length; ++i)
            {
                result.Append(_array[i] + " ");
            }

            return result.ToString().Trim();
        }

        private void Resize()
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

        private void Shift(int indexFrom, int indexTo, int shiftCount)
        {
            if (shiftCount > 0)
            {
                for (int i = indexTo; (i - shiftCount) >= indexFrom; --i)
                {
                    _array[i] = _array[i - shiftCount];
                }
            }
            else
            {
                for (int i = indexFrom; i < indexTo; ++i)
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

        private void SortAscending()
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

        private void SortDescending()
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


    }
}