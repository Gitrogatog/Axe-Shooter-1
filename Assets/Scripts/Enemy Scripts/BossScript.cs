using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    public float spinSpeed;
    private Quaternion currentRotation;
    private int state; // 0 = rotating towards player; 1 = spinning and attacking
    EnemyBulletSpawner enemyBullet;
    //private Rigidbody2D rb;
    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        state = 0;
        enemyBullet = GetComponent<EnemyBulletSpawner>();
        enemyBullet.enabled = false;

        //playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 5f * Time.deltaTime);
            if (transform.rotation == player.transform.rotation)
            {
                state = 1;
                currentRotation = transform.rotation;
            }

        } else if (state == 1)
        {
            enemyBullet.enabled = true;
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            if (transform.rotation == currentRotation)
            {
                state = 0;
            }
        }
    }
}
