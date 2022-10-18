using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerTest : MonoBehaviour
{
    public PlayerHealthScript healthScript;
    public LevelLoaderScript level;

    void Update(){
        if(Input.GetKeyDown("b")){
            healthScript.TakeDamage(100);
            Debug.Log("Dead");
        }
        else if(Input.GetKeyDown("h")){
            level.LevelComplete();
            Debug.Log("Finish");
        }
    }
}
