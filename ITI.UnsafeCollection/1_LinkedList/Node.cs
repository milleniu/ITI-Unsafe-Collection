using System;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public struct Node<T>
    {
        public T Value { get; set; }
        public IntPtr Next { get; set; }

        public Node( T value )
        {
            throw new NotImplementedException();
        }

        public static explicit operator Node<T>( IntPtr ptr )
            => throw new NotImplementedException();
    }
}
