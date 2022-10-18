using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public float speed = 5;
    public bool controlRotation = true;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = playerTransform.position - transform.position;
        lookDir.Normalize();
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if(controlRotation){
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        rb.velocity = new Vector2(lookDir.x * speed, lookDir.y * speed);
    }
}
