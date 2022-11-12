# 🐺 Genetic Programming 

_by John Koza 1990_

## **Characteristics**
• Solves problems without the user specifying the structure of the solution.

• Its main idea is to evolve a population of computer programs.

• Individuals are represented as syntax trees.

• Could be applied to machine learning.

<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_intr.png"> </img>
</p>


##  **Applications**

<table><tr><td>

<p align="center">
<img width="60%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_appl.png"> </img>    
</p>

</td><td>

### _Supervised Learning Problem_ 
• Consists of mapping several inputs with outputs.

• Each GP individual represents a solution to solve the problem.

</td><tr>

</table>


##  **Representation**
Inviduals are commonly represented as syntax trees.

<table>
    <tbody>
        <tr>
            <td rowspan=1>Terminals</td>
            <td rowspan=1>
                <b>Leave nodes in syntax tree</b>
                <p>They can be variables such as "x" and "y", or functions with no arguments (e.g., rand()), or constants that can be predefined or randomly generated.</p>
                <i>The terminal set <b>T</b> defines all the terminal elements.</i>
            </td>
        </tr>
        <tr>
            <td rowspan=1>Functions</td>
            <td rowspan=1>
                <b>Operations that correspond to the internal nodes in a syntax tree.</b>
                <p>The function <b>F</b> depends on the problem's nature.</p>
                <p>For example, in numeric problems could be formed by arithmetic operators or trigonometric functions.</p>
            </td>
        </tr>
    </tbody>
</table>



## **Fitness**
Depends on the problem we are trying to solve.

For example, in *Supervised Learning Problems* we need to find an individual whose function matches inputs with outputs. In this case, the fitness function must measure how similar the individual outputs are to the real outputs.

<p align="center">
<img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_fit.png"> </img>    
</p>


## **Initial Population**

<table>
    <tbody>
        <tr>
            <td rowspan=1>
                <p align="center">
                    Full</br>
                    <img width="60%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popFull.png"> </img>    
                </p>
            </td>
            <td rowspan=1>
                <p>Randomly create the trees.</p>
                <p>All the leaves have the same depth.</p>
            </td>
        </tr>
        <tr>
            <td rowspan=1><p align="center">
                    Grow</br>
                    <img width="60%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popGrow.png"> </img>    
                </p></td>
            <td rowspan=1>
                Each node randomly selects an element from the function set F or the terminal set T
            </td>
        </tr>
         <tr>
            <td rowspan=1>
            <p align="center">
            <h3>Ramped half-and-half</h3></br> 
                <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popFull.png"></img>    
                +
                <img width="25%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popGrow.png"> </img>    
                </br>
                <i>Full & Grow</i>
            </p>
            </td>
            <td rowspan=1>
                <p>Half of the population is created with the <b>full</b>technique and the other half with <b>grow</b>.</p>
            </td>
        </tr>
    </tbody>
</table>