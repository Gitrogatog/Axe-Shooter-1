using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "object" || collision.tag == "Enemy")
        {
            //ObjectHealthScript objectHealth = collision.GetComponent<ObjectHealthScript>();
            //objectHealth.UpdateHealth(damage);
        }
    }



}
