package Assignment6_000867069;

/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Warlord extends Orcs {

    /**
     * Warload
     */
    public int rating; // leaderboard rating
    public Orcs[] i = new Orcs[5]; // orcs array

    /**
     * constructor to set all parameters to specified values
     * @param clan
     * @param f
     * @param d
     * @param m
     * @param t
     * @param h
     * @param rating
     * @param infants
     */

    public Warlord(String clan, int f, int d, int m, int t, int h, int rating, Orcs[] infants) {
        super(f, d, m, h, t, clan);
        this.rating = rating;
        this.i = infants;
    }

    /**
     * constructor to set al parameters to default values
     * @param clan
     */

    public Warlord(String clan) {
        super(clan);
        this.rating = 3;
        for (int j = 0; j < this.i.length; j++) {
            Orcs temp = new Orcs("Infantry" + j);
            this.i[j] = temp;
        }
    }

    /**
     * funtion to increase the leadership rating
     */

    private void increaseRating() {
        if (this.rating < 5 && this.isAlive()) {
            this.rating += rating;
        }

    }

    /**
     * deacrease leadership rating
     */

    private void decreaseRating() {
        if (this.rating > 1 && this.isAlive()) {
            this.rating -= rating;
        }
    }

    /**
     * calculate battle score differently for warlord than other monsters
     * @return int(battle score)
     */
    public int getBattleScore() {
        return (int) (Math.floor((this.getFerocity() + this.getDefense() + this.getMagic()) / 3) * 1.5);
    }

    /**
     * implement warload battle cry healing
     */

    public void heal() {
        if (this.isAlive()) {
            int healthBoost = 5 * this.rating;
            for (int j = 0; j < this.i.length; j++) {
                if (this.i[j].isAlive()) {
                    this.i[j].increaseHealth(healthBoost);
                }
            }
        }

    }


    /**
     * increase treasure and leadership rating for the warlord
     * @param value
     */

    public void increaseTreasure(int value) {
        if (this.isAlive()) {
            this.treasure += value;
            int temp = (int) Math.floor(value / 10);
            this.rating += temp;
        }

    }

    /**
     * to string
     * @return toString
     */
    public String toString() {
        return "CNAME : WARLORD " + super.toString();
    }
}
