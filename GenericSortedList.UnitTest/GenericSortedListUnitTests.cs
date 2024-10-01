using GenericSortedList.Logic;

#nullable disable

namespace GenericSortedList.UnitTest
{
    /// <summary>
    /// Unit tests for the <see cref="ISortedList{T}"/> implementation.
    /// This class contains tests to verify the behavior of a generic sorted list,
    /// including adding, removing, and accessing items, as well as ensuring
    /// that the list maintains its sorted order throughout various operations.
    /// </summary>
    [TestClass]
    public class GenericSortedListUnitTests
    {
        private ISortedList<int> sortedList;

        /// <summary>
        /// Initializes the test environment before each test is run.
        /// This method creates a new instance of the <see cref="Logic.SortedList{T}"/> class,
        /// specifically for integers, ensuring a fresh state for each test case.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            sortedList = new Logic.SortedList<int>();
        }

        /// <summary>
        /// Tests that the count of a sorted list is zero when the list is empty.
        /// </summary>
        /// <remarks>
        /// This test method verifies the behavior of the sorted list when it is initialized without any elements.
        /// It asserts that the count property of the sorted list returns zero, indicating that there are no items in the list.
        /// </remarks>
        [TestMethod]
        public void ItShouldReturnZeroCount_GivenAnEmptyList()
        {
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Verifies that the count of items in the sorted list increases by one when an item is added.
        /// </summary>
        /// <remarks>
        /// This test method adds a single item (5) to the sorted list and asserts that the count of the list is now 1.
        /// </remarks>
        [TestMethod]
        public void ItShouldIncreaseCount_GivenAnItemIsAdded()
        {
            sortedList.Add(5);
            Assert.AreEqual(1, sortedList.Count);
        }

        /// <summary>
        /// Tests that the <see cref="SortedList"/> correctly sorts items when multiple items are added.
        /// </summary>
        /// <remarks>
        /// This test method adds three integers (10, 5, and 15) to the <see cref="SortedList"/>
        /// and asserts that they are sorted in ascending order.
        /// The expected order is: 5 at index 0, 10 at index 1, and 15 at index 2.
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown if the items in the <see cref="SortedList"/> are not in the expected order.
        /// </exception>
        [TestMethod]
        public void ItShouldSortItemsCorrectly_GivenMultipleItemsAreAdded()
        {
            sortedList.Add(10);
            sortedList.Add(5);
            sortedList.Add(15);
            Assert.AreEqual(5, sortedList[0]);
            Assert.AreEqual(10, sortedList[1]);
            Assert.AreEqual(15, sortedList[2]);
        }

        /// <summary>
        /// Tests that the count of the sorted list decreases when an item is removed.
        /// </summary>
        /// <remarks>
        /// This test method adds an item to the sorted list and then removes it,
        /// verifying that the count of items in the list is zero after the removal.
        /// </remarks>
        [TestMethod]
        public void ItShouldDecreaseCount_GivenAnItemIsRemoved()
        {
            sortedList.Add(5);
            sortedList.Remove(5);
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Tests the removal of an existing item from a sorted list.
        /// </summary>
        /// <remarks>
        /// This test verifies that when an item is removed from the sorted list,
        /// the count of items in the list is updated correctly, and the remaining
        /// items are in the expected order.
        /// </remarks>
        [TestMethod]
        public void ItShouldRemoveItem_GivenAnExistingItemIsRemoved()
        {
            sortedList.Add(10);
            sortedList.Add(5);
            sortedList.Remove(5);
            Assert.AreEqual(1, sortedList.Count);
            Assert.AreEqual(10, sortedList[0]);
        }

        /// <summary>
        /// Tests that the sorted list maintains the correct order after an item is removed.
        /// </summary>
        /// <remarks>
        /// This test adds three integers to the sorted list, removes one, and then asserts
        /// that the remaining items are in the correct sorted order.
        /// </remarks>
        [TestMethod]
        public void ItShouldSortAfterRemoval_GivenAnItemIsRemoved()
        {
            sortedList.Add(10);
            sortedList.Add(5);
            sortedList.Add(20);
            sortedList.Remove(10);
            Assert.AreEqual(5, sortedList[0]);
            Assert.AreEqual(20, sortedList[1]);
        }

        /// <summary>
        /// Tests that the count of the sorted list is zero after the <see cref="Clear"/> method is called.
        /// </summary>
        /// <remarks>
        /// This test adds two elements to the sorted list, clears the list, and then asserts that the count is zero.
        /// </remarks>
        [TestMethod]
        public void ItShouldReturnZeroCount_GivenClearIsCalled()
        {
            sortedList.Add(5);
            sortedList.Add(10);
            sortedList.Clear();
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Tests that the sorted list returns the correct values when accessed by index.
        /// </summary>
        /// <remarks>
        /// This test adds two integers to the sorted list and asserts that the values
        /// are returned in the correct order when accessed by their respective indices.
        /// </remarks>
        [TestMethod]
        public void ItShouldReturnCorrectValue_GivenIndexIsAccessed()
        {
            sortedList.Add(5);
            sortedList.Add(10);
            Assert.AreEqual(5, sortedList[0]);
            Assert.AreEqual(10, sortedList[1]);
        }

        /// <summary>
        /// Tests that the sorted list updates correctly when an item is set by the indexer.
        /// </summary>
        /// <remarks>
        /// This test method adds two items to the sorted list and then updates the second item using the indexer.
        /// It verifies that the list is sorted correctly after the update.
        /// </remarks>
        [TestMethod]
        public void ItShouldSortAfterUpdate_GivenAnItemIsSetByIndexer()
        {
            sortedList.Add(5);
            sortedList.Add(10);
            sortedList[1] = 1;
            Assert.AreEqual(1, sortedList[0]);
            Assert.AreEqual(5, sortedList[1]);
        }

        /// <summary>
        /// Tests that adding duplicate items to the sorted list keeps both items.
        /// </summary>
        /// <remarks>
        /// This test method verifies that when the same item is added multiple times,
        /// the sorted list retains all instances of that item. It checks that the count
        /// of items in the list is equal to the number of additions and that the items
        /// at the respective indices are equal to the added value.
        /// </remarks>
        [TestMethod]
        public void ItShouldKeepBothItems_GivenDuplicateItemsAreAdded()
        {
            sortedList.Add(5);
            sortedList.Add(5);
            Assert.AreEqual(2, sortedList.Count);
            Assert.AreEqual(5, sortedList[0]);
            Assert.AreEqual(5, sortedList[1]);
        }

        /// <summary>
        /// Tests that removing a non-existent item from the sorted list does not alter the list.
        /// </summary>
        /// <remarks>
        /// This method adds an item to the sorted list and then attempts to remove an item that is not present.
        /// It asserts that the count of the sorted list remains unchanged after the removal operation.
        /// </remarks>
        [TestMethod]
        public void ItShouldDoNothing_GivenANonExistentItemIsRemoved()
        {
            sortedList.Add(5);
            sortedList.Remove(10);  // 10 is not in the list
            Assert.AreEqual(1, sortedList.Count);
        }

        /// <summary>
        /// Tests that calling <see cref="Clear()"/> on an empty <see cref="SortedList{TKey, TValue}"/>
        /// results in the list remaining empty.
        /// </summary>
        /// <remarks>
        /// This test verifies that the count of the sorted list is zero after the <see cref="Clear()"/>
        /// method is invoked on an empty instance of the list.
        /// </remarks>
        [TestMethod]
        public void ItShouldRemainEmpty_GivenClearIsCalledOnAnEmptyList()
        {
            sortedList.Clear();
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Tests that removing an item from an empty list does not change the list.
        /// </summary>
        /// <remarks>
        /// This test verifies that when an item is attempted to be removed from an empty list,
        /// the count of the list remains zero, indicating that no changes were made to the list.
        /// </remarks>
        [TestMethod]
        public void ItShouldDoNothing_GivenAnItemIsRemovedFromAnEmptyList()
        {
            sortedList.Remove(5);  // Remove from empty list
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown when an invalid index is accessed
        /// in the <see cref="SortedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This test method adds an element to the sorted list and then attempts to access an index
        /// that is out of range, ensuring that the appropriate exception is thrown.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the index specified for accessing the sorted list is less than zero or greater than
        /// or equal to the number of elements in the list.
        /// </exception>
        [TestMethod]
        public void ItShouldThrowOutOfRangeException_GivenInvalidIndexIsAccessed()
        {
            sortedList.Add(5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sortedList[1]);
        }

        /// <summary>
        /// Tests that the sorted list correctly sorts negative numbers when they are added.
        /// </summary>
        /// <remarks>
        /// This test method adds a series of integers including negative numbers to the sorted list
        /// and verifies that the elements are sorted in ascending order.
        /// Specifically, it checks that -10 is the first element, -5 is the second, and 10 is the third.
        /// </remarks>
        [TestMethod]
        public void ItShouldSortCorrectly_GivenNegativeNumbersAreAdded()
        {
            sortedList.Add(-5);
            sortedList.Add(10);
            sortedList.Add(-10);
            Assert.AreEqual(-10, sortedList[0]);
            Assert.AreEqual(-5, sortedList[1]);
            Assert.AreEqual(10, sortedList[2]);
        }

        /// <summary>
        /// Tests that the sorted list updates correctly when items are added and removed.
        /// </summary>
        /// <remarks>
        /// This test method adds three integers (5, 10, and 15) to the sorted list,
        /// removes two of them (5 and 10), and then verifies that the count of items
        /// in the list is 1 and that the remaining item is 15.
        /// </remarks>
        [TestMethod]
        public void ItShouldUpdateCorrectly_GivenItemsAreAddedAndRemoved()
        {
            sortedList.Add(5);
            sortedList.Add(10);
            sortedList.Add(15);
            sortedList.Remove(10);
            sortedList.Remove(5);
            Assert.AreEqual(1, sortedList.Count);
            Assert.AreEqual(15, sortedList[0]);
        }

        /// <summary>
        /// Tests that the count of items in the sorted list is zero after all items are removed.
        /// </summary>
        /// <remarks>
        /// This test adds two items to the sorted list, removes both items, and asserts that the count of the list is zero.
        /// </remarks>
        [TestMethod]
        public void ItShouldReturnZeroCount_GivenAllItemsAreRemoved()
        {
            sortedList.Add(10);
            sortedList.Add(20);
            sortedList.Remove(10);
            sortedList.Remove(20);
            Assert.AreEqual(0, sortedList.Count);
        }

        /// <summary>
        /// Tests that the count of the sorted list increases correctly after clearing the list
        /// and adding a new element.
        /// </summary>
        /// <remarks>
        /// This test method first adds an element to the sorted list, then clears the list,
        /// and finally adds a new element. It asserts that the count of the list is 1
        /// and that the newly added element is the first element in the list.
        /// </remarks>
        [TestMethod]
        public void ItShouldIncreaseCount_GivenClearAndAddIsCalled()
        {
            sortedList.Add(5);
            sortedList.Clear();
            sortedList.Add(10);
            Assert.AreEqual(1, sortedList.Count);
            Assert.AreEqual(10, sortedList[0]);
        }

        /// <summary>
        /// Tests that the sorted list correctly maintains order after a series of mixed add and remove operations.
        /// </summary>
        /// <remarks>
        /// This test verifies that after adding the elements 1, 2, and 3, removing the element 2,
        /// and then adding the element 0, the sorted list will contain the correct number of elements
        /// and that those elements are in the expected sorted order.
        /// </remarks>
        [TestMethod]
        public void ItShouldSortCorrectly_GivenMixedAddAndRemoveOperations()
        {
            sortedList.Add(1);
            sortedList.Add(2);
            sortedList.Add(3);
            sortedList.Remove(2);
            sortedList.Add(0);
            Assert.AreEqual(3, sortedList.Count);
            Assert.AreEqual(0, sortedList[0]);
            Assert.AreEqual(1, sortedList[1]);
            Assert.AreEqual(3, sortedList[2]);
        }

        /// <summary>
        /// Tests that the <see cref="SortedList{T}"/> iterates in sorted order when enumeration is called.
        /// </summary>
        /// <remarks>
        /// This test adds three integers to the sorted list: 1, 3, and 2.
        /// It then enumerates through the list and verifies that the items are returned in sorted order.
        /// The expected result is a collection containing the integers 1, 2, and 3.
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown when the actual collection does not match the expected collection.
        /// </exception>
        [TestMethod]
        public void ItShouldIterateInSortedOrder_GivenEnumerationIsCalled()
        {
            sortedList.Add(1);
            sortedList.Add(3);
            sortedList.Add(2);
            var items = new List<int>();
            foreach (var item in sortedList)
            {
                items.Add(item);
            }
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, items);
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentNullException"/> is thrown when a null item is added to the <see cref="SortedList{TKey}"/>.
        /// </summary>
        /// <remarks>
        /// This test verifies that the <see cref="SortedList{TKey}.Add"/> method correctly handles null values
        /// by throwing an <see cref="ArgumentNullException"/> when attempting to add a null key.
        /// </remarks>
        [TestMethod]
        public void ItShouldThrowArgumentNullException_GivenANullItemIsAdded()
        {
            SortedList<string> stringList = new SortedList<string>();

            Assert.ThrowsException<ArgumentNullException>(() => stringList.Add(null));
        }
    }
}