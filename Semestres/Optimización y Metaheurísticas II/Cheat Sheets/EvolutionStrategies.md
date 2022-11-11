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
        <img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ES_mutation.png"> </img>
</p>