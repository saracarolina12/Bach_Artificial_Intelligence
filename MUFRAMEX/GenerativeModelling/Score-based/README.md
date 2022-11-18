# Score-based generative models
_Émile_

## **Energy-based models (EBMs)**

### _What are EBMs?_
An energy-based model is a probabilistic model governed by an energy function that describes the probability of a certain state.

### _Approach_
- Capture dependencies by associating an unnormalized probability scalar (energy) to each configuration of the combination of observed and latent variables.


### _Applications_
- Natural language processing
- Robotics
- Computer vision


### _Langevin Dynamics_

- LD is an iterative algorithm that introduces noise to the estimator as part of learning an objective function.
- It can be used for Bayasian learning scenarios by producing samples from a posterior distribution
- EBMs do not need that energies be normalized as probabilities  (they do not need to sum 1)

### _Characteristics_
- **Simplicity and stability:** EBM need to be designed and traines. Separate networks need not be trained to ensure balance.
- **Flexibility_** In VAE and flow-based models, the generator learns a map from a continuous space to a discontinuous space containing different data modes.


### _Experimental results_
    An EBM model generated high-quality images relatively quickly in both examples
* CIFAR-10

<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/GenerativeModelling/imgs/CIFAR-10.png"> </img>
</p>

* ImageNet 32x32
<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/GenerativeModelling/imgs/ImageNet.png"> </img>
</p>

