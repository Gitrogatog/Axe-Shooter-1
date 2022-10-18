using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth = 1;
    public float invulTime = 2;
    private float timer;

    private PlayerDeathScript deathScript;
    public TextMeshProUGUI healthText;
    void Start()
    {
        deathScript = GetComponent<PlayerDeathScript>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        if(healthText != null){
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            KillPlayer();
            if(CinemachineShakeScript.instance != null){
                CinemachineShakeScript.instance.ShakeCamera(10, .5f);
                AudioManager.instance.PlaySound("Player Death");
            }
        }
        else{
            timer = invulTime;
            AudioManager.instance.PlaySound("Hit 3");
            if(CinemachineShakeScript.instance != null){
                CinemachineShakeScript.instance.ShakeCamera(9, .4f);
            }
        }
    }

    public void HitEnemy(int damage){
        //if player is not invincible
        if(timer <= 0){
            TakeDamage(damage);
        }
        
    }

    void KillPlayer(){
        AudioManager.instance.PlaySound("Player Death");
        deathScript.KillPlayer();
    }

    public void RefillHealth(){
        currentHealth = maxHealth;
    }

    public int GetPlayerHealth(){
        return currentHealth;
    }
}
