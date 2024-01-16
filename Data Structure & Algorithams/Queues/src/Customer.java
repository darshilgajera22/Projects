/**
 * Customer class
 *
 * @author Darshil Gajera, 000867069
 */
public class Customer {

    private int cartItems; // customer items in the cart


    /**
     * Customer constructor
     * @param cartItems // customer's items in the cart
     */
    public Customer(int cartItems){
        this.cartItems = cartItems;
    }

    /**
     * getter for cartItems
     * @return cartItems count
     */
    public int getCartItems() {
        return cartItems;
    }

    /**
     * method to calculate customer serving time as per the cart items
     * @return serving time
     */
    public int calcServTime(){
        return 45 +5 * cartItems;
    }

    /**
     * toString to print customer cart info
     * @return cartItems and total serving time for customer
     */
    @Override
    public String toString() {
        return cartItems + "(" + calcServTime() + "s)";
    }
}
