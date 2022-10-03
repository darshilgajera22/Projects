package assignment2_000867069;

import java.util.Scanner;

/**
 * Assignment 2
 * ParrotCraft class, that interacts with users,
 * taking inputs from User and sending to Parrot.java
 * showing output that is obtained from Parrot.java
 *
 * @author Darshil Gajera (000867069)
 */


public class ParrotCraft {
    public static void main(String[] args) {

        // creating class object and initializing variables

        Parrot p1 = new Parrot("Julius", 2.1, true, true, 2, true);
        Parrot p2 = new Parrot("Nancy", 0.6, true, false, 1, true);
        Parrot p3 = new Parrot("Johnette", 1.0, true, true, 3, false);

        // variables for user inputs
        int choice, parrot_choice, feed_choice, cookie_quantity, fly_stay;
        double seed_quantity;

        Scanner sc = new Scanner(System.in);

        //loop for user inputs
        for (int i = 1; i > 0; i++) {
            // printing the parrot state
            System.out.println(p1.toString());
            System.out.println(p2.toString());
            System.out.println(p3.toString());

            //choices for play
            System.out.println("\n 1. Feed 2. Command 3. Play 4. Hit 5.Quit");
            choice = sc.nextInt();

            switch (choice) {
                case 1:
                    // taking Parrot choice
                    System.out.println("Choice: " + choice);
                    System.out.println("Which Parrot?");
                    parrot_choice = sc.nextInt();

                    //validating Parrot choice
                    if (parrot_choice > 0 && parrot_choice <= 3) {
                        switch (parrot_choice) {
                            //case 1 for Parrot 1
                            case 1:
                                //taking feed choice
                                System.out.println("1. Seed 2. Cookie");
                                feed_choice = sc.nextInt();
                                if (feed_choice == 1) {
                                    System.out.println("How Much?");
                                    seed_quantity = sc.nextDouble();
                                    p1.setSeed(seed_quantity);
                                } else {
                                    System.out.println("How many Cookie");
                                    cookie_quantity = sc.nextInt();
                                    p1.setSeed(cookie_quantity);
                                }
                                break;
                            //case 2 for Parrot 2
                            case 2:
                                //taking feed choice
                                System.out.println("1. Seed 2. Cookie");
                                feed_choice = sc.nextInt();
                                if (feed_choice == 1) {
                                    System.out.println("How Much?");
                                    seed_quantity = sc.nextDouble();
                                    p2.setSeed(seed_quantity);
                                } else {
                                    System.out.println("How many Cookie");
                                    cookie_quantity = sc.nextInt();
                                    p2.setSeed(cookie_quantity);
                                }
                                break;
                            //case 3 for Parrot 3
                            case 3:
                                //taking feed choice
                                System.out.println("1. Seed 2. Cookie");
                                feed_choice = sc.nextInt();
                                if (feed_choice == 1) {
                                    System.out.println("How Much?");
                                    seed_quantity = sc.nextDouble();
                                    p3.setSeed(seed_quantity);
                                } else {
                                    System.out.println("How many Cookie");
                                    cookie_quantity = sc.nextInt();
                                    p3.setSeed(cookie_quantity);
                                }
                                break;
                        }
                    }
                    break;
                //main case 1 end
                case 2:
                    //taking Parrot choice
                    System.out.println("Choice: " + choice);
                    System.out.println("Which Parrot?");
                    parrot_choice = sc.nextInt();
                    //validating Parrot choice
                    if (parrot_choice > 0 && parrot_choice <= 3) {
                        switch (parrot_choice) {
                            // case 1 for Parrot 1
                            case 1:
                                //command option
                                System.out.println("1. Fly 2. Stay");
                                fly_stay = sc.nextInt();
                                if (fly_stay == 1) {
                                    p1.setFlying(true);
                                } else {
                                    p1.setFlying(false);
                                }
                                break;
                            //case 2 for parrot 2
                            case 2:
                                //command option
                                System.out.println("1. Fly 2. Stay");
                                fly_stay = sc.nextInt();
                                if (fly_stay == 1) {
                                    p2.setFlying(true);
                                } else {
                                    p2.setFlying(false);
                                }
                                break;
                            //case 3 for parrot 3
                            case 3:
                                //command option
                                System.out.println("1. Fly 2. Stay");
                                fly_stay = sc.nextInt();
                                if (fly_stay == 1) {
                                    p3.setFlying(true);
                                } else {
                                    p3.setFlying(false);
                                }
                                break;
                        }
                    }
                    break;
                //main case 2 end
                case 3:
                    //taking parrot choice
                    System.out.println("Choice: " + choice);
                    System.out.println("Which Parrot?");
                    parrot_choice = sc.nextInt();
                    break;
                //main case 3 end
                case 4:
                    //taking parrot choice
                    System.out.println("Choice: " + choice);
                    System.out.println("Which Parrot?");
                    parrot_choice = sc.nextInt();
                    //validation parrot choice
                    if (parrot_choice > 0 && parrot_choice <= 3) {
                        switch (parrot_choice) {
                            //case 1 for parrot 1
                            case 1:
                                //calling hit mathod of parrot class
                                p1.hit();
                                System.out.println("Ouch!");
                                break;
                            //case 2 for parrot 2
                            case 2:
                                //calling hit mathod of parrot class
                                p2.hit();
                                System.out.println("Ouch!");
                                break;
                            //case 3 for parrot 3
                            case 3:
                                //calling hit mathod of parrot class
                                p3.hit();
                                System.out.println("Ouch!");
                                break;
                        }
                    }
                    break;
                // Main Case 4 end
                case 5:
                    //initializing i value as negative to terminate program
                    i = -2;
                    break;
                //main Case 5 end
            }//End of main switch
        }//End of foor loop

    }//End of PSVM

}// End of class
