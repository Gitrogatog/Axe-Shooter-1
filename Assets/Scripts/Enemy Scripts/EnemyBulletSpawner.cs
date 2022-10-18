using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public SpawnerStats[] spawnerStats;
    //public GameObject bulletPattern;
    public Transform bulletSource;
    public float timerOffset = 1;
    public float waveCooldown = 5;
    private float timer;
    private int spawnerIndex = -1;
    private int loopsLeft = 0;
    private bool offsetEnded = false;
    //public int shootSound = 1;
    void Awake()
    {
        timer = timerOffset;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            if(!offsetEnded){
                offsetEnded = true;
                spawnerIndex = 0;
                loopsLeft = spawnerStats[spawnerIndex].numLoops;
            }
            /*
            if(spawnerIndex == spawnerStats.Length){
                spawnerIndex = -1;
                timer = waveCooldown;
            }
            else */
            if(spawnerIndex < 0 || spawnerIndex >= spawnerStats.Length){
                Debug.Log("Error: spawnerIndex is not in index: " + spawnerIndex);
                spawnerIndex = 0;
            }
            else{
                AudioManager.instance.PlaySound("Shoot " + Random.Range(1, 6));
                Instantiate(spawnerStats[spawnerIndex].bulletPattern, bulletSource.position, transform.rotation);
                if(loopsLeft > 0){
                    timer = spawnerStats[spawnerIndex].timeToNextLoop;
                    loopsLeft--;
                }
                else{
                    IncreaseIndex();
                }
                /*
                if(spawnerStats[spawnerIndex].numLoops == 0){
                    
                    IncreaseIndex();
                }
                else{
                    if(loopsLeft > 0){
                        loopsLeft--;
                        if(loopsLeft == 0){
                            
                            IncreaseIndex();
                        }
                        else{
                            timer = spawnerStats[spawnerIndex].timeToNextLoop;
                        }
                    }
                    else{
                        loopsLeft = spawnerStats[spawnerIndex].numLoops;
                        timer = spawnerStats[spawnerIndex].timeToNextLoop;
                    }
                }
                */ 
            }
        }
        /*
        if(timer <= 0){
            Instantiate(bulletPattern, bulletSource.position, transform.rotation);
            timer = shootCooldown;
        }
        */
    }

    void IncreaseIndex(){
        timer = spawnerStats[spawnerIndex].timeToNextShot;
        spawnerIndex++;
        if(spawnerIndex >= spawnerStats.Length){
            spawnerIndex = 0;
            timer += waveCooldown;
        }
        loopsLeft = spawnerStats[spawnerIndex].numLoops;
    }
}
