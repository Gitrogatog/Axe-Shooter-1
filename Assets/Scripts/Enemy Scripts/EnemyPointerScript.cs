using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointerScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    //private Rigidbody2D rb;
    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        //playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
