# 🐦 Particle Swarm Optimization

_by Kennedy and Eberhart 1995_

## **Characteristics**
• Inspired by the movement of a flock of birds when searching for food.


## **Representation**
Represented by a vector where each element (particle) acts for a solution of the problem. 

In the time $t$, each particle has the position $x^i(t)\inℝ^d$ and a velocity $v^i\inℝ^d$.


<p align="center">
<img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/PSO_repr.png"> </img>    
</p>

## **How it works**

In order to update the position and velocity of each particle, we apply the following equation:

<p align="center">
<img width="50%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/PSO_posvel.png"> </img>    
</p>

where:

• $P^i_{best}$ is the best position where the particle $i$ has been.

• $G_{best}$ is the best location we have until now.

• $r_1$ and $r_2$ random numbers between 0 and 1.

•  $w,c_1, c_2$ are hyper parameters. We can initialize them at 0.9 and gradually reduce them to 0.1


## **Pseudocode**
    Parameters:
        N: number of particles
        MaxIter: max number of iterations
        func: objective function
        bounds: search-space
    Return: 𝐺𝑏𝑒𝑠𝑡 (the best position)

    Begin
        Initialize 𝑐1, 𝑐2, 𝑤
        Randomly create the particles positions and velocities.
        Calculate the objective function values
        Calculate 𝑃(i)𝑏𝑒𝑠𝑡 as the current positions
        Calculate 𝐺𝑏𝑒𝑠𝑡
        While t < MaxIter || haven't found a good solution:
            For each particle i:
                Update the velocity
                Update the position
                Calculate func(x^i)
                If(f(x^i) < func(P(i)_best)):
                    update P(i)_best
                If(f(x^i) < func(𝐺𝑏𝑒𝑠𝑡)):
                    update 𝐺𝑏𝑒𝑠𝑡
            End for
        Decrease 𝑐1, 𝑐2, 𝑤
        End while
    End

    Return 𝐺𝑏𝑒𝑠𝑡



