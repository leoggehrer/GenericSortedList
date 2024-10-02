
using System.Collections;

namespace GenericSortedList.Logic
{
    /// <summary>
    /// Represents a sorted list of items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sorted list. Must implement <see cref="IComparable{T}"/>.</typeparam>
    public class SortedList<T> : ISortedList<T>
            where T : IComparable<T>
    {
        #region embedded types
        /// <summary>
        /// Represents a node in a linked list.
        /// </summary>
        /// <typeparam name="T">The type of the value stored in the node.</typeparam>
        private class Node
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Node{T}"/> class.
            /// </summary>
            /// <param name="value">The value to be stored in the node.</param>
            /// <param name="next">The next node in the linked list, or <c>null</c> if there is no next node.</param>
            /// <summary>
            /// Initializes a new instance of the <see cref="Node{T}"/> class.
            /// </summary>
            /// <param name="value">The value stored in the node.</param>
            /// <param name="next">The next node in the linked list, or <c>null</c> if there is no next node.</param>
            public Node(T value, Node? next)
            {
                Value = value;
                Next = next;
            }
            /// <summary>
            /// Gets or sets the value of the property.
            /// </summary>
            /// <value>
            /// The value of type <typeparamref name="T"/>.
            /// </value>
            /// <summary>
            /// Gets or sets the value of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of the value.</typeparam>
            /// <value>The current value of the property.</value>
            public T Value { get; set; }
            /// <summary>
            /// Gets or sets the next node in the linked structure.
            /// </summary>
            /// <value>
            /// The next <see cref="Node"/> or <c>null</c> if there is no subsequent node.
            /// </value>
            /// <summary>
            /// Gets or sets the next node in the linked list.
            /// </summary>
            /// <value>
            /// The next <see cref="Node"/> instance, or <c>null</c> if there is no next node.
            /// </value>
            public Node? Next { get; set; }
        }
        /// <summary>
        /// Represents an enumerator for a linked list, allowing iteration over the nodes in the list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the linked list.</typeparam>
        private class Enumerator : IEnumerator<T>
        {
            private Node? _head;
            private Node? _current;
            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> class.
            /// </summary>
            /// <param name="head">The head node of the linked list. This can be null if the list is empty.</param>
            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> class.
            /// </summary>
            /// <param name="head">The head node of the linked list, or <c>null</c> if the list is empty.</param>
            public Enumerator(Node? head)
            {
                _head = head;
                _current = null;
            }
            /// <summary>
            /// Gets the current value of the property.
            /// </summary>
            /// <value>
            /// The current value of type <typeparamref name="T"/>.
            /// This value is guaranteed to be non-null.
            /// </value>
            /// <remarks>
            /// The property accesses a backing field (_current) and ensures that it is not null
            /// before returning its value. If _current is null, a <see cref="NullReferenceException"/>
            /// may be thrown.
            /// </remarks>
            /// <summary>
            /// Gets the current value of the property.
            /// </summary>
            /// <value>
            /// The current value of type <typeparamref name="T"/>.
            /// This property will never return null, as it is guaranteed to have a value.
            /// </value>
            public T Current => _current!.Value!;
            /// <summary>
            /// Gets the current element in the collection as an <see cref="object"/>.
            /// </summary>
            /// <remarks>
            /// This property implements the <see cref="IEnumerator.Current"/> interface and returns the current element
            /// of the collection. The value is of type <see cref="object"/> and may need to be cast to the appropriate
            /// type for use.
            /// </remarks>
            /// <summary>
            /// Gets the current element in the collection being iterated over.
            /// </summary>
            /// <remarks>
            /// This property implements the <see cref="IEnumerator.Current"/> interface,
            /// providing access to the current element of the enumerator.
            /// </remarks>
            object IEnumerator.Current => Current;
            /// <summary>
            /// Releases the resources used by the current instance of the class.
            /// </summary>
            /// <remarks>
            /// This method should be called when the object is no longer needed to free up resources.
            /// </remarks>
            /// <summary>
            /// Releases all resources used by the current instance of the class.
            /// </summary>
            /// <remarks>
            /// This method is called to perform cleanup operations before the object is reclaimed by garbage collection.
            /// It is important to call this method to free up unmanaged resources and other resources that are not
            /// handled by the garbage collector.
            /// </remarks>
            public void Dispose() { }
            /// <summary>
            /// Advances the enumerator to the next element in the collection.
            /// </summary>
            /// <returns>
            /// <c>true</c> if the enumerator was successfully advanced to the next element;
            /// <c>false</c> if the enumerator has passed the end of the collection.
            /// </returns>
            /// <remarks>
            /// If the enumerator is at the start (i.e., before the first element),
            /// it will move to the first element on the first call.
            /// If there are no more elements in the collection,
            /// the method will return <c>false</c>.
            /// </remarks>
            /// <summary>
            /// Advances the enumerator to the next element in the collection.
            /// </summary>
            /// <returns>
            /// <c>true</c> if the enumerator was successfully advanced to the next element;
            /// <c>false</c> if the enumerator has passed the end of the collection.
            /// </returns>
            /// <remarks>
            /// This method initializes the enumerator to the first element of the collection
            /// when called for the first time, and continues to move to the next element
            /// with each subsequent call. If there are no more elements, it returns <c>false</c>.
            /// </remarks>
            public bool MoveNext()
            {
                if (_current == null)
                {
                    _current = _head;
                }
                else
                {
                    _current = _current.Next;
                }
                return _current != null;
            }
            /// <summary>
            /// Resets the current state by setting the current object to null.
            /// </summary>
            /// <summary>
            /// Resets the current state by setting the <c>_current</c> field to <c>null</c>.
            /// </summary>
            public void Reset()
            {
                _current = null;
            }
        }
        #endregion embedded types

