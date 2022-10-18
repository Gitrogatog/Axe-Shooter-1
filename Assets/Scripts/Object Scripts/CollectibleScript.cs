using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public int scoreGiven = 100;
    public int healthGiven = 0;
    public int coinsGiven = 0;
    public int meterGiven = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(scoreGiven > 0){
                
            }
            if(healthGiven > 0){

            }
            if(coinsGiven > 0){

            }
            if(meterGiven > 0){

            }
        }
        else if(other.tag == "Axe"){
            transform.parent = other.gameObject.transform;
        }
    }
}
