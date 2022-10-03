package Assignment7_000867069;

import java.awt.Color;
import java.util.Scanner;

/**
 * Tims Product, Mug class, contains attributes of Mug
 *
 * @author Darshil Gajera, 000867069
 */


public class Mug extends TimsProduct {

    private Color color; // Mug's Color

    /**
     * Constructor Mug
     *
     * @param name
     * @param color
     * @param cost
     * @param price
     */
    private Mug(String name, Color color, double cost, double price) {
        super(name, cost, price); // passing values to parent's constructor variables
        this.color = color; // Mugs Color value
    }

    /**
     * Create a order for Mug
     *
     * @return customerOrders
     */
    public static Mug create() {
        Scanner sc = new Scanner(System.in); // Scanner object
        Mug customerOrders = null; // Mug class object
        int colorChoice; // Mug Color choice
        boolean valid; // valid input

        do {
            double userCost, userPrice; // cost and price of product
            Color userColor; // Customer's Mug choice

            // Menu for mug types
            System.out.println("Which kind of mug customer want?    ");
            System.out.println("    1) Ceramic Mug 2) Travel Mug 3) Classic Mug    ");
            int mugChoice = sc.nextInt(); // getting customer choice

            switch (mugChoice) {
                case 1:
                    System.out.println("Enter the cost of Mug");
                    userCost = sc.nextDouble(); // cost of mug

                    System.out.println("Enter the price of Mug");
                    userPrice = sc.nextDouble(); // price of mug

                    // mug color menu
                    System.out.println("Enter the Color of Mug");
                    System.out.println("    1) Orange 2) Yellow 3) Magenta 4) Dark Gray    ");
                    colorChoice = sc.nextInt(); // getting customer choice

                    switch (colorChoice) {
                        case 1:
                            userColor = Color.ORANGE; // black color
                            break;
                        case 2:
                            userColor = Color.YELLOW; // yellow color
                            break;
                        case 3:
                            userColor = Color.MAGENTA; // magenta color
                            break;
                        case 4:
                        default:
                            userColor = Color.DARK_GRAY; // dark gray color
                            break;
                    }
                    // creating mug order
                    customerOrders = new Mug("Ceramic Mug", userColor, userCost, userPrice);
                    valid = true; // valid input
                    break;
                case 2:
                    System.out.println("Enter the cost of Mug");
                    userCost = sc.nextDouble(); // cost of mug

                    System.out.println("Enter the price of Mug");
                    userPrice = sc.nextDouble(); // price of mug

                    System.out.println("Enter the Color of Mug");
                    System.out.println("    1) Black 2) Blue 3) White 4) Red    ");

                    colorChoice = sc.nextInt(); // getting customer choice
                    switch (colorChoice) {
                        case 1:
                            userColor = Color.ORANGE; // orange color
                            break;
                        case 2:
                            userColor = Color.YELLOW; // yellow color
                            break;
                        case 3:
                            userColor = Color.MAGENTA; // magenta color
                            break;
                        case 4:
                        default:
                            userColor = Color.DARK_GRAY; // dark gray color
                            break;
                    }
                    // creating mug order
                    customerOrders = new Mug("Travel Mug", userColor, userCost, userPrice);
                    valid = true; // valid input
                    break;
                case 3:
                    System.out.println("Enter the cost of Mug");
                    userCost = sc.nextDouble(); // cost of mug

                    System.out.println("Enter the price of Mug");
                    userPrice = sc.nextDouble(); // price of mug

                    System.out.println("Enter the Color of Mug");
                    System.out.println("    1) Black 2) Blue 3) White 4) Red    ");

                    colorChoice = sc.nextInt(); // getting customer choice
                    switch (colorChoice) {
                        case 1:
                            userColor = Color.ORANGE; // orange color
                            break;
                        case 2:
                            userColor = Color.YELLOW; // yellow color
                            break;
                        case 3:
                            userColor = Color.MAGENTA; // magenta color
                            break;
                        case 4:
                        default:
                            userColor = Color.DARK_GRAY; // dark grey color
                            break;
                    }
                    // creating mug order
                    customerOrders = new Mug("Classic Mug", userColor, userCost, userPrice);
                    valid = true; // valid input
                    break;
                default:
                    System.out.println("\nxxxxxxxxxxxxxxxxxxxx--You enter Wrong Choice--xxxxxxxxxxxxxxxxxxxx\n");
                    valid = false; // Invalid input
            }
        } while (valid != true); // invalid input rerun Switch Case

        return customerOrders; // return customer's order
    }

    /**
     * to get mug's color
     *
     * @return color
     */
    public Color getColor() {
        return color;
    }

    /**
     * toString
     *
     * @return String
     */
    @Override
    public String toString() {
        return "Tims Product: [" + super.toString() + "] [Color: " + this.color + "]";
    }
}
