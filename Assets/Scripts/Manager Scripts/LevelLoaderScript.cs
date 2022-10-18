using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public Animator other;
    public TextMeshProUGUI transitionText;
    public GameObject otherUI;
    public float transitionTime = 1;
    private int currentLevel = 0;
    bool canReset = false;
    bool canAdvance = false;
    public string[] levelMusic;
    void Awake(){
        otherUI.SetActive(false);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void Update(){
        if(Input.GetKeyDown("escape")){
            QuitGame();
        }
        if(canAdvance && Input.GetKeyDown("space")){
            NextLevel();
            canAdvance = false;
        }
        if(canReset && Input.GetKeyDown("r")){
            ResetLevel();
            canReset = false;
        }
    }
    public void ResetLevel(){
        ChangeLevel(currentLevel);
    }

    public void NextLevel(){
        
        
        ChangeLevel(currentLevel + 1);
    }

    private void ChangeLevel(int newLevel){
        StartCoroutine(LoadLevel(newLevel));
    }

    IEnumerator LoadLevel(int levelIndex){
        if(levelIndex != currentLevel){
            if(currentLevel < levelMusic.Length){
                AudioManager.instance.StopSound(levelMusic[currentLevel]);
            }
        }
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        if(levelIndex < levelMusic.Length && levelIndex != currentLevel){
            AudioManager.instance.PlaySound(levelMusic[levelIndex]);
        }
        SceneManager.LoadScene(levelIndex);
        currentLevel = levelIndex;
    }

    public void PlayerDeath(){
        otherUI.SetActive(true);
        transitionText.text = "You Died! Press R to Restart";
        canReset = true;
    }

    public void LevelComplete(){
        if(!canReset){
            otherUI.SetActive(true);
            canAdvance = true;
            transitionText.text = "Level Complete! Press Space to Continue";
        }
        
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMenu(){
        ChangeLevel(0);
    }
}
