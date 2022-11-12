# 🐺 Genetic Programming 

_by John Koza 1990_

## **Characteristics**
• Solves problems without the user specifying the structure of the solution.

• Its main idea is to evolve a population of computer programs.

• Individuals are represented as syntax trees.

• Could be applied to machine learning.

<p align="center">
    <img width="20%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_intr.png"> </img>
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
<img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_fit.png"> </img>    
</p>


## **Initial Population**

<table>
    <tbody>
        <tr>
            <td rowspan=1>
                <p align="center">
                    Full</br>
                    <img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popFull.png"> </img>    
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
                    <img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popGrow.png"> </img>    
                </p></td>
            <td rowspan=1>
                Each node randomly selects an element from the function set F or the terminal set T
            </td>
        </tr>
         <tr>
            <td rowspan=1>
            <p align="center">
            Ramped half-and-half</br>   
                <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popFull.png"></img>    
                +
                <img width="25%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_popGrow.png"> </img>    
                </br>
            </p>
            </td>
            <td rowspan=1>
                <p>Half of the population is created with the <b>full</b>technique and the other half with <b>grow</b>.</p>
            </td>
        </tr>
    </tbody>
</table>


## **Selection**
[Tournament Selection](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/GeneticAlgorithms.md#selection-of-parents) is commonly used. 


## **Crossover**
The classical crossover consists of randomly selecting a crossover point in each parent, take the subtree from the selected point of the second parent and replace the first's parent selected node with it.

<p align="center">
<img width="25%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_crossover.png"> </img>    
</p>


## **Mutation**
_Subtree Mutation_: Randomly select a mutation point and substitute the subtree of it with another randomly generated.

<p align="center">
<img width="25%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/GP_mut.png"> </img>    
</p>


---
## **Pseudocode**
    Create an initial population P of programs
    Calculate the fitness of all programs in P-
    best, best_fitness <- The best program of P and its fitness
    
    While !termination_criterion_reached:
        p1, p2 <- two programs selected from P based on fitness
        new <- result of applying crossover(p1,p2) and mutation(p1,p2)
        old <- program chosen from P using negative selection (remove the worst element)
        Remove "old" from P
        Add "new" to P
        new_fit <- the fitness of "new"
        if(new_fit > best_fitness):
            best <- new
            best_fitness <- new_fit
        End
    End While

    Return best

---

#### _by Sara Carolina_

