using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DLinkedList<T> : IList<T> where T : IComparable
    {
        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                return GetCurrentNode(index).Value;
            }

            set
            {
                if ((index >= 0) && (index < Length))
                {
                    DLNode<T> current = _root;

                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }

                    current.Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        private DLNode<T> _root;
        private DLNode<T> _tail;

        public DLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DLinkedList(T value)
        {
            Length = 1;
            _root = new DLNode<T>(value);
            _tail = _root;
        }

        public DLinkedList(T[] values)
        {
            if (!(values is null))
            {
                Length = values.Length;

                if (values.Length != 0)
                {
                    _root = new DLNode<T>(values[0]);
                    _tail = _root;

                    for (int i = 1; i < values.Length; i++)
                    {
                        _tail.Next = new DLNode<T>(values[i]);
                        _tail.Next.Previous = _tail;
                        _tail = _tail.Next;
                    }
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Add(T value)
        {
            if (Length == 0)
            {
                _root = new DLNode<T>(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new DLNode<T>(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }

            ++Length;
        }

        public void AddAtFirst(T value)
        {
            Length++;
            DLNode<T> current = new DLNode<T>(value);
            _root.Previous = current;
            current.Next = _root;
            _root = current;
        }

        public void AddAt(int index, T value)
        {
            DLNode<T> nodeForAdding = new DLNode<T>(value);

            if ((index >= 1) && (index < Length))
            {
                DLNode<T> current = GetCurrentNode(index - 1);

                nodeForAdding.Next = current.Next;
                current.Next.Previous = nodeForAdding;
                nodeForAdding.Previous = current;
                current.Next = nodeForAdding;
                Length++;
            }
            else if (index == 0)
            {
                AddAtFirst(value);
            }
            else if (index == Length)
            {
                Add(value);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(IList<T> listForAdding)//
        {
            DLinkedList<T> dListForAdding = (DLinkedList<T>)listForAdding;
            Length += dListForAdding.Length;
            _tail.Next = dListForAdding._root;
            dListForAdding._root.Previous = _tail;
            _tail = dListForAdding._tail;
        }

        public void AddListAtFirst(IList<T> listForAdding)//
        {
            DLinkedList<T> dListForAdding = (DLinkedList<T>)listForAdding;
            Length += dListForAdding.Length;
            dListForAdding._tail.Next = _root;
            _root.Previous = dListForAdding._tail;
            _root = dListForAdding._root;
        }

        public void AddListAt(int index, IList<T> listForAdding)
        {
            DLinkedList<T> dListForAdding = (DLinkedList<T>)listForAdding;

            if ((index >= 1) && (index < Length))
            {
                DLNode<T> current = GetCurrentNode(index - 1);

                Length += dListForAdding.Length;
                dListForAdding._tail.Next = current.Next;
                dListForAdding._root.Previous = current;
                current.Next.Previous = dListForAdding._tail;
                current.Next = dListForAdding._root;
            }
            else if (index == 0)
            {
                AddListAtFirst(dListForAdding);
            }
            else if (index == Length)
            {
                AddList(dListForAdding);
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
                if (Length > 1)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                }
                else
                {
                    _root = null;
                    _tail = null;
                }

                --Length;
            }
        }

        public void RemoveAtFirst()
        {
            if (Length > 0)
            {
                _root.Previous = null;
                _root = _root.Next;

                if (Length == 1)
                {
                    _tail = null;
                }

                Length--;
            }

        }

        public void RemoveAt(int index)
        {
            if ((index > 0) && (index < Length - 1))
            {
                DLNode<T> current = GetCurrentNode(index);

                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                --Length;
            }
            else if (index == 0)
            {
                RemoveAtFirst();
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRange(int count)
        {
            if (count < Length)//
            {
                int currentIndex = Length - count - 1;
                DLNode<T> current = GetCurrentNode(currentIndex);
                Length -= count;
                _tail = current;
                current.Next = null;
            }
            else
            {
                Length = 0;
                _tail = null;
                _root = null;
            }

        }

        public void RemoveRangeAtFirst(int count)//
        {
            if (count < Length)
            {
                DLNode<T> current = GetCurrentNode(count);
                _root = current;
                _root.Previous = null;
                Length -= count;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public void RemoveRangeAt(int index, int count)//
        {
            if ((index > 0) && (index < Length - 1))
            {
                DLNode<T> current = GetCurrentNode(index - 1);
                int indexLastPart = index + count;
                if (indexLastPart < Length)
                {
                    DLNode<T> LastPart = GetCurrentNode(indexLastPart);
                    current.Next = LastPart;
                    LastPart.Previous = current;
                    Length -= count;
                }
                else
                {
                    _tail = current;
                    current.Next = null;
                    Length = index;
                }
            }
            else if (index == 0)
            {
                RemoveRangeAtFirst(count);
            }
            else if (index == Length - 1)
            {
                RemoveRange(count);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int RemoveByValue(T value)
        {
            int indexForRemove = -1;

            Comparer<T> comparer = Comparer<T>.Default;

            if (_root.Value.CompareTo(value) == 0)//
            {
                RemoveAtFirst();
                indexForRemove = 0;
            }
            else if (comparer.Compare(_tail.Value, value) == 0)
            {
                indexForRemove = Length - 1;
                Remove();
            }
            else
            {
                DLNode<T> current = _root.Next;

                for (int i = 1; i < Length - 1; ++i)
                {
                    if (comparer.Compare(current.Value, value) == 0)
                    {
                        indexForRemove = i;
                        current.Next.Previous = current.Previous;
                        current.Previous.Next = current.Next;
                        --Length;
                        break;
                    }
                    current = current.Next;
                }
            }

            return indexForRemove;
        }

        public int RemoveAllByValue(T value)
        {
            int count = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            DLNode<T> current = _root;

            if (Length > 1)
            {
                while (!(current.Next.Next is null))
                {
                    if (comparer.Compare(current.Next.Value, value) == 0)
                    {
                        current.Next.Next.Previous = current;
                        current.Next = current.Next.Next;
                        ++count;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

                Length -= count;

                if (comparer.Compare(_root.Value, value) == 0)
                {
                    RemoveAtFirst();
                    ++count;
                }
                if (comparer.Compare(_tail.Value, value) == 0)
                {
                    Remove();
                    ++count;
                }
            }
            else if (Length == 1)
            {
                Remove();
                ++count;
            }

            return count;
        }

        public void Reverse()
        {
            DLNode<T> current = _root;

            for (int i = 0; i < Length; ++i)
            {
                DLNode<T> tmp = current.Next;
                current.Next = current.Previous;
                current.Previous = tmp;
                current = current.Previous;
            }

            current = _root;
            _root = _tail;
            _tail = current;
        }

        public int GetIndexByValue(T value)
        {
            int result = -1;
            Comparer<T> comparer = Comparer<T>.Default;

            if (comparer.Compare(_root.Value, value) == 0)
            {
                result = 0;
            }
            else
            {
                DLNode<T> current = _root.Next;

                for (int i = 1; i < Length; ++i)
                {
                    if (comparer.Compare(current.Value, value) == 0)
                    {
                        result = i;
                        break;
                    }
                    current = current.Next;
                }
            }

            return result;
        }

        public int GetIndexOfMax()
        {
            if (Length != 0)
            {
                int result = 0;
                T maxValue = _root.Value;
                Comparer<T> comparer = Comparer<T>.Default;
                DLNode<T> current = _root;

                for (int i = 0; i < Length; ++i)
                {
                    if (comparer.Compare(current.Value, maxValue) > 0)
                    {
                        maxValue = current.Value;
                        result = i;
                    }
                    current = current.Next;
                }
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetIndexOfMin()
        {
            if (Length != 0)
            {
                int result = 0;
                T minValue = _root.Value;
                Comparer<T> comparer = Comparer<T>.Default;

                DLNode<T> current = _root;

                for (int i = 0; i < Length; ++i)
                {
                    if (comparer.Compare(current.Value, minValue) < 0)
                    {
                        minValue = current.Value;
                        result = i;
                    }
                    current = current.Next;
                }

                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public T GetMax()
        {
            return this[GetIndexOfMax()];
        }

        public T GetMin()
        {
            return this[GetIndexOfMin()];
        }

        public void Sort(bool isAscending = true)
        {
            _root = MergeSort(_root, isAscending);
        }

        public void SortAscending()
        {
            this._root = this.MergeSort(this._root, isAscending: true);
        }

        public void SortDescending()
        {
            this._root = this.MergeSort(this._root, isAscending: false);
        }

        private DLNode<T> MergeSort(DLNode<T> root, bool isAscending)
        {
            // Base case : if head is null  
            if (root == null || root.Next == null)
            {
                return root;
            }

            // get the middle of the list  
            DLNode<T> middle = GetMiddle(root);
            DLNode<T> nextofmiddle = middle.Next;

            // set the next of middle node to null  
            middle.Next = null;

            // Apply mergeSort on left list  
            DLNode<T> left = MergeSort(root, isAscending);

            // Apply mergeSort on right list  
            DLNode<T> right = MergeSort(nextofmiddle, isAscending);

            // Merge the left and right lists  
            DLNode<T> sortedlist = SortedMerge(left, right, isAscending);
            return sortedlist;
        }

        private DLNode<T> GetMiddle(DLNode<T> node)
        {
            // Base case  
            if (node == null)
            {
                return node;
            }

            DLNode<T> fastptr = node.Next;
            DLNode<T> slowptr = node;

            // Move fastptr by two and slow ptr by one  
            // Finally slowptr will point to middle node  
            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }

        private DLNode<T> SortedMerge(DLNode<T> a, DLNode<T> b, bool isAscending)//
        {
            DLNode<T> result = null;
            /* Base cases */
            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            Comparer<T> comparer = Comparer<T>.Default;

            switch (isAscending)
            {
                case true:

                    /* SortAscending a, b and recur */
                    if (comparer.Compare(a.Value, b.Value) <= 0)
                    {
                        result = a;
                        result.Next = SortedMerge(a.Next, b, isAscending);
                        result.Next.Previous = result;
                        result.Previous = null;
                    }
                    else
                    {
                        result = b;
                        result.Next = SortedMerge(a, b.Next, isAscending);
                        b.Next.Previous = b;
                        b.Previous = null;
                    }
                    break;

                case false:
                    /* SortDescending a, b and recur */
                    if (comparer.Compare(a.Value, b.Value) >= 0)
                    {
                        result = a;
                        result.Next = SortedMerge(a.Next, b, isAscending);
                        result.Next.Previous = result;
                        result.Previous = null;
                    }
                    else
                    {
                        result = b;
                        result.Next = SortedMerge(a, b.Next, isAscending);
                        b.Next.Previous = b;
                        b.Previous = null;
                    }
                    break;
            }

            return result;
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DLNode<T> current = _root;
                StringBuilder result = new StringBuilder(string.Empty);
                result.Append(current.Value + " ");

                while (!(current.Next is null))
                {
                    current = current.Next;
                    result.Append(current.Value + " ");//$
                }

                return result.ToString().Trim();
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            DLinkedList<T> comparableList = (DLinkedList<T>)obj;
            bool isEquals = true;

            if (this.Length == comparableList.Length)
            {
                DLNode<T> left = this._root;
                DLNode<T> right = comparableList._root;
                Comparer<T> comparer = Comparer<T>.Default;

                if (!((left is null) && (right is null)))
                {
                    left = left.Next;
                    right = right.Next;
                    for (int i = 1; i < Length - 1; ++i)
                    {
                        if (comparer.Compare(left.Value, right.Value) != 0)
                        {
                            isEquals = false;
                            break;
                        }
                        if (comparer.Compare(left.Next.Value, right.Next.Value) != 0)
                        {
                            isEquals = false;
                            break;
                        }
                        if (comparer.Compare(left.Previous.Value, right.Previous.Value) != 0)
                        {
                            isEquals = false;
                            break;
                        }
                        right = right.Next;
                        left = left.Next;
                    }
                }
            }
            else
            {
                isEquals = false;
            }

            return isEquals;
        }

        private DLNode<T> GetCurrentNode(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                if (index < (Length / 2))
                {
                    DLNode<T> current = _root;

                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                    return current;
                }
                else
                {
                    DLNode<T> current = _tail;

                    for (int i = Length - 1; i > index; --i)
                    {
                        current = current.Previous;
                    }
                    return current;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            DLNode<T> node = _root;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }
}
