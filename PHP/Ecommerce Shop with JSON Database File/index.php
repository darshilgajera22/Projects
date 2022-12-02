
<!-- @author : Darshil Gajera - 000867069
I certify that this is my work.
Purpose : Sport Shop to shop sports items like cricket football table tannies.
Professor: Sam Scott -->


<!-- session Start -->
<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <style>
        header {
            background-color: #54A494;
        }

        .header_text {
            position: relative;
        }

        h1 {
            text-align: center;
            font-weight: bolder;
            font-size: 70px;
            color: white;
            font-family: sans-serif;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        #logo {
            max-width: 80%;
            justify-content: end;
        }

        .navbar {
            height: 500px;
            background-color: #C5D0CE;
        }

        .nav-link {
            color: white;
            font-weight: bolder;
            background-color: #54A494;
            padding: 10px 40px !important;
            border-radius: 20px;
        }

        .table a {
            color: black;
            text-decoration: none;
        }

        .nav-item a:hover {
            color: #54A494 !important;
            background-color: white !important;
        }

        .table th {
            color: white;
            background-color: #54A494 !important;
        }

        .table td {
            background-color: #C5D0CE;
        }

        .Products_Catalog {
            padding-bottom: 50px !important;
        }

        #move {
            text-decoration: none;
            width: 100%;
            background-color: #54A494;
            border: none;
            border-radius: 10px;
            color: white;
            font-weight: bolder;
            padding: 10px;
        }
        #delete{
            width: 20px;
            height: 20px;
        }
        #checkout {
            text-decoration: none;
            width: 100%;
            background-color: #54A494;
            border: none;
            border-radius: 10px;
            color: white;
            font-weight: bolder;
            padding: 10px;
        }
    </style>
</head>

