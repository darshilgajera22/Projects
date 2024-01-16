/**
 * COMP-10205 - Starting code for Assignment # 2
 *
 */
/**
 * Assignment #2 (To Sort or not to Sort)
 * COMP-10205 - Data Structures and algorithms
 * @author Darshil Gajera (000867069)
 */

import java.util.Arrays;
import java.util.Random;

/**
 * ------------------- PART C -----------------------
 *
 * ------------------ A -------------------------
 * 1) cSort
 * 2) bSort
 * 3) gSort
 * 4) fSort
 * 5) aSort
 * 6) dSort
 * 7) eSort
 * ----------------- B --------------------------
 * 1) gSort
 * 2) aSort
 * 3) fSort
 * 4) dSort
 * 5) cSort
 * 6) bSort
 * 7) eSort
 * ---------------- C -------------------
 * At 50000 elements bSort & cSort has the lowest basic instruction time than other algorithms.
 * bSort & cSort are more efficient to compare elements while sorting
 *
 * ---------------- D ------------------------------
 *      Sort Algorithm Identification
 * ==========================================================
 *    Sort       Sort Algorithm      Big O       Big O
 *  Algorithm        Name            (time)      (space)
 * -----------------------------------------------------------
 * aSort         Quick Sort         O(nlogn)    O(1)
 * bSort         Selection Sort     O(n^2)      O(1)
 * cSort         Insertion Sort     O(n^2)      O(1)
 * dSort         Merge Sort         O(nlogn)    O(n)
 * eSort         Bubble Sort        O(n^2)      O(1)
 * fSort         Shell Sort         O(nlogn)    O(1)
 * gSort         Radix Sort         O(n)        O(r) r = range
 *
 *
 */


/**
 * interface used so we can pass method references to Performance method
 */
interface sortingMethodCollection {
    // to call particular sort method
    int callSort(int[] data);

    // to know method name
    String getSortName();
}

/**
 * All methods are static to the class - functional style
 *
 * @author mark.yendt
 */
public class Assignment2_Start {

    static long qSortCompares = 0;  // Left in for comparison purposes only

    /**
     * The swap method swaps the contents of two elements in an int array.
     *
     * @param array where elements are to be swapped.
     * @param a     The subscript of the first element.
     * @param b     The subscript of the second element.
     */
    private static void swap(int[] array, int a, int b) {
        int temp;

        temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }

    //------------------- e Sort -------------------------
    public static long eSort(int[] array) {
        int lastPos;     // Position of last element to compare
        int index;       // Index of an element to compare
        int countCompare = 0;
        // The outer loop positions lastPos at the last element
        // to compare during each pass through the array. Initially
        // lastPos is the index of the last element in the array.
        // During each iteration, it is decreased by one.
        for (lastPos = array.length - 1; lastPos >= 0; lastPos--) {
            // The inner loop steps through the array, comparing
            // each element with its neighbor. All of the elements
            // from index 0 thrugh lastPos are involved in the
            // comparison. If two elements are out of order, they
            // are swapped.
            for (index = 0; index <= lastPos - 1; index++) {
                // Compare an element with its neighbor.
                countCompare++;
                if (array[index] > array[index + 1]) {
                    // Swap the two elements.
                    swap(array, index, index + 1);
                }
            }
        }
        return countCompare;
    }

    /**
     * ------------- cSort -------------------------------------------------
     */
    public static long cSort(int[] array) {
        int unsortedValue;  // The first unsorted value
        int scan;           // Used to scan the array
        int countComparison = 0;

        // The outer loop steps the index variable through
        // each subscript in the array, starting at 1. The portion of
        // the array containing element 0  by itself is already sorted.
        for (int index = 1; index < array.length; index++) {
            // The first element outside the sorted portion is
            // array[index]. Store the value of this element
            // in unsortedValue.
            unsortedValue = array[index];

            // Start scan at the subscript of the first element
            // outside the sorted part.
            scan = index;

            // Move the first element in the still unsorted part
            // into its proper position within the sorted part.
            while (scan > 0 && array[scan - 1] > unsortedValue) {
                countComparison++;
                array[scan] = array[scan - 1];
                scan--;
            }

            // Insert the unsorted value in its proper position
            // within the sorted subset.
            array[scan] = unsortedValue;
        }
        return countComparison;
    }

