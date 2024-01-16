/**
 * COMP10205 - Lab#4 Starting Code
 */


/***
 * 1) There is remarkable difference between adding elements in to the linked list and array list.
 *    Linked list has time complexity O(n) for the worst case, because it has to traverse through entire list to find correct position for the element.
 *    Array list has also time complexity O(n^2), because arraylist insert element on particular index and we are also sorting arraylist while adding, so it has to shift all elements of the arraylist that increase the overall time complexity.
 *    Overall, sorted linked list performs well as compare to arraylist, because it does not require to shift elements to manage sorting order.
 *
 *
 * 2) There is significant difference between removing elements from the linked list and array list.
 *    Linked list has time complexity to removing element is O(n) for the worst case, because it has to find a particular node and change the reference.
 *    Array list has time complexity to removing element is O(n) for the worst case, because it only requires index and shift the all elements.
 *    Overall, arraylist performs well as compare to linked list, because it does not require to traverse to all elements to find particular element to remove.
 *
 *
 * 3) I think that if we requires frequent sorted insertion, memory efficiency and need to maintain sorted order, than linkedlist is a better option.
 *    However, arraylist provides simplicity of use, it has better removing performance and, it give frequent random access.
 *
 * @author Darshil Gajera, 000867069
 */



import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;
import java.util.Scanner;

public class Assignment4
{
  public static void main(String[] args)
  {
    final int NUMBER_OF_NAMES = 18756;
    final String filename = "src/bnames.txt";
    final String[] names = new String[NUMBER_OF_NAMES];
    
     // May be useful for selecting random words to remove
    Random random = new Random(); 
    
    // Read in all of the names 
    try {
      Scanner fin = new Scanner(new File(filename));
      for (int i=0; i<NUMBER_OF_NAMES; i++)
          names[i] = fin.next();
      fin.close();
    } catch (FileNotFoundException e) {
      System.out.println("Exception caught: " + e.getMessage());
      System.exit(-1);
    }
 
    // Use the system to build the linked List
    ArrayList<String> arrayList_String = new ArrayList<>();
    ArrayList<Integer> arrayList_Integer = new ArrayList<>();

    System.out.println("\n-------------- Adding elemetns in to collections ------------");
    // 1. Create the linkedList and add all items in Array
    SortedLinkedList<String> linkedList_String = new SortedLinkedList<>();
    long start = System.nanoTime();
    for (int i=0; i<NUMBER_OF_NAMES;i++){
      linkedList_String.add(names[i]);
    }
    System.out.printf("The time required to add %d elements to a Linked List = %d us\n", NUMBER_OF_NAMES, (System.nanoTime() - start) / 1000);

    // adding items in arraylist string and measuring time
    start = System.nanoTime();
    for (int i=0; i<NUMBER_OF_NAMES;i++){
      arrayList_String.add(names[i]);
      Collections.sort(arrayList_String); // sorting arraylist string
    }
    long stopTime = (System.nanoTime() - start)/1000;
    System.out.printf("The time required to add %d elements to an ArrayList String = %d us\n", NUMBER_OF_NAMES, stopTime);

    // adding items in arraylist integer and measuring time
    System.out.println("\n\n---------- ArrayList Integer Size ------------");
    for (int i=0;i<NUMBER_OF_NAMES;i++){
      arrayList_Integer.add(random.nextInt(1000) + 1);
      Collections.sort(arrayList_Integer); // sorting arraylist integer
    }
    System.out.println("Array List Integer size is " + arrayList_Integer.size());


    System.out.println("\n\n--------- Removing half elements --------");
    // 2. Remove half the items and time the code.
    // interate through half size of linkedlist
      start = System.nanoTime();
      for (int i=0;i<NUMBER_OF_NAMES/2;i++){
        int randIndex = random.nextInt(linkedList_String.size()); // getting random index
        String name = names[randIndex]; // getting name as per index
        linkedList_String.remove(name); // removing name
      }
      stopTime = (System.nanoTime() - start)/1000;
    System.out.println("Time taken by linked list to remove half elements is " + stopTime);

    // interate through half size of arraylist
    start = System.nanoTime();
    for (int i=0;i<NUMBER_OF_NAMES/2;i++){
      int randIndex = random.nextInt(arrayList_String.size());
      arrayList_String.remove(randIndex); // removing element
    }
    stopTime = (System.nanoTime() - start)/1000;
    System.out.println("Time taken by array list to remove half element is " + stopTime);

  }

}
