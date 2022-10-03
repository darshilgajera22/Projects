package Assignment7_000867069;

import java.util.Scanner;

/**
 * Tims Product, Burger class, contains attributes of Burger
 *
 * @author Darshil Gajera, 000867069
 */

public class Burger extends TimsProduct implements Consumable {

    private String description; // Product's description
    private int calorieCount; // Products Calories


    /**
     * Burger Constructor
     *
     * @param name
     * @param description
     * @param cost
     * @param price
     * @param calorieCount
     */
    public Burger(String name, String description, double cost, double price, int calorieCount) {
        super(name, cost, price); // passing values to parent's constructor variables
        this.description = description; // Product description value
        this.calorieCount = calorieCount; // Product Calories value
    }

    /**
     * To get Customer order
     *
     * @return customerOrder
     */
    public static Burger create() {
        Scanner sc = new Scanner(System.in); // Scanner object

        Burger customerOrder = null; // Burger object
        boolean valid; // valid input

        do {
            double userCost, userPrice; // cost and price of product

            // menu to take customer order
            System.out.println("Which kind of burger customer wants?");
            System.out.println("    1) Veg. Burger 2) AluTikki Burger 3) Cheese Burger  ");
            int burgerChoice = sc.nextInt(); // getting customer order

            switch (burgerChoice) {
                case 1:
                    // to get cost of product
                    System.out.println("Enter the cost of Burger");
                    userCost = sc.nextDouble(); // cost input

                    // to get price of product
                    System.out.println("Enter the price of Burger");
                    userPrice = sc.nextDouble(); // price input

                    // passing Burger attributes values in parameters
                    customerOrder = new Burger("Veg. Burger", "Burger with Vegies", userCost, userPrice, 418);
                    valid = true; // valid input
                    break;
                case 2:
                    // to get cost of product
                    System.out.println("Enter the cost of Burger");
                    userCost = sc.nextDouble();

                    // to get price of product
                    System.out.println("Enter the price of Burger");
                    userPrice = sc.nextDouble();

                    // passing Burger attributes values in parameters
                    customerOrder = new Burger("AluTikki Burger", "Burger with AluTikki", userCost, userPrice, 538);
                    valid = true; // valid input
                    break;
                case 3:
                    // to get cost of product
                    System.out.println("Enter the cost of Burger");
                    userCost = sc.nextDouble();

                    // to get price of product
                    System.out.println("Enter the price of Burger");
                    userPrice = sc.nextDouble();

                    // passing Burger attributes values in parameters
                    customerOrder = new Burger("Cheese Burger", "Burger with Extra Cheese", userCost, userPrice, 602);
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
     * to get Calories of product
     *
     * @return calorieCount
     */
    @Override
    public int getCalorieCount() {
        return this.calorieCount;
    }

    /**
     * to get Consumption method
     *
     * @return String
     */
    @Override
    public String getConsumptionMethod() {
        return "Eat it";
    }

    /**
     * toString
     *
     * @return String
     */
    @Override
    public String toString() {
        return "Tims Product: [" + super.toString() + " " + getConsumptionMethod() + "] [" + description + ", Calories = " + getCalorieCount() + "]";
    }
}