        #region fields
        private Node? _head = null;
        #endregion fields

        /// <summary>
        /// Gets the number of nodes in the linked list.
        /// </summary>
        /// <value>
        /// An integer representing the total count of nodes.
        /// Returns 0 if the list is empty.
        /// </value>
        public int Count
        {
            get
            {
                int result = 0;
                Node? run = _head;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }
        /// <summary>
        /// Gets or sets the value at the specified index.
        /// </summary>
        /// <param name="index">The specified index.</param>
        /// <returns>The value on the specified index.</returns>
        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                Node? run = _head;
                for (int i = 0; i < index; i++)
                {
                    run = run!.Next;
                }
                return run!.Value!;
            }
            set
            {
                CheckIndex(index);

                Node? run = _head;
                for (int i = 0; i < index; i++)
                {
                    run = run!.Next;
                }
                Remove(run!.Value);
                Add(value);
            }
        }

        /// <summary>
        /// Checks if the specified index is within the valid range.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the index is less than zero or greater than or equal to the total count.
        /// </exception>
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Clears the contents of the data structure by setting the head to null.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        /// <summary>
        /// Adds an item to the collection in a sorted order.
        /// </summary>
        /// <param name="item">The item to be added to the collection. This cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="item"/> is null.</exception>
        /// <remarks>
        /// This method maintains the sorted order of the collection by inserting the item in its correct position.
        /// If the collection is empty, the item becomes the head of the list.
        /// </remarks>
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (_head == null)      // Insert at the head
            {
                _head = new Node(item, _head);
            }
            else                    // Insert in the middle or at the end
            {
                Node? run = _head;
                Node? prev = null;

                while (run != null && run.Value!.CompareTo(item) < 0)
                {
                    prev = run;
                    run = run.Next;
                }
                if (prev == null)   // Insert at the head
                {
                    _head = new Node(item, _head);
                }
                else                // Insert in the middle or at the end
                {
                    prev.Next = new Node(item, run);
                }
            }
        }
        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="item">The item to be removed from the collection.</param>
        /// <remarks>
        /// This method searches for the first occurrence of the specified item in the collection.
        /// If the item is found, it is removed from the linked list. If the item is not found,
        /// the collection remains unchanged. If the item to be removed is the head of the list,
        /// the head is updated accordingly.
        /// </remarks>
        public void Remove(T item)
        {
            Node? run = _head;
            Node? prev = null;

            while (run != null && run.Value!.CompareTo(item) != 0)
            {
                prev = run;
                run = run.Next;
            }
            if (run != null)
            {
                if (prev == null)
                {
                    _head = run.Next;
                }
                else
                {
                    prev.Next = run.Next;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_head);
        }
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_head);
        }
    }
}
