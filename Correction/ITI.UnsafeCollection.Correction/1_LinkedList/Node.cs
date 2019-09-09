using System;
using System.Runtime.InteropServices;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public struct Node<T>
    {
        public T Value { get; set; }
        public IntPtr Next { get; set; }
        
        public Node( T value )
        {
            Value = value;
            Next = IntPtr.Zero;
        }

        public static explicit operator Node<T>( IntPtr ptr )
            => ptr != IntPtr.Zero
                ? Marshal.PtrToStructure<Node<T>>( ptr )
                : throw new InvalidOperationException( "Node next is not defined." );
    }
}
