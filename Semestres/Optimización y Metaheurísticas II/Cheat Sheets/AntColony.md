# 🐜 Ant Colony 

_by Marco Dorigo 1990_

## **Characteristics**
• Inspired by ant's colony foraging behaviour.
<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants.jpg"> </img>
</p>

## **Background**
Ants are insects that prefer community survival rather than as individual species.

They communicate with each other through sounds, touch and pheromone.


Pheromones are organic chemical compounds secreted by the ants so that members of their same species smell it and know where other ants have been. This is how ants think smartly so they gradually improve their food search





##  **Applications**

<table><tr><td>
    <p align="center">
        <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants_appl.png"> </img>
    </p>
</td><td>

### _[Find short paths]()_
Calculate the shortest path between two cities.
</td><tr>
</table>

##  **Representations**
The solution is represented with graphs.
<p align="center">
        <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants.gif"> </img>
</p>


## **Selecting the next node**


<table><tr><td>
    <p align="center">
        <img width="60%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants_nextnode.png"> </img>
    </p>


</td><td>
<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants_formula.png"> </img>
</p>

where $N_i$ represents all the nodes where the ant can move in the next steps (not visited nodes).

$\alpha$ and $\beta$ control the importance of the pheromone vs the heuristic information. 

</td><tr>
</table>


## **Update Pheromones**
Give more weight (pheromones) to the shortest path.
<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants_update.png"> </img>
</p>

## **Evaporate Pheromones**
When ants stop going through a specific path, gradually evaporate it.
<p align="center">
    <img width="20%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/Semestres/Optimizaci%C3%B3n%20y%20Metaheur%C3%ADsticas%20II/Cheat%20Sheets/imgs/ants_evaporate.png"> </img>
</p>


---
## **Pseudocode**
    • First of all:
        Initialize pheromones with a small value

    • Move the ants one by one:
        - Use the previous equation and start moving the ants around the graph (node by 
        node).
    
    • When all the ants record the graph:
        - Update pheromones 
        - Evaporate pheromones
---

#### _By Sara Carolina_