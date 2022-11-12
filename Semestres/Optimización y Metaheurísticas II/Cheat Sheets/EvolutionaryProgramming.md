# 💻Evolutionary Programming


_by Lawrence Fogel 1960_

## **Characteristics**

* The solutions represent species instead of individuals.
* Its classical example is about finite state machines (FSM)

<table><tr><td>
<p align="center">
<img width="80%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_FSM.png"> </img>

        
</p>

</td><td>

Given a finite alphabet of input symbols, respond in a finite alphabet of output symbols.

We have 5 usable mutation operators to generate new FSMs

* Changing an output symbol
* Changing a state transition
* Adding a state
* Deleting a state
* Changing the initial state


</td><tr>
</table>


## **Applications**
<table><tr><td>
<p align="center">
<img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_prob_balancer.png"> </img>

        
</p>

</td><td>

### <u> _[Balancer Problem](https://github.com/saracarolina12/IA_School/tree/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/EvolutionaryProgramming/Balancer)_ </u>

Given two equations, balance them.



</td><tr>

<tr><td>
<p align="center">
<img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_prob_sinusoidal.png"> </img>

        
</p>

</td><td>

### <u> _[Sinusoidal Problem](https://github.com/saracarolina12/IA_School/tree/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Evolutionary%20Computation/EvolutionaryProgramming/Balancer)_ </u>

Try to approach to the given sin.


</td><tr>
</table>



## **Representation**
Same as [Evolution Strategies](https://github.com/saracarolina12/IA_School/blob/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/EvolutionStrategies.md) Represented as vector.
<p align="center">
<img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_representation.png"> </img>
</p>

## **Mutation**
The individuals can be seen as points in a multidimensional space, where the mutation's goal is to move them so that the position of the mutated individual is close to the positition of the individual before mutation.

The specie's position $\vec{x}_i$ is modified by adding up a random number as follows:
<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/EP_mutation.png"> </img>

where $a\approx 0.2$
</p>

## **Crossover**
Does not apply. He have species not individuals.

## **Parent Selection**
Does not apply.  

## **Parent Selection**
<p align="center">

$(\mu+\mu)$

</p>

1. Each specie generates another by mutation. 
2. From the set of all the species, the $\mu$ best are deterministically selected to be part of the new generation.

---
## **Pseudocode**
    Parameters:
        μ: population size
        G: max number of generations.
    Return: the elite individual

    Begin
        Create the iniatl population
        Calculate the population fitness
        Get the elite
        While numGen < G || haven't find solution:
            Mutation of all species.
            Calculate the population fitness
            Survivor selection
            Get the elite or include the elite in the population
        End while
    End
---

#### _by Sara_