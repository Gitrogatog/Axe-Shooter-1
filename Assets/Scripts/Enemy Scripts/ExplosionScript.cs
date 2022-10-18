using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 1;
    private float timer;

    void Awake()
    {
        AudioManager.instance.PlaySound("Explosion");
        timer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealthScript healthScript = other.gameObject.GetComponent<PlayerHealthScript>();
            if(healthScript != null){
                healthScript.TakeDamage(damage);
            }
        }
        else if (other.tag == "Enemy" || other.tag == "object"){
            ObjectHealthScript objHealthScript = other.gameObject.GetComponent<ObjectHealthScript>();
            if(objHealthScript != null){
                objHealthScript.UpdateHealth(damage);
            }
        }
    }
}
