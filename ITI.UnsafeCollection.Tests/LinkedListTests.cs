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
        public void _00_new_node_has_its_value_set_and_next_pointer_set_to_null()
        {
            const int value = 3712;
            var ptr = Node.NewPinnedNode( value );
            ptr->Value.Should().Be( value );
            (ptr->Next == null).Should().BeTrue();
        }

        [Test]
        public void _01_linked_list_initialization()
        {
            var linkedList = new IntegerLinkedList();
            (linkedList.First == null).Should().BeTrue();
            (linkedList.Last == null).Should().BeTrue();
        }

        [Test]
        public void _02_can_add_element_to_linked_list_with_value()
        {
            var linkedList = new IntegerLinkedList();
            const int a = 8, b = 16, c = 32;
            linkedList.AddLast( b );
            linkedList.AddFirst( a );
            linkedList.AddLast( c );

            var first = linkedList.First;
            first->Value.Should().Be( a );

            var second = first->Next;
            second->Value.Should().Be( b );

            var third = second->Next;
            third->Value.Should().Be( c );

            linkedList.Last->Value.Should().Be( c );
        }

        [Test]
        public void _03_can_add_element_to_linked_list_with_ptr()
        {
            var linkedList = new IntegerLinkedList();
            const int a = 8, b = 16, c = 32;
            linkedList.AddLast( Node.NewPinnedNode( b ) );
            linkedList.AddFirst( Node.NewPinnedNode( a ) );
            linkedList.AddLast( Node.NewPinnedNode( c ) );

            var first = linkedList.First;
            first->Value.Should().Be( a );

            var second = first->Next;
            second->Value.Should().Be( b );

            var third = second->Next;
            third->Value.Should().Be( c );

            linkedList.Last->Value.Should().Be( c );
        }

        [Test]
        public void _04_can_remove_element_to_linked_list_with_value()
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
        public void _05_can_remove_element_to_linked_list_with_ptr()
        {
            const int a = 8, b = 16, c = 32, d = 64, e = 128;
            var aPtr = Node.NewPinnedNode( a );
            var bPtr = Node.NewPinnedNode( b );
            var cPtr = Node.NewPinnedNode( c );
            var dPtr = Node.NewPinnedNode( d );
            var ePtr = Node.NewPinnedNode( e );

            var linkedList = new IntegerLinkedList();
            linkedList.AddLast( aPtr );
            linkedList.AddLast( bPtr );
            linkedList.AddLast( cPtr );
            linkedList.AddLast( dPtr );
            linkedList.AddLast( ePtr );

            linkedList.Remove( cPtr ).Should().BeTrue();
            linkedList.First->Value.Should().Be( a );
            linkedList.Last->Value.Should().Be( e );

            linkedList.Remove( aPtr ).Should().BeTrue();
            linkedList.First->Value.Should().Be( b );
            linkedList.Last->Value.Should().Be( e );

            linkedList.Remove( ePtr ).Should().BeTrue();
            linkedList.First->Value.Should().Be( b );
            linkedList.Last->Value.Should().Be( d );
        }

        [Test]
        public void _06_removing_non_contained_element_returns_false()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Remove( -1 ).Should().BeFalse();
        }

        [Test]
        public void _07_removing_the_single_element_from_list_set_first_and_last_to_null()
        {
            const int value = 42;
            var linkedList = new IntegerLinkedList( new[] { value } );
            linkedList.Remove( value ).Should().BeTrue();
            (linkedList.First == null).Should().BeTrue();
            (linkedList.Last == null).Should().BeTrue();
        }

        [Test]
        public void _08_cleared_linked_list_should_be_empty()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Clear();
            (linkedList.First == null).Should().BeTrue();
            (linkedList.Last == null).Should().BeTrue();
            linkedList.Count().Should().Be( 0 );
        }

        [Test]
        public void _09_count_returns_the_number_of_nodes()
        {
            var linkedList = new IntegerLinkedList( new[] { 1, 2, 3 } );
            linkedList.Count().Should().Be( 3 );

            linkedList.First->Next = linkedList.Last;
            linkedList.Count().Should().Be( 2 );

            linkedList.Remove( 1 );
            linkedList.Count().Should().Be( 1 );

            linkedList.AddLast( 4 );
            linkedList.Count().Should().Be( 2 );

            linkedList.Clear();
            linkedList.Count().Should().Be( 0 );
        }

        [Test]
        public void _10_read_and_write_with_accessor()
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

            linkedList.Clear();

            linkedList.Invoking( sut => sut[ 0 ] ).Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void _11_contains_returns_whether_the_value_exists()
        {
            var linkedList = new IntegerLinkedList( new []{ 1, 2, 3 });
            linkedList.Contains( 2 ).Should().BeTrue();
            linkedList.Contains( 4 ).Should().BeFalse();
            linkedList.Contains( 3 ).Should().BeTrue();
        }

        [Test]
        public void _12_find_returns_the_first_occurence_of_the_value()
        {
            const int lookUpValue = 42;
            var nodePtr = Node.NewPinnedNode( lookUpValue );

            var linkedList = new IntegerLinkedList();
            linkedList.AddLast( 3 );
            linkedList.AddLast( 7 );
            linkedList.AddLast( 12 );
            linkedList.AddLast( lookUpValue );

            linkedList.AddFirst( nodePtr );

            (linkedList.Find( lookUpValue ) == nodePtr).Should().BeTrue();
        }

        [Test]
        public void _13_find_last_returns_the_last_occurence_of_the_value()
        {
            const int lookUpValue = 42;
            var nodePtr = Node.NewPinnedNode( lookUpValue );

            var linkedList = new IntegerLinkedList();
            linkedList.AddLast( 3 );
            linkedList.AddLast( lookUpValue );
            linkedList.AddLast( 7 );
            linkedList.AddLast( 12 );
            linkedList.AddLast( nodePtr );

            (linkedList.FindLast( lookUpValue ) == nodePtr).Should().BeTrue();
        }
    }
}
