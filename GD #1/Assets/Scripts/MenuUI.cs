using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void Exit()
    {

        Application.Quit();
    }
    public void StartBttn()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Level");
    }
}
