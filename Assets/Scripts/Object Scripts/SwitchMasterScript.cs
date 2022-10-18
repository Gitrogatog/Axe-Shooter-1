using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMasterScript : MonoBehaviour
{
    public GameObject[] doors;
    public int switchesNeeded = 1;
    private int switchesEnabled = 0;
    private bool isEnabled = false;

    public void EnableSwitch(){
        switchesEnabled++;
        if(switchesEnabled >= switchesNeeded && !isEnabled){
            ActivateDoors();
        }
    }

    public void DisableSwitch(){
        switchesEnabled--;
        if(switchesEnabled < switchesNeeded && isEnabled){
            DeactivateDoors();
        }
    }

    void ActivateDoors(){
        foreach(GameObject d in doors){
            d.BroadcastMessage("Activate");
        }
        isEnabled = true;
    }

    void DeactivateDoors(){
        foreach(GameObject d in doors){
            d.BroadcastMessage("Deactivate");
        }
        isEnabled = false;
    }
}
