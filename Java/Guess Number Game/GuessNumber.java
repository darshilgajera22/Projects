package assignment5_000867069;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.scene.text.Font;
import javafx.stage.Stage;

import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;



/**
 * Guess number game, program will generate a computer random number and user have to guess the computer random number.
 * @author Darshil Gajera
 *
 */


public class GuessNumber extends Application {

    // TODO: Instance Variables for View Components and Model

    // for game title
    private Label gameName;
    // for displaying game result
    private Label gameResult;
    // for user name
    private Label enterName;
    // for user number
    private Label enterNumber;
    // to get user name and user number
    private TextField userName, userNumber;
    // submit to get user number, check to check both numbers, computerrandom to generates computer random, restart to restart the game
    private Button submit, check, computerRandom, reStart;
    // object of class GuessNumberModel
    GuessNumberModel guessNumberModel = new GuessNumberModel();


    // TODO: Private Event Handlers and Helper Methods

    /**
     * To get username and usernumber
     * @param actionEvent
     * @return none
     */
    private void buttonHandler(ActionEvent actionEvent) {
        String user = userName.getText(); // getting text of textfield
        guessNumberModel.setUserName(user); // setting username in model

        int number = Integer.parseInt(userNumber.getText()); // getting text of textfield
        guessNumberModel.setUserNumber(number); // setting usernumber in model
        gameResult.setText("You Submitted Your Number"); // Displaying message
    }

    /**
     * To generates computer random
     * @param actionEvent
     * @return none
     */

    private void computerRandom(ActionEvent actionEvent) {
        guessNumberModel.generateComputerNumber(); // calling fucntion to generate computer random
        gameResult.setText("You Generated Computer Number"); // Displaying message
    }

    /**
     * To check the both numbers
     * @param actionEvent
     * @return none
     */

    private void checkNumbers(ActionEvent actionEvent) {
        guessNumberModel.checkNum(); // calling function checknum to check both numbers
        gameResult.setText(guessNumberModel.toString()); // setting game result through tostring
        String output = guessNumberModel.getResult(); // storing game result in output
        // if user guess correct number
        if (output == "Correct! You Guess the right number"){
            reStart.setVisible(true); // restart buttton will appears
            submit.setVisible(false); // submit buttton will hide
            computerRandom.setVisible(false); // computer random buttton will hide
            check.setVisible(false); // check buttton will hide
        }
    }

    /**
     * To restart the game
     * @param actionEvent
     * @return none
     */
    private void reStart(ActionEvent actionEvent) {
        guessNumberModel.reStart(); // calling restart function
        gameResult.setText(" "); // setting gameresult null
        userNumber.setText("0"); // setting text in usernumber
        submit.setVisible(true); // submit buttton will appears
        computerRandom.setVisible(true); // computer random buttton will appears
        check.setVisible(true); // check button will appears
        reStart.setVisible(false); // restart buttton will hide
    }

    /**
     * This is where you create your components and the model and add event
     * handlers.
     *
     * @param stage The main stage
     *
     * @throws Exception
     */

    @Override
    public void start(Stage stage) throws Exception {
        Pane root = new Pane();
        Scene scene = new Scene(root, 350, 450); // set the size here
        stage.setTitle("Guess Number Game"); // set the window title here
        stage.setScene(scene);

        // TODO: Add your GUI-building code here

        // 1. Create the model
        // 2. Create the GUI components
        gameName = new Label("Guess Number "); // game title
        enterName = new Label("Enter your Name "); // username label
        userName = new TextField(""); // username textfield
        enterNumber = new Label("Enter Number between 1 to 100 "); // enter number label
        userNumber = new TextField("0"); // enternumber textfield
        gameResult = new Label(); // game result label
        submit = new Button("Submit Your Number"); // submit button
        check = new Button("Check Numbers"); // check button
        computerRandom = new Button("Generate Computer Number"); // computer random button
        reStart = new Button("Restart Game"); // restart game button
        reStart.setVisible(false); // hide the restart button

        // 3. Add components to the root
        root.getChildren().addAll(gameName, enterName, userName, userNumber, gameResult, submit, enterNumber, check, computerRandom, reStart);


        // 4. Configure the components (colors, fonts, size, location)
        root.setStyle("-fx-background-color: Lightblue;-fx-text-fill: darkblack"); // setting background color for root

        gameName.relocate(0, 5);  // relocating on x & y
        gameName.setFont(new Font("Script", 30)); // setting font
        gameName.setPrefSize(350, 10); // setting width & height
        gameName.setStyle("-fx-text-fill: LightCoral;-fx-wrap-text:true;-fx-alignment:center"); // setting color alignment and wraping the text

        enterName.relocate(0, 50); // relocating on x & y
        enterName.setFont(new Font("Sans Serif", 15)); // setting font
        enterName.setPrefSize(350, 15); // setting width & height
        enterName.setStyle("-fx-wrap-text:true; -fx-text-fill: DarkOliveGreen;-fx-alignment:center"); // setting color alignment and wraping the text

        userName.relocate(0, 80); // relocating on x & y
        userName.setFont(new Font("Sans Serif", 15)); // setting font
        userName.setPrefSize(350, 15); // setting width & height

        enterNumber.relocate(0, 120); // relocating on x & y
        enterNumber.setFont(new Font("Sans Serif", 15)); // setting font
        enterNumber.setPrefSize(350, 15); // setting width & height
        enterNumber.setStyle("-fx-wrap-text:true;-fx-text-fill: DarkOliveGreen;-fx-alignment:center"); // setting color alignment and wraping the text

        userNumber.relocate(0, 150); // relocating on x & y
        userNumber.setFont(new Font("Sans Serif", 15)); // setting font
        userNumber.setPrefSize(350, 15); // setting width & height

        submit.relocate(10, 200); // relocating on x & y
        submit.setStyle("-fx-background-color: DarkSlateBlue; -fx-text-fill: White"); // setting color alignment and wraping the text
        submit.setPrefSize(150, 10); // setting width & height

        computerRandom.relocate(170, 200); // relocating on x & y
        computerRandom.setStyle("-fx-background-color: DarkSlateBlue; -fx-text-fill: White"); // setting color alignment and wraping the text
        computerRandom.setPrefSize(170, 10); // setting width & height

        gameResult.relocate(0, 260); // relocating on x & y
        gameResult.setFont(new Font("Helvetica", 20)); // setting font
        gameResult.setStyle("-fx-wrap-text:true;-fx-text-fill: Teal;-fx-alignment:center"); // setting color alignment and wraping the text


        check.relocate(105, 390); // relocating on x & y
        check.setStyle("-fx-background-color: DarkSlateBlue; -fx-text-fill: White;-fx-alignment:center"); // setting color alignment and wraping the text
        check.setPrefSize(150, 10); // setting width & height

        reStart.relocate(105, 420); // relocating on x & y
        reStart.setStyle("-fx-background-color: DarkSlateBlue; -fx-text-fill: White"); // setting color alignment and wraping the text
        reStart.setPrefSize(150, 10); // setting width & height

        // 5. Add Event Handlers and do final setup
        submit.setOnAction(this::buttonHandler); // onclick button event handlers
        check.setOnAction(this::checkNumbers); // onclick button event handlers
        computerRandom.setOnAction(this::computerRandom); // onclick button event handlers
        reStart.setOnAction(this::reStart); // onclick button event handlers

        // 6. Show the stage
        stage.show();
    }


    /**
     * Make no changes here.
     *
     * @param args unused
     */
    public static void main(String[] args) {
        launch(args);
    }
}



