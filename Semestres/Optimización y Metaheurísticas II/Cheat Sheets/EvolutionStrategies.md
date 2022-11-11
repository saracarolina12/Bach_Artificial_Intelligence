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
        <img width="80%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_successRule.png"> </img>
        
where $p$ is the relative frequency of successful mutations

and $c$ is the range $0.817≤c≤1$

</p>

</td><tr>

</table>

### **Special cases of mutation in Evolution Strategies**
<table><tr><td>

<p align="center">

**Uncorrelated Mutation with One Step Size**

</p>

</td><td>

<p align="center">
        <img width="80%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_oneStepSize"> </img>

In this case, the mutation will be performed as follows:
</p>
<p align="center">
        <img width="80%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_mutation_onestep"> </img>
</p>

</td><tr>

</table>