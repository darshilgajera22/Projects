<?PHP

/**
 * index.php to communicate with database
 * 
 * Darshil Gajera, December 2022
 */
include "connect.php";

$method = $_SERVER['REQUEST_METHOD'];
$path = $_SERVER['REQUEST_URI'];
// die("$method $path");

// Updating the quantity in the database
if (isset($path)) {
    
    $found = strpos($path, '/~sa000867069/10260/Assignment3/webservice/product/quantity/');
    if ($found === 0) {
        
        $productID = substr($path, strlen('/~sa000867069/10260/Assignment3/webservice/product/quantity/'));
        if ($method == "PUT") {
            
            $productquantity = json_decode(file_get_contents('php://input'), true);
            if (isset($productquantity["product_quantity"])) {
                $cmd = "UPDATE catalogue SET product_quantity=product_quantity+? WHERE product_id= ?";
                $stmt = $dbh->prepare($cmd);
                $params = [$productquantity["product_quantity"], $productID];
                $stmt->execute($params);
                http_response_code(204);
            } else {
                http_response_code(404);
            }
        } else {
            http_response_code(401);
        }
    }
}
// cart requeats 
if(isset($path)){
    $found = strpos($path,'/~sa000867069/10260/Assignment3/webservice/cart/');
    if($found === 0){
        $sessionID = substr($path, strlen('/~sa000867069/10260/Assignment3/webservice/cart/'));
        
        // inserting data in to session table
        if($method == "POST"){
            $productID = json_decode(file_get_contents('php://input'), true);
            
            if (isset($productID['product_id'])) {
                // die($sessionID);
                $cmd = "INSERT INTO session(session_id,session_data) VALUES (?,?)";
                $Stmt = $dbh->prepare($cmd);
                $Stmt->execute([$sessionID, $productID['product_id']]);
                http_response_code(204);
            } else {
                http_response_code(304);
            }
        }

        // getting the user selected items from the cart
        if ($method == "GET") {
            $cmd = "SELECT product_id,product_name,product_price FROM catalogue c Join session s ON s.session_data = c.product_id Where s.session_id = ?";
            $stmt = $dbh->prepare($cmd);
            $stmt->execute([$sessionID]);
            $cartdata = [];
            while ($row = $stmt->fetch()) {
                http_response_code(200);
                array_push($cartdata, ["product_id" => $row["product_id"], "product_name" => $row["product_name"], "product_price" => $row["product_price"]]);
            }
            echo json_encode($cartdata);
        } else{
            http_response_code(405);
        }

        // deleting cart data
        if($method == "DELETE") {
            $productID = json_decode(file_get_contents('php://input'), true);

            if (isset($productID['product_id'])) {
                $cmd = "DELETE FROM session Where session_id = ? AND session_data = ? LIMIT 1";
                $stmt = $dbh->prepare($cmd);
                $stmt->execute([$sessionID, $productID['product_id']]);
                http_response_code(204);
            } else {
                http_response_code(304);
            }
        } else {
            http_response_code(405);
        }
    }
}



// selecting total categories from the database
if ($path == "/~sa000867069/10260/Assignment3/webservice/product/categories/") {
    if ($method == "GET") {
        $cmd = "SELECT DISTINCT product_category FROM catalogue";
        $stmt = $dbh->query($cmd);

        $categories = [];
        while ($row = $stmt->fetch()) {
            array_push($categories, $row["product_category"]);
            http_response_code(200);
        }
        echo json_encode($categories);
    } else {
        http_response_code(405);
    }
} else {
    // displaying all products
    $found = strpos($path, "/~sa000867069/10260/Assignment3/webservice/product");
    if ($found === 0) {
        //die($path);
        if ($method == "GET") {
            if (isset($_GET["start"]) && isset($_GET["length"])) {
                $start = $_GET["start"];
                $length = $_GET["length"];

                if (isset($_GET["category"]) && $_GET["category"] != "AllProducts") {
                    $category = $_GET["category"];

                    // getting all proudcts as per category
                    $cmd = "SELECT product_id,product_name,product_description,product_price,product_quantity FROM catalogue WHERE product_category='$category' LIMIT $start,$length";
                    $stmt = $dbh->query($cmd);
                    $products = [];
                    while ($row = $stmt->fetch()) {
                        if ($row == null) {
                            http_response_code(404);
                        }
                        http_response_code(200);
                        array_push($products, ["product_id" => $row["product_id"], "product_name" => $row["product_name"], "product_description" => $row["product_description"], "product_price" => $row["product_price"], "product_quantity" => $row["product_quantity"]]);
                    }
                    echo json_encode($products);
                } else {
                    // getting all products as per start and length
                    $cmd = "SELECT product_id,product_name,product_description,product_price,product_quantity FROM catalogue LIMIT $start,$length";
                    $stmt = $dbh->query($cmd);
                    $products = [];
                    while ($row = $stmt->fetch()) {
                        if ($row == null) {
                            http_response_code(404);
                        }
                        http_response_code(200);
                        array_push($products, ["product_id" => $row["product_id"], "product_name" => $row["product_name"], "product_description" => $row["product_description"], "product_price" => $row["product_price"], "product_quantity" => $row["product_quantity"]]);
                    }
                    echo json_encode($products);
                }
            }
            // fetching products data
            if (isset($_GET["productid"])) {
                //die($path);
                $productID = $_GET["productid"];
                $cmd = "SELECT product_id,product_name,product_description,product_price,product_quantity FROM catalogue WHERE product_id = '$productID'";
                $stmt = $dbh->query($cmd);
                $products = [];
                while ($row = $stmt->fetch()) {
                    if ($row == null) {
                        http_response_code(404);
                    }
                    http_response_code(200);
                    array_push($products, ["product_id" => $row["product_id"], "product_name" => $row["product_name"], "product_description" => $row["product_description"], "product_price" => $row["product_price"], "product_quantity" => $row["product_quantity"]]);
                }
                echo json_encode($products);
            }
        }
        else {
            http_response_code(405);
        }
    }
}


