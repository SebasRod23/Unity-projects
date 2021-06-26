using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text[] txts;
    public GameObject winPanel, loosePanel;
    public bool isWaiting;
    public float waitTime;
    public Text[] txt;
    public float gameTime;
    public Text time;
    public GameObject coinList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            if (waitTime <= 0)
            {
                isWaiting = false;
                waitTime = 6;
                ReloadScene();
            }
            else
            {
                waitTime = waitTime - Time.deltaTime;
                txt[1].text = "Restarting in ... " + Mathf.RoundToInt(waitTime);
            }
        }
        else
        {
            if (CheckCoins()) endGame(true);
            else
            {
                if (gameTime <= 0)
                {
                    endGame(false);
                }
                else
                {
                    gameTime = gameTime - Time.deltaTime;
                    time.text = "Time: " + Mathf.RoundToInt(gameTime);
                }
            }
        }
        
    }

    public bool CheckCoins()
    {
        foreach(Text txt in txts)
        {
            if (txt.text != "Collected") return false;
        }
        return true;
    }
    public void endGame(bool won)
    {
        if (won)
        {
            winPanel.SetActive(true);
            txt = winPanel.GetComponentsInChildren<Text>();
        }
        else
        {
            loosePanel.SetActive(true);
            txt = loosePanel.GetComponentsInChildren<Text>();
        }
        isWaiting = true;
        coinList.SetActive(false);
        
    }
    public void ReloadScene()
    {
        Debug.Log("Reloaded");
        SceneManager.LoadScene("Level");
    }
}
