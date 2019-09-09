using System;
using System.Collections.Generic;
using System.Threading;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public class LinkedList<T>
    {
        private IntPtr linkedListPtr;

        public Node<T> First => throw new NotImplementedException();

        public Node<T> Last => throw new NotImplementedException();

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
            throw new NotImplementedException();    
        }

        public LinkedList( IEnumerable<T> collection )
        {
            throw new NotImplementedException();
        }

        public void Add( T value )
        {
            throw new NotImplementedException();
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
