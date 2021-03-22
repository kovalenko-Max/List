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
                if ((index >= 0) && (index <= Length))
                {
                    Node<T> current = _root;

                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                    return current.Value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

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
            Length++;
            _tail.Next = new Node<T>(value);
            _tail = _tail.Next;
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
            else if(index == 0)
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
            
        }

        public void RemoveAtFirst()
        {
            
        }

        public void RemoveAt(int index)
        {
            if ((index < Length) && (index >= 0))
            {
                
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRange(int count)
        {
           
        }

        public void RemoveRangeAtFirst(int count)
        {
            
        }

        public void RemoveRangeAt(int index, int count)
        {
            if ((index >= 0) && (index <= Length))
            {
               
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int RemoveByValue(T value)
        {
            int indexForRemove = 0;
           

            return indexForRemove;
        }

        public int RemoveAllByValue(T value)
        {
            int count = 0;
            

            return count;
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
                while (!(currentThis.Next is null));
            }
            else
            {
                isEquals = false;
            }

            return isEquals;
        }
    }
}
