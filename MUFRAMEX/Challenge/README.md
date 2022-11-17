# 🚶🏽‍♀️ **Human Motion Prediction**

<p align="center">
    <img width="30%" src="https://raw.githubusercontent.com/saracarolina12/IA_School/master/MUFRAMEX/Challenge/imgs/walking.gif"> </img>
</p>

## **Objective**
- Generate multiple predictions for an initial motion sequence.

## **Base model**
- Regression problem
- Deterministic model (for 1 input)
- Forked from <u>_[here]()_</u>

## **Data**
- Rough data from H3.6m have 99 values per frame; first 3 are global translation of the person in space; the rest are joint angles.
- Selection process that selects 54 of these variables.
- Normalization process to center the data and set them to unitary variance.

These steps are done in _read_all_data()_

## **Prediction evaluation**
- Done after conversion of the data into Euler angles (in radians).
- Function evaluate_batch
- The squared difference between Euler angles (ground truth vs predicted).