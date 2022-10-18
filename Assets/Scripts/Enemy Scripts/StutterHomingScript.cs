using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StutterHomingScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public float speed = 5;
    public bool controlRotation = true;
    public float moveTime = 2;
    public float waitTime = 2;
    public float startWaitTime;
    private float timer;
    private int state = 0; //0 = startWait, 1 = normalWait, 2 = moving

    private Vector2 currentDir = Vector2.zero;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>(); 
        timer = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            if(state == 0 || state == 1){
                timer = moveTime;
                state = 2;
                currentDir = playerTransform.position - transform.position;
                currentDir.Normalize();
            }
            else{
                timer = waitTime;
                state = 1;
                currentDir = Vector2.zero;
            }
        }
        if(state == 2){
            rb.velocity = new Vector2(currentDir.x * speed, currentDir.y * speed);
            if(controlRotation){
                float angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        else{
            rb.velocity = Vector2.zero;
        }
        /*
        Vector2 lookDir = playerTransform.position - transform.position;
        lookDir.Normalize();
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if(controlRotation){
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        rb.velocity = new Vector2(lookDir.x * speed, lookDir.y * speed);
        */
    }
}
