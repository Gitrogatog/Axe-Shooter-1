using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefillScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealthScript health = other.gameObject.GetComponent<PlayerHealthScript>();
            health.RefillHealth();
            Destroy(gameObject);
        }
    }
}
