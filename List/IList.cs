using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList<T> : IEnumerable
    {
        public T this[int index] { get; set; }

        public void Add(T value);

        public void AddAtFirst(T value);

        public void AddAt(int index, T value);

        void AddList(IList<T> linkedList);

        void AddListAtFirst(IList<T> linkedList);

        void AddListAt(int index, IList<T> linkedList);

        public void Remove();

        public void RemoveAtFirst();

        public void RemoveAt(int index);

        public void RemoveRange(int count);

        public void RemoveRangeAtFirst(int count);

        public void RemoveRangeAt(int index, int count);

        public int RemoveByValue(T value);

        public int RemoveAllByValue(T value);

        public void Reverse();

        public int GetIndexByValue(T value);

        public int GetIndexOfMax();

        public int GetIndexOfMin();

        public T GetMax();

        public T GetMin();

        public void Sort(bool isAisAscending = true);
    }
}
