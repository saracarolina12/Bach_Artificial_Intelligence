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

-$\hat{Y}:$ prediction

-$L(.,.):$ Loss function

</p>

### _<u>Errors and errors</u>_
Work arounds:
Add terms to reflect apriori knowledge, use probabilistic upperbounds, split data in train and test.


### **2. Examples of $\hat{Y}(x)$**
_Nearest neighbour and k-NN_
Given x, look at $N_k(x)$ the set of the $k$ closest observations to $x$.

• _Classification:_ decide by voting, assign $x$ to the most frequent class in ${y_i, i \in} N_k(x)$

• _Regression:_ decide by averaging. Calculate avg of ${y_i, i \in N_k(x)}$

<p align="center">
    <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/2_examples.png"> </img>
</p>

#### **Regression Model**
• _Linear model:_ Parameter estimation by maximum the likelihood.


#### **Neural network**
    A single neuron may not do a lot, by many neurons together might do great things.
_Step 1: The base function(=simple function)_
We start composing functions by wrapping the notation we previously saw in the regression model ($x_i$ values multiplied by $\beta_i$).

The wrapper functions can be some basic operations. Like:

- Sign

- Identity

_Step 2: Composition of base functions_
Take as input of a base function (neuron) the output of other base functions (neurons)

Denote function associated with neuron $i$ as $$F(\beta_{i,0}+\sum{_j}\beta_{i,j}x_j)$$

If we change the $\beta$ value of the yellow input, this will actually affect the red output.
$g(z)=g_1(g_2(z)),\frac{dg(z)}{gz}=\frac{dg_1(y)}{dy}\frac{dg_2(z)}{dz}$ with $dg_1(y){dy}$

<p align="center">
    <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/2_neural_networks.png"> </img>
</p>

Instead of summing over all data, take subsamples: _stochastic gradient method_.


## **3. Data and Data**
• From vector based to object based
<p align="center">
    <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/3_book.jpg"> </img>
</p>

• From tall to wide data

<p align="center">
    <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/3_excel.png"> </img>
</p>

Need for (implicit) dimension reduction to an informative (latent) space.

[insert img neural networks]


## **4. Challenges**
_according to M. Jordan_

1. __Uncertainty:__ How to calibrate confidence.
2. __Robustness and adversaries:__ persons are not detected if a piece of paper is interrupting the image.
3. __Biases and fairness:__ If your dataset does not represent the population, mistakes can be made.
4. __Explainability and interpretability:__ Using perturbation methods can tell the importance or not importance of a method.


## **5. Final note**
    Prediction is difficult but enthusiasm is important...too


