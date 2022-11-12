# 🏞️ Differential Evolution
_by Stom and Price 1995_

## **Characteristics**
• Solves continuous multidimensional optimization problems.

• The mutation operator uses 3 individuals instead of 2.

## **Applications**


<table><tr><td>

<p align="center">
<img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_prob_balancer.png"> </img>

        
</p>

</td><td>

### <u> _[Balancer Problem](https://github.com/saracarolina12/IA_School/tree/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/EvolutionaryProgramming/Balancer)_ </u>

Given two equations, balance them.



</td><tr>


<tr><td>
<p align="center">
<img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_prob_sinusoidal.png"> </img>

        
</p>

</td><td>

### <u> _[Sinusoidal Problem](https://github.com/saracarolina12/IA_School/tree/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/EvolutionaryProgramming/SinusoidalProblem)_ </u>

Try to approach the given sin.


</td><tr>

<tr><td>

<p align="center">
        <img width="80%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_appl.png"> </img>
</p>

</td><td>

### <u> _[Image Out Of Circles](https://github.com/saracarolina12/IA_School/tree/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/DifferentialEvolution/ImagesOutOfCircles)_ </u>
Given an image, this project tries to make a similar one by drawing a bunch of circles. For each circle the algorithm has to calculate the optimal values of the folllowing features.
</td><tr>


</table>


## **Representation**
Individuals are represented as vectors.
<p align="center">
    <img width="20%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_repre.png"> </img>
</p>

Calculate each k of i-th individual as follows:

<p align="center">
    <img width="20%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_repre_calc.png"> </img>
</p>

where $0<=r<=1$

## **Mutation**






<table>
    <tbody>
        <tr>
            <td rowspan=1>
                1. Randomly select 3 individuals (𝑥1, 𝑥2, 𝑥3)
                 <p align="center"><img width="55%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_mut.png"><img></p>
                 2. The new vector will be as follows:
                <p align="center">
                    <img width="55%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_mut.png"> </img>
                    </br>
                    <i>Where 0<=𝐹<=2</i>
                </p>
            </td>
            <td rowspan=1>
                 <p align="center"><img width="55%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/DIF_mut2.png"><img></p>
            </td>
        </tr>
    </tbody>
</table>
