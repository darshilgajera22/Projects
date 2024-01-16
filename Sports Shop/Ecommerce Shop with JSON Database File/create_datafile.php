<?PHP 

include_once "file_storage.php"; 

$filename = 'C:\xampp\htdocs\MyProjects\SportShop\sportsitems.json'; 

$data = array("0"=>array("product_id"=>"cricket-bat-001","product_name"=>"Cricket Bat ","product_category"=>"Cricket", 

                                   "product_description"=>" SS Kashmir Willow Leather Ball Cricket Bat, Exclusive Cricket Bat For Adult Full Size with Full Protection Cover","product_price"=>84.24,"product_quantity"=>6), 

              "1"=>array("product_id"=>"cricket-helmet-002","product_name"=>"Cricket Helmet","product_category"=>"Cricket", 

                                   "product_description"=>"SS Cricket Gutsy Cricket Helmet (Blue & Black Color)","product_price"=>69.99,"product_quantity"=>7), 

              "2"=>array("product_id"=>"cricket-gloves-003","product_name"=>"Cricket Gloves","product_category"=>"Cricket", 

                                   "product_description"=>"Superlite Cricket Batting Gloves Mens Right Hand and Left Hand Batting","product_price"=>71.37,"product_quantity"=>3), 

              "3"=>array("product_id"=>"cricket-balls-004","product_name"=>"Cricket Balls","product_category"=>"Cricket", 

                                   "product_description"=>"Cricnix Cricket Ball Gold Red Leather 142g (1-Pack/3-Pack/6-Pack) for Practice or Training","product_price"=>22.99,"product_quantity"=>0), 

              "4"=>array("product_id"=>"cricket-stumps-005","product_name"=>"Cricket Stumps","product_category"=>"Cricket", 

                                   "product_description"=>"FORTRESS Spring Back Cricket Stumps - 28in ICC Regulation Stumps for Cricket | Club & Pro Styles | Spring Back Wickets & Bails","product_price"=>99.99,"product_quantity"=>8),

               "5"=>array("product_id"=>"cricket-shoe-006","product_name"=>"Cricket Shoe","product_category"=>"Cricket", 

                                   "product_description"=>"KD Vector Cricket Shoes Rubber Spike Cricket","product_price"=>85.36,"product_quantity"=>15),       

                "6"=>array("product_id"=>"football-ball-007","product_name"=>"Football Ball","product_category"=>"Football", 

                                   "product_description"=>"Adidas Tango Glider Soccer Ball","product_price"=>25.18,"product_quantity"=>10),
                "7"=>array("product_id"=>"football-Jersey-008","product_name"=>"Football Jersey","product_category"=>"Football", 

                                   "product_description"=>"Messi Argentina Football Leo #10 Soccer Jersey Style Shirt Men ","product_price"=>24.99,"product_quantity"=>3),
                            
               "8"=>array("product_id"=>"football-shoe-009","product_name"=>"Football Shoe","product_category"=>"Football", 

                                    "product_description"=>"Soccer Cleats for Mens Womens FG Football Boots Outdoor Professional","product_price"=>65.27,"product_quantity"=>4),       

                "9"=>array("product_id"=>"football-gloves-010","product_name"=>"Football Gloves","product_category"=>"Football", 

                                    "product_description"=>"Football Gloves Adult Youth Football Receiver Gloves,Enhanced Performance Football Gloves and Tacky Silicone Grip Football Gloves","product_price"=>26.99,"product_quantity"=>5),
                "10"=>array("product_id"=>"football-pads-011","product_name"=>"Football Pads","product_category"=>"Football", 

                                    "product_description"=>"Youth Padded Compression Shirt, Chest Protector, Heart Guard Sternum Protection Shirt","product_price"=>29.99,"product_quantity"=>6),
                "11"=>array("product_id"=>"TableTennis-racket-012","product_name"=>"Table Tennis Racket","product_category"=>"TableTennis", 

                                    "product_description"=>"STIGA Pro Carbon Table Tennis Racket","product_price"=>133.12,"product_quantity"=>9),       

                "12"=>array("product_id"=>"TableTennis-balls-013","product_name"=>"Table Tennis Balls","product_category"=>"TableTennis", 

                                    "product_description"=>"PRO-SPIN Ping Pong Balls - Orange 3-Star 40+ Table Tennis Balls (Pack of 12, 24) | High-Performance ABS Training Balls | Ultimate Durability","product_price"=>16.99,"product_quantity"=>14),
                "13"=>array("product_id"=>"TableTennis-table-014","product_name"=>"Table Tennis Table, RUSTIC OAK","product_category"=>"TableTennis", 

                                    "product_description"=>"JOOLA Midsize Compact Table Tennis Table Great for Small Spaces and Apartments, Multi-Use Free Standing Table - Compact Storage","product_price"=>228.99,"product_quantity"=>3),
                "14"=>array("product_id"=>"TableTennis-net-015","product_name"=>"Table Tennis Net","product_category"=>"TableTennis", 

                                    "product_description"=>"JOOLA Professional Grade WX Aluminum Indoor & Outdoor Table Tennis Net and Post Set - Quick Setup - 72in Regulation Ping Pong","product_price"=>83.71,"product_quantity"=>5));
               
                                    
    writeDataFile($filename,$data); 

    if ( file_exists($filename) ){ print "Data File Created!";} 

    else { print "Data file not created!";} 

    ?> 