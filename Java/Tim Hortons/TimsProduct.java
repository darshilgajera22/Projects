package Assignment7_000867069;

/**
 * Tims Product class, contains common attributes of all Products
 *
 * @author Darshil Gajera, 000867069
 */

public abstract class TimsProduct implements Commodity {

    private String name; // product name
    private double cost; // production cost
    private double price; // retail price

    /**
     * Constructor TimProduct
     *
     * @param name
     * @param cost
     * @param price
     */

    public TimsProduct(String name, double cost, double price) {
        this.name = name; // product's name value
        this.cost = cost; // product's cost value
        this.price = price; // product's price value
    }

    /**
     * to get product's name
     *
     * @return name
     */
    public String getName() {
        return name; // returning name of product
    }

    /**
     * to get production cost of product
     *
     * @return cost
     */
    @Override
    public double getProductionCost() {
        return this.cost; // returning cost of product
    }

    /**
     * to get retail price
     *
     * @return price
     */
    @Override
    public double getRetailPrice() {
        return this.price; // returning price of product
    }

    /**
     * toString
     *
     * @return String
     */
    @Override
    public String toString() {
        return name + ", Cost $" + this.cost + " , Price $" + this.price + " ";
    }
}
