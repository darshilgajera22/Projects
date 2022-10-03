package Assignment7_000867069;

import java.util.Scanner;

/**
 * Tims Product, Order class, to get order and call the create method of every product class
 *
 * @author Darshil Gajera, 000867069
 */

public class TimsOrder {

    private int size; // Order Quantity
    private String name; // Customer Name

    private static TimsProduct[] timsProducts; // TimsProduct Array

    private TimsOrder(int size, String name) {
        this.size = size; // Order Size
        this.name = name; // Customer's Name
        timsProducts = new TimsProduct[size]; // Setting size of timsProducts
    }

    /**
     * to get Customer Order
     *
     * @return timsOrder
     */
    public static TimsOrder create() {

        Scanner sc = new Scanner(System.in); // Scanner object
        System.out.println("Enter customer name: ");
        String name = sc.nextLine(); // to get customer name
        System.out.println("How many items customer want to order?    ");
        int totalCommodities = sc.nextInt(); // to get order quantity
        // creating object of TimsOrder and passing value in parameters
        TimsOrder timsOrder = new TimsOrder(totalCommodities, name);

        // to get customer's order for all commodity one by one
        for (int i = 0; i < timsProducts.length; i++) {

            boolean valid; // valid input
            do {
                // menu to get Customer order
                System.out.println("What customer want to order from the Today's Menu");
                System.out.println("    1) Donut 2) Mug 3) Burger 4) Gift Card    ");
                int customerOrder = sc.nextInt(); // getting product choice

                switch (customerOrder) {
                    case 1:
                        // calling create method of Donut Class
                        timsProducts[i] = Donut.create();
                        valid = true; // valid input
                        break;
                    case 2:
                        // calling create method of Mug Class
                        timsProducts[i] = Mug.create();
                        valid = true; // valid input
                        break;
                    case 3:
                        // calling create method of Burger Class
                        timsProducts[i] = Burger.create();
                        valid = true; // valid input
                        break;
                    case 4:
                        // calling create method of Gift Card Class
                        timsProducts[i] = giftCard.create();
                        valid = true; // valid input
                        break;
                    default:
                        System.out.println("\nxxxxxxxxxxxxxxxxxxxx--You enter Wrong Choice--xxxxxxxxxxxxxxxxxxxx\n");
                        valid = false; // invalid input
                }
            } while (valid != true); // invalid input rerun Switch Case

        }
        return timsOrder; // return timsOrder
    }


    /**
     * to calculate bill amount
     *
     * @return totalBillAmount
     */
    public double getAmountDue() {
        double totalBillAmount = 0; // to store price of all products
        int j = 0; // to start loop
        while (j < timsProducts.length) {
            totalBillAmount += timsProducts[j].getRetailPrice(); // adding price of all product
            j++; // increment
        }
        return totalBillAmount; // returning total Bill Amount
    }

    /**
     * toString
     *
     * @return orderSummary
     */
    @Override
    public String toString() {
        // designing the output
        System.out.println("\n\t\t\tOrder Summary");
        System.out.println("x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x");
        String orderSummary = "\n Order For:    " + name + "\n"; // displaying customer's name

        int j = 0; // to start loop
        while (j < timsProducts.length) {
            orderSummary += timsProducts[j].toString() + "\n\n"; // storing toString of every product
            j++;
        }
        return orderSummary; // returning every product toString to display after completing order
    }
}
