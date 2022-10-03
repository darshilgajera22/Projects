package Assignment6_000867069;

/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Infantry extends Orcs {
    /**
     * constructor to set all parameters to specified values
     * @param ferocity
     * @param defense
     * @param magic
     * @param health
     * @param treasure
     * @param clan
     */
    public Infantry(int ferocity, int defense, int magic, int health, int treasure, String clan) {
        super(ferocity, defense, magic, treasure, health, clan);
    }

    /**
     * constructor to set all parameters to default values
     * @param clan
     */

    public Infantry(String clan) {
        super(clan);
    }

    /**
     * to string
     * @return toString
     */

    public String toString() {
        return "CNAME : INFANTRY " + super.toString();
    }
}
