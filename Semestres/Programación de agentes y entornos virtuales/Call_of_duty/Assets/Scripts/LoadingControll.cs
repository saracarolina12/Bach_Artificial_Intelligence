using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random=UnityEngine.Random;

public class LoadingControll : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    public Text loadText;
    String[] str = new String[] {
        "Awaiting for textures...",
        "Loading assets",
        "Synchronizing game settings...",
        "Awaiting gamestate","Getting ready",
        "Building interfaces",
        "Setting up everything..."
    };
    
    float[] randomTime = new float[]{
        0.5f,
        0.8f,
        1.2f,
        1.9f,
        1.6f
    };
    int[] randomSlider = new int[]{
        5,
        8,
        10,
        3,
        15
    };

    void Awake()
    {
        Debug.Log("Awake");
        slider.value = 0;
    }

    void Start()
    {
        Debug.Log("Start1");
        Debug.Log(slider.value);
        StartCoroutine(ChangeProgressBar());
    }
    IEnumerator ChangeProgressBar(){
        while(slider.value <= 100){
            slider.value+= randomSlider[Random.Range(0, randomSlider.Length)];
            yield return new WaitForSeconds (.5f);
            loadText.text = str[Random.Range(0, str.Length)];
            float num = randomTime[Random.Range(0, randomTime.Length)];
            yield return new WaitForSeconds (num);
            Debug.Log(num);    
            if(slider.value >= 100) break;
        }
        yield return new WaitForSeconds (1.2f); 
        Debug.Log("100% Change to main");
        SceneManager.LoadScene("Main");   
    }

    // public static IEnumerator changeText(){
    //     Text.text = "Awaiting for textures...";
    //     yield return new WaitForSeconds (.5f);
    //     Text.text = ;
    //     yield return new WaitForSeconds (1f);
    //     Text.text = ;
    //     yield return new WaitForSeconds (0.2f);
    //     Text.text = ;
    //     yield return new WaitForSeconds (2f);
    //     Text.text = ;
    //     yield return new WaitForSeconds (0.1f);
    // }


}
