# 🧬Genetic Algorithms

_by John Holland 1970s_

## **Characteristics**
• Inspired by people's DNA structure.

• Solutions represented by binary arrays
<p align="center">
    <img width="30%" src="imgs/1.jpg"> </img>
</p>


##  **Applications**

<table><tr><td>

<p align="center">
        <img width="50%" src="imgs/TravelingSalesman.jpg"> </img>
</p>

</td><td>

### <u> _[Traveling Salesman](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Code/Evolutionary%20Computation/Genetic%20Algorithms/TravelerSalesman/TravelerSalesman.ipynb)_ </u>
Calculate the path (without repeating nodes) that a salesperson must follow in order to minimize the distance by ending in the same start node . 

</td><tr>

<tr><td>

<p align="center">
        <img width="50%" src="imgs/8Queens.png"> </img>
</p>

</td><td>

### <u> _[8 Queens](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Code/Evolutionary%20Computation/Genetic%20Algorithms/8Queens/8Queens.ipynb)_ </u> 
Place 8 queens on the 8x8 board without letting them to attack each other in diagonal, up or down.

</td><tr>

<tr><td>

<p align="center">
        <img width="50%" src="imgs/sudoku.png"> </img>
</p>

</td><td>

### <u> _[Sudoku](https://www.researchgate.net/publication/311250094/figure/fig1/AS:550057118101504@1508155244101/A-Sudoku-with-17-clues-and-its-unique-solution.png)_ </u>
Must solve the traditional 9x9 sudoku.
</td><tr>


</table>


##  **Representations**
The individuals' representation can be divided into **Genotype** (codified version of the solution) and **Phenotype** (the solution that represents an individual).

|   |   |
|---|---|
|__Binary__| Binary array (0,1) |
|__Integer__| Integer array. (for example, use this integers for directions left, right, up, down) |
|__Real__| eal arrays  [𝑥1,𝑥2,…,𝑥𝑛] where $x_i ∈ ℝ$ |
|__Permutation__| Permutation of a set. |

## **Selection of parents**
• **Roulette Selection:** Each section is assigned to an individual.

$$p_i = \frac{f_i}{\sum_kf_k}$$
where $p_i$ is the individual's proportion and $f_i$ its fitness.

Calcutate the range for each individual. Select an individual by choosing a random number between 0 and 1, if the number is between x range previously calculated, select it as a parent.
<p align="center">
    <img width="60%" src="imgs/rouletteSelection_2.jpg"> </img>
    <img width="19%" src="imgs/rouletteSelection.jpg"> </img>
</p>

• **Tournament Selection:** Very well-known. Randomly select $k$ individuals and select the fittest one. $k =$ tournament size.



## **Reproduction (crossover or recombination)**
The goal is to generate new individuals (called offsprings) by combinating it's parent's properties.

### <u>*Binary and integer representation*</u>
* **1 point crossover**
<p align="center">
    <img width="35%" src="imgs/1point_crossover.jpg"> </img>
</p>

* **n point crossover**
<p align="center">
    <img width="35%" src="imgs/npoint_crossover.jpg"> </img>
</p>

* **Uniform crossover:** Copy the gene of the first or the second parent randomly (uniform ditribution)


### <u>*Real-valued representation*</u>
* **Discrete reproduction:** Same idea as uniform crossover. Randomly copy the value of parent 1 or 2 and repeat this for each children.
* **Discrete reproduction:** $$o = \alpha p1 + (1-\alpha p2)$$ where $0<=a<=1$

### <u>*Permutation representation*</u>
* **Simple permutation crossover:** 
    1. Divide the array in two parts and copy each section into offspring.
    2. Calculate the duplicated and missing elements.
    3. Randomly replace the repeated with the missing values.
<p align="center">
    <img width="80%" src="imgs/SPC.jpg"> </img>
</p>

* **Partially mapped crossover:** 
    1. Divide the array in 3 parts and copy the intermediate section into offspring.
    2. Copy the first and third section of de second parent except for those who already exist in offspring.
    3. Add the missing values of the second part of the second parent that do not already appear in offspring.
<p align="center">
    <img width="80%" src="imgs/PMC.jpg"> </img>
</p>



## **Mutation**
_Consists on modifying the individuals in order to have more variants and check if these fit better._
* **Bitwise mutation:** Binary representation. Randomly select one or multiple genes and change its values. (0->1, 1->0)
* **Random resetting:** Integer representation. Randomly select one or multiple genes and reset its values.
* **Uniform mutation:** Real-valued representation. Randomly select one or multiple genes. Then, choose a random value between [min,max].
* **Swap mutation:** Permutation representation. Randomly select 2 elements and swap their values.
<!-- --- -->
<p align="center">

| Holland's original proposal of Genetic Arlgorithms        
| --------------------------------------------------------
| * **Representation:** binary
| * **Parents' selection:** roulette
| * **Crossover:** 1 point
| * **Mutation:** bitwise
| * **Population model:** generational

</p>

<!-- --- -->