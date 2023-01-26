<?php
    $read = file_get_contents("README.md");
    echo nl2br($read)
?>