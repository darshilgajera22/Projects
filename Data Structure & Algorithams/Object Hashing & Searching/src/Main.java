import java.awt.print.Book;
import java.io.File;
import java.io.IOException;
import java.util.*;
import java.util.Collection;

/***
 * 1) ArrayList Contains method took 19204821 time.
 * 2) ArrayLust BinarySearch method took 114144 time.
 * 3) HashSet method took 18464 time.
 *
 * The contains method does linear search that took highest amount of time because it compares every elements of the collection.
 * Binary search performs well as compare to contains method, because binary search removes half elements each step.
 * Hashset method performs good as compare to other both methods, because it has to directly look in to buckets as per hash code.
 *
 *
 * @author Darshil Gajera, 000867069
 */



public class Main {
    public static void main(String[] args) {

        // Part A
        ArrayList<BookWord> novel = new ArrayList<>(); // contains no repetitive words
        ArrayList<BookWord> dictionary1BookWord = new ArrayList<>(); // contains US dictionary words
        SimpleHashSet<BookWord> dictionary2Hash = new SimpleHashSet<>(); // contains US dictionary words

        // Part B
        ArrayList<BookWord> novel2 = new ArrayList<>(); // contains WarAndPeace novel words

        // getting file
        File US = new File("src/US.txt");
        File WarAndPeace = new File("src/WarAndPeace.txt");

        // regex to remove special characters
        String regEx = "\\.|\\?|\\!|\\s|\"|\\(|\\)|\\,|\\_|\\-|\\:|\\;|\\n";

        try{
            Scanner scanner1 = new Scanner(WarAndPeace); // reading file
            while (scanner1.hasNext()){
                String[] textWords = scanner1.nextLine().split(regEx); // storing all words in a string
                for (String text: textWords) {
                    text = text.toLowerCase(); // un-capitalizing words
                    // removing space and apostrophes
                    if(!text.isEmpty() && !text.contains("'"))
                    {
                        novel2.add(new BookWord(text)); // adding all words of novel
                        boolean textMatch = false;
                        for (BookWord bookWord : novel){
                            // if match found
                            if (bookWord.getText().equals(text)){
                                bookWord.incrementCount(); // increment count for word
                                textMatch = true;
                                break;
                            }
                        }
                        if (!textMatch){
                            novel.add(new BookWord(text)); // if word is not added then add into novel
                        }
                    }
                }
            }
            scanner1.close();
            // reading US dictionary file
            Scanner scanner2 = new Scanner(US);
            while (scanner2.hasNext()){
                String row = scanner2.nextLine();
                row = row.toLowerCase(); // un-capitalizing words
                // adding dictionary words in to ArrayList
                dictionary1BookWord.add(new BookWord(row));
                dictionary2Hash.insert(new BookWord(row));
            }
            scanner2.close();
        }catch (IOException e){
            System.out.println("File not Found!!!!!" + e.getMessage());
        }

        // soring novel collection that contains non repetitive words
        sortCollections(novel);

        // Part A
        System.out.println("\nx-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x");
        System.out.println("\n Total numbers of words that WarAndPeace contains is: " + novel2.size()); // total number of words in novel
        System.out.println("\n Total number of words that are unique is: " + novel.size()); // total number of non-repetitive words in novel
        // displaying top 15 words that has highest frequency and displying words that has 41 frequency
        displayWords(novel,15,41);

        System.out.println("\n Measuring performance of 3 methods");
        long startTime; // start time
        // Measuring performance of ArrayList Contains method
        startTime = System.nanoTime();
        long count1 = arrayListContains(novel,dictionary1BookWord); // count of misspelled words
        long timeTakenByArrayListContains =(System.nanoTime() - startTime)/1000; // time taken by ArrayList contains
        System.out.println("The number of misspelled words is " + count1 + " and time taken by ArrayList Contains method is " + timeTakenByArrayListContains);

        // Measuring performance of binary method
        startTime = System.nanoTime(); // start time
        sortCollections(dictionary1BookWord); // sorting the dictionary collection
        long count2 = binarySearch(novel,dictionary1BookWord); // count of misspelled words
        long timeTakenByBinarySearch = (System.nanoTime() - startTime)/1000; // time taken by binary search
        System.out.println("The number of misspelled words is " + count2 + " and time taken by BinarySearch method is " + timeTakenByBinarySearch);

        // Measuring performance of HashSet contains method
        startTime = System.nanoTime(); // start time
        long count3 = hashSetContains(novel,dictionary2Hash); // count of misspelled words
        long timeTakenByArrayListHashSet = (System.nanoTime() - startTime)/1000; // time taken by HashSet contains
        System.out.println("The number of misspelled words is " + count3 + " and time taken by SimpleHashSet Contains method is " + timeTakenByArrayListHashSet);


        System.out.println("\n Buckets");
        // total number of buckets
        System.out.println("Total number of buckets is " + dictionary2Hash.getNumberofBuckets());
        // total number of empty buckets
        System.out.println("Total number of empty bucket is " + dictionary2Hash.getNumberofEmptyBuckets());
        // largest bucket size
        System.out.println("Largest buckets size is " + dictionary2Hash.getLargestBucketSize());

        // Part B
        partB(novel2);

    }