    /**
     * ------------------- b Sort ---------------------------------------------
     */
    public static long bSort(int[] array) {

        int countComparison = 0;
        int startScan;   // Starting position of the scan
        int index;       // To hold a subscript value
        int minIndex;    // Element with smallest value in the scan
        int minValue;    // The smallest value found in the scan

        // The outer loop iterates once for each element in the
        // array. The startScan variable marks the position where
        // the scan should begin.
        for (startScan = 0; startScan < (array.length - 1); startScan++) {
            // Assume the first element in the scannable area
            // is the smallest value.
            minIndex = startScan;
            minValue = array[startScan];

            // Scan the array, starting at the 2nd element in
            // the scannable area. We are looking for the smallest
            // value in the scannable area.
            for (index = startScan + 1; index < array.length; index++) {
                countComparison++;
                if (array[index] < minValue) {
                    //countComparison++;
                    minValue = array[index];
                    minIndex = index;
                }
            }

            // Swap the element with the smallest value
            // with the first element in the scannable area.
            array[minIndex] = array[startScan];
            array[startScan] = minValue;
        }
        return countComparison;
    }

    /**
     * -------------------------- f Sort --------------------------------
     */

    public static long fSort(int array[]) {
        int n = array.length;
        int countCompare = 0;
        for (int gap = n / 2; gap > 0; gap /= 2) {
            for (int i = gap; i < n; i++) {
                int key = array[i];
                int j = i;

                while (j >= gap && array[j - gap] > key) {
                    countCompare++;
                    array[j] = array[j - gap];
                    j -= gap;
                }
                array[j] = key;
            }
        }
        return countCompare;
    }

    /**
     * ---------------------------- g Sort ---------------------------------------
     */

    public static long gSort(int array[]) {
        int count = 0;

        int min = array[0];
        int max = array[0];
        for (int i = 1; i < array.length; i++) {
            if (array[i] < min)
                min = array[i];
            else if (array[i] > max)
                max = array[i];
        }
        int b[] = new int[max - min + 1];
        for (int i = 0; i < array.length; i++)
            b[array[i] - min]++;

        for (int i = 0; i < b.length; i++)
            for (int j = 0; j < b[i]; j++) {
                array[count++] = i + min;
            }

        return count;
    }


    /**
     * The non-recursive Quicksort - manages first call
     *
     * @param array an unsorted array that will be sorted upon method completion
     * @return
     */
    public static long aSort(int array[]) {
        qSortCompares = 0;
        return doASort(array, 0, array.length - 1, 0);
    }

    /**
     * The doQuickSort method uses the QuickSort algorithm to sort an int array.
     *
     * @param array The array to sort.
     * @param start The starting subscript of the list to sort
     * @param end   The ending subscript of the list to sort
     */
    private static long doASort(int array[], int start, int end, long numberOfCompares) {
        int pivotPoint;

        if (start < end) {
            // Get the pivot point.
            pivotPoint = part1(array, start, end);
            // Note - only one +/=
            numberOfCompares += (end - start);
            // Sort the first sub list.
            numberOfCompares = doASort(array, start, pivotPoint - 1, numberOfCompares);

            // Sort the second sub list.
            numberOfCompares = doASort(array, pivotPoint + 1, end, numberOfCompares);
        }
        return numberOfCompares;
    }

