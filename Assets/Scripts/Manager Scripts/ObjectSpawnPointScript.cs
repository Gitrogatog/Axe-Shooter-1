using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnPointScript : MonoBehaviour
{
    private bool hasSpawned = false;
    public bool objectDestroyed = false;
    public GameObject obj;
    private GameObject objectInst;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!objectDestroyed && hasSpawned && objectInst == null){
            objectDestroyed = true;
        }
    }

    public void SpawnObject(){
        objectInst = Instantiate(obj, transform.position, transform.rotation);
        hasSpawned = true;
    }
}
