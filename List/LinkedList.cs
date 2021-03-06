using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedList<T> : IList<T> where T : IComparable
    {
        protected Node<T> _root;
        protected Node<T> _tail;
        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                return GetCurrentNode(index).Value;
            }

            set
            {
                if ((index >= 0) && (index <= Length))
                {
                    Node<T> current = _root;

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

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(T value)
        {
            Length = 1;
            _root = new Node<T>(value);
            _tail = _root;
        }

        public LinkedList(T[] values)
        {
            if (!(values is null))
            {
                Length = values.Length;

                if (values.Length != 0)
                {
                    _root = new Node<T>(values[0]);
                    _tail = _root;

                    for (int i = 1; i < values.Length; i++)
                    {
                        _tail.Next = new Node<T>(values[i]);
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
                _root = new Node<T>(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node<T>(value);
                _tail = _tail.Next;
            }
            ++Length;
        }

        public void AddAtFirst(T value)
        {
            Node<T> current = new Node<T>(value);
            current.Next = _root;
            _root = current;

            if (Length < 1)
            {
                _tail = current;
            }

            Length++;
        }

        public void AddAt(int index, T value)
        {
            Node<T> nodeForAdding = new Node<T>(value);

            if ((index >= 1) && (index < Length))
            {
                Node<T> current = GetCurrentNode(index - 1);

                nodeForAdding.Next = current.Next;
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

        public void AddList(IList<T> listForAdding)
        {
            foreach (T value in listForAdding)
            {
                Add(value);
            }
        }

        public void AddListAtFirst(IList<T> listForAdding)
        {
            LinkedList<T> linkedListForAdding;

            if (listForAdding is LinkedList<T>)
            {
                linkedListForAdding = (LinkedList<T>)listForAdding;
            }
            else
            {
                linkedListForAdding = new LinkedList<T>(listForAdding.ToArray());
            }

            Length += linkedListForAdding.Length;
            linkedListForAdding._tail.Next = _root;
            _root = linkedListForAdding._root;
        }

        public void AddListAt(int index, IList<T> listForAdding)
        {
            if ((index >= 1) && (index <= Length))
            {
                LinkedList<T> linkedListForAdding;
                Node<T> current = GetCurrentNode(index - 1);

                if (listForAdding is LinkedList<T>)
                {
                    linkedListForAdding = (LinkedList<T>)listForAdding;
                }
                else
                {
                    linkedListForAdding = new LinkedList<T>(listForAdding.ToArray());
                }

                Length += linkedListForAdding.Length;
                linkedListForAdding._tail.Next = current.Next;
                current.Next = linkedListForAdding._root;
            }
            else if (index == 0)
            {
                AddListAtFirst(listForAdding);
            }
            else if (index == Length)
            {
                AddList(listForAdding);
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
                    _tail = GetCurrentNode(Length - 2);
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
                if (Length > 1)
                {
                    _root = _root.Next;
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
                Length--;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index > 0) && (index < Length))
            {
                Node<T> current = _root;

                current = GetCurrentNode(index - 1);
                current.Next = current.Next.Next;
                Length--;
            }
            else if (index == 0)
            {
                RemoveAtFirst();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRange(int count)
        {
            if (count < Length)
            {
                int currentIndex = Length - count - 1;
                Node<T> current = GetCurrentNode(currentIndex);
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

        public void RemoveRangeAtFirst(int count)
        {
            if (count < Length)
            {
                Node<T> current = GetCurrentNode(count);
                _root = current;
                Length -= count;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public void RemoveRangeAt(int index, int count)
        {
            if ((index > 0) && (index < Length - 1))
            {
                Node<T> current = GetCurrentNode(index - 1);
                int indexLastPart = index + count;
                if (indexLastPart < Length)
                {
                    Node<T> LastPart = GetCurrentNode(indexLastPart);
                    current.Next = LastPart;
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
                RemoveRange(1);
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

            if (comparer.Compare(_root.Value, value) == 0)
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
                Node<T> current = _root;

                for (int i = 1; i < Length; ++i)
                {
                    if (comparer.Compare(current.Next.Value, value) == 0)
                    {
                        indexForRemove = i;
                        current.Next = current.Next.Next;
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
            Node<T> current = _root;

            if (Length > 1)
            {
                for (int i = 1; i < Length - 1;)
                {
                    if (comparer.Compare(current.Next.Value, value) == 0)
                    {
                        current.Next = current.Next.Next;
                        count++;
                        --Length;
                    }
                    else
                    {
                        current = current.Next;
                        ++i;
                    }
                }

                if (comparer.Compare(_root.Value, value) == 0)
                {
                    RemoveAtFirst();
                    count++;
                }

                if (comparer.Compare(_tail.Value, value) == 0)
                {
                    Remove();
                    count++;
                }
            }
            else
            {
                Remove();
                count++;
            }


            return count;
        }

        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> current = _root;
            Node<T> following = _root;

            while (!(current is null))
            {
                following = following.Next;
                current.Next = previous;
                previous = current;
                current = following;
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
                Node<T> current = _root.Next;
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
                Node<T> current = _root;

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

                Node<T> current = _root;

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

        public T[] ToArray()
        {
            T[] array = new T[Length];
            Node<T> current = _root;

            for (int i = 0; i < Length; ++i)
            {
                array[i] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> node = _root;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node<T> current = _root;
                StringBuilder result = new StringBuilder(string.Empty);
                result.Append(current.Value + " ");

                while (!(current.Next is null))
                {
                    current = current.Next;
                    result.Append(current.Value + " ");
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
            LinkedList<T> comparableList = (LinkedList<T>)obj;
            bool isEquals = true;

            if (this.Length == comparableList.Length)
            {
                Node<T> left = this._root;
                Node<T> right = comparableList._root;
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

        private Node<T> MergeSort(Node<T> root, bool isAscending)
        {
            // Base case : if head is null  
            if (root == null || root.Next == null)
            {
                return root;
            }

            // get the middle of the list  
            Node<T> middle = GetMiddle(root);
            Node<T> nextofmiddle = middle.Next;

            // set the next of middle node to null  
            middle.Next = null;

            // Apply mergeSort on left list  
            Node<T> left = MergeSort(root, isAscending);

            // Apply mergeSort on right list  
            Node<T> right = MergeSort(nextofmiddle, isAscending);

            // Merge the left and right lists  
            Node<T> sortedlist = SortedMerge(left, right, isAscending);
            return sortedlist;
        }

        private Node<T> GetMiddle(Node<T> node)
        {
            // Base case  
            if (node == null)
            {
                return node;
            }

            Node<T> fastptr = node.Next;
            Node<T> slowptr = node;

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

        private Node<T> SortedMerge(Node<T> a, Node<T> b, bool isAscending)
        {
            Node<T> result = null;

            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            Comparer<T> comparer = Comparer<T>.Default;

            int compareResult = isAscending ? -1 : 1;

            if (comparer.Compare(a.Value, b.Value) == compareResult)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b, isAscending);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next, isAscending);
            }

            return result;
        }

        private Node<T> GetCurrentNode(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                Node<T> current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
