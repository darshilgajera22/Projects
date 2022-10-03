package Assignment6_000867069;

/**
 * Game of 3 Monster of Foon.
 * @author Darshil Gajera, Akshay Patel
 *
 */

public class Manticore extends Monsters {

    /**
     * constructor to set all parameters to specified values
     * @param ferocity
     * @param defense
     * @param magic
     * @param health
     * @param treasure
     * @param clan
     */

    public Manticore(int ferocity, int defense, int magic, int health, int treasure, String clan) {
        super(ferocity, defense, magic, treasure, health, clan);
    }

    /**
     * constructor to set al parameters to default values
     * @param clan
     */

    public Manticore(String clan) {
        super(8, 12, 10, 10, 4, clan);
    }

    /**
     * function to change clan of a manticore
     * @param clan
     */

    public void changeClan(String clan) {
        if (this.isAlive()) {
            this.clan = clan;
        } else {
            System.out.println("Dead Manticore can't change the clan!!");
        }
    }

    /**
     * To String
     * @return tostring
     */
    public String toString() {
        return "CNAME : MANTICORE " + super.toString();
    }


}
