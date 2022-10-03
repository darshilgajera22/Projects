package assignment3_000867069;

import javafx.scene.canvas.GraphicsContext;

import javafx.scene.paint.Color;


/**
 * Assignment 3, House Class
 *
 * @author Darshil Gajera, 000867069
 * <p>
 * Mohawk College, 2022
 */

public class House {

    /**
     * x and y location for house
     */
    private double x;
    private double y;

    /**
     * House size
     */
    private double size;

    /**
     * people living in house
     */
    private int occupants;

    /**
     * house color
     */
    private Color color;

    /**
     * Constructor
     *
     * @param x     left of house
     * @param y     top of house
     * @param size  size of house
     * @param color color of house
     */
    public House(double x, double y, double size, Color color) {
        this.x = x;
        this.y = y;
        this.size = size;
        this.color = color;
    }

    public House(double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     * Draw the house
     *
     * @param gc GraphicsContext to draw on
     */
    public void draw(GraphicsContext gc) {
        gc.setFill(color);
        gc.fillRect(x, y, size, size);
        Door d1 = new Door(x + 65, y + size / 2, size / 2);
        d1.draw(gc);
        Window w1 = new Window(x + 20, y + 20, 15);
        w1.draw(gc);

    }

    // getter of occupants
    public int getOccupants() {
        return occupants;
    }

    // setter of occupants
    public void setOccupants(int n) {
        this.occupants = n;
    }

    // getter of size
    public double getSize() {
        return size;
    }
}
