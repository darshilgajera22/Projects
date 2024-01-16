/**
 * page load event
 */
window.addEventListener("load", function () {

    // continue request to get cart data
    let request = new Request('UserCart.php',
        {
            method: 'post',
            type: 'basic',
            headers: {
                "Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
            },
        }
    );
    fetch(request)
        .then(response => response.json())
        .then(success)


    // to add item in cart button listener
    let additembtn = this.document.getElementById("move");
    additembtn.addEventListener("click", function (event) {

        // getting product value
        let addProduct = document.getElementById("MoveInCart").value;

        // request to add product
        let request = new Request('UserCart.php',
        {
            method: 'post',
            type: 'basic',
            headers: {"Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
            },
            body: 'addProduct='+addProduct
        });
        fetch(request)
            .then(response => response.json())
            .then(success)
    });

});


/**
 * display updated Cart 
 * @param {*} text 
 */
function success(text) {
    console.log(text);

    // to display cart 
    let cartItems = "<table class='table table-striped'><tr><th>Product Name</th><th>Product Price</th><th>Remove</th></tr>";
    let total = 0; // to display total of cart items

    for (let i = 0; i < text.length; i++) {
        // adding rows in cart
        cartItems += "<tr><td>" + text[i].product_name + "</td><td>" + text[i].product_price + "</td>";
        //cartItems += "<td><form method='POST'><input type= 'image' class='removeimg' src='images\\canceling.png' width='40' height='40'><input type='hidden' id='removeValue' value='" + text[i].product_id + "'></form></td></tr>";
        cartItems += "<td><form action='index.php?'><img id='removeitem' onclick='deleteItem(\""+text[i].product_id+"\")' src='images\\canceling.png' width='40' height='40'></img></form></td></tr>";       
        total += parseInt(text[i].product_price);
    }
    cartItems += "</table>";
    console.log(cartItems);
    // setting cart css
    document.querySelector("th").style.cssText = "color: white !important: backgroundColor: #54A494 !important";
    document.querySelector("td").style.backgroundColor = "#C5D0CE !important";
    document.getElementById("cart").innerHTML = cartItems;
    document.getElementById("BillAmount").innerHTML = "<h6>Total Amount $" + total.toFixed(2) + "</h6>";
    
}

/**
 * Remove from the Cart
 * @param {*} removeProduct 
 */
function deleteItem(removeProduct){
    console.log(removeProduct);

   let request = new Request('UserCart.php',
       {
           method: 'post',
           type: 'basic',
           headers: {
               "Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
           },
           body: 'removeProduct='+ removeProduct
       }
   );

   
    fetch(request)
        .then(response => response.json())
        .then(success)

}





