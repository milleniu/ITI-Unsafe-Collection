using System.Runtime.InteropServices;

namespace ITI.UnsafeCollection._1_LinkedList
{
    public unsafe struct Node
    {
        public int Value { get; set; }
        public Node* Next { get; set; }

        private Node( int value )
        {
            Value = value;
            Next = null;
        }

        public static Node* NewPinnedNode( int value )
        {
            var node = new Node( value );
            var handle = GCHandle.Alloc( node, GCHandleType.Pinned );
            return (Node*)handle.AddrOfPinnedObject().ToPointer();
        }
    }
}
