using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class DLNode<T>
    {
        public T Value { get; set; }
        public DLNode<T> Previous { get; set; }
        public DLNode<T> Next { get; set; }

        public DLNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
