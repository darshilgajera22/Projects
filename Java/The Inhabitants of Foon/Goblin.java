package Assignment6_000867069;


/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Goblin extends Monsters {

    /**
     * Monster Goblin
     */
    public Goblin enemy;

    /**
     * constructor to set all parameters to specified values
     * @param enemy
     * @param ferocity
     * @param defense
     * @param magic
     * @param treasure
     * @param health
     * @param clan
     */
    public Goblin(Goblin enemy, int ferocity, int defense, int magic, int treasure, int health, String clan) {
        super(ferocity, defense, magic, treasure, health, clan);
        this.enemy = enemy;
    }

    /**
     * constructor to set all parameters to default values
     * @param clan
     */

    public Goblin(String clan) {
        super(10, 12, 13, 15, 3, clan);
    }

    /**
     * to string
     * @return tostring
     */
    public String toString() {
        return "CNAME : GOBLINE " + super.toString();
    }

}
