<?php
// session Start
session_start();
require_once "connect.php";
?>

<!---------------------------------------
    @author : Darshil Gajera - 000867069
    I certify that this is my work.
    Purpose : Sport Shop for sports items cricket, football, table tannies.
    Professor: Sam Scott 
---------------------------------------->

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>
    <script src="cartupdate.js"></script>
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

        .itemCategorymenu{
            text-align: center;
            padding-top: 50px;
            padding-bottom: 50px;
            background-color: #54A494;
        }
        .itemCategorymenu a{
            display: block;
            margin: 5px;
            background-color: #C5D0CE;
            color: white;
            text-decoration: none;
            padding: 10px;
            font-weight: bold;
        }
        .itemCategorymenu a:hover{
            font-size: medium;
            background-color: white;
            color: #54A494;
        }
        .table a {
            color: black;
            text-decoration: none;
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
        #delete {
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
        .itemtable{
            position: relative;
        }
        .nextprev {
            position: absolute;
            bottom: 0;
            width: 100%;
            height: 50px;
        }
        .nextprev button{
            width: 150px;
            border: none;
            border-radius: 5px;
            background-color: #54A494;
            color: white;
            font-size: medium;
            font-weight: bold;
            padding: 10px;

        }
        .nextbtn{
            position: absolute;
            bottom: 0;
            right: 0;
            margin-right: 25px;
            
        }
        .prevbtn{
            position: absolute;
            bottom: 0;
            left: 0;
        }
        .outstockmsg{
            color: red;
            font-weight: bold;
        }
    </style>
</head>

<body class="mb-5">
    <?php
    $query = "";
    /**
     * to display category menu
     * params: $dbh
     */
    function category($dbh)
    {
        // sql query
        $query = "SELECT DISTINCT product_category FROM `catalogue`";
        $cursor = $dbh->query($query);
        echo "<div class='itemCategorymenu'>";
        // fetching data from database
        while ($row = $cursor->fetch()) {
            echo "<a href='index.php?item_category=$row[product_category]'>$row[product_category]</a>";
        }
        echo "<a href='index.php?'>All Items</a></div>";
    }
    /**
     * to display all products
     * params: $dbh
     */
    function allProducts($dbh)
    {
        echo "<div class = 'nextprev'><form method='POST'>";
        if (isset($_POST['next7'])) {
            // display 7 to 14 items
            $query = "SELECT product_name,product_description,product_price,product_quantity FROM catalogue LIMIT 7,7";
            echo "<button class='prevbtn' name='prev17' value='prev'>Previous</button>";
            echo "<button class='nextbtn' name='next1' value='next'>Next</button>";
        } elseif (isset($_POST['next1'])) {
            // display last item
            $query = "SELECT product_name,product_description,product_price,product_quantity FROM catalogue LIMIT 14,15";
            echo "<button class='prevbtn' name='prev27' value='prev'>Previous</button>";
        } elseif (isset($_POST['prev27'])) {
            // display 7 to 14 items
            $query = "SELECT product_name,product_description,product_price,product_quantity FROM catalogue LIMIT 7,7";
            echo "<button class='prevbtn'>Previous</button>";
            echo "<button class='nextbtn' name='next1' value='next'>Next</button>";
        } else {
            // display first 7 items
            $query = "SELECT product_name,product_description,product_price,product_quantity FROM catalogue LIMIT 0,7";
            echo "<button class='nextbtn' name='next7' value='next'>Next</button>";
        }
        echo "</form></div>";

        echo "<tr><th>Product Name</th><th>Product Description</th><th>Product Price</th><th>Quantity</th></tr>";
        $cursor = $dbh->query($query);
        // fetching data from database
        while ($row = $cursor->fetch()) {
            echo "<tr><td><a href='index.php?item_info=$row[product_name]'>$row[product_name]</td><td>$row[product_description]</td></a><td>$row[product_price]</td>";
            if($row['product_quantity'] <=0){
                echo "<td class='outstockmsg'>Out of Stock</td></tr>";
            }else{
                echo "<td>$row[product_quantity]</td></tr>";
            }
        }
    }

    /**
     * Display products as per category
     * params: $categoryOfItem, $dbh
     */
    function categoryProducts($categoryOfItem, $dbh)
    {
        echo "<tr><th>Product Name</th><th>Product Name</th><th>Product Price</th><th>Quantity</th></tr>";
        $query = "SELECT product_name,product_description,product_price,product_quantity FROM catalogue WHERE product_category = '$categoryOfItem'";

        $cursor = $dbh->query($query);
        
        while ($row = $cursor->fetch()) {
            echo "<tr><td><a href='index.php?item_info=$row[product_name]'>$row[product_name]</td><td>$row[product_description]</a></td><td>$row[product_price]</td>";
            if($row['product_quantity'] <=0){
                echo "<td class='outstockmsg'>Out of Stock</td></tr>";
            }else{
                echo "<td>$row[product_quantity]</td></tr>";
            }
        }
    }
    /**
     * Display products information
     * params: $dbh, $selectedItem
     */
    function itemData($dbh, $selectedItem)
    {
        $query = "SELECT product_id,product_name,product_description,product_price,product_quantity FROM catalogue WHERE product_name = '$selectedItem'";
        $cursor = $dbh->query($query);

        while ($row = $cursor->fetch()) {
            echo "<tr><th>Product Code</th><td>$row[product_id]</td><tr>";
            echo "<tr><th>Product Name</th><td>$row[product_name]</td><tr>";
            echo "<tr><th>Product Description</th><td>$row[product_description]</td><tr>";
            echo "<tr><th>Product Price</th><td>$row[product_price]</td><tr>";
            if ($row['product_quantity'] <= 0) {
                echo "<tr><td colspan='2' class='outstockmsg'>Out of Stock</td></tr>";
            } else {               
                echo "<tr><td><form action='index.php?' method='POST'><input type='hidden' id='MoveInCart' name='MoveInCart' value='$row[product_id]'></td><td><input type='submit' id='move' value='Move to cart'></form></td></tr>";
            }
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

    <main class="mt-1 row">
        <div class="col-2">
            <?php
            // display category menu
            category($dbh);
            ?>
        </div>

        <div class="col-7 itemtable">
            <table class='table mb-5'>
                <?php
                if (isset($_GET["item_category"])) {
                    // display products as per category
                    $categoryOfItem = $_GET["item_category"];
                    categoryProducts($categoryOfItem, $dbh);
                } else if (isset($_GET["item_info"])) {
                    // display iteam info to add into cart
                    $selectedItem = $_GET["item_info"];
                    itemData($dbh, $selectedItem);
                } else {
                    // display all products
                    allProducts($dbh);
                }
                ?>
            </table>
        </div>

        <div class="col-3">
            <h3>Shopping Cart</h3>
            <div id="cart">

            </div>
            <div id="BillAmount"></div>
            <button id='checkout' value ='Check Out'>Check Out</button>
        </div>
    </main>
</body>

</html>