    /**
     * The partition method selects a pivot value in an array and arranges the
     * array into two sub lists. All the values less than the pivot will be
     * stored in the left sub list and all the values greater than or equal to
     * the pivot will be stored in the right sub list.
     *
     * @param array The array to partition.
     * @param start The starting subscript of the area to partition.
     * @param end   The ending subscript of the area to partition.
     * @return The subscript of the pivot value.
     */
    private static int part1(int array[], int start, int end) {
        int pivotValue;    // To hold the pivot value
        int endOfLeftList; // Last element in the left sub list.
        int mid;           // To hold the mid-point subscript

        // see http://www.cs.cmu.edu/~fp/courses/15122-s11/lectures/08-qsort.pdf
        // for discussion of middle point - This improves the almost sorted cases
        // of using quicksort
        // Find the subscript of the middle element.
        // This will be our pivot value.
        mid = (start + end) / 2;
        // mid = start;

        // Swap the middle element with the first element.
        // This moves the pivot value to the start of
        // the list.
        swap(array, start, mid);

        // Save the pivot value for comparisons.
        pivotValue = array[start];

        // For now, the end of the left sub list is
        // the first element.
        endOfLeftList = start;

        // Scan the entire list and move any values that
        // are less than the pivot value to the left
        // sub list.
        for (int scan = start + 1; scan <= end; scan++) {
            qSortCompares++;
            if (array[scan] < pivotValue) {
                endOfLeftList++;
                swap(array, endOfLeftList, scan);
            }
        }

        // Move the pivot value to end of the
        // left sub list.
        swap(array, start, endOfLeftList);

        // Return the subscript of the pivot value.
        return endOfLeftList;
    }

    public static long dSort(int inputArray[]) {
        int length = inputArray.length;
        // Create array only once for merging
        int[] workingArray = new int[inputArray.length];
        long count = 0;
        count = doDSort(inputArray, workingArray, 0, length - 1, count);
        return count;
    }

    private static long doDSort(int[] inputArray, int[] workingArray, int lowerIndex, int higherIndex, long count) {
        if (lowerIndex < higherIndex) {
            int middle = lowerIndex + (higherIndex - lowerIndex) / 2;
            // Below step sorts the left side of the array
            count = doDSort(inputArray, workingArray, lowerIndex, middle, count);
            // Below step sorts the right side of the array
            count = doDSort(inputArray, workingArray, middle + 1, higherIndex, count);
            // Now merge both sides
            count += part2(inputArray, workingArray, lowerIndex, middle, higherIndex);
        }
        return count;
    }

    private static long part2(int[] inputArray, int[] workingArray, int lowerIndex, int middle, int higherIndex) {

        long count = 0;
        for (int i = lowerIndex; i <= higherIndex; i++) {
            workingArray[i] = inputArray[i];
        }
        int i1 = lowerIndex;
        int i2 = middle + 1;
        int newIndex = lowerIndex;

        while (i1 <= middle && i2 <= higherIndex) {
            if (workingArray[i1] <= workingArray[i2]) {
                inputArray[newIndex] = workingArray[i1];
                i1++;
            } else {
                inputArray[newIndex] = workingArray[i2];
                i2++;
            }
            count++;
            newIndex++;
        }
        while (i1 <= middle) {
            inputArray[newIndex] = workingArray[i1];
            newIndex++;
            i1++;
            count++;
        }
        return count;
    }


    /**
     * A demonstration of recursive counting in a Binary Search
     *
     * @param array - array to search
     * @param low   - the low index - set to 0 to search whiole array
     * @param high  - set to length of array to search whole array
     * @param value - item to search for
     * @param count - Used in recursion to accumulate the number of comparisons made (set to 0 on initial call)
     * @return
     */
    private static int[] binarySearchR(int[] array, int low, int high, int value, int count) {
        int middle;     // Mid point of search

        // Test for the base case where the value is not found.
        if (low > high)
            return new int[]{-1, count};

        // Calculate the middle position.
        middle = (low + high) / 2;

        // Search for the value.
        if (array[middle] == value)
            // Found match return the index
            return new int[]{middle, count};
        else if (value > array[middle])
            // Recursive method call here (Upper half of remaining data)
            return binarySearchR(array, middle + 1, high, value, count + 1);
        else
            // Recursive method call here (Lower half of remaining data)
            return binarySearchR(array, low, middle - 1, value, count + 1);
    }


