using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 pastVelo = Vector2.zero;
    public bool useStartSpeed = false;
    public float startX = 1;
    public float startY = 1;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(useStartSpeed){
            rb.velocity = new Vector2(startX * RandSign(), startY * RandSign());
        }
        pastVelo = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        pastVelo = rb.velocity;
        if(pastVelo.x == 0 && pastVelo.y == 0){
            rb.velocity = new Vector2(startX * RandSign(), startY * RandSign());
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        float speed = pastVelo.magnitude;
        Vector2 direction = Vector2.Reflect(pastVelo.normalized, collision.contacts[0].normal);
        Vector2 newVelo = direction * speed;
        rb.velocity = newVelo;
    }

    private int RandSign(){
        int value = Random.Range(0, 2);
        if(value == 0){
            value = -1;
        }
        return value;
    }
}
