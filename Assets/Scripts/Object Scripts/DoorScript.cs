using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //public Collider2D[] startOffDoors;
    //public Collider2D[] startOnDoors;
    private Collider2D col;
    private SpriteRenderer sprite;
    private bool isOn = true;
    public bool startOff = false;
    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        if(startOff){
            isOn = false;
            Deactivate();
        }
        /*
        foreach(Collider2D col in startOffDoors){
            col.enabled = false;
        }
        */
    }

    public void Activate(){
        isOn = true;
        col.enabled = true;
        sprite.enabled = true;
        /*
        foreach(Collider2D col in startOffDoors){
            col.enabled = true;
        }
        foreach(Collider2D col in startOnDoors){
            col.enabled = false;
        }
        */
    }
    public void Deactivate(){
        isOn = false;
        col.enabled = false;
        sprite.enabled = false;
        //Debug.Log("deactivated");
        /*
        foreach(Collider2D col in startOffDoors){
            col.enabled = false;
        }
        foreach(Collider2D col in startOnDoors){
            col.enabled = true;
        }
        */
    }
}
