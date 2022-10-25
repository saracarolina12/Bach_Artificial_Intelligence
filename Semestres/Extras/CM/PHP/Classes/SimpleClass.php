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

    // include files
    // create functions
    // open file as readable
    // superglobal variable
        // Which superglobal variable holds information about headers, paths, and script locations?
    // add 1 to varialbe ++
    // die and exit
    //create cookie
    // php array

?>

