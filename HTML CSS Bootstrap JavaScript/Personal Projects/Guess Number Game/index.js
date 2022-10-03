/**
 * Author: Darshil Gajera, 000867069
 * Created On: July 21, 2022
 * Assignment 5
 * JavaScript file for SVG Animation and user input validation
 */

/**
 * Function to on click focus on elements 
 */
function focusfunction() {
    // getting number field and setting on click focus color
    document.getElementById("usernumber").style.background = "thistle";
}

/**
 * On page load  
 * @param load
 * @param function()
 */

window.addEventListener("load", function () {

    // getting checknum button through it ID
    var checknum = document.getElementById("checknum");
    // getting text element through it ID
    var result = document.getElementById("output");
    // getting restart button through it ID
    var restart = document.getElementById("restart");
    // declaring computer random variable
    var computerRandom;
    // declaring valid user name
    var validusernum;
    // setting restart button disabled
    restart.disabled = true;
    // setting counter 0
    var counter = 0;
    // getting polygone through ID
    var svgtries = document.getElementById("totaltries");

    // setting element null
    var element = null;
    // setting cordinates to -700
    var cordinates = -700;
    // calling fucntion polyanim for svg element animation
    element = this.setInterval(polyanim, 9);

    /**
     * Function to animate polygone
     * reference: https://www.w3schools.com/graphics/svg_intro.asp
     */
    function polyanim() {
        // clear interval at 0 coordinates
        if (cordinates == 0) {
            clearInterval(element);
        }
        else {
            // drop down the svg elements
            cordinates += 5;
            // setting coordinated for animation
            svgtries.style.top = cordinates + 'px';
        }
    }


    // initializing computer number randomly from 0 to 100
    computerRandom = Math.round(Math.random() * 100);
    console.log("Computer Random1 " + computerRandom); // debug

    // on checknum button click, calling function validate number to validate 
    checknum.addEventListener("click", validateNumber);
    // on restart button click, calling function to restart the game
    restart.addEventListener("click", restartGame);


    /**
     * Function to validate user number
     * @returns boolean
     */
    function validateNumber() {
        // getting user number through HTML input element ID
        var usernumber = document.getElementById("usernumber").value;
        // getting paragraph to display error msg
        var errormsg = document.getElementById("errormsg");

        // to check if user number is null
        if (usernumber == "") {
            // Displaying error 
            errormsg.innerHTML = "* Please Enter Your Number";
            return false; // validation failed
        }
        // to check if user number is negative
        else if (usernumber < 0) {
            // Displaying error 
            errormsg.innerHTML = "* Please Enter Positive Number";
            return false; // validation failed
        }
        // to check if user number is greater than 100
        else if (usernumber > 100) {
            // Displaying error 
            errormsg.innerHTML = "* Please Enter Number Between 1 To 100";
            return false; // validation failed
        }
        // user number is valid
        else {
            errormsg.innerHTML = ""; // removing error message
            validusernum = usernumber; // assign user number to validusernum
            checkNumber(); // calling checknum function
            console.log("Computer Random2 " + computerRandom); // debug
            return true; // validation success
        }
    }

    /**
     * Function to check both Numbers and displaying result
     * User Number & Computer Number
     * 
     */
    function checkNumber() {
        console.log("Computer Random3 " + computerRandom); // debug
        // counter increment on button click
        counter++;
        console.log(counter); // debug

        //setting opacity low to off set polygone
        document.getElementById("polytries" + counter).style.opacity = 0.2;

        if (counter < 5) {
            // if both number are same
            if (validusernum == computerRandom) {
                // displaying result
                result.innerHTML = "You guess the right number";
                //counter = 5;
            }
            // if user guess too high number
            else if (validusernum > computerRandom + 10) {
                // displaying result
                result.innerHTML = "You guess too high number";

            }
            // if user guess is near to computer number
            else if (validusernum > computerRandom) {
                // displaying result
                result.innerHTML = "You guess high number";

            }
            // if user guess too low number
            else if (validusernum > computerRandom - 10) {
                // displaying result
                result.innerHTML = "You guess low number";

            }
            // if user guess is near to computer number
            else if (validusernum < computerRandom) {
                // displaying result
                result.innerHTML = "You guess too low number";

            }
        }
        else if (counter == 5) {
            // displaying result
            result.innerHTML = "Game Over";
            // setting checknum disabled
            checknum.disabled = true;
            // setting restart button enable
            restart.disabled = false;
        }
        else {
            // setting checknum disabled
            checknum.disabled = true;
            // setting restart button enable
            restart.disabled = false;

        }
    }

    /**
     * Function to restart the game
     * 
     */
    function restartGame() {
        counter = 0; // setting counter to zero
        computerRandom = Math.round(Math.random() * 100); // generating new random number
        console.log("Computer Random4 " + computerRandom); // debug
        document.getElementById("usernumber").value = ""; // setting user value to null
        result.innerHTML = " Result "; // clear the result
        checknum.disabled = false; // setting checknum button enable
        restart.disabled = true; // setting restart button disable
        // setting opacity to normal for polygone
        for (var i = 1; i <= 5; i++) {
            document.getElementById("polytries" + i).style.opacity = 1;
        }
    }


});