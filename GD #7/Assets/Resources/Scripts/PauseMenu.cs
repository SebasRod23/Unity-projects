using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused=false;
    public GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resuming...");
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Pausing...");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Pausing...");
        GameObject.Find("GameManager").GetComponent<GameManager>().StopAll();
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("Menu");
    }
}
