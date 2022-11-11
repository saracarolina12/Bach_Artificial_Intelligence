# 🐿️ Evolution Strategies

_by Rechenberg & Schwefel 1960_


## **Characteristics**
• Solves continuous multidimensional optimization problems.

• Self-adaptative in relation to its parameters (some parameters might change during the execution).

##  **Applications**

<table><tr><td>

<p align="center">
        <img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES.jpg"> </img>
</p>

</td><td>

### <u> _[Image Transformation](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/Evolutive%20Strategies/ImageTransformation.ipynb)_ </u>
Transform an image to approach as much as possible to the original one.

</td><tr>

</table>


##  **Representation**
The individual $i$'s solution is represented as a vector  $𝑥_𝑖⃗$ ∈ $ℝ^d$ where $d$ = the number of features.
<p align="center">

$$<𝑥_𝑖⃗,\sigma_i>$$

where $\sigma$ represents the mutation parameters.

</p>


## **Mutation**
The individuals can be seen as points in a multidimensional space, where the mutation's goal is to move them so that the position of the mutated individual is close to the positition of the individual before mutation.

<p align="center">
        <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_mutation.png"> </img>
</p>

In order to achive this, we modify $𝑥_𝑖⃗$ by adding a random number to each entry. This number follows a normal distrivution zero-centered and a standard desviation $\sigma_i$ (mutation step size -> defines how much we modify the individual).

###

<table><tr><td>

<p align="center">

### **$\frac{1}{5}$ Success Rule**

</p>

</td><td>

<p align="center">
        <img width="60%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_successRule.png"> </img>
        
where $p$ is the relative frequency of successful mutations

and $c$ is the range $0.817≤c≤1$

</p>

</td><tr>

</table>

### **Special cases of mutation in Evolution Strategies**
<table><tr><td>

<p align="center">

**$1$ Step Size**

</p>

</td><td>

<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_oneStepSize.png"> </img>

In this case, the mutation will be performed as follows:
</p>
<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_mutation_onestep.png"> </img>
</p>

</td><tr>

<tr><td>

<p align="center">

**$d$ Step Size**

</p>

</td><td>

<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_dsteps.png"> </img>

In this case, the mutation will be performed as follows:
</p>
<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_mutation_dsteps.png"> </img>
</p>

</td><tr>

</table>


## **Recombination**

<table><tr><td>

<p align="center">

**Intermediate**

</p>

</td><td>

<p align="center">



</p>
<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_recombination_intermediate.png"> </img>
</p>

</td><tr>

<tr><td>

<p align="center">

**Discrete**

</p>

</td><td>

<p align="center">



</p>
<p align="center">
        <img width="70%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_recombination_discrete.png"> </img>
</p>

</td><tr>

</table>


## **Selection of Parents**
The parent selection is random (the whole population is seen as a parent).


## **Survivor Selection**
<table><tr><td>

<p align="center">

### (𝜇,𝜆)

</p>

</td><td>

<p align="center">



</p>
<p align="center">

Only the best 𝜇 offspring are selected 

</p>

</td><tr>

<tr><td>

<p align="center">

### (𝜇+𝜆)

</p>

</td><td>

<p align="center">



</p>
<p align="center">
The best 𝜇 individuals (Union of parents and offspring) are selected.
</p>

</td><tr>

</table>


---
## **Pseudocode**
        Parameters:
                N: population size
                𝜆: offspring size
                G: max number of generations
        Return: the elite individual

        Begin
                Create the initial population
                Calculate the population fitness
                Get the elite
                While numGen < G || haven't found solution:
                        Recombination (generate 𝜆 offspring)
                        Mutation of parents and offspring
                        Calculate population fitness
                        Survivor Selection
                        Get the elite or include the elite in the population
                End while
        End
                        

---

##### _by Sara Carolina_