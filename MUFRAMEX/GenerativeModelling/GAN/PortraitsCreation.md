# 👩🏽 **How to take portraits of people who do not exist?**
_Mariano Rivera_

_<u>[See more about Mariano's projects](http://personal.cimat.mx:8181/~mrivera/cursos/temas_aprendizaje.html)</u>_

## **Data Generation**
We need to estimate the data distribution and generate samples.

1. The generated images are similar to those of the training database.
2. The generator is parameterized by a vector of latent variables with a know distribution and simple to sample
3. The generated images are not present in the training database; it is not a simple memory.


## **Autoencoder**

Take the data(real data), compress it and finally expand it (this is our prediction).


## **Variational Autoencoder**
The problem is the solution is stochastic and doesn't allow backpropagation.

We can solve this with reparametrization trick.


## **VAE Loss**

1. Recontruction error
2. The desviation of the latent variables distribution respect to the normal gaussian.


## **Pix2pix**
<p align="center">
        <img width="40%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/AI/imgs/pix2pix.jpg"> </img>
</p>