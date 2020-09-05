using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinBanner : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("Menu");
    }
}
