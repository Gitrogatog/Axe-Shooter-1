using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointScript : MonoBehaviour
{
    private bool hasSpawned = false;
    public GameObject enemy;
    private GameObject enemyInst;
    public bool enemyDestroyed = false;
    //public bool testEnemyDeath = false;
    private ScreenArenaManagerScript screenScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyDestroyed && hasSpawned && enemyInst == null){
            enemyDestroyed = true;
            if(screenScript != null){
                screenScript.AddDeadEnemy();
            }
        }
    }

    public void SpawnEnemy(ScreenArenaManagerScript screenManagerScript){
        Debug.Log("spawned");
        screenScript = screenManagerScript;
        enemyInst = Instantiate(enemy, transform.position, transform.rotation);
        hasSpawned = true;
        //Destroy(enemyInst, 5f);
    }
}
