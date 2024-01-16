
/**
 * Generic Linked List class that always keeps the elements in order 
 * @author mark.yendt
 */
public class SortedLinkedList<T extends Comparable>
{
  /**
   * The Node class stores a list element and a reference to the next node.
   */
  private final class Node<T extends Comparable>
  {
    T value;
    Node next;

    /**
     * Constructor.
     * @param val The element to store in the node.
     * @param n The reference to the successor node.
     */
    Node(T val, Node n)
    {
      value = val;
      next = n;
    }

    /**
     * Constructor.
     *
     * @param val The element to store in the node.
     */
    Node(T val)
    {
      // Call the other (sister) constructor.
      this(val, null);
    }
  }
  private Node first;  // list head

  /**
   * Constructor.
   */
  public SortedLinkedList()
  {
    first = null;
  }

  /**
   * The isEmpty method checks to see if the list is empty.
   *
   * @return true if list is empty, false otherwise.
   */
  public boolean isEmpty()
  {
    return first == null;
  }

  /**
   * The size method returns the length of the list.
   * @return The number of elements in the list.
   */
  public int size()
  {
    int count = 0;
    Node p = first;
    while (p != null) {
      // There is an element at p
      count++;
      p = p.next;
    }
    return count;
  }

  /**
   * The add method adds an element at a position.
   * @param element The element to add to the list in sorted order.
   */
  public void add(T element)
  {
      // node to add
      Node newElement = new Node(element);

      // if list is empty or element is small as compare to first element
      if (first == null || element.compareTo(first.value) <= 0) {
          newElement.next = first; // give refrence of first element to new element
          first = newElement; // making first as new element
      } else {
          Node currNode = first;
          Node prevNode = null;
            // traversing to all node to find correct position
          while (currNode != null && element.compareTo(currNode.value) > 0) {
              prevNode = currNode;
              currNode = currNode.next;
          }

          // changing node reference
          newElement.next = currNode;
          prevNode.next = newElement;
      }
  }

  /**
   * The toString method computes the string representation of the list.
   * @return The string form of the list.
   */
  public String toString()
  {
      String listOfItems = "";

      Node curr = first;
      // traverse thriugh all node
      while (curr != null) {
          // adding items in string
          listOfItems += curr.value + "\n";
          curr = curr.next;
      }
      return listOfItems;
  }

  /**
   * The remove method removes an element.
   * @param element The element to remove.
   * @return true if the remove succeeded, false otherwise.
   */
  public boolean remove(T element)
  {
      Node currNode = first; // getting first node
      Node prevNode = null; // setting previous to null

      // traversing through the every node of the list
      while (currNode != null && !currNode.value.equals(element)) {
          prevNode = currNode; // set current to previous node
          currNode = currNode.next; // current will be the next node
      }


      if (currNode != null) {
          if (prevNode == null) {
              // If the element to remove is in the first node
              first = currNode.next;
          } else {
              prevNode.next = currNode.next;
          }
          return true;
      }
      return false;
  }
}