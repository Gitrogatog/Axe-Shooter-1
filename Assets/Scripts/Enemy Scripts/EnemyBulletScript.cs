using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public int damage = 1;
    //public float speed = 5;
    //public float angleOffset;
    public bool doesTurn = false;
    public bool isHoming = false;
    public bool destroyOnHit = true;
    public bool destroyOnDamage = true;
    public float decel = 0;
    public float lifetime = 10;
    private float timer;
    private Rigidbody2D rb;
    void Start()
    {
        timer = lifetime;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(gameObject);
        }
        if(isHoming){
            
        }
        if (doesTurn && (rb.velocity.y != 0 || rb.velocity.x != 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 180 * Mathf.Atan2(rb.velocity.y, rb.velocity.x) / Mathf.PI);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealthScript playerHealth = other.gameObject.GetComponent<PlayerHealthScript>();
            if(playerHealth != null){
                playerHealth.HitEnemy(damage);
            }
            if(destroyOnDamage){
                Destroy(gameObject);
            }
        }
        else if(other.tag == "wall" && destroyOnHit){
            Destroy(gameObject);
        }
    }

    /*
    public void ActivateBullet(float totalAngle, float startSpeed){
        //float totalAngle = startAngle + Mathf.PI * angleOffset / 180;
        float xVelo = Mathf.Cos(totalAngle) * startSpeed;
        float yVelo = Mathf.Sin(totalAngle) * startSpeed;
        rb.velocity = new Vector2(xVelo, yVelo);
    }
    */
}
