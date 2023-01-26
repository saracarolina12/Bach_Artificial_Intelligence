<?php
    class SimpleClass
    {
        // property declaration
        public $var = 'Sara:D';

        // method declaration
        public function displayVar() {
            echo $this->var;
        }
    }

    /* EXTEND */
    class ExtendClass extends SimpleClass
    {
        // Redefine the parent method
        function displayVar()
        {
            echo "Hi, ";
            parent::displayVar();
        }
    }

    $extended = new ExtendClass();
    $extended->displayVar();
?>

