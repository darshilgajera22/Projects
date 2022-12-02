/**
 * Author: Darshil Gajera, 000867069
 * Created On: July 30, 2022 
 * Assignment 6
 * For webpage Functionality
 */


/**
 * On page load  
 * @param load
 * @param function()
 */

window.addEventListener("load", function () {
    /**
     * to prevent default
     * @param submit
     * @param function(event)
     */
    document.forms.ajaxform.addEventListener("submit", function (event) {
        event.preventDefault();
    });

    /**
     * to fetch assignment header on first button click
     * @param click
     * @param function(event)
     */
    document.forms.ajaxform.header_button.addEventListener("click", function (event) {

        // url to fetch data
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php";
        // get method to fetch data
        fetch(url, { credentials: 'include' })
            .then(response => response.text())
            .then(success1) // on success calling function
    });

    /**
     * to fetch series images and data on second button click
     * @param click
     * @param function(event)
     */
    document.forms.ajaxform.seriescharacter_button.addEventListener("click", function (event) {
        // to get user input
        let usertextinput = document.getElementById("userchoice").value;
        // url to fetch data and calling validation function to validate user input
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php?choice=" + validation(usertextinput);
        // get method to fetch data
        fetch(url, { credentials: 'include' })
            .then(response => response.json())
            .then(success2) // on success calling function

    });

    /**
     * to fetch series images and data on third button click
     * @param click
     * @param function(event)
     */
    document.forms.ajaxform.tablebutton.addEventListener("click", function (event) {
        // to get user input
        let usertextinput = document.getElementById("userchoice").value;
        // calling validation function and user input as parameters
        let params = "choice=" + validation(usertextinput);
        // url to fetch data and calling validation function to validate user input
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php";
        // post method to fetch data
        fetch(url, {
            credentials: 'include',
            method: 'POST',
            headers: { "Content-type": "application/x-www-form-urlencoded" },
            body: params
        })
            .then(response => response.json())
            .then(success3); // on success calling function
    });

});


/**
 * to validate user input
 * @param {*} usertextinput 
 * @returns usertextinput
 * 
 */
function validation(usertextinput) {

    // if user input is null
    if (usertextinput == "") {
        // to error message
        document.getElementById("validationmsg").innerHTML = " **   Please Enter Series Name";
        return false; // validation fail
    }
    // if user input is correct
    else if (usertextinput == "starwars" || usertextinput == "mario") {
        // to clear error message
        document.getElementById("validationmsg").innerHTML = "";
        // disabling user input field
        document.getElementById("userchoice").disabled = true;
        return usertextinput; // validation success
    }
    // if user input is incorrect
    else {
        // to error message
        document.getElementById("validationmsg").innerHTML = "**    Please Enter only starwars or mario";
        return false; // validation fail
    }
}

/**
 * to display header 
 * @param {*} text 
 */
function success1(text) {
    // getting html element by ID
    let header = document.getElementById("header");
    // setting header data
    header.innerHTML = "<h1 class= 'text-center'>" + text + " #000867069" + "</h1>";
}

/**
 * to display series image and data
 * @param {*} d 
 */
function success2(d) {
    // variable to all image data
    var allimagedata = "";
    // getting user input
    let usertextinput = document.getElementById("userchoice").value;

    // array length is 3 div width 33%
    if (d.length == 3) {
        // accessing array element 
        for (let i = 0; i < d.length; i++) {
            // storing single image data in one variable
            let singleimgdata = "<h2>" + d[i].series + "</h2>" +
                "<img src='" + d[i].url + "' />" +
                "<p>" + d[i].name + "</p>";
            // storing all image data in one variable    
            allimagedata += "<div class = 'col-sm-4'>" + singleimgdata + "</div>";
        }
    }
    // array length is 2 div width 50%
    else if (d.length == 2) {
        // accessing array element 
        for (let i = 0; i < d.length; i++) {
            // storing single image data in one variable
            let singleimgdata = "<h2>" + d[i].series + "</h2>" +
                "<img src='" + d[i].url + "' />" +
                "<p>" + d[i].name + "</p>";
            // storing all image data in one variable
            allimagedata += "<div class = 'col-sm-6'>" + singleimgdata + "</div>";
        }
    }
    // array length is 1 div width 100%
    else {
        // accessing array element 
        for (let j = 0; j < d.length; j++) {
            // storing single image data in one variable
            let singleimgdata = "<h2>" + d[j].series + "</h2>" +
                "<img src='" + d[j].url + "' />" +
                "<p>" + d[j].name + "</p>";
            // storing all image data in one variable
            allimagedata += "<div class='col-sm-12'>" + singleimgdata + "</div>";
        }
    }
    // displaying image data in html element
    document.getElementById("image_data").innerHTML = allimagedata;
    // getting html element through ID
    let img_caption = document.getElementById("img_caption");
    // user input is starwars 
    if (usertextinput == "starwars") {
        // this caption will display
        img_caption.innerHTML = "Star Wars &copy; & TM 2022 Lucasfilm Ltd. All rights reserved. Visual material &copy; 2022 Electronic Arts Inc.";
    }
    // user input is mario
    else if (usertextinput == "mario") {
        // this caption will display
        img_caption.innerHTML = "Game trademarks and copyrights are properties of their respective owners. Nintendo properties are trademarks of Nintendo. &copy; 2019 Nintendo.";
    }
}


/**
 * to display table
 * @param {*} d 
 */
function success3(d) {

    // getting element through its ID
    table = document.getElementById("serieslink_table");
    // setting table heading 
    tabledata = "<tr><th>Series</th><th>Name</th><th>Link</th></tr>";

    // accessing array element
    for (let k = 0; k < d.length; k++) {
        // setting row blank
        row = "";
        // setting every data in row
        row = "<td>" + d[k].series + "</td>" +
            "<td>" + d[k].name + "</td>" +
            "<td><a href=" + d[k].url + ">" + d[k].url + "</a></td>";
        // setting row in table data
        tabledata += "<tr>" + row + "</tr>";
    }

    // getting user input
    let usertextinput = document.getElementById("userchoice").value;
    // calling validation function
    let userincap = validation(usertextinput);
    // user input is starwars     
    if (userincap == "starwars") {
        // this caption will display
        table.innerHTML = tabledata + "<caption>Star Wars &copy; &and; TM 2022 Lucasfilm Ltd. All rights reserved. Visual material &copy; 2022 Electronic Arts Inc. </caption>";
    }
    // user input is mario 
    else if (userincap == "mario") {
        // this caption will display
        table.innerHTML = tabledata + "<caption>Game trademarks and copyrights are properties of their respective owners. Nintendo properties are trademarks of Nintendo. &copy; 2019 Nintendo.  </caption>";
    }
}