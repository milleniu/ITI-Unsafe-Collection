using System;
using System.Collections.Generic;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public unsafe class IntegerLinkedList
    {
        public Node* First { get; private set; } = null;
        public Node* Last { get; private set; } = null;

        public int this[int i]
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
        
        public IntegerLinkedList()
        {
            throw new NotImplementedException();    
        }

        public IntegerLinkedList( IEnumerable<int> collection )
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void AddFirst( int value )
        {
            throw new NotImplementedException();
        }

        public void AddFirst( Node* ptr )
        {
            throw new NotImplementedException();
        }

        public void AddLast( int value )
        {
            throw new NotImplementedException();
        }

        public void AddLast( Node* ptr )
        {
            throw new NotImplementedException();
        }

        public bool Remove( int value )
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Contains( int i )
        {
            throw new NotImplementedException();
        }

        public Node* Find( int i )
        {
            throw new NotImplementedException();
        }

        public Node* FindLast( int i )
        {
            throw new NotImplementedException();
        }
    }
}
