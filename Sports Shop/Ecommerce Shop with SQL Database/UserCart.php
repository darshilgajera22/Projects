<?php
session_start();
$sessionid = session_id();
require_once "connect.php";

// to store cart data
$cartdata = [];
// to add product in session
if (isset($_POST['addProduct'])) {
    $addProduct = $_POST['addProduct'];
    $query = "INSERT INTO session(session_id,session_data) VALUES(?,?)";
    $cursor = $dbh->prepare($query);
    $cursor->execute([session_id(), $addProduct]);
    // update quantity in catalogue table
    $query1 = "UPDATE catalogue SET product_quantity = product_quantity-1 WHERE product_id = '$addProduct'";
    $cursor2 = $dbh->query($query1);
} 
// to remove product from the session
if (isset($_POST['removeProduct'])) {
    $removeProduct = $_POST['removeProduct'];
    $query = "DELETE FROM session WHERE session_id = ? AND session_data = ? LIMIT 1";
    $cursor = $dbh->prepare($query);
    $cursor->execute([$sessionid, $removeProduct]);
    // update quantity in catalogue table
    $query1 = "UPDATE catalogue SET product_quantity = product_quantity+1 WHERE product_id = ?";
    $cursor1 = $dbh->prepare($query1);
    $cursor1->execute([$removeProduct]);

}

// retrive all rows from session table and price and product name from catalogue table
$query = "SELECT product_id,product_name,product_price from catalogue cat JOIN session sess ON sess.session_data = cat.product_id WHERE sess.session_id = ?";
$cursor = $dbh->prepare($query);
$cursor->execute([session_id()]);
// assigning all data to array $cartdata
while ($row = $cursor->fetch()) {
    array_push($cartdata, ["product_id" => $row["product_id"], "product_name" => $row["product_name"], "product_price" => $row["product_price"]]);
}
echo json_encode($cartdata);
