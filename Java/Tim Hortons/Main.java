package Assignment7_000867069;

public class Main {

    /**
     * Main method to run TimsOrder
     *
     * @param args
     */
    public static void main(String[] args) {
        // creating TimsOrder object and calling it's create method
        TimsOrder timsOrder = TimsOrder.create();
        System.out.println(timsOrder); // Displying timsOrder
        System.out.printf("Total Bill Amount: $%.2f\n", timsOrder.getAmountDue()); // Displying Bill Amount
    }
}
