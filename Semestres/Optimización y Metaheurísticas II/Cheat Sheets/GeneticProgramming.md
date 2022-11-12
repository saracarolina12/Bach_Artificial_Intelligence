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
<img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_appl.png"> </img>    
</p>