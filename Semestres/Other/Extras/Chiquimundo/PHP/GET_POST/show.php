<?php
    $user = $_POST["username"];
    $passw = $_POST["password"];

    if($user == "sara" AND $passw=="123") echo "Welcome back, sir";
    else echo "Access Denied";
?>