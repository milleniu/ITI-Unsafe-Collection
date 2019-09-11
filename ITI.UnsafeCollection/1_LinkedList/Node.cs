using System;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public unsafe struct Node
    {
        public int Value { get; set; }
        public Node* Next { get; set; }

        private Node( int value )
        {
            throw new NotImplementedException();
        }

        public static Node* NewPinnedNode( int value )
        {
            throw new NotImplementedException();
        }

    }
}
