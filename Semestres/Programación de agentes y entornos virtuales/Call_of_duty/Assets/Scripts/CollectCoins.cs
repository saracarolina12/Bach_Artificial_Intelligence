﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoins : MonoBehaviour
{
    AudioSource coinsSound;
    public Text Coinstext;
    public int coins;
    bool m_ToggleChange;
    void Start()
    {
        coinsSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider Col){
        if(Col.gameObject.tag == "Coin"){
            coins += 1;
            Col.gameObject.SetActive(false);
            coinsSound.Play();
            Coinstext.text = coins.ToString();
            if(coins == 5) SceneManager.LoadScene("LoadingGame");
        }
         //coinsSound.Stop();
         //m_ToggleChange = false;
    }
}
