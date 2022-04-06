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
    void Start(){
        ExecuteAfterTime(1f);
    }
  
     IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    
         for(;;){
             Console.WriteLine(slider.value);
            slider.value++;
            if(slider.value == 0.9f){
                slider.value = 1f;
                break;
            }
            ExecuteAfterTime(2f);
        }
    }

}
