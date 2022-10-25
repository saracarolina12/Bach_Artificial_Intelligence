<?php
    class SimpleClass
    {
        // property declaration
        public $var = 'Sariux :D';

        // method declaration
        public function displayVar() {
            echo $this->var;
        }
    }
    $myvar = new SimpleClass();
    $myvar->displayVar();
?>