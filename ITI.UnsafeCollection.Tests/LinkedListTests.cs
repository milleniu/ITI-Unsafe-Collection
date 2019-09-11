using System;
using System.Text;
using FluentAssertions;
using ITI.UnsafeCollection._1_LinkedList;
using NUnit.Framework;

namespace ITI.UnsafeCollection.Tests
{
    [TestFixture]
    public unsafe class LinkedListTests
    {
        [Test]
        public void new_node_has_value_and_next_pointer_to_zero()
        {
            const int value = 3712;
            var ptr = Node.NewPinnedNode( value );
            ptr->Value.Should().Be( value );
            (ptr->Next == null).Should().BeTrue();
        }

        [Test]
        public void linked_list_initialization()
        {
            var linkedList = new IntegerLinkedList();
            (linkedList.First == null).Should().BeTrue();
            (linkedList.Last == null).Should().BeTrue();
        }

        [Test]
        public void can_add_element_to_linked_list()
        {
            var linkedList = new IntegerLinkedList();
            const int a = 8, b = 16, c = 32;
            linkedList.Add( a );
            linkedList.Add( b );
            linkedList.Add( c );

            var first = linkedList.First;
            first->Value.Should().Be( a );

            var second = first->Next;
            second->Value.Should().Be( b );

            var third = second->Next;
            third->Value.Should().Be( c );

            linkedList.Last->Value.Should().Be( c );
        }

        [Test]
        public void can_remove_element_to_linked_list()
        {
            const int a = 8, b = 16, c = 32, d = 64, e = 128;
            var linkedList = new IntegerLinkedList( new[] { a, b, c, d, e } );

            linkedList.Remove( c ).Should().BeTrue();
            linkedList.First->Value.Should().Be( a );
            linkedList.Last->Value.Should().Be( e );

            linkedList.Remove( a ).Should().BeTrue();
            linkedList.First->Value.Should().Be( b );
            linkedList.Last->Value.Should().Be( e );

            linkedList.Remove( e ).Should().BeTrue();
            linkedList.First->Value.Should().Be( b );
            linkedList.Last->Value.Should().Be( d );
        }

        [Test]
        public void removing_non_contained_element_returns_false()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Remove( -1 ).Should().BeFalse();
        }

        [Test]
        public void removing_the_single_element_from_list_set_first_and_last_to_null()
        {
            const int value = 42;
            var linkedList = new IntegerLinkedList( new[] { value } );
            linkedList.Remove( value ).Should().BeTrue();
            (linkedList.First == null).Should().BeTrue();
            (linkedList.Last == null).Should().BeTrue();
        }

        [Test]
        public void count_returns_the_number_of_nodes()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Count().Should().Be( 3 );

            linkedList.First->Next = linkedList.Last;
            linkedList.Count().Should().Be( 2 );

            linkedList.Remove( 1 );
            linkedList.Count().Should().Be( 1 );

            linkedList.Add( 4 );
            linkedList.Count().Should().Be( 2 );

            linkedList.Remove( 3 );
            linkedList.Remove( 4 );
            linkedList.Count().Should().Be( 0 );
        }

        [Test]
        public void read_and_write_with_accessor()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Invoking( sut => sut[ -1 ] ).Should().Throw<ArgumentException>();

            linkedList[ 0 ].Should().Be( 1 );
            linkedList[ 1 ].Should().Be( 2 );
            linkedList[ 2 ].Should().Be( 3 );

            linkedList[ 1 ] = 4;
            linkedList[ 0 ].Should().Be( 1 );
            linkedList[ 1 ].Should().Be( 4 );
            linkedList[ 2 ].Should().Be( 3 );

            linkedList.Invoking( sut => sut[ 4 ] ).Should().Throw<ArgumentOutOfRangeException>();

            linkedList.Remove( 1 );
            linkedList.Remove( 4 );
            linkedList.Remove( 3 );

            linkedList.Invoking( sut => sut[ 0 ] ).Should().Throw<InvalidOperationException>();
        }
    }
}