    /**
     * The main method will run through all of the Sorts for the prescribed sizes and produce output for parts A and B
     * <p>
     * Part C should be answered at the VERY TOP of the code in a comment
     * *
     */
    public static void main(String[] args) {
        // creating random numbers dataset of 20,100,10000,50000, 100000
        int[] randomNumbersData20 = generateRandomNumbers(20);
        int[] randomNumbersData100 = generateRandomNumbers(100);
        int[] randomNumbersData10000 = generateRandomNumbers(10000);
        int[] randomNumbersData50000 = generateRandomNumbers(50000);
        int[] randomNumbersData100000 = generateRandomNumbers(100000);


        // collection of methods
        sortingMethodCollection[] sortingMethods = {aSort, bSort, cSort, dSort, eSort, fSort, gSort};


        // ------------ PART A ----------------------
        System.out.println("\n ----------------- PART A ---------------");

        // table for 20 dataset
        displayTableHeadings(20);
        // calling every method
        for (sortingMethodCollection method : sortingMethods) {
            measureAlgorithmsPerformance(randomNumbersData20, method);
        }

        // table for 100 dataset
        displayTableHeadings(100);
        // calling every method
        for (sortingMethodCollection method : sortingMethods) {
            measureAlgorithmsPerformance(randomNumbersData100, method);
        }

        // table for 10000 dataset
        displayTableHeadings(10000);
        // calling every method
        for (sortingMethodCollection method : sortingMethods) {
            measureAlgorithmsPerformance(randomNumbersData10000, method);
        }

        // table for 50000 dataset
        displayTableHeadings(50000);
        // calling every method
        for (sortingMethodCollection method : sortingMethods) {
            measureAlgorithmsPerformance(randomNumbersData50000, method);
        }


        // ------------ PART B ----------------------
        System.out.println("\n\n\n ----------------- PART B ---------------");

        // linear search
        // to calculate time
        long startTime, totalTimeLinear, totalTimeBinary;
        long countComparison = 0; // to count comparison
        startTime = System.nanoTime();
        // calling linear search method to search value -1
        countComparison = linearSearch(Arrays.copyOf(randomNumbersData100000, randomNumbersData100000.length), -1);
        totalTimeLinear = System.nanoTime() - startTime;
        System.out.println("Linear Search:");
        System.out.println("Time Taken: " + totalTimeLinear + " ns");
        System.out.println("Comparison: " + countComparison);


        // binary search
        // copying array
        int[] binarySorted = Arrays.copyOf(randomNumbersData100000, randomNumbersData100000.length);
        startTime = System.nanoTime();
        int countComparisongSort = (int) dSort(binarySorted); // sorting array using dSort
        // binarySearch to find value -1
        int[] comparisonBinary = binarySearchR(binarySorted, 0, randomNumbersData100000.length, -1, 0);
        totalTimeBinary = System.nanoTime() - startTime;
        System.out.println("\nBinary Search (after sorting):");
        System.out.println("Time Taken: " + totalTimeBinary + " ns");
        System.out.println("Comparison: " + comparisonBinary[1] + countComparisongSort);

        // calculating number of linear search requires
        int linearSearchingToJustifySortingDataFirst = (int) (totalTimeBinary / totalTimeLinear);

        System.out.println("\nNumber of Linear searches requires to justify sorting data first: " + linearSearchingToJustifySortingDataFirst);
        System.out.println("--------------------------------------------------------------------------------");
    }


    /**
     * to do linear search
     * @param randomNumbersData100000  array of 100000 elements
     * @param value the value to find
     * @return comparisons that has been done to find value
     */
    public static long linearSearch(int[] randomNumbersData100000, int value) {
        long countComparison = 0;
        for (int randomNumber : randomNumbersData100000) {
            countComparison++;
            // comparing 1 element with the value
            if (randomNumber == value) {
                break;
            }
        }
        return countComparison;
    }

