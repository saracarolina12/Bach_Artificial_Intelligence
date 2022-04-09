using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_GO : MonoBehaviour
{
    public void GoBackTo_MainMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
