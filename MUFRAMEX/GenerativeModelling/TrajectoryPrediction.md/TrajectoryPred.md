# Application of Deep Generative Modelling in Pedestrian Trajectory Prediction
_Jean-Bernard Hayet_

## **Motivation**
Give the robots the ability of knowing what will happen next

## **Applications**
- Monitoring traffic intersections
- Robot navigation
- Safety around autonomous vehicles.

## **Motion prediction: Problem statement**
- Scenes populated with interacting agents (cars, bicycles, robot,...)
- Positions measured in a fixed frame, either world or image coordinates 


## **Generative models and HTP**
- In many situations, predictive distributions should be moltimodal.

- Auto-encoders to encode the occupancy map

## __Evaluation of HTP methods__
- **Average Displacement Error (ADE):** Evaluates the error on average on the prediction horizon

- **Final Displacement Error (FDE):** Evaluates the error at the last predicted point.

- **Negative log-likelihood (NLL):**  Negative log-likelihood of the ground-truth data evaluated on the output distribution (obtained through KDE).
