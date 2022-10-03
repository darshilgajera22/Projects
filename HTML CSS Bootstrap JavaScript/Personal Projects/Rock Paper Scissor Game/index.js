/**
 * Author: Darshil Gajera, 000867069
 * Created On: June 29, 2022
 * Assignment 4
 * JavaScript file for DOM Manipulation and Functionalities
 */

/**
 * On page load  
 * @param load
 * @param function()
 * 
 */

window.addEventListener("load", function () {

    // getting HTML Submit button element by it's ID
    var submit = document.getElementById("submit");
    // Submit button onclick, calling function validationForm
    submit.addEventListener("click", validationForm);

    // getting game HTML div element by it's ID
    var game = document.getElementById("game");
    // setting game div visibility none
    game.style.visibility = "none";

    // getting restart button HTML element by it's ID
    var restart = document.getElementById("reStart");
    // restart button onclick, calling function restartGame
    restart.addEventListener("click", restartGame);

    // declaring javaScript variables to store user valid input
    var usergameround; // int usergameround
    var validusername; // String validusername

    /**
     * To validate username and gameround number
     * @returns true
     */
    function validationForm() {
        //getting username from HTML element by it's id     
        var username = document.getElementById("username").value;
        //getting gameround from HTML element by it's id
        var gameround = document.getElementById("gameRound").value;

        // **reference "https://www.codegrepper.com/code-examples/javascript/javascript+check+input+character"
        var usercharcheck = /^[a-zA-Z]+$/; // String character pattern

        // for username is null?
        if (username == "") {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg").innerHTML = "** Please enter User Name";
            return false; // validation false
        }
        // username length is between 4 to 8?
        else if (username.length > 8 || username.length < 4) {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg").innerHTML = "** Please enter username in 4 to 8 characters";
            return false; // validation false
        }
        //username contains any number or special character?
        else if (!username.match(usercharcheck)) {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg").innerHTML = "** Please enter only characters";
            return false; // validation false
        }
        //First letter is capital?
        else if (username[0].toUpperCase() !== username[0]) {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg").innerHTML = "** First letter is not Capital";
            return false; // validation false
        }
        // username is in ascending order?
        else if (username.length <= 8 && username.length >= 4) {
            // converting username to uppercase
            let capusername = username.toUpperCase();
            // creating an array
            var useracendingcheck = [];

            // declaring variable sorted username and temp
            var sortedUserName;
            var temp;

            // for loop to convert string in to an array
            for (var i = 0; i < capusername.length; i++) {
                // storing string as array in array
                useracendingcheck[i] = capusername[i];

                // sorting an array 
                if (i == capusername.length - 1) {
                    // storing and sorting array
                    sortedUserName = useracendingcheck.sort();
                }
            }

            // removing comma from sorted array
            temp = sortedUserName.join("");

            // cheking username is equal to sorted array
            if (temp != capusername) {
                //Displaying error by using HTML element through it's ID
                document.getElementById("errormsg").innerHTML = "** Please enter all character in ascending order";
                return false; // validation false
            }
        }
        //gameround is null?
        if (gameround == "") {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg2").innerHTML = "** Please enter game rounds";
            return false; // validation false
        }
        // gameround is nagetive
        if (gameround < 1) {
            //Displaying error by using HTML element through it's ID
            document.getElementById("errormsg2").innerHTML = "** Please enter game rounds in positive number";
            return false; // validation false
        }
        // username and gameround is null?
        else if (username != "" && gameround != "") {
            //clearing error message
            document.getElementById("errormsg").innerHTML = "";
            document.getElementById("errormsg2").innerHTML = "";

            // assigning username and gameround value to another variable
            usergameround = gameround;
            validusername = username;

            // displaying the game 
            game.style.visibility = "visible";

            // disabling user inputs username & gameround
            document.getElementById("username").disabled = true;
            document.getElementById("gameRound").disabled = true;
            document.getElementById("submit").disabled = true;

            // enabling game buttons
            rock.disabled = false;
            paper.disabled = false;
            scissor.disabled = false;

            // calling startgame function
            startgame();
            return true; // validation success

        }
    }

    // accesing HTML options buttons element by it's class
    var optionsBtns = document.querySelectorAll(".choicebtn");
    // accesing HTML options buttons element by it's ID
    var rock = document.getElementById("rock");
    var paper = document.getElementById("paper");
    var scissor = document.getElementById("scissor");

    // accesing HTML h3 element by it's ID
    var playerChoice = document.querySelector('#playertext');
    var computerChoice = document.querySelector('#computertext');
    var resultDisplay = document.querySelector('#resulttext');

    // to store individual result
    var player; // String
    var computer; // String

    /**
     * Function to start game
     * 
     */

    function startgame() {

        // declaring variables to count wins & tie
        var userresult = 0; // int
        var computerresult = 0; // int
        var tieresult = 0; // int
        // to count game round
        var counter = 0; // int


        /**
         * Button click event to play game
         * @param button
         */
        optionsBtns.forEach(function (button) {
            return button.addEventListener("click", function () {

                // on button click increasing counter
                counter++;
                // get user option through button selection
                player = button.textContent;
                // generating computer option through calling computerChoice_random function
                computerChoice_random();

                // Displaying individual choice and result
                playerChoice.innerHTML = "Player: " + player;
                computerChoice.innerHTML = "Computer: " + computer;
                resultDisplay.innerHTML = "Result: " + gameResult();


                // to count indivudual wins and tie
                if (counter <= usergameround) {
                    // condition if user wins
                    if (gameResult() == "YOU WON") {
                        // user wins counters increase
                        userresult++;
                        // displaying total user wins
                        document.getElementById("playerResult").innerHTML = userresult;
                    }
                    // condition if computer wins
                    else if (gameResult() == "YOU LOOSE") {
                        // computer wins counters increase
                        computerresult++;
                        // displaying total computer wins
                        document.getElementById("computerResult").innerHTML = computerresult;
                    }
                    else {
                        // tie counter increase
                        tieresult++;
                        // displaying total ties
                        document.getElementById("tieResult").innerHTML = tieresult;
                    }
                }

                // to show Final result 
                // condition to stop game
                if (counter == usergameround) {

                    // game option buttons setting disabled
                    optionsBtns.disabled = "true";
                    // comparing user and computer wins
                    if (userresult > computerresult) {
                        // displaying final result
                        document.getElementById("finalresult").innerHTML = validusername + " Won";
                    }
                    // comparing user and computer wins
                    else if (userresult < computerresult) {
                        // displaying final result
                        document.getElementById("finalresult").innerHTML = "Computer Won";
                    }
                    else {
                        // displaying final result
                        document.getElementById("finalresult").innerHTML = "TIE";
                    }
                    // enabling restart button
                    restart.disabled = false;
                    //disabling game option buttons
                    rock.disabled = true;
                    paper.disabled = true;
                    scissor.disabled = true;

                }
            });
        });

    }


    /**
     * Function to restart game
     */


    function restartGame() {

        // enabling game option buttons
        rock.disabled = false;
        paper.disabled = false;
        scissor.disabled = false;

        // setting individual total wins to 0
        document.getElementById("playerResult").innerHTML = 0;
        document.getElementById("computerResult").innerHTML = 0;
        document.getElementById("tieResult").innerHTML = 0;

        // setting indidual result null
        playerChoice.innerHTML = "Player: ";
        computerChoice.innerHTML = "Computer: ";
        resultDisplay.innerHTML = "Result: ";

        // clearing final result
        document.getElementById("finalresult").innerHTML = "Final Result";

        //calling function startgame
        startgame();

    }


    /**
     * to generate computer random
     * 
     */

    function computerChoice_random() {
        // generating computer random number from 1 to 3
        var randnum = Math.floor(Math.random() * 3 + 1);

        // switch case to select computer choice as per random number
        switch (randnum) {
            // to select rock
            case 1:
                computer = "ROCK";
                break;
            //to select paper
            case 2:
                computer = "PAPER";
                break;
            // to select scissor
            case 3:
                computer = "SCISSOR";
                break;
        }

    }

    /**
     * Function to select game winner
     * @returns String
     */

    function gameResult() {
        // if both select the same option
        if (player === computer) {
            return "TIE";
        }
        // player choose rock
        else if (player == 'ROCK') {
            // computer choose paper
            if (computer == 'PAPER') {
                // player loose
                return "YOU LOOSE";

            } else {
                // player wins
                return "YOU WON";
            }
        }
        // player choose scissor
        else if (player == 'SCISSOR') {
            // computer choose rock
            if (computer == 'ROCK') {
                // player loose
                return "YOU LOOSE";
            } else {
                // player wins
                return "YOU WON";
            }
        }
        // player choose paper
        else if (player == 'PAPER') {
            // computer choose scissor
            if (computer == 'SCISSOR') {
                // player loose
                return "YOU LOOSE";
            } else {
                // player wins
                return "YOU WON";
            }
        }
    }

});