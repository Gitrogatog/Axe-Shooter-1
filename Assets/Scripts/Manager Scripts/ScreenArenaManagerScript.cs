using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenArenaManagerScript : MonoBehaviour
{
    //public ObjectSpawnPointScript[] objectSpawns;
    public EnemySpawnPointScript[] enemySpawns;
    public DoorScript[] disableOnEnterDoors;
    public DoorScript[] enableOnEnterDoors;
    public DoorScript[] disableOnExitDoors;
    public DoorScript[] enableOnExitDoors;
    private PlayerMovement playerScript;
    private bool playerEntered = false;
    private int numDead = 0;
    public float walkXDir;
    public float walkYDir;
    public bool startingArea; 

    void Start(){
        playerScript = FindObjectOfType<PlayerMovement>();
        /*
        foreach(DoorScript door in enableOnEnterDoors){
            if(door != null){
                door.Deactivate();
            }
            
        }
        foreach(DoorScript door in disableOnEnterDoors){
            if(door != null){
                door.Activate();
            }
            
        }
        foreach(DoorScript door in enableOnExitDoors){
            if(door != null){
                door.Deactivate();
            }
            
        }
        foreach(DoorScript door in disableOnExitDoors){
            if(door != null){
                door.Activate();
            }
            
        }
        */
    }
    
    void Update()
    {
        if(playerEntered){
            if(numDead >= enemySpawns.Length){
                RoomCompleted();
            }
            /*
            bool allDead = true;
            foreach(EnemySpawnPointScript s in enemySpawns){
                allDead = s.enemyDestroyed;
            }
            if(allDead){
                RoomCompleted();
            }
            */
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !playerEntered){
            PlayerEnter();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && playerEntered){
            PlayerExit();
        }
    }

    void PlayerEnter(){
        if(!playerEntered){
            playerEntered = true;
            foreach(EnemySpawnPointScript s in enemySpawns){
                s.SpawnEnemy(this);
            }
            if (!startingArea)
            {
                playerScript.LockPlayerWalk(new Vector2(walkXDir, walkYDir));
            }
            /*
            foreach(ObjectSpawnPointScript o in objectSpawns){
                o.SpawnObject();
            }
            
            */
        
            
        }

    
        
    }

    void PlayerExit(){
        foreach(DoorScript door in enableOnEnterDoors){
            if(door != null){
                door.Activate();
            }
            
        }
        foreach(DoorScript door in disableOnEnterDoors){
            if(door != null){
                door.Deactivate();
            }
            
        }
        playerScript.UnlockPlayerWalk();
    }

    void RoomCompleted(){
        foreach(DoorScript door in enableOnExitDoors){
            if(door != null){
                door.Activate();
            }
            
        }
        foreach(DoorScript door in disableOnExitDoors){
            if(door != null){
                door.Deactivate();
            }
            
        }
    }

    public void AddDeadEnemy(){
        numDead++;
    }
}
