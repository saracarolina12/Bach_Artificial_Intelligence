# Score-based generative models

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

