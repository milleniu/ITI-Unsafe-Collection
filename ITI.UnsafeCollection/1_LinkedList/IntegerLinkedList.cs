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

        public void Add( int value )
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
    }
}
