using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelAreaScript : MonoBehaviour
{
    private LevelLoaderScript level;
    private bool playerEntered = false;

    void Awake(){
        level = FindObjectOfType<LevelLoaderScript>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !playerEntered){
            level.LevelComplete();
        }
    }
}
