using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoins : MonoBehaviour
{
    public AudioSource[] myAudios;
    public AudioSource coinsSound; //1
    public AudioSource zombieAttack; //2
    public AudioSource endGame; //3
    public AudioSource Ouch; //4
    public AudioSource ByeBye; //5
    public AudioSource GAMEOVER; //6
    public Slider healthBar;
    public Image healthfill;
    public Text Coinstext;
    public int coins;
    bool m_ToggleChange;
    public GameObject m_GotHitScreen;
    public Camera mainCamera;
    private Vector3 currentPos;
    private Quaternion currentRot;
    public Text textTry, textExit, gameoverText; 
    void Start()    
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        myAudios = GetComponents<AudioSource>();
        coinsSound = myAudios[0];
        zombieAttack = myAudios[1];
        endGame = myAudios[2];
        Ouch = myAudios[3];
        ByeBye = myAudios[4];
        GAMEOVER = myAudios[5];
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
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a = 0.7f;
                m_GotHitScreen.GetComponent<Image>().color = color;
                zombieAttack.Play();
                yield return new WaitForSeconds (0.5f);
                healthBar.value++;
                //Debug.Log(healthBar.value);
                if(healthBar.value > 10){
                   //DETENGO AUDIO
                    Ouch.Stop();
                    Ouch.volume = 0.0f;
                    //COLOR RED SCREEN
                    color = m_GotHitScreen.GetComponent<Image>().color;
                    color.a = 0.6f;
                    m_GotHitScreen.GetComponent<Image>().color = color;
                    //TIRO LA CÁMARA AL PISO
                    Vector3 newCameraPos = new Vector3(currentPos[0],-0.002f,currentPos[2]);
                    mainCamera.transform.position = newCameraPos;
                    Quaternion newCameraRot = Quaternion.Euler(-4.7f,currentRot[1],-58.11f);
                    mainCamera.transform.rotation = newCameraRot;
                    //SHOW TEXT GAME OVER
                    Debug.Log("GameOver");
                    var GOcolor = gameoverText.GetComponent<Text>().color;
                    color.a = 1f;
                    gameoverText.GetComponent<Text>().color = color;
                    //SHOW BUTTONS GAME OVER
                    var trycolor = textTry.GetComponent<Text>().color;
                    color.a = 1f;
                    textTry.GetComponent<Text>().color = color;
                    var exitcolor = textExit.GetComponent<Text>().color;
                    color.a = 1f;
                    textExit.GetComponent<Text>().color = color;
                    //BYE BYE
                    ByeBye.Play();
                    yield return new WaitForSeconds (4f);
                    endGame.Play();
                    coinsSound.Stop(); 
                    zombieAttack.Stop();
                    endGame.Stop();
                    Ouch.Stop();
                    ByeBye.Stop(); 
                    GAMEOVER.Play();
                    //yield return new WaitForSeconds (4.6f);
                    //SceneManager.LoadScene("GameOver");
                }
        }else if(Col.gameObject.tag == "Obstacle"){
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a = 0.7f;
                m_GotHitScreen.GetComponent<Image>().color = color;
                Ouch.Play();
                yield return new WaitForSeconds (0.5f);
                healthBar.value++;
                if(healthBar.value > 10){
                   //DETENGO AUDIO
                    Ouch.Stop();
                    Ouch.volume = 0.0f;
                    //COLOR RED SCREEN
                    color = m_GotHitScreen.GetComponent<Image>().color;
                    color.a = 0.6f;
                    m_GotHitScreen.GetComponent<Image>().color = color;
                    //TIRO LA CÁMARA AL PISO
                    Vector3 newCameraPos = new Vector3(currentPos[0],-0.002f,currentPos[2]);
                    mainCamera.transform.position = newCameraPos;
                    Quaternion newCameraRot = Quaternion.Euler(-4.7f,currentRot[1],-58.11f);
                    mainCamera.transform.rotation = newCameraRot;
                    //SHOW TEXT GAME OVER
                    var GOcolor = gameoverText.GetComponent<Text>().color;
                    color.a = 1f;
                    gameoverText.GetComponent<Text>().color = color;
                    //SHOW BUTTONS GAME OVER
                    var trycolor = textTry.GetComponent<Text>().color;
                    color.a = 1f;
                    textTry.GetComponent<Text>().color = color;
                    var exitcolor = textExit.GetComponent<Text>().color;
                    color.a = 1f;
                    textExit.GetComponent<Text>().color = color;
                    //BYE BYE
                    ByeBye.Play();
                    yield return new WaitForSeconds (4f);
                    endGame.Play();
                    ByeBye.Stop();
                    endGame.Stop();
                    GAMEOVER.Play();
                    //yield return new WaitForSeconds (4.6f);
                    //SceneManager.LoadScene("GameOver");
                }
        }
        yield return new WaitForSeconds (0f);
    }

    public void Update(){
        currentPos = new Vector3( mainCamera.transform.position[0],  mainCamera.transform.position[1],  mainCamera.transform.position[2]);
        currentRot = Quaternion.Euler(mainCamera.transform.rotation[0],  mainCamera.transform.rotation[1],  mainCamera.transform.rotation[2]);

        if(m_GotHitScreen.GetComponent<Image>().color.a > 0  && healthBar.value < 10){
            var color = m_GotHitScreen.GetComponent<Image>().color;
            color.a -= 0.02f;
            m_GotHitScreen.GetComponent<Image>().color = color;
        }
    }
 
}


