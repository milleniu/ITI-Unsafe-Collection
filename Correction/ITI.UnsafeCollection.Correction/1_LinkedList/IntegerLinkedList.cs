using System;
using System.Collections.Generic;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public unsafe class IntegerLinkedList
    {
        public Node* First { get; private set; } = null;
        public Node* Last { get; private set; } = null;

        public int this[ int i ]
        {
            get
            {
                if (i < 0) throw new ArgumentException();
                if (First == null) throw new InvalidOperationException();

                var count = 0;
                var current = First;

                while (current != null)
                {
                    if (count == i) return current->Value;
                    current = current->Next;
                    count++;
                }

                throw new ArgumentOutOfRangeException();

            }
            set 
            {
                if (i < 0) throw new ArgumentException();
                if (First == null) throw new InvalidOperationException();

                var count = 0;
                var current = First;

                while (current != null)
                {
                    if (count == i)
                    {
                        current->Value = value;
                        return;
                    };
                    current = current->Next;
                    count++;
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public IntegerLinkedList() { }

        public IntegerLinkedList( IEnumerable<int> collection )
        {
            foreach( var value in collection )
                Add( value );
        }

        public void Clear()
        {
            First = null;
            Last = null;
        }

        public void Add( int value )
        {
            if( First == null )
            {
                First = Node.NewPinnedNode( value );
                Last = First;
            }
            else
            {
                Last->Next = Node.NewPinnedNode( value );
                Last = Last->Next;
            }
        }

        public bool Remove( int value )
        {
            if( First == null ) return false;

            if( First->Value == value )
            {
                First = First->Next;
                if( First == null ) Last = null;
                return true;
            }

            var last = First;
            var current = First;

            while( (current = current->Next) != null )
            {
                if( current->Value == value )
                {
                    last->Next = current->Next;
                    if( last->Next == null ) Last = last;
                    return true;
                }

                last = current;
            }
            return false;
        }

        public int Count()
        {
            var count = 0;
            var current = First;

            while( current != null)
            {
                count++;
                current = current->Next;
            }

            return count;
        }
    }
}
