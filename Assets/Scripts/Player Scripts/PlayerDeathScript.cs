using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer sprite;
    private PlayerMovement playerMovement;
    public GameObject deathObject;
    public LevelLoaderScript levelLoader;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void KillPlayer(){
        col.enabled = false;
        //sprite.enabled = false;
        animator.SetTrigger("Death");
        playerMovement.KillPlayer();
        levelLoader.Invoke("PlayerDeath", 3f);
    }
}
