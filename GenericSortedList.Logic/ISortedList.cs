namespace GenericSortedList.Logic
{
    /// <summary>
    /// Represents a sorted collection of objects that can be accessed by index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sorted list. Must implement <see cref="IComparable{T}"/>.</typeparam>
    public interface ISortedList<T> : IEnumerable<T>
            where T : IComparable<T>
    {
        /// <summary>
        /// Gets the number of items.
        /// </summary>
        /// <value>
        /// The total count of items.
        /// </value>
        int Count { get; }
        T this[int index] { get; set; }

        /// <summary>
        /// Clears the current collection or data structure, removing all items.
        /// </summary>
        void Clear();
        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <param name="item">The item to be added to the collection.</param>
        /// <remarks>
        /// This method will throw an exception if the item is null or if it cannot be added
        /// to the collection due to constraints such as size limits or duplicate entries.
        /// </remarks>
        void Add(T item);
        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="item">The item to be removed from the collection.</param>
        /// <remarks>
        /// This method will not throw an exception if the item is not found in the collection.
        /// </remarks>
        void Remove(T item);
    }
}
