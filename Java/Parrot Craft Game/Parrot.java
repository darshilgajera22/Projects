package assignment2_000867069;

/**
 * Assignment 2
 * <p>
 * Parrot Class contains Parrot's information
 * ParrotCraft Game
 * Implemented through object-oriented programming
 *
 * @author Darshil Gajera (000867069)
 */


public class Parrot {

    //Private Parrot's variables
    private String parrotName = "Julius";
    private boolean tamed;
    private boolean alive;
    private boolean flying;
    private int health = 3;
    private double seed;
    private int cookie;


    /**
     * to feed cookie
     *
     * @param cookie
     */
    public void feedcookie(int cookie) {
        this.cookie = this.cookie + cookie;
        this.alive = false;
        setAlive(false);
    }

    /**
     * to feed seed
     *
     * @param seed
     */

    public void feedseed(double seed) {
        this.seed = this.seed + seed;
        setTamed(true);
        if (this.health < 3) {
            this.health = this.health + 1;
        }
    }


    /**
     * to feed
     *
     * @param cookie
     * @param seed
     */
    public void feed(int cookie, double seed) {
        setSeed(this.seed + seed);
        feedcookie(cookie);
    }


    /**
     * to command fly or sit
     *
     * @param comm
     */

    public void command(int comm) {
        if (comm == 1) {
            this.flying = true;
        } else {
            this.flying = false;
        }
    }


    /**
     * to hit parrot
     */
    public void hit() {
        this.health -= 1;
        if (isTamed() == true) {
            this.tamed = false;
        }
    }


    /**
     * constructor of class to get values of variables
     *
     * @param name
     * @param seed
     * @param alive
     * @param tamed
     * @param health
     * @param flying
     */

    public Parrot(String name, double seed, boolean alive, boolean tamed, int health, boolean flying) {
        this.parrotName = name;
        this.seed = seed;
        this.alive = alive;
        this.tamed = tamed;
        this.health = health;
        this.flying = flying;
    }

    /**
     * tostring function to print output
     *
     * @return
     */

    @Override
    public String toString() {
        String tamed = this.tamed ? " Tamed" : " Untamed ";
        String alive = this.alive ? " Alive " : " Dead ";
        String flying = this.flying ? " Flying " : " Sitting ";
        String health = this.health == 1 ? " Heart " : "Hearts";
        return tamed + " " + alive + " Parrot " + parrotName + " : " + seed + " kg " + this.health + " " + health + "," + flying;
    }

    /**
     * getter parrotname
     *
     * @return
     */

    public String getParrotName() {
        return parrotName;
    }

    /**
     * setter parrotname
     *
     * @param parrotName
     */

    public void setParrotName(String parrotName) {
        this.parrotName = parrotName;
    }


    /**
     * getter tamed
     *
     * @return
     */
    public boolean isTamed() {
        return tamed;
    }

    /**
     * setter tamed
     *
     * @param tamed
     */

    public void setTamed(boolean tamed) {
        this.tamed = tamed;
    }

    /**
     * getter alive
     *
     * @return
     */

    public boolean isAlive() {
        return alive;
    }

    /**
     * setter alive
     *
     * @param alive
     */

    public void setAlive(boolean alive) {
        this.alive = alive;
    }

    /**
     * getter flying
     *
     * @return
     */
    public boolean isFlying() {
        return flying;
    }

    /**
     * setter flying
     *
     * @param flying
     */

    public void setFlying(boolean flying) {
        this.flying = flying;
    }


    /**
     * getter health
     *
     * @return
     */
    public int getHealth() {
        return health;
    }

    /**
     * setter health
     *
     * @param health
     */

    public void setHealth(int health) {
        this.health = health;
    }

    /**
     * getter seed
     *
     * @return
     */

    public double getSeed() {
        return seed;
    }

    /**
     * setter seed
     *
     * @param seed
     */

    public void setSeed(double seed) {
        this.seed = seed;
    }
}
