package assignment3_000867069;

import javafx.scene.canvas.GraphicsContext;

import javafx.scene.paint.Color;

import java.lang.Math;

/**
 * Assignment 3, Village Class
 *
 * @author Darshil Gajera, 000867069
 *
 * Mohawk College, 2022
 */
public class Village {

    /**
     * X and Y location for villages
     */
    private double x;
    private double y;

    /**
     * Size of Village
     */
    private double size = Math.round(Math.random() * 100);

    /**
     * Village house color
     */
    private Color color;

    /**
     * Village name
     */
    private String name;

    /**
     * Constructor
     *
     * @param x     left of Village
     * @param y     top of village
     * @param color house color of village
     * @param name  village name
     */
    public Village(double x, double y, Color color, String name) {
        this.x = x;
        this.y = y;
        this.color = color;
        this.name = name;
    }

    /**
     * Draw the houses
     *
     * @param gc GraphicsContext to draw on
     */
    public void draw(GraphicsContext gc) {

        // Draw house 1
        House h1 = new House(x + 10 + Math.random() * 20, y + 30, 100 + Math.random() * 100, color);
        h1.setOccupants((int) (Math.random() * 5));
        h1.draw(gc);

        // Draw house 2
        House h2 = new House(x + 200 + Math.random() * 20, y + 60, 100 + Math.random() * 100, color);
        h2.setOccupants((int) (Math.random() * 5));
        h2.draw(gc);

        // Draw house 3
        House h3 = new House(x + 400 + Math.random() * 20, y + 70, 100 + Math.random() * 100, color);
        h3.setOccupants((int) (Math.random() * 50));
        h3.draw(gc);

        // Text to display village size and population
        int population = h1.getOccupants() + h2.getOccupants() + h3.getOccupants();
        gc.setFill(Color.BLACK);
        gc.fillText(name + "(" + size + "m, Population " + population + ")", x + 150, y + 250, 400);

    }

}
