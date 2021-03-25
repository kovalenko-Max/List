using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedList<T> where T : IComparable
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

        private Node<T> _root;
        private Node<T> _tail;

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
            Length++;
            Node<T> current = new Node<T>(value);
            current.Next = _root;
            _root = current;
        }

        public void AddAt(int index, T value)
        {
            Node<T> nodeForAdding = new Node<T>(value);
            if ((index >= 1) && (index <= Length))
            {
                Node<T> current = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    current = current.Next;
                }

                nodeForAdding.Next = current.Next;
                current.Next = nodeForAdding;
                Length++;
            }
            else if (index == 0)
            {
                AddAtFirst(value);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(LinkedList<T> linkedList)
        {
            Length += linkedList.Length;
            _tail.Next = linkedList._root;
        }

        public void AddListAtFirst(LinkedList<T> linkedList)
        {
            Length += linkedList.Length;
            linkedList._tail.Next = _root;
            _root = linkedList._root;
        }

        public void AddListAt(int index, LinkedList<T> linkedList)
        {
            if ((index >= 1) && (index <= Length))
            {
                Length += linkedList.Length;
                Node<T> current = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    current = current.Next;
                }

                linkedList._tail.Next = current.Next;
                current.Next = linkedList._root;
            }
            else if (index == 0)
            {
                AddListAtFirst(linkedList);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public void Remove()
        {
            _tail = GetCurrentNode(Length - 1);
            _tail.Next = null;
            --Length;
        }

        public void RemoveAtFirst()
        {
            _root = _root.Next;
            Length--;
        }

        public void RemoveAt(int index)
        {
            if ((index > 0) && (index < Length))
            {
                Node<T> current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

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
                Node<T> current = GetCurrentNode(Length - count);
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
            if ((index > 0) && (index <= Length))
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
                _root.Next = _root.Next.Next;
                indexForRemove = 0;
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


            while (!(current.Next is null))
            {
                if (comparer.Compare(current.Next.Value, value) == 0)
                {
                    current.Next = current.Next.Next;
                    count++;
                }
                else
                {
                    current = current.Next;
                }
            }

            if (comparer.Compare(_root.Value, value) == 0)
            {
                _root = _root.Next;
                count++;
            }

            Length -= count;

            return count;
        }

        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> current = _root;
            Node<T> following = _root;
            
            while (!(current is null!))
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

        public void SortAscending()
        {
            this._root = this.mergeSort(this._root);
        }

        private Node<T> mergeSort(Node<T> h)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            // Base case : if head is null  
            if (h == null || h.Next == null)
            {
                return h;
            }

            // get the middle of the list  
            Node<T> middle = getMiddle(h);
            Node<T> nextofmiddle = middle.Next;

            // set the next of middle node to null  
            middle.Next = null;

            // Apply mergeSort on left list  
            Node<T> left = mergeSort(h);

            // Apply mergeSort on right list  
            Node<T> right = mergeSort(nextofmiddle);

            // Merge the left and right lists  
            Node<T> sortedlist = sortedMerge(left, right);
            return sortedlist;
        }

        private Node<T> getMiddle(Node<T> node)
        {
            // Base case  
            if (node == null)
                return node;
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

        private Node<T> sortedMerge(Node<T> a, Node<T> b)
        {
            Node<T> result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            Comparer<T> comparer = Comparer<T>.Default;
            /* Pick either a or b, and recur */
            if(comparer.Compare(a.Value,b.Value)<=0)
            {
                result = a;
                result.Next = sortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = sortedMerge(a, b.Next);
            }
            return result;
        }



        public void SortDescending()
        {
            Comparer<T> comparer = Comparer<T>.Default;

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
            LinkedList<T> list = (LinkedList<T>)obj;
            bool isEquals = true;

            if (this.Length == list.Length)
            {
                Node<T> currentThis = this._root;
                Node<T> currentList = list._root;
                Comparer<T> comparer = Comparer<T>.Default;

                if (!((currentThis is null) && (currentList is null)))
                {
                    do
                    {
                        if (comparer.Compare(currentThis.Value, currentList.Value) != 0)
                        {
                            isEquals = false;
                            break;
                        }
                        currentList = currentList.Next;
                        currentThis = currentThis.Next;
                    }
                    while (!(currentThis is null));
                }
            }
            else
            {
                isEquals = false;
            }

            return isEquals;
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
