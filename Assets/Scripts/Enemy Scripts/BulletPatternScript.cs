using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternScript : MonoBehaviour
{
    public BulletStats[] bullets;
    void Awake()
    {
        foreach(BulletStats b in bullets){

            float totalAngle = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + b.angleOffset + 90);
            Rigidbody2D proj = Instantiate(b.bulletRB, transform.position, transform.rotation);
            float xVelo = Mathf.Cos(totalAngle) * b.speed;
            float yVelo = Mathf.Sin(totalAngle) * b.speed;
            proj.velocity = new Vector2(xVelo, yVelo);
        }
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        
    }

    public void CreateBullets(){
        
    }
}
