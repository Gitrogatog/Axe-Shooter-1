using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightMusicScript : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    int state = 0; //0 = player hasn't touched it, 1 = player touched, playing intro, 2 = intro ended
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1 && !source.isPlaying){
            AudioManager.instance.PlaySound("Boss");
            state = 2;
        }
        if(state == 2 && playerHealth.GetPlayerHealth() <= 0){
            AudioManager.instance.StopSound("Boss");
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && state == 0){
            source.Play();
            state = 1;
        }
    }
}
