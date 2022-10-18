using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public SwitchMasterScript masterScript;
    private bool isEnabled = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Axe"){
            isEnabled = !isEnabled;
            if(isEnabled){
                masterScript.EnableSwitch();
            }
            else{
                masterScript.DisableSwitch();
            }
        }
    }
}
