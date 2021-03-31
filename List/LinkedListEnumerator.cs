using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class LinkedListEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private Node<T> _current;
        private Node<T> _root;
        
        public T Current
        {
            get 
            {
                if (_current == null)
                {
                    throw new InvalidOperationException();
                }

                return _current.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _current;
            }
        }

        public LinkedListEnumerator(Node<T> current)
        {
            _current = current;
            _root = _current;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            bool isMove = false;

            if(!(_current.Next is null))
            {
                _current = _current.Next;
                isMove = true;    
            }

            return isMove;
        }

        public void Reset()
        {
            _current = _root;
        }
    }
}
