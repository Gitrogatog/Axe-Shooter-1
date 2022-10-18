using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionTestScript : MonoBehaviour
{
    public LevelLoaderScript loadLevelScript;
    private bool activated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!activated && Input.GetKeyDown("space")){
            loadLevelScript.NextLevel();
        }
    }
}
