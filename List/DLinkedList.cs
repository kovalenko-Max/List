using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DLinkedList<T> where T : IComparable
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
            if ((index >= 1) && (index <= Length))
            {
                DLNode<T> current = GetCurrentNode(index-1);

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
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddList(DLinkedList<T> linkedList)
        {
            Length += linkedList.Length;
            _tail.Next = linkedList._root;
        }

        public void AddListAtFirst(DLinkedList<T> linkedList)
        {
            Length += linkedList.Length;
            linkedList._tail.Next = _root;
            _root = linkedList._root;
        }

        public void AddListAt(int index, DLinkedList<T> linkedList)
        {
            if ((index >= 1) && (index <= Length))
            {
                Length += linkedList.Length;
                DLNode<T> current = _root;
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
            DLinkedList<T> list = (DLinkedList<T>)obj;
            bool isEquals = true;

            if (this.Length == list.Length)
            {
                DLNode<T> currentThis = this._root;
                DLNode<T> currentList = list._root;
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

                    for (int i = Length-1; i > index; --i)
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

    }
}
