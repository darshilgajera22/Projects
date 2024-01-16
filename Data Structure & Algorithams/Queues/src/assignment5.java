import java.io.File;
import java.io.IOException;
import java.util.Scanner;

/**
 * Assignment 5
 *
 * @author Darshil Gajera, 000867069
 */
public class assignment5 {
    public static void main(String[] args) {
        File customersFile = new File("src/CustomerData.txt"); // customer data

        int expressLines = 0; // number of express line
        int normalLines = 0; // number of normal line
        int maxItemsLimitExpress = 0; // maximum items limit for express
        int totalCustomers = 0; // number of customers

        try{
            // scanning file data
            Scanner scanner = new Scanner(customersFile);
            // reading file data
            while (scanner.hasNext()){
                expressLines = scanner.nextInt();
                normalLines = scanner.nextInt();
                maxItemsLimitExpress = scanner.nextInt();
                totalCustomers = scanner.nextInt();

                // total checkout lines
                LinkedQueue<Customer>[] checkoutLines = new LinkedQueue[expressLines + normalLines];

                for (int i=0; i<checkoutLines.length;i++){
                    // creating queue for each checkout line
                    checkoutLines[i] = new LinkedQueue<>();
                }

                // getting customer cart info
                for (int i = 0; i < totalCustomers; i++) {
                    int cartItems = scanner.nextInt();
                    // creating customer object
                    Customer customer = new Customer(cartItems);

                    // line number
                    int lineNum = 0;
                    // calculating minimum time
                    int minTime = Integer.MAX_VALUE;

                    // if express lines is available then customer go to express and express also has least waiting time
                    for (int k = 0; k<expressLines; k++){
                        if (customer.getCartItems() <= maxItemsLimitExpress) {
                            // calculating express lime time
                            int expressTime = calcEstTime(checkoutLines[k]) + customer.calcServTime();
                            // expresstime has less waiting time than minimum waiting time
                            if (expressTime < minTime) {
                                minTime = expressTime;
                                // express line number
                                lineNum = k;
                            }
                        }
                    }


                    // finding normal lines with least waiting time
                    for (int j = expressLines; j < checkoutLines.length; j++) {
                        // finding estimated time for each normal line
                        int estTime = calcEstTime(checkoutLines[j]) + customer.calcServTime();
                        // estimated time is less than minimum time
                        if (estTime < minTime) {
                            minTime = estTime;
                            lineNum = j; // getting line number that has least waiting time
                        }
                    }
                    // assigning customer to line
                    checkoutLines[lineNum].enqueue(customer);
                }


                System.out.println("PART A - Checkout lines and time estimates for each line");
                int totalServingTime = 0; // total serving time requires to serve all customers
                int estTime = 0; // estimated time for queue
                for (int i = 0; i < checkoutLines.length; i++) {
                    // first few lines is express
                    String lineName = (i < expressLines) ? "Express" : "Normal";
                    estTime = calcEstTime(checkoutLines[i]); // getting estimated time of each line
                    System.out.print("CheckOut(" + lineName + ") # " + (i + 1) + " (Est Time = " + estTime + " s) = ");

                    // Print the customers as per queues
                    System.out.print("[");
                    while (!checkoutLines[i].isEmpty()) {
                        Customer customer = checkoutLines[i].dequeue();
                        System.out.print(customer + ",");
                    }
                    System.out.println("]");

                    // finding highest serving time
                    if (totalServingTime < estTime) {
                        totalServingTime = estTime;
                    }
                }
                System.out.println("Time to clear store of all customers = " + totalServingTime + " s");
            }
        }
        catch (IOException ex){
            // file not found exception
            System.out.println("File not found!!!!!" + ex.getMessage());
        }
    }


    /**
     * finding estimating time for each lines
     * @param checkoutLine
     * @return totalTime - estimated time of each line
     */
    private static int calcEstTime(LinkedQueue<Customer> checkoutLine) {
        int totalTime = 0;

        // temporary queue to store customer
        LinkedQueue<Customer> tempQueue = new LinkedQueue<>();
        while (!checkoutLine.isEmpty()) {
            Customer currentCustomer = checkoutLine.dequeue(); // dequing customer
            tempQueue.enqueue(currentCustomer); // enquing to temporary queue
            totalTime += currentCustomer.calcServTime(); // getting customer serving time
        }

        // restoring the original queue
        while (!tempQueue.isEmpty()) {
            checkoutLine.enqueue(tempQueue.dequeue());
        }
        return totalTime; // estimated total time of queue
    }
}
