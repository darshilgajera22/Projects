<?php
try {
    $dbh = new PDO(
        "mysql:host=localhost;dbname=sa000867069",
        "sa000867069",
        "Sa_19991216"
    );
} catch (Exception $e) {
    die("ERROR: Couldn't connect. {$e->getMessage()}");
}
