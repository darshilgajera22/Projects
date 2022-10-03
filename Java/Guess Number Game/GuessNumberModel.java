package assignment5_000867069;

/**
 * Guess number game, program will generate a computer random number and user have to guess the computer random number.
 * @author Darshil Gajera
 *
 */

public class GuessNumberModel {

    // Computer Random Number
    private int computerRandom;
    // Players Guess Number
    private int userNumber;
    // Player name
    private String userName;
    // total tries
    private int count = 0;
    // Displays the result
    private String result;

    /**
     * Constructor without parameters
     */
    public GuessNumberModel() {
    }


    /**
     * to restart the game
     * @param // none
     * @return // none
     */

    public void reStart() {
        count = 0; // total tries 0
        generateComputerNumber(); // generating new computer random
        result = ""; // setting result null
        userNumber = 0; // setting user number 0
    }

    /**
     * to generate computer random number
     * @param // none
     * @return // none
     */

    public void generateComputerNumber(){
        this.computerRandom = (int) (Math.random() * 100); // using math. random to choose a number
        System.out.println("Computer Random Number is " + computerRandom); // Displaying computer random number
    }

    /**
     * to check the both numbers
     * @param // none
     * @return // none
     */
    public void checkNum() {

        String output = " "; // Stores the result

        // to check usernumber is greater then computer random
        if (this.userNumber > this.computerRandom) {
            output = "Oops! You Guess high number"; // storing String result in output
            count++; // incresing total tries number by 1
        }
        // to check usernumber is lower then computer number
        else if (this.userNumber < this.computerRandom) {
            output = "Oops! You Guess low number"; // storing String result in output
            count++; // incresing total tries number by 1
        }
        // to check if both numbers are same
        else if (this.userNumber == this.computerRandom) {
            output = "Correct! You Guess the right number"; // storing String result in output
        }
        result = output; // Storing output in result String
    }

    /**
     * setter for usernumber
     * @param userNumber
     * @return none
     */

    public void setUserNumber(int userNumber) {
        this.userNumber = userNumber; // assign the local variable value to global private variable
    }

    /**
     * setter for username
     * @param userName
     * @return none
     */

    public void setUserName(String userName) {
        this.userName = userName; // assign the local variable value to global private variable
    }

    /**
     * getter for result
     * @param //none
     * @return result
     *
     */


    public String getResult() {
        return result; // returning the result value
    }

    /**
     * toString for output
     * @return
     */

    @Override
    public String toString() {
        return "Player Name: " + userName + " \n Total attempt: " + count + " \n " + result; // Displays the output
    }
}
