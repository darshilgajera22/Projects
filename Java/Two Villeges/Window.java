package assignment3_000867069;

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;


/**
 * Assignment 3, Window Class
 *
 * @author Darshil Gajera, 000867069
 * <p>
 * Mohawk College, 2022
 */
public class Window {

    private double x;
    private double y;
    private double diameter;

    /**
     * Constructor
     *
     * @param x        left of window
     * @param y        top of window
     * @param diameter diameter of window
     */
    public Window(double x, double y, double diameter) {
        this.x = x;
        this.y = y;
        this.diameter = diameter;
    }

    /**
     * Draw the Window
     *
     * @param gc GraphicsContext to draw on
     */
    public void draw(GraphicsContext gc) {
        gc.setFill(Color.WHITE);
        gc.fillOval(x, y, diameter, diameter);
    }
}
