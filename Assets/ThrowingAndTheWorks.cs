using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAndTheWorks : MonoBehaviour
{
    public Transform throwingPoint;
    public GameObject axe;
    public Animator animator;
    public float axeForce = 10f;
    public bool holdingAxe;
    Axe retribution;
    //bool clingPossibility;

    private void Start()
    {
        retribution = axe.GetComponent<Axe>();
        //Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), axe.GetComponent<PolygonCollider2D>());
        //clingPossibility = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (holdingAxe)
            {
                retribution.ThrowThyself(throwingPoint, axeForce);
                holdingAxe = false;
            } else
            {
                retribution.Summon(axeForce);
            }
        }
        if (Input.GetButtonDown("Fire2") && !holdingAxe)
        {
           if (retribution.state == 2)
            {
                transform.position = axe.transform.position;
                axe.transform.parent = gameObject.transform;
                holdingAxe = true;
                Rigidbody2D axeRigidbody = axe.GetComponent<Rigidbody2D>();
                axeRigidbody.simulated = false;
                Axe aScript = axe.GetComponent<Axe>();
                aScript.state = 0;
                //GameObject shockwave = GameObject.FindGameObjectWithTag("shockwave");
                //Destroy(shockwave);
            }
        }
        animator.SetBool("Holding", holdingAxe);
    }
}
