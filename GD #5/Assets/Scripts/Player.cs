using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlaying;
    public void ChangeMode()
    {
        //Debug.Log("Changing Mode");
        if (isPlaying) {
            GameManager.ChangeModeToEditing();
            isPlaying = false;
        }
        else
        {
            GameManager.ChangeModeToPlaying();
            isPlaying = true;
        }

    }
    public void SaveGame()
    {
        GameManager.SaveGame();
    }
    public void LoadLast()
    {
        GameManager.LoadGame();
    }
    public void ActivateDeath()
    {
        Debug.Log("PlayerDeath");
        gameObject.GetComponent<Animator>().SetTrigger("Death");
    }
}
