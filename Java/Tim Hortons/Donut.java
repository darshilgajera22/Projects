package Assignment7_000867069;

import java.util.Scanner;

/**
 * Tims Product, Donut class, contains attributes of Donut
 *
 * @author Darshil Gajera, 000867069
 */

public class Donut extends TimsProduct implements Consumable {

    private String description; // Product Description
    private int calorieCount; // Product Calories

    /**
     * Donut Constructor
     *
     * @param name
     * @param description
     * @param cost
     * @param price
     * @param calories
     */
    private Donut(String name, String description, double cost, double price, int calories) {
        super(name, cost, price); // passing values to parent's constructor variables
        this.description = description; // setting description of product
        this.calorieCount = calories; // setting calorie of product
    }


    /**
     * Create method to take customer's order
     *
     * @return customerOrders
     */
    public static Donut create() {

        Scanner sc = new Scanner(System.in); // Scanner object
        Donut customerOrders = null; // Donut Class object

        double userCost = 0, userPrice = 0; // Cost and Price of Product

        boolean valid; // valid input

        do {
            // menu to take customer order
            System.out.println("Which kind of donut customer want?");
            System.out.println("    1) Maple Dip Donuts 2) Honey Dip Donuts 3) Old Fashion Glazed Donuts");
            int donutsChoice = sc.nextInt(); // getting Customer's choice

            switch (donutsChoice) {
                case 1:
                    // to take product cost
                    System.out.println("Enter the cost of Donut");
                    userCost = sc.nextDouble(); // cost input

                    // to take retail price
                    System.out.println("Enter the price of Donut");
                    userPrice = sc.nextDouble(); // price input

                    // creating customer order, passing Donuts values in parameters
                    customerOrders = new Donut("Maple Dip Donuts", "Best with Peach Real Fruit Quencher", userCost, userPrice, 350);
                    valid = true; // valid input
                    break;
                case 2:
                    // to take product cost
                    System.out.println("Enter the cost of Donut");
                    userCost = sc.nextDouble(); // cost input

                    // to take retail price
                    System.out.println("Enter the price of Donut");
                    userPrice = sc.nextDouble(); // price input

                    // creating customer order, passing Donuts values in parameters
                    customerOrders = new Donut("Honey Dip Donuts", "Try with Strawberry Creamy Chill", userCost, userPrice, 350);
                    valid = true; // valid input
                    break;
                case 3:
                    // to take product cost
                    System.out.println("Enter the cost of Donut");
                    userCost = sc.nextDouble(); // cost input

                    // to take retail price
                    System.out.println("Enter the price of Donut");
                    userPrice = sc.nextDouble(); // price input

                    // creating customer order, passing Donuts values in parameters
                    customerOrders = new Donut("Old Fashion Glazed Donuts", "Customer Prefers with Freshly Brewed Iced Tea Quencher", userCost, userPrice, 499);
                    valid = true; // valid input
                    break;
                default:
                    System.out.println("\nxxxxxxxxxxxxxxxxxxxx--You enter Wrong Choice--xxxxxxxxxxxxxxxxxxxx\n");
                    valid = false; // invalid input
            }
        } while (valid != true); // invalid input rerun Switch Case

        return customerOrders; // return customer's order
    }

    /**
     * to get product description
     *
     * @return description
     */
    public String getDescription() {
        return description;
    }

    /**
     * to get calorie of product
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
        return "Tims Product: [" + super.toString() + getConsumptionMethod() + "] [" + description + ", Calories = " + getCalorieCount() + "]";
    }
}
