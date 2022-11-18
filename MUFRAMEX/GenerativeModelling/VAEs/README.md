# Introduction to generative modelling

## VAEs, NFs and GANs

_Émile Mathieu_

## **What is generative modelling?**

- Given a distribution $\pi\in\rho(\reals^d)$  how to obtain sample from $\pi$

- Access to the empirical distribution


## **Applications**

- Nowcasting (meteorology). 

    - Prediction of rain in the next 2 hours (nowcasting)    
    <p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/GenerativeModelling/imgs/nowcasting.png"> </img>
    </p>

- Computational Biology.
    
    - Amino-acid sequence to 3D structure
    
    - Determine the shape of the protein.
    <p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/GenerativeModelling/imgs/protein.png"> </img>
    </p>


# **Variational Autoencoders**

## **Introduction to ELBO**

_<u>Manifold hypothesis</u>_

- The data distribution is supported on a space (submanifold).
(e.g How many muscles you have in your face).

- Evaluating the log-likelihood is a **marginalisation** problem.

