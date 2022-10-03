package assignment3_000867069;

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

import java.awt.*;

/**
 * Assignment 3, Door Class
 *
 * @author Darshil Gajera, 000867069
 * <p>
 * Mohawk College, 2022
 */

public class Door {

    /**
     * x and y for Door
     * height for door
     */
    private double x;
    private double y;
    private double height;


    /**
     * Constructor
     *
     * @param x      left of door
     * @param y      top of door
     * @param height of door
     */
    public Door(double x, double y, double height) {
        this.x = x;
        this.y = y;
        this.height = height;
    }

    /**
     * Draw the door
     *
     * @param gc GraphicsContext to draw on
     */
    public void draw(GraphicsContext gc) {
        gc.setFill(Color.WHITE);
        gc.fillRect(x, y, height / 2, height);
    }
}