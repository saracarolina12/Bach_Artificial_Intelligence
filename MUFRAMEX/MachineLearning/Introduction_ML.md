# Machine Learning and other stories
_Johan Van Horebeek_
    "ML is about solving an optimization problem of a not (completely) known function"

### Books
• Regression and other Stories - Andrew Gelman, Jennifer Hill and Aki Vehtari


## **1. Introduction**
*Machine Learning:* systems that learn to solve a problem from data and experience.

### _<u>Application example</u>_
Classify flower types
 <p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/setosa.png"> </img>
</p>

• Calculate discriminator
<p align="center">

$$f(x) = \sum_k\alpha_kx_k$$

</p>

### _<u>Notation and terminology:</u>_
<p>

-$X:$ predictors

-$Y:$ response variable

• regression: $Y\in R$ </br>
• classification: $Y$ is label

-$Yhead:$ prediction

-$L(.,.):$ Loss function

</p>

### _<u>Errors and errors</u>_
Work arounds:
Add terms to reflect apriori knowledge, use probabilistic upperbounds, split data in train and test.


### **2. Examples of Ygorrito(x)**
_Nearest neighbour and k-NN_
Given x, look at $N_k(x)$ the set of the $k$ closest observations to $x$.

• _Classification:_ decide by voting, assign $x$ to the most frequent class in ${y_i, i \in} N_k(x)$

• _Regression:_ decide by averaging. Calculate avg of ${y_i, i \in N_k(x)}$

 <p align="center">
    <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/2_examples.png"> </img>
</p>