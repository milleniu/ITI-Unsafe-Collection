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
                AddLast( value );
        }

        public void Clear()
        {
            First = null;
            Last = null;
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

        public void AddLast( Node* ptr )
        {
            throw new NotImplementedException();
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
