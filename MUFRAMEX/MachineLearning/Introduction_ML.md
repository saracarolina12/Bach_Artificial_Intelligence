# Machine Learning and other stories
_Johan Van Horebeek_

### Books
• Regression and other Stories - Andrew Gelman, Jennifer Hill and Aki Vehtari


## 1. Introduction
**Machine Learning:** systems that learn to solve a problem from data and experience.

### Application example
Classify flower types
 <p align="center">
        <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/MachineLearning/imgs/setosa.png"> </img>
    </p>

• Calculate discriminator
<p align="center">

$$f(x) = \sum_k\alpha_kx_k$$

</p>

### Notation and terminology:
<p>

-$X:$ predictors

-$Y:$ response variable

• regression: $Y\in R$ </br>
• classification: $Y$ is label

-$Yhead:$ prediction

-$L(.,.):$ Loss function

</p>

### Errors and errors
Work arounds:
Add terms to reflect apriori knowledge, use probabilistic upperbounds, split data in train and test.
