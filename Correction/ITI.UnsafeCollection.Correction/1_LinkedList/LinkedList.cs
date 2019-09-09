using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public class LinkedList<T> where T : struct
    {
        private IntPtr _firstPtr = IntPtr.Zero;
        private IntPtr _lastPtr = IntPtr.Zero;

        private static int SizeOfNode => Marshal.SizeOf( default( Node<T> ) );

        public Node<T> First => (Node<T>) _firstPtr;
        public Node<T> Last => (Node<T>) _lastPtr;


        public Node<T> this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        
        public LinkedList()
        {
            Console.WriteLine( SizeOfNode );
        }

        public LinkedList( IEnumerable<T> collection )
        {
            throw new NotImplementedException();
        }

        public void Add( T value )
        {
            var node = new Node<T>( value );
            if( _firstPtr != IntPtr.Zero )
            {
                var last = Last;
                last.Next = Marshal.AllocHGlobal( SizeOfNode );
                Marshal.StructureToPtr( node, last.Next, true );
                _lastPtr = last.Next;
            }
            else
            {
                _firstPtr = Marshal.AllocHGlobal( SizeOfNode );
                Marshal.StructureToPtr( node, _firstPtr, true );
                _lastPtr = _firstPtr;
            }
        }

        public bool Remove( T value )
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
