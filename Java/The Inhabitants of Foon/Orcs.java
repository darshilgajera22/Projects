package Assignment6_000867069;

/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

//class to handle both warlord and infantry
public class Orcs extends Monsters {

    /**
     * constructor to set all parameters to specified values
     * @param ferocity
     * @param defense
     * @param magic
     * @param health
     * @param treasure
     * @param clan
     */

    public Orcs(int ferocity, int defense, int magic, int health, int treasure, String clan) {
        super(ferocity, defense, magic, treasure, health, clan);
    }

    /**
     * constructor to set all parameters to default values
     * @param clan
     */

    public Orcs(String clan) {
        super(10, 15, 20, 5, 5, clan);
    }

}
