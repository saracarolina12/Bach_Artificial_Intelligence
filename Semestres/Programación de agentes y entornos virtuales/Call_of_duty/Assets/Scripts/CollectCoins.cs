using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoins : MonoBehaviour
{
    AudioSource coinsSound;
    public Slider healthBar;
    public Image healthfill;
    public Text Coinstext;
    public int coins;
    bool m_ToggleChange;
    void Start()
    {
        coinsSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public IEnumerator OnTriggerEnter(Collider Col){
        if(Col.gameObject.tag == "Coin"){
            coins += 1;
            Col.gameObject.SetActive(false);
            coinsSound.Play();
            Coinstext.text = coins.ToString();
            if(coins == 5){
                yield return new WaitForSeconds (1f);
                SceneManager.LoadScene("Winner");
            }
             yield return new WaitForSeconds (0f);
        }else if(Col.gameObject.tag == "Zombie"){
                yield return new WaitForSeconds (1f);
                healthBar.value++;
                Debug.Log(healthBar.value);
                if(healthBar.value == 10){
                    yield return new WaitForSeconds (1f);
                    SceneManager.LoadScene("GameOver");
                }
        }
        yield return new WaitForSeconds (0f);
    }
}