<body>
    <?php
    // Adding file "file_storage"
    include "file_storage.php";
    // storing file data in filedata
    $filedata = readDataFile("sportsitems.json");

    // if post deletefromcart is not empty
    if (isset($_POST["DeleteFromCart"])) {
        // adding 1 quanitty to cart array
        $crtproductmove = $filedata[$_POST["DeleteFromCart"]]["product_quantity"];
        $crtproductmove += 1;
        $filedata[$_POST["DeleteFromCart"]]["product_quantity"] = $crtproductmove;
        writeDataFile("sportsitems.json", $filedata);
        // serching quantity in cart array
        $value = array_search($_POST["DeleteFromCart"], $_SESSION["CartProducts"]);
        // removing 1 quanity from cart array
        array_splice($_SESSION["CartProducts"], $value, 1);
    } else if (isset($_POST["MoveInCart"])) {


        // decreasing the quantity of the product from the cart
        $crtproductdelete = $filedata[$_POST["MoveInCart"]]["product_quantity"];
        $crtproductdelete -= 1;
        $filedata[$_POST["MoveInCart"]]["product_quantity"] = $crtproductdelete;
        // adding quantity in database
        writeDataFile("sportsitems.json", $filedata);
        // if session is set
        if (isset($_SESSION["CartProducts"])) {
            // adding the item in the cart array
            array_push($_SESSION["CartProducts"], $_POST["MoveInCart"]);
        } else {
            // creating session
            $_SESSION["CartProducts"] = [$_POST["MoveInCart"]];
        }
    }

    ?>

    <header>
        <div class="container-fluid border p-3">
            <div class="row">
                <div class="col-10 header_text">
                    <h1>Sport Shop</h1>
                </div>
                <div class="col-2">
                    <img id="logo" src="images/headerlogo.jpeg" alt="Logo">
                </div>
            </div>
        </div>
    </header>

    <main class="mt-3 row">
        <div class="col-2">
            <nav class="navbar border justify-content-center ms-2">
                <ul class="navbar-nav">
                    <li class="nav-item m-2">
                        <a class="nav-link p-2" href="index.php?item_category=Cricket">Cricket</a>
                    </li>
                    <li class="nav-item m-2">
                        <a class="nav-link p-2" href="index.php?item_category=Football">Football</a>
                    </li>
                    <li class="nav-item m-2">
                        <a class="nav-link p-2" href="index.php?item_category=TableTennis">Table Tennis</a>
                    </li>
                    <li class="nav-item m-2">
                        <a class="nav-link p-2" href="index.php">All Products</a>
                    </li>
                </ul>
            </nav>
        </div>
        <div class="col-7">
            <table class='table'>

                <?php
                // if get parameter item_category is set
                if (isset($_GET["item_category"])) {
                    echo "<tr><th>Product id</th><th>Product Name</th><th>Product Price</th><th>Quantity</th></tr>";
                    // to print filedata elements
                    for ($i = 0; $i < count($filedata); $i++) {
                        // user selected category match with product category
                        if ($filedata[$i]["product_category"] == $_GET["item_category"]) {
                            echo "<tr><td>{$filedata[$i]["product_id"]}</td>";
                            echo "<td><a href='index.php?item_info=$i'>{$filedata[$i]["product_name"]}</a></td><td>{$filedata[$i]["product_price"]}</td>";
                            // product quantity is not 0
                            if (($filedata[$i]["product_quantity"]) != 0) {
                                echo "<td>{$filedata[$i]["product_quantity"]}</td></tr>";
                            } else {
                                echo "<td>Out of Stock</td></tr>";
                            }
                        }
                    }
                    // if parameter GET iteam_info is set
                } else if (isset($_GET["item_info"])) {
                    // accesing filedata elements 
                    foreach ($filedata as $items => $items_data) {
                        // if user item match with filedata element
                        if ($items == $_GET["item_info"]) {
                            // displaying data and move to cart option
                            echo "<tr><th>Product Code</th><td>$items_data[product_id]</td></tr>";
                            echo "<tr><th>Product Name</th><td>$items_data[product_name]</td></tr>";
                            echo "<tr><th>Product Description</th><td>$items_data[product_description]</td></tr>";
                            echo "<tr><th>Product Price</th><td>$items_data[product_price]</td></tr>";
                            // move to cart if item quantity is not 0
                            if ($items_data["product_quantity"] <= 0) {
                                echo "<tr><td>Out of Stock</td></tr>";
                            } else {
                                echo "<form action='index.php?' method='POST'>";
                                echo "<tr><td><input type='hidden' name='MoveInCart' value='$items'></td><td><input type='submit' id='move' value='Move to cart'></td></tr></form>";
                            }
                        }
                    }
                } else {
                    // displaying all items
                    echo "<tr><th>Product id</th><th>Product Name</th><th>Product Price</th><th>Quantity</th></tr>";
                    for ($i = 0; $i < count($filedata); $i++) {
                        echo "<tr><td>{$filedata[$i]["product_id"]}</td>";
                        echo "<td><a href='index.php?item_info=$i'>{$filedata[$i]["product_name"]}</a></td><td>{$filedata[$i]["product_price"]}</td>";
                        if (($filedata[$i]["product_quantity"]) != 0) {
                            echo "<td>{$filedata[$i]["product_quantity"]}</td></tr>";
                        } else {
                            echo "<td>Out of Stock</td></tr>";
                        }
                    }
                }
                ?>
            </table>
        </div>
        <div class="col-3">
            <h3>Shopping Cart</h3>
            <table class="table table-striped">
                <?php
                // to add products price
                $billAmount = 0;
                // if POST & SESSION are set
                if (isset($_POST["MoveInCart"]) || isset($_SESSION["CartProducts"]) || isset($_POST["DeleteFromCart"])) {
                    echo "<tr><th>Product id</th><th>Product Name</th><th>Product Price</th><th></th></tr>";
                    // displaying all products of the cart
                    foreach ($_SESSION["CartProducts"] as $product) {
                        foreach ($filedata as $item => $itemdata) {
                            if ($product == $item) {
                                echo "<tr><td>$itemdata[product_id]</td>";
                                echo "<td><a href='index.php?item_info=item'>$itemdata[product_name]</td><td>$itemdata[product_price]</td>";
                                echo "<form action='index.php?' method='POST'>";
                                echo "<input type='hidden' name='DeleteFromCart' value='$item'>";
                                echo "<td><input type='image' id='delete' src='images/canceling.png' alt='remove'></td></tr>";
                                // adding products price in bill amount
                                $billAmount += $itemdata["product_price"];
                                echo "</form>";
                            }
                        }
                    }
                }

                // displaying bill amount
                echo "</div></table><h3> Total : $  $billAmount</h3>";

                // check out button
                echo "<form><input type='submit' id='checkout' value = 'Check Out'></form>";

                ?>

        </div>
    </main>
</body>

</html>