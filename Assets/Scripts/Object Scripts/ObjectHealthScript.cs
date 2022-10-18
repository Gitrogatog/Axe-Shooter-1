using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthScript : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth = 1;
    public GameObject deathSpawn;
    private Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void UpdateHealth(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            //AudioManager.instance.PlaySound("Enemy Death " + Random.Range(1, 2));
            AudioManager.instance.PlaySound("Enemy Death 2");
            if(deathSpawn != null){
                GameObject death = Instantiate(deathSpawn, transform.position, transform.rotation);
                Destroy(death, 3f);
                Debug.Log("Death Spawned");
            }
            Destroy(gameObject);
        }
        else{
            AudioManager.instance.PlaySound("Enemy Death 1");
            //AudioManager.instance.PlaySound("Hit " + Random.Range(1, 2));
            animator.SetBool("IsHurt", true);
        }
    }

    public void StopHurt(){
        animator.SetBool("IsHurt", false);
    }
}
