package assignment3_000867069;

import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.shape.ArcType;
import javafx.scene.text.Font;
import javafx.stage.Stage;

/**
 * Assignment 3 Main class to draw village and King house
 *
 * @author Darshil Gajera, 000867069
 * <p>
 * Mohawk College, 2022
 */

public class TwoVillages extends Application {

    /**
     * Start method
     *
     * @param stage The FX stage to draw on
     * @throws Exception
     */

    @Override
    public void start(Stage stage) throws Exception {
        Group root = new Group();
        Scene scene = new Scene(root);
        Canvas canvas = new Canvas(1200, 750); // Canvas Width and Height
        stage.setTitle("Assignment 3 Two Village"); // Window title
        root.getChildren().add(canvas);
        stage.setScene(scene);
        GraphicsContext gc = canvas.getGraphicsContext2D();
        gc.setFill(Color.BROWN);
        gc.fillRect(0, 0, 1200, 750);


        // King House
        gc.setFill(Color.ORANGE);
        gc.fillRect(900, 200, 250, 250);
        gc.setFill(Color.WHITE);
        gc.fillOval(930, 230, 40, 40);
        gc.setFill(Color.WHITE);
        gc.fillRect(1050, 350, 50, 100);


        /**
         * Village Constructor and setting x and y axis for villages
         */

        // Village 1
        Village v1 = new Village(10, 10, Color.RED, "Beszel");
        // Village 2
        Village v2 = new Village(100, 450, Color.BLUE, "UI Qoma");

        // Calling draw method of village
        v1.draw(gc);
        v2.draw(gc);


        // For Displaying Canvas
        stage.show();
    }

    /**
     * Main method to launch the app
     *
     * @param args unused
     */

    public static void main(String[] args) {
        launch(args);
    }
}
