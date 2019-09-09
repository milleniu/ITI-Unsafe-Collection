using System;
using FluentAssertions;
using ITI.UnsafeCollection._1_LinkedList;
using NUnit.Framework;

namespace ITI.UnsafeCollection.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void new_node_has_value_and_next_pointer_to_zero()
        {
            const int value = 3712;
            var node = new Node<int>( value );
            node.Value.Should().Be( value );
            node.Next.Should().Be( IntPtr.Zero );
        }

        [Test]
        public void linked_list_initialization()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Invoking( sut => sut.First ).Should().Throw<InvalidOperationException>();
            linkedList.Invoking( sut => sut.Last ).Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void can_add_element_to_linked_list()
        {
            var linkedList = new LinkedList<int>();
            const int a = 8, b = 16, c = 32;
            linkedList.Add( a );
            linkedList.Add( b );
            linkedList.Add( c );

            var first = linkedList.First;
            first.Value.Should().Be( a );

            var second = (Node<int>) first.Next;
            second.Value.Should().Be( b );

            var third = (Node<int>) second.Next;
            third.Value.Should().Be( c );

            linkedList.Last.Value.Should().Be( c );
        }

        [Test]
        public void can_remove_element_to_linked_list()
        {
            var linkedList = new LinkedList<int>();
            const int a = 8, b = 16, c = 32;
            linkedList.Add( a );
            linkedList.Add( b );
            linkedList.Add( c );

            linkedList.Remove( c );
            linkedList.Last.Value.Should().Be( (b) );
            linkedList.Remove( b );
            linkedList.Last.Value.Should().Be( (a) );
            linkedList.Remove( a );

            linkedList.Remove( 11 ).Should().Be( (false) );
        }
    }
}