    /**
     * to print table heading
     * @param dataSet array size
     */
    public static void displayTableHeadings(int dataSet) {
        System.out.println("\nComparison for array size of " + dataSet + " (Averaged over 5 runs)");
        System.out.println("================================================================================");
        System.out.printf("Sort Algorithm \t\t");
        System.out.printf("Execution Time (ns) \t\t");
        System.out.printf("Compares \t\t");
        System.out.printf("Basic Step (ns) \t\n");
        System.out.println("--------------------------------------------------------------------------------");
    }

    /**
     * to display every method performance data in table form
     * @param sortName sort name that used to sort data
     * @param executionTime execution time to do sort
     * @param compares number of comparison done in sort
     * @param basicStep executionTime/compares
     */
    private static void displayTableData(String sortName, long executionTime, long compares, double basicStep) {
        // format to print table data with specified width
        String tableFormat = String.format("%-20s %-23d %-15d %.1f", sortName, executionTime, compares, basicStep);
        System.out.println(tableFormat);
    }


    /**
     * to measure algorithms performance through time and comparisons
     * @param randomNumbersData unsorted data in array
     * @param sortingMethod sorting method that is used to sort array
     */
    public static void measureAlgorithmsPerformance(int[] randomNumbersData, sortingMethodCollection sortingMethod) {
        // to measure time and comparisons
        long comparison = 0, avgComparison;
        long startTime, stopTime, timeTaken = 0, avgTimeTaken;
        double basicSteps;

        // calling sorting methods 5 times
        // calling sort method and counting comparison for every call
        for (int i = 0; i < 5; i++) {
            // start time
            startTime = System.nanoTime();
            comparison += sortingMethod.callSort(Arrays.copyOf(randomNumbersData, randomNumbersData.length));
            stopTime = System.nanoTime(); // stop time
            timeTaken += stopTime - startTime; // total time taken to sort
        }

        // taking average of time and comparison
        avgTimeTaken = timeTaken / 5;
        avgComparison = comparison / 5;

        //counting basic steps
        basicSteps = (double) avgTimeTaken / avgComparison;

        // displaying performance data in the table form
        displayTableData(sortingMethod.getSortName(), avgTimeTaken, avgComparison, basicSteps);

    }


    /**
     * Implementing interface methods for aSort
     */
    static sortingMethodCollection aSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) aSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "aSort";
        }
    };


    /**
     * Implementing interface methods for bSort
     */
    static sortingMethodCollection bSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) bSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "bSort";
        }
    };

    /**
     * Implementing interface methods for cSort
     */
    static sortingMethodCollection cSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) cSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "cSort";
        }
    };


    /**
     * Implementing interface methods for dSort
     */
    static sortingMethodCollection dSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) dSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "dSort";
        }
    };


    /**
     * Implementing interface methods for eSort
     */
    static sortingMethodCollection eSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) eSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "eSort";
        }
    };


    /**
     * Implementing interface methods for fSort
     */
    static sortingMethodCollection fSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) fSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "fSort";
        }
    };


    /**
     * Implementing interface methods for gSort
     */
    static sortingMethodCollection gSort = new sortingMethodCollection() {
        /**
         * to call sorting method
         * @param data unsorted data
         * @return comparisons
         */
        @Override
        public int callSort(int[] data) {
            return (int) gSort(data);
        }

        /**
         * for sort name
         * @return sort name
         */
        @Override
        public String getSortName() {
            return "gSort";
        }
    };


    /**
     * to generate random number for any number of data set
     * @param maxRandomNumberLimit  data set limit
     * @return randomNumbers  array of random numbers
     */
    public static int[] generateRandomNumbers(int maxRandomNumberLimit) {
        Random random = new Random(); // to generate numbers
        int[] randomNumbers = new int[maxRandomNumberLimit]; // creating array and initializing with dataset size
        for (int i = 0; i < maxRandomNumberLimit; i++) {
            randomNumbers[i] = random.nextInt(999) + 1;
        }
        return randomNumbers;
    }

}
