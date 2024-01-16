<?php
session_start();

/**
 * PHPApp.php to call webservice
 * 
 * Darshil Gajera, December 2022
 */

include "callAPI.php";

/**
 * If request is set
 */
if (isset($_GET["request"])) {
    $request = $_GET["request"];

    // display categoris
    if ($request == "categories") {
        $row = callAPI("/webservice/product/categories/", "GET");
        $data = $row["data"];
        
        $category = "<div class='itemCategorymenu'>";
        
        for ($i = 0; $i < count($data); $i++) {
            $category .= "<div onclick='displaycategorisProducts(\"" . $data[$i] . "\")'>" . $data[$i] . "</div>";
        }
        $category .= "<div onclick='displaycategorisProducts(allproduct)'>All Products</div>";
        $category .= "</div>";
        echo $category;
    }
    // display all products
    if ($request == "AllProducts" && isset($_GET["start"]) && isset($_GET["length"])) {
        $start = $_GET["start"];
        $length = $_GET["length"];

        $row = callAPI("/webservice/product?start=" . $start . "&length=" . $length, "GET");
        $data = $row["data"];

        $productsTable = "<tr><th>Product ID</th><th>Product Name</th><th>Product Description</th><th>Product Price</th><th>Product Quantity</th></tr>";

        for ($i = 0; $i < count($data); $i++) {
            $productsTable .= "<tr>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_id"] . "</div></td>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_name"] . "</div></td>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_description"] . "</div></td>";
            $productsTable .= "<td>" . $data[$i]["product_price"] . "</td>";
            if ($data[$i]["product_quantity"] >= 1) {
                $productsTable .= "<td>" . $data[$i]["product_quantity"] . "</td>";
            } else {
                $productsTable .= "<td class='outstockmsg'>Out Of Stock</td>";
            }
            $productsTable .= "</tr>";
        }

        $productsTable .= "<div class = 'nextprev'>";
        $productsTable .= "<button onclick='prev(\"" . $start . "\",\"" . $length . "\")'>Prev</button>";
        $productsTable .= "<button onclick='next(\"" . $start . "\",\"" . $length . "\")'>Next</button>";
        $productsTable .= "</div>";
        echo $productsTable;
    }
    // display product as per category
    if ($request == "SportsProducts" && isset($_GET["start"]) && isset($_GET["length"]) && isset($_GET["category"])) {
        $category = $_GET["category"];
        $start = $_GET["start"];
        $length = $_GET["length"];

        $row = callAPI("/webservice/product?category=" . $category . "&start=" . $start . "&length=" . $length, "GET");
        $data = $row["data"];

        $productsTable = "<tr><th>Product ID</th><th>Product Name</th><th>Product Description</th><th>Product Price</th><th>Product Quantity</th></tr>";
        ///die($data);
        for ($i = 0; $i < count($data); $i++) {
            $productsTable .= "<tr>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_id"] . "</div></td>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_name"] . "</div></td>";
            $productsTable .= "<td><div onclick='displayProductData(\"" . $data[$i]["product_id"] . "\")'>" . $data[$i]["product_description"] . "</div></td>";
            $productsTable .= "<td>" . $data[$i]["product_price"] . "</td>";
            if ($data[$i]["product_quantity"] >= 1) {
                $productsTable .= "<td>" . $data[$i]["product_quantity"] . "</td>";
            } else {
                $productsTable .= "<td class='outstockmsg'>Out Of Stock</td>";
            }
            $productsTable .= "</tr>";
        }
        if ($category == "AllProducts") {
            $productsTable .= "<div class = 'nextprev'>";
            $productsTable .= "<button class='prevbtn' onclick='prev(\"" . $start . "\",\"" . $length . "\")'>Prev</button>";
            $productsTable .= "<button class='nextbtn' onclick='next(\"" . $start . "\",\"" . $length . "\")'>Next</button>";
            $productsTable .= "</div>";
        }

        echo $productsTable;
    }
    // products details
    if ($request == "productData" && isset($_GET["productID"])) {
        $productID = $_GET["productID"];

        $row = callAPI("/webservice/product?productid=" . $productID, "GET");
        $data = $row["data"];

        $productdataTable = "";
        for ($i = 0; $i < count($data); $i++) {
            $productdataTable .= "<tr><th>Product ID</th><td>" . $data[$i]["product_id"] . "</td></tr>";
            $productdataTable .= "<tr><th>Product Name</th><td>" . $data[$i]["product_name"] . "</td></tr>";
            $productdataTable .= "<tr><th>Product Description</th><td>" . $data[$i]["product_description"] . "</td></tr>";
            $productdataTable .= "<tr><th>Product Price</th><td>" . $data[$i]["product_price"] . "</td></tr>";
            if ($data[$i]["product_quantity"] >= 1) {
                $productdataTable .= "<button id='move' class='m-3 text-center' onclick='addtocart(\"" . $data[$i]["product_id"] . "\")'>Add to Cart</button>";
            } else {
                $productdataTable .= "<tr><th colspan=2 class='outstockmsg'>Out of Stock</th></tr>";
                $allpro = "AllProducts";
                $productdataTable .= "<button id='backbtn' onclick='displaycategorisProducts(\"" . $allpro . "\")'>Back</button>";
            }
        }

        echo $productdataTable;
    }

    // add products in to the cart
    if ($request == "addtocart") {
        if (isset($_GET["productID"])) {
            $productID = json_encode(["product_id" => $_GET["productID"]]);

            $row = callAPI("/webservice/cart/" . $_COOKIE["PHPSESSID"], "POST", $productID);

            if ($row["response"] == 204) {
                echo "success";
            } else {
                echo "fail " . $row["response"];
            }
        }
    }
    // display the cart
    if ($request == "cart") {
        $row = callAPI("/webservice/cart/" . $_COOKIE['PHPSESSID'], "GET");

        $data = $row["data"];
        $total = 0;
        $CartTable = "<tr><th>Product Name</th><th>Price</th><th>Remove</th></tr>";
        for ($i = 0; $i < count($data); $i++) {
            $total += $data[$i]["product_price"];
            $CartTable .= "<tr><td>" . $data[$i]["product_name"] . "</td><td>" . $data[$i]["product_price"] . "</td>";
            $CartTable .= "<td><img id='removeitem' onclick='deleteItem(\"" . $data[$i]["product_id"] . "\")' src='images\\canceling.png' width='40' height='40'></img></td></tr>";
        }
        $CartTable .= "<div id='BillAmount' class='mt-5'><h4>Cart Total: $total</h4></div>";

        echo $CartTable;
    }
    // delete item from the cart
    if ($request == "deleteCartItem") {
        if (isset($_GET["productID"])) {
            $productID = json_encode(["product_id" => $_GET["productID"]]);

            $row = callAPI("/webservice/cart/".$_COOKIE['PHPSESSID'], "DELETE", $productID);

            if($row["response"] == 204) {
                echo "success";
            } else {
                echo "fail " . $row["response"];
            }
        }
    }
    // update the quanity in the database
    if ($_GET["request"] == "quantity" && isset($_GET["productID"]) && isset($_GET["quantityvalue"])) {

        $quantity = json_encode(["product_quantity" => $_GET["quantityvalue"]]);
        $row = callAPI("/webservice/product/quantity/" . $_GET["productID"], "PUT", $quantity);
        if ($row["response"] == 204) {
            echo "success";
        } else {
            echo "fail " . $row["response"];
        }
    }
}
