using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingControll : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;

    //private float update;

    void Awake()
    {
        Debug.Log("Awake");
        slider.value = 0;
        //update = 0.0f;
    }

    void Start()
    {
        Debug.Log("Start1");
        Debug.Log(slider.value);
        StartCoroutine(ChangeProgressBar());
    }
    IEnumerator ChangeProgressBar(){
        while(slider.value <= 100){
            slider.value+= 5;
            Debug.Log("before");
            yield return new WaitForSeconds (.5f);
            Debug.Log(slider.value);    
            Debug.Log("after");
            if(slider.value == 100)break;
        }
        yield return new WaitForSeconds (1.2f); 
        Debug.Log("100% Change to main");
        SceneManager.LoadScene("Main");   
        Debug.Log(slider.value);  
    }


}
