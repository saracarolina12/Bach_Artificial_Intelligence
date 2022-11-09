# 🧬Genetic Algorithms

_by John Holland 1970s_

## Characteristics
 ### • Inspired by people's DNA structure.
 ### • Solutions represented by binary arrays
<p align="center">
    <img width="40%" src="imgs/1.jpg"> </img>
</p>


##  Applications
### <u> _[- Traveling Salesman](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Code/Evolutionary%20Computation/Genetic%20Algorithms/TravelerSalesman/TravelerSalesman.ipynb)_ </u>
Calculate the path (without repeating nodes) that a salesperson must follow in order to minimize the distance by ending in the same start node . 
<p align="center">
    <img width="30%" src="imgs/TravelingSalesman.jpg"> </img>
</p>

### <u> _[- 8 Queens](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Code/Evolutionary%20Computation/Genetic%20Algorithms/8Queens/8Queens.ipynb)_ </u>
<p align="center">
    <img width="30%" src="imgs/8Queens.png"> </img>
</p>

### <u> _[- Sudoku](https://www.researchgate.net/publication/311250094/figure/fig1/AS:550057118101504@1508155244101/A-Sudoku-with-17-clues-and-its-unique-solution.png)_ </u>
<p align="center">
    <img width="30%" src="imgs/sudoku.png"> </img>
</p>


##  Representations
The individuals' representation can be divided into **Genotype** (codified version of the solution) and **Phenotype** (the solution that represents an individual).

• **Binary representation:** Binary array. 

• **Integer representation:** Integer array. (for example, use this integers for directions [left, right, up, down]).

• **Real representation:** Real arrays [$x_1, x_2,...,x_n$] $where$ $x_i ∈ ℝ$

• **Permutation representation:** Permutation of a set.


</br>

## Selection of parents
• **Roulette Selection:** Each section is assigned to an individual.
<p align="center">
    <img width="70%" src="imgs/RouletteSelection_2.jpg"> </img>
    <img width="22%" src="imgs/RouletteSelection.jpg"> </img>
</p>