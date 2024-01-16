/***
 * Class BookWord
 *
 * to store novel words as text and count it frequency
 *
 * @author Darshil Gajera, 000867069
 */
public class BookWord {

    final private String text; // to store words
    private int count = 1; // words counts

    /**
     * Class Constructor
     * @param wordText object of word
     */
    public BookWord(String wordText) {
        this.text = wordText;
    }

    /**
     * to retrieve the text of the object
     * @return text
     */
    public String getText() {
        return text;
    }

    /**
     * to retrieve the count of text
     * @return count
     */
    public int getCount() {
        return count;
    }

    /**
     * to increment the count of text
     */
    public void incrementCount(){
        this.count++;
    }

    /**
     * to equal method to compare two objects
     * @param wordToCompare object that should be compared with class object
     * @return true or false
     */
    @Override
    public boolean equals(Object wordToCompare) {
        if(wordToCompare != null && wordToCompare.getClass() == this.getClass()){
            if (text.equals(((BookWord) wordToCompare).text)){
                return true;
            }
        }
        return false;
    }

    /**
     * to calculate HashCode of text
     * @return result, hashcode of text
     * Reference: https://stackoverflow.com/questions/2730865/how-do-i-calculate-a-good-hash-code-for-a-list-of-strings
     */
    @Override
    public int hashCode(){
        final int prime = 19;
        int result = 1;
        for (int i=0; i<text.length();i++){
            result = (result * prime) + text.charAt(i);
        }
        return result;
    }

    /**
     * ToString to print the object
     * @return
     */
    @Override
    public String toString() {
        return String.format("The count of the Word: %-12s is : %d", text, count);
    }


}