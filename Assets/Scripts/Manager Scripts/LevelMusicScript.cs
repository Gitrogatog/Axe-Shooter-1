using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicScript : MonoBehaviour
{
    public string musicName;

    void Start(){
        Invoke("PlayMusic", .5f);
    }

    void PlayMusic(){
        AudioManager.instance.PlaySound(musicName);
    }
}