    /**
     * to find pairs of war and peace
     * @param novel contains all words
     */
    public static void partB(ArrayList<BookWord> novel) {
        int textWarPOS = -1; // war word position
        int textPeacePOS = -1; // peace word position
        int pairsDistance = 0; // pair distance
        int pairCount = 0; // pair count

        for (int i = 0; i < novel.size(); i++) {
            String text = novel.get(i).getText();
            // if text matches with war
            if (text.equals("war")) {
                textWarPOS = i; // store the position of war
            } // if text matches with peace
            else if (text.equals("peace")) {
                textPeacePOS = i; // store the position of peace
            }

            // if found the position of both the words
            if (textWarPOS != -1 && textPeacePOS != -1) {
                int distance = Math.abs(textWarPOS - textPeacePOS); // calculate distance as per position of both words
                pairsDistance += distance; // sum of distance
                System.out.println("shortest distance between war at pos(" + textWarPOS + ") and peace(" + textPeacePOS + ") = " + distance);
                pairCount++; // increment pair count
                textWarPOS = -1; // setting war position to -1 until it found next war word
                textPeacePOS = -1; // setting peace position to -1 until it found next peace word
            }
        }

        // if pair is found
        if (pairCount > 0) {
            // calculating average distance as per pair count
            double pairAvgDist = (double) pairsDistance / pairCount;
            System.out.println("The total sum of distances between the matched pairs of war and peace = " + pairsDistance);
            System.out.println("The average distance between the matched pairs of war and peace = " + pairAvgDist);
        } else {
            System.out.println("No pairs of 'war' and 'peace' found in the text.");
        }
    }


    /**
     * to sort the collections
     * @param collection novel or dictionary
     */
    public static void sortCollections(ArrayList<BookWord> collection){
        Collections.sort(collection, (text1,text2) ->{
            int countCompare = Integer.compare(text2.getCount(), text1.getCount()); // sort by word counts in descending order
            if (countCompare != 0){
                return countCompare;
            }
            return text1.getText().compareTo(text2.getText()); // sort by alphabets if count is same
        });
    }


    /**
     * to perform search using arrayList contains method
     * @param novel contains all words of novel
     * @param dictionary contains all words of dictionary
     * @return count - number of words are not in dictionary
     */
    public static long arrayListContains(ArrayList<BookWord> novel, ArrayList<BookWord> dictionary){
        long count = 0;
        // iterating each word of novel
        for (BookWord text: novel){
            // dictionary does not contains novel words
            if (!dictionary.contains(text)){
                count++; // increment count by 1
            }
        }
        return count;
    }

    /**
     * to perform hashSet contains method
     * @param novel contains all words of novel
     * @param dictionary contains all words of dictionary
     * @return count - number of words are not in dictionary
     */
    public static long hashSetContains(ArrayList<BookWord> novel, SimpleHashSet<BookWord> dictionary){
        long count = 0;
        // iterating each word of novel
        for (BookWord text: novel){
            // dictionary does not contains novel words
            if (!dictionary.contains(text)){
                count++; // increment count by 1
            }
        }
        return count;
    }

    /**
     * to perform binary search method
     * @param novel contains all words of novel
     * @param dictionary contains all words of dictionary
     * @return count - number of words are not in dictionary
     */
    public static long binarySearch(ArrayList<BookWord> novel, ArrayList<BookWord> dictionary){
        long count=0;
        // iterating each word of novel
        for (BookWord text: novel){
            // comparing words of novel with words of dictionary
            int index = Collections.binarySearch(dictionary, text, (dicWord1, novelWord1) -> dicWord1.getText().compareTo(novelWord1.getText()));
            // index will be -1 if word is not found
            if (index<0){
                count++; // increment count by 1
            }
        }
        return count;
    }


    /**
     * to display top 15 words that has highest frequency and to display words that has 41 frequency
     * @param novel collections of novel words
     * @param numOfTop to find top 15 highest frequency words
     * @param frequency to find words that has 41 frequency
     */
    public static void displayWords(ArrayList<BookWord> novel, int numOfTop, int frequency) {
        // number of top is in novel size range
        if (numOfTop > 0 && numOfTop <= novel.size()) {
            System.out.println("\n Top " + numOfTop + " words that has highest counts are: ");
            // print all words
            for (int i = 0; i < numOfTop; i++) {
                System.out.println(novel.get(i));
            }
        } else {
            System.out.println("Invalid number of top words.");
        }

        boolean found = false;
        System.out.println("\n The words that has frequency " + frequency + " are: ");
        for (int i = 0; i < novel.size(); i++) {
            // to print matched frequency words
            if (novel.get(i).getCount() == frequency) {
                System.out.println(novel.get(i));
                found = true;
            }
        }
        if (!found) {
            System.out.println("No words found with the given frequency.");
        }
    }

}