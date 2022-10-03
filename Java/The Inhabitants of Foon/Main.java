package Assignment6_000867069;


/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Main {

    /**
     * Main method to debug
     * @param args
     */

    public static void main(String[] args) {
        //Display welcome message
        System.out.println("\n...................Welcome, to Game of Foons!.........................\n");


        //2 Manticore objects
        Manticore m1 = new Manticore(8, 10, 14, 8, 4, "Manticore 1");
        Manticore m2 = new Manticore("Manticore 2");


        //5 Infantry object
        Infantry i1 = new Infantry("Infantry 1");
        Infantry i2 = new Infantry("Infantry 2");
        Infantry i3 = new Infantry(10, 8, 12, 9, 9, "Infantry 1");
        Infantry i4 = new Infantry(12, 13, 14, 6, 9, "Infantry 2");
        Infantry i5 = new Infantry(13, 11, 9, 12, 6, "Infantry 3");

        //creating an infantry array
        Infantry[] i = new Infantry[5];
        i[0] = i1;
        i[1] = i2;
        i[2] = i3;
        i[3] = i4;
        i[4] = i5;


        //2 Warlord object
        Warlord w1 = new Warlord("Warlord 2");
        Warlord w2 = new Warlord("Warlord 1", 10, 15, 18, 10, 7, 4, i);


        //2 Goblin objects
        Goblin g1 = new Goblin("Goblin 1");
        Goblin g2 = new Goblin(g1, 10, 13, 15, 6, 10, "Goblin 2");



        System.out.println("......................Details of all the members....................... ");
        System.out.println(m1); // Displaying Details
        System.out.println(m2); // Displaying Details
        System.out.println(i1); // Displaying Details
        System.out.println(i2); // Displaying Details
        System.out.println(i3); // Displaying Details
        System.out.println(i4); // Displaying Details
        System.out.println(i5); // Displaying Details
        System.out.println(w1); // Displaying Details
        System.out.println(w2); // Displaying Details
        System.out.println(g1); // Displaying Details
        System.out.println(g2); // Displaying Details



        //Infantry attack another infantry
        System.out.println("\ni1 attacks i2");
        i1.attack(i2); // calling method
        System.out.println("------Result------");
        System.out.println(i1); // Displaying result
        System.out.println(i2); // Displaying result

        System.out.println("\ni3 attacks g1");
        i3.attack(g1); // calling method
        System.out.println("------Result------");
        System.out.println(i3); // Displaying result
        System.out.println(g1); // Displaying result


        //Goblin attacks manticore
        System.out.println("\nGoblin attack Manticore");
        g1.attack(m1); // calling method
        System.out.println("------Result------");
        System.out.println(g1); // Displaying result
        System.out.println(m1); // Displaying result


        //warlord2 increasing the treasure
        System.out.println("\nTreasure Increase");
        w2.increaseTreasure(30); // calling method
        System.out.println("------Result------");
        System.out.println(w2); // Displaying result

        //warlord attacks warlord
        System.out.println("\nWarload Attacks Warload");
        w2.attack(w1); // calling method
        System.out.println("------Result------");
        System.out.println(w1); // Displaying result
        System.out.println(w2); // Displaying result

        //goblin attacks warlord
        System.out.println("\nGoblin attcks Warload");
        g2.attack(m2); // calling method
        System.out.println("------Result------");
        System.out.println(g2); // Displaying result
        System.out.println(m2); // Displaying result

        //manticore attacks manticore
        System.out.println("\nManticore Attacks Manticore");
        m2.attack(m1); // calling method
        System.out.println("------Result------");
        System.out.println(m1); // Displaying result
        System.out.println(m2); // Displaying result


        //warlord attacks goblin
        System.out.println("\nWarload Attacks Goblin");
        w1.attack(g2); // calling method
        System.out.println("------Result------");
        System.out.println(w1); // Displaying result
        System.out.println(g2); // Displaying result


        //goblin attacks goblin
        System.out.println("\nGoblin Attcks Goblin");
        g2.attack(g1); // calling method
        System.out.println("------Result------");
        System.out.println(g1); // Displaying result
        System.out.println(g2); // Displaying result


        //infantry attack manticore
        System.out.println("\nInfantry Attacks Manticore");
        i2.attack(m2); // calling method
        System.out.println("------Result------");
        System.out.println(i2); // Displaying result
        System.out.println(m2); // Displaying result

        //warload attack manticore
        System.out.println("\nWarload Attacks Manticore");
        w2.attack(m1); // calling method
        System.out.println("------Result------");
        System.out.println(w2); // Displaying result
        System.out.println(m1); // Displaying result


        //amnticore changes the clan
        System.out.println("\nManticore Changes The Clan");
        m1.changeClan("Manticore 3"); // calling method
        System.out.println("------Result------");
        System.out.println(m1); // Displaying result

        //manticore attacks warlord
        System.out.println("\nManticore Attacks Warload");
        m1.attack(w2); // calling method
        System.out.println("------Result------");
        System.out.println(m1); // Displaying result
        System.out.println(w2); // Displaying result


        //warlord increases treasure
        System.out.println("\nIncrease Treasure");
        w1.increaseTreasure(30); // calling method
        System.out.println("------Result------");
        System.out.println(w1); // Displaying result


        //warlord healing
        System.out.println("\nWarload Healing");
        w1.heal(); // calling method
        System.out.println("------Result------");
        System.out.println(w1); // Displaying result



    }
}
