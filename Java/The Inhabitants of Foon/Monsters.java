package Assignment6_000867069;


/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Monsters {
    //instance variables to store the values
    public String clan; // Monsters Clan name
    private int ferocity = 0; // Monsters ferocity
    private int defense = 0; // Monsters defence
    private int magic = 0; // Monsters magic
    public int treasure = 0; // mosters treasure
    private int health = 0; // monsters health


    /**
     * super class constructor to instantiate all variables
     * @param ferocity
     * @param defense
     * @param magic
     * @param treasure
     * @param health
     * @param clan
     */

    public Monsters(int ferocity, int defense, int magic, int treasure, int health, String clan) {
        this.ferocity = ferocity;
        this.defense = defense;
        this.magic = magic;
        this.treasure = treasure;
        this.health = health;
        this.clan = clan;
    }

    /**
     * increase ferocity by 1
     *
     */

    public void increaseFerocity() {
        if (this.ferocity < 20) {
            this.ferocity += this.ferocity;
        }
    }

    /**
     * increase defense by 1
     */

    public void increaseDefense() {
        if (this.defense < 20) {
            this.defense += this.defense;
        }
    }

    /**
     * increase magic by 1
     */

    public void increaseMagic() {
        if (this.magic < 20) {
            this.magic += this.magic;
        }
    }

    /**
     * decrease ferocity by 1
     */

    public void decreaseFerocity() {
        if (this.ferocity > 20) {
            this.ferocity -= this.ferocity;
        }
    }

    /**
     * decrease defense by 1
     */

    public void decreaseDefense() {
        if (this.defense > 20) {
            this.defense -= this.defense;
        }
    }

    /**
     * decrease magic by 1
     */

    public void decreaseMagic() {
        if (this.magic > 20) {
            this.magic -= this.magic;
        }
    }

    /**
     * get ferocity
     * @return ferocity
     */

    public int getFerocity() {
        return this.ferocity;
    }

    /**
     * get defense
     * @return defence
     */

    public int getDefense() {
        return this.defense;
    }

    /**
     * get magic
     * @return magic
     */

    public int getMagic() {
        return this.magic;
    }

    /**
     * get health
     * @return health
     */

    public int getHealth() {
        return this.health;
    }

    /**
     * get treasure
     * @return treasure
     */

    public int getTreasure() {
        return this.treasure;
    }

    /**
     * get clan
     * @return clan
     */

    public String getClan() {
        return this.clan;
    }

    /**
     * increase health by given amount
     * @param value
     */

    public void increaseHealth(int value) {
        this.health += value;
    }

    /**
     * decrease health by given amount
     * @param value
     */

    public void decreaseHealth(int value) {
        this.health -= value;
    }

    /**
     * return whether the monster is alive or dead
     * @return health
     */

    public boolean isAlive() {
        return this.health > 0;
    }

    /**
     * increase treasure by given value
     * @param value
     */

    public void increaseTreasure(int value) {
        if (this.isAlive()) {
            this.treasure += value;
        }
    }

    /**
     * decrease the treasure by given value
     * @param value
     */

    public void decreaseTreasure(int value) {
        if (this.isAlive()) {
            this.treasure -= value;
        }
    }

    /**
     * calculate battlescore for all other monsters other than Warlord
     * @return int (battle score)
     */

    public int getBattleScore() {
        return (int) Math.floor((this.ferocity + this.defense + this.magic) / 3);
    }
    /**
     * handle attack function
     * @param m2
     */

    public void attack(Monsters m2) {
        if (this.isAlive() && m2.isAlive()) {
            int b1 = this.getBattleScore();
            int b2 = m2.getBattleScore();
            if (b2 > b1) {
                this.decreaseHealth(b2 - b1);
            } else {
                m2.decreaseHealth(b1 - b2);
            }
        } else {
            System.out.println("Cannot attack a dead monster!!");
        }
    }

    /**
     * print the object details
     * @return toString
     */

    public String toString() {
        String s = this.isAlive() ? "Alive" : "Dead";
        return " Status: " + s + " CLAN AFFILIATION: " + this.getClan() + " Ferocity: " + this.getFerocity() + " Defense: " + this.getDefense() + " Magic: " + this.getMagic() + " Trasures: " + this.getTreasure() + " Health: " + this.getHealth();
    }

}
