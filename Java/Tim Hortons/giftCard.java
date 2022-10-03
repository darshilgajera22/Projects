package Assignment7_000867069;

import java.util.Random;
import java.util.Scanner;

/**
 * Tims Product, Gift Card class, contains attributes of Gift Card
 *
 * @author Darshil Gajera, 000867069
 */


public class giftCard extends TimsProduct {

    private long giftCardNumber; // 8 digits Gift card number

    /**
     * Gift Card Constructor
     *
     * @param name
     * @param giftCardNumber
     * @param cost
     * @param price
     */
    public giftCard(String name, long giftCardNumber, double cost, double price) {
        super(name, cost, price); // passing values to parent's constructor variables
        this.giftCardNumber = giftCardNumber; // setting giftcard number
    }

    /**
     * to create order
     *
     * @return customerOrder
     */
    public static giftCard create() {

        Scanner sc = new Scanner(System.in); // Scanner object
        giftCard customerOrder = null; // GiftCard Class object

        boolean valid; // valid input
        do {
            // menu to take order
            System.out.println("Which kind of gift card customer want?");
            System.out.println("    1) Normal 2) Premium 3) Supreme");
            int giftCardChoice = sc.nextInt(); // getting customer's choice

            Random random = new Random(); // Random object of Random class
            long number = random.nextLong(99999999); // generating random number of 8 digits

            switch (giftCardChoice) {
                // choice 1 Normal Gift Card
                case 1:
                    // passing Gift Card values in parameters
                    customerOrder = new giftCard("Normal", number, 25, 28.48);
                    valid = true; // valid input
                    break;
                // chioce 2 Premium Gift Card
                case 2:
                    // passing Gift Card values in parameters
                    customerOrder = new giftCard("Premium", number, 50, 53.23);
                    valid = true; // valid input
                    break;
                // chioce 2 Supreme Gift Card
                case 3:
                    // passing Gift Card values in parameters
                    customerOrder = new giftCard("Supreme", number, 100, 103.08);
                    valid = true; // valid input
                    break;
                default:
                    System.out.println("\nxxxxxxxxxxxxxxxxxxxx--You enter Wrong Choice--xxxxxxxxxxxxxxxxxxxx\n");
                    valid = false; // invalid input
            }
        } while (valid != true); // invalid input rerun Switch Case

        return customerOrder; // return customer's order
    }


    /**
     * toString
     *
     * @return String
     */
    @Override
    public String toString() {
        return "Tims Product: [Gift Card, Prepaid Card " + super.toString() + "] [Gift Card Number: " + this.giftCardNumber + "]";
    }
}
