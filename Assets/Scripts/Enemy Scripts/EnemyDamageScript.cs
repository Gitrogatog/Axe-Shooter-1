using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthScript playerHealth = other.gameObject.GetComponent<PlayerHealthScript>();
            if(playerHealth != null){
                playerHealth.HitEnemy(damage);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealthScript playerHealth = collision.gameObject.GetComponent<PlayerHealthScript>();
            if(playerHealth != null){
                playerHealth.HitEnemy(damage);
            }
        }
    }
}
