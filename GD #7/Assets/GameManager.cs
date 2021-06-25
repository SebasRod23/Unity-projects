using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static int points=0;
    public Text lblPoints;
    public Text lblTime;
    public static GameObject finishPanel;
    public static int time = 180;
    public static Text primaryText;
    public static Text secondaryText;

    public static void addPoints(int p)
    {
        points = points + p;
    }
    private void Start()
    {
        points = 0;
        time = 180;
        if (lblTime != null)
        {
            lblTime.text = "Time: 210";
            setTime();
            setFinish();
        }
    }
    public void setFinish()
    {
        finishPanel = GameObject.Find("Finish");
        primaryText = (Text) GameObject.Find("PrincipalMessage").GetComponent<Text>();
        secondaryText = GameObject.Find("SecondaryMessage").GetComponent<Text>();
        finishPanel.active = false;
    }
    public static int getPoints()
    {
        return points;
    }
    public static void reduceTime(int t)
    {
        time = time - t;
    }
    public static int getTime()
    {
        return time;
    }
    private void Update()
    {
        lblPoints.text = "Points: "+getPoints();
        if (time == 0) FinishGame();

    }
    public static void EndGame()
    {
        finishPanel.active = true;
        primaryText.text = "YOU WON";
        addPoints(time * 50);
        secondaryText.text = "SCORE: " + getPoints();
        primaryText.color = Color.green;
        GameManager g = new GameManager();
        //g.StopAll();
    }

    public static Text getPrimaryText()
    {
        return primaryText;
    }
    public static Text getSecondaryText()
    {
        return secondaryText;
    }
    public static GameObject getFinishPanel()
    {
        return finishPanel;
    }
    public void FinishGame()
    {
        GameObject fPanel = getFinishPanel();
        Text pText = getPrimaryText();
        Text sText = getSecondaryText();
        fPanel.active = true;
        pText.text = "TIME'S UP, YOU LOST";
        sText.text = "SCORE: " + getPoints();
        pText.color = Color.red;
        StopAll();
    }
    private void setTime()
    {
        InvokeRepeating("reduceByOneSecond", 2f, 1f);
    }
    public bool hidden=false;
    private void reduceByOneSecond()
    {
        if (Time.deltaTime != 0) time = time - 1;
        lblTime.text = "Time: " + time;
        if (time <= 190 && !hidden)
        {
            GameObject.Find("Instructions").active = false;
            hidden = true;
        }
    }
    public void StopAll()
    {
        CancelInvoke();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level");
        Destroy(gameObject);
        Debug.Log("Reloaded");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
