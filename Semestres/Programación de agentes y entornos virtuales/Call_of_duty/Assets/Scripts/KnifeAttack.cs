    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class KnifeAttack : MonoBehaviour
    {
        public AudioSource[] myAudios;
        private AudioSource knifeSound;
        private AudioSource hurtZombie;
        private AudioSource deathZombie;
        public Text Textkills;
        public GameObject obj;
        PlayerControllers control;
        PlayerControllers.GameplayActions actions;
        private bool weAttacked;
        Animator knifeAnim;
        public int health;
        public int kills = 0;
        
        void Awake()
        {
            health = 3;
            kills = 0;
            Textkills = GameObject.Find("numberKills").GetComponent<Text>(); 
            control = new PlayerControllers();
            actions = control.Gameplay;
            knifeAnim = GetComponent<Animator>();

            myAudios = GetComponents<AudioSource>();
            knifeSound = myAudios[0];
            hurtZombie = myAudios[1];
            deathZombie = myAudios[2];


            actions.Attack.performed += ctx => weAttacked = true;
        }
        private void OnEnable() { 
            control.Enable();
        }
        private void OnDestroy() { 
            control.Disable();
        }
        void Update()
        {
            if(weAttacked == true){
                knifeAnim.SetBool("attacking", true);
                knifeSound.Play();
            }
            else knifeAnim.SetBool("attacking", false);
            weAttacked = false;
        }

        public void OnTriggerEnter(Collider Col){
            if(Col.gameObject.tag == "Zombie"){
                if(weAttacked == true){
                     hurtZombie.Play();
                    if(health>0) health--;
                    if(health == 0){
                        deathZombie.Play();
                        kills++;
                        Textkills.text = kills.ToString();
                        Destroy(Col.gameObject);
                    }
                }
               
            }
        }
    }